using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class GameScreen : Screen
    {
        [SerializeField] private Button _menuBtn;
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private Image _foodImage;
        
        public event Action onMenu;

        public override void Show()
        {
            base.Show();
            _menuBtn.onClick.AddListener(Menu);
        }

        public override void Hide()
        {
            _menuBtn.onClick.RemoveListener(Menu);
            base.Hide();
        }
        
        private void Menu()
        {
            onMenu?.Invoke();
        }
        
        public void SetLevelTask(Sprite sprite, int count)
        {
            _foodImage.sprite = sprite;
            _countText.text = count.ToString();
        }
        
        public void ChangeCount(int count)
        {
            _countText.text = count.ToString();
        }
    }
}