using Level;
using UI;
using UI.Screens;
using UnityEngine.SceneManagement;
using Utils.StateMachineTool;

namespace States
{
    public class VictoryState : State<Core>
    {
        private VictoryScreen _screen;
        public VictoryState(Core core) : base(core) {}

        public override void OnEnter()
        {
            core.processManager.RemoveAllProcesses();
            core.screenManager.CloseLastScreen();
            _screen = core.screenManager.OpenScreen(ScreenTypes.VICTORY) as VictoryScreen;
            _screen.onNext += OnNext;
            
            core.factory.conveyor.Release(core.conveyor);
            
            foreach (var food in core.model.foods)
            {
                core.factory.foods[food.id].Release(food);
            }
            
            core.camera.Move(core.config.cameraVictoryPosition, core.config.cameraVictoryRotation);
            core.player.PlayDance();
        }
        
        private void OnNext()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public override void OnExit()
        {
            _screen.onNext -= OnNext;
        }
    }
}