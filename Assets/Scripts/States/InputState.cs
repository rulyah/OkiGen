using System.Collections;
using Level;
using UnityEngine;
using Utils.StateMachineTool;
using Views;

namespace States
{
    public class InputState : State<Core>
    {
        private Coroutine _loop;
        private Camera _camera;
        public InputState(Core core) : base(core) {}

        public override void OnEnter()
        {
            _camera = Camera.main;
            _loop = core.StartCoroutine(InputLoop());
        }

        public override void OnExit()
        {
            core.StopCoroutine(_loop);
        }

        private IEnumerator InputLoop()
        {
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var ray = _camera.ScreenPointToRay(Input.mousePosition);
                    if (!Physics.Raycast(ray, out var hit)) continue;
            
                    if (hit.transform.CompareTag("Food"))
                    {
                        var food = hit.transform.gameObject.GetComponent<Food>();
                        core.model.currentFood = food;
                        ChangeState(new PickUpState(core));
                    }
                }
                yield return null;
            }
        }
    }
}