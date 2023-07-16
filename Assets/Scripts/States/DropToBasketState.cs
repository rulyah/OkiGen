using Level;
using UI;
using Utils.StateMachineTool;

namespace States
{
    public class DropToBasketState : State<Core>
    {
        public DropToBasketState(Core core) : base(core) {}

        public override void OnEnter()
        {
            core.player.PlayCorrect();
            core.player.Drop(core.model.currentFood);
            core.player.onMoveDone += OnMoveDone;
        }
        
        private void OnMoveDone()
        {
            core.model.currentFood = null;
            ScoreSpawner.Instance.SpawnScore();
            core.model.ChangeTaskCount();
            
            if (core.model.taskFoodCount <= 0)
            {
                ChangeState(new VictoryState(core));
            }
            else
            {
                ChangeState(new InputState(core));
            }
        }

        public override void OnExit()
        {
            core.player.onMoveDone -= OnMoveDone;
        }
    }
}