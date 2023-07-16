using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class VictoryScreen : Screen
    {
        [SerializeField] private Button _nextBtn;
    
        public event Action onNext;

        public override void Show()
        {
            base.Show();
            _nextBtn.onClick.AddListener(Next);
        }

        public override void Hide()
        {
            _nextBtn.onClick.RemoveListener(Next);
            base.Hide();
        }

        private void Next()
        {
            onNext?.Invoke();
        }
    }
}