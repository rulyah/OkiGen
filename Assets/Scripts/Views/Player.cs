using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Utils.FactoryTool;

namespace Views
{
    public class Player : PoolableMonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private TwoBoneIKConstraint _rightHandIKConstraint;
        [SerializeField] private TwoBoneIKConstraint _leftHandIKConstraint;
        [SerializeField] private Transform _hand;
        [SerializeField] private Transform _rightHandDropPos;
        [SerializeField] private Transform _leftHandDropPos;
        [SerializeField] private GameObject _basket;
        [SerializeField] private List<Transform> _posInBasket;
        
        private List<Food> _foodsInBasket = new();
        
        public event Action onMoveDone;
        
        private Food _food;
        private Transform _leftHandTarget;
        private Transform _rightHandTarget;
        
        private static readonly int _wrongTrigger = Animator.StringToHash("WrongTrigger");
        private static readonly int _isVictoryBool = Animator.StringToHash("isVictoryBool");
        private static readonly int _correctTrigger = Animator.StringToHash("CorrectTrigger");

        private void Awake()
        {
            _rightHandTarget = _rightHandIKConstraint.data.target.transform;
            _leftHandTarget = _leftHandIKConstraint.data.target.transform;
        }

        public void PickUp(Food food)
        {
            _food = food;
            _rightHandTarget.rotation = Quaternion.Euler(140.0f, 80.0f, 50.0f);
            ChangeHandIKWeight(0.5f, true,() =>
            {
                _food = null;
                food.SetSpeed(0.0f);
                food.transform.parent = _hand.transform;
                food.transform.localPosition = Vector3.zero;
                
                ChangeHandIKWeight(0.5f, true,() => onMoveDone?.Invoke());
            });
        }
        
        public void Drop(Food food)
        {
            var leftHandPos = _leftHandTarget.position;
            _leftHandTarget.transform.DOMove(_leftHandDropPos.position, 0.5f);
            
            _rightHandTarget.position = _rightHandDropPos.position;
            _rightHandTarget.rotation = Quaternion.Euler(90.0f, 0.0f, 60.0f);
            
            ChangeHandIKWeight(0.5f, true,() =>
            {
                food.IsUsePhysics(true);
                food.transform.parent = _basket.transform;

                StartCoroutine(Delay(0.4f,() =>
                {
                    food.transform.position = _posInBasket[_foodsInBasket.Count].position;
                    _foodsInBasket.Add(food);

                    food.IsUsePhysics(false);
                    _leftHandTarget.transform.DOMove(leftHandPos, 0.5f);
                    ChangeHandIKWeight(0.5f,true,() => onMoveDone?.Invoke());
                }));
            });
        }

        public void PlayWrong()
        {
            StartCoroutine(WrongMove(() => onMoveDone?.Invoke()));
        }
        
        public void PlayCorrect()
        {
            _animator.SetTrigger(_correctTrigger);
        }

        public void PlayDance()
        {
            _basket.SetActive(false);
            ChangeHandIKWeight(0.2f, false, () =>
            {
                _animator.SetBool(_isVictoryBool, true);
            });
        }
        
        public void ChangeHandIKWeight(float duration, bool isRightHand, Action action = null)
        {
            var hand = isRightHand ? _rightHandIKConstraint : _leftHandIKConstraint;
            var endValue = hand.weight == 0.0f ? 1.0f : 0.0f;
            DOTween.To(() => hand.weight, x => hand.weight = x, endValue, duration)
                .OnComplete(() => action?.Invoke());
        }

        private void Update()
        {
            if(_food == null) return;
            _rightHandTarget.position = _food.transform.position;
        }
        
        private IEnumerator WrongMove(Action action)
        {
            _animator.SetTrigger(_wrongTrigger);
            yield return new WaitForSeconds(1.0f);
            action?.Invoke();
        }

        private IEnumerator Delay(float delay, Action action)
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }
    }
}