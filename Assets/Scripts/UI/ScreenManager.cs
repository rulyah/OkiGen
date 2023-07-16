using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ScreenManager : MonoBehaviour
    {
        private List<Screen> _screens = new();
        private Stack<Screen> _screenStack = new();
    
        private void Awake()
        {
            var screens = Resources.LoadAll<Screen>("Prefabs/Screens");
            foreach (var screen in screens)
            {
                var instance = Instantiate(screen, transform);
                _screens.Add(instance);
            }
        }

        public Screen OpenScreen(ScreenTypes type)
        {
            var screen = _screens.Find(n => n.type == type);
            screen.Show();
            _screenStack.Push(screen);
            return screen;
        }
        
        public Screen GetCurrentScreen()
        {
            return _screenStack.Peek();
        }

        public void CloseLastScreen()
        {
            if (_screenStack.Count <= 0) return;
            _screenStack.Pop().Hide();
        }
    }
}