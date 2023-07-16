using Level;
using Processes;
using UI;
using UI.Screens;
using UnityEngine;
using Utils.StateMachineTool;

namespace States
{
    public class MainMenuState : State<Core>
    {
        private MenuScreen _screen;
        public MainMenuState(Core core) : base(core) {}

        public override void OnEnter()
        {
            _screen = core.screenManager.OpenScreen(ScreenTypes.MENU) as MenuScreen;
            _screen.onPlay += OnPlay;
            _screen.onExit += OnClose;
            
        }

        private void OnPlay()
        {
            _screen.onPlay -= OnPlay;
            _screen.onExit -= OnClose;
            core.screenManager.CloseLastScreen();
            var screen = core.screenManager.OpenScreen(ScreenTypes.GAME) as GameScreen;
            var gameScreenProcess = new GameScreenProcess(core, screen).Start();
            core.processManager.AddProcess(gameScreenProcess);
            ChangeState(new PrepareLevelState(core));
        }
        
        private void OnClose()
        {
            Application.Quit();
        }
    }
}