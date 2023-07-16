using Level;
using UI.Screens;
using UnityEngine.SceneManagement;
using Utils.ProcessTool;

namespace Processes
{
    public class GameScreenProcess : Process
    {
        private GameScreen _screen;
        private Core _core;

        public GameScreenProcess(Core core, GameScreen screen) : base(core)
        {
            _screen = screen;
            _core = core;
        }

        protected override void OnStart()
        {
            _screen.onMenu += OnMenu;
            _core.model.onCountChange += OnCountChange;
        }

        private void OnMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        private void OnCountChange(int count)
        {
            _screen.ChangeCount(count);
        }

        protected override void OnStop()
        {
            _screen.onMenu -= OnMenu;
            _core.model.onCountChange -= OnCountChange;
        }
    }
}