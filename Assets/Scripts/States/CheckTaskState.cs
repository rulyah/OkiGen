using Level;
using Utils.StateMachineTool;

namespace States
{
    public class CheckTaskState : State<Core>
    {
        public CheckTaskState(Core core) : base(core) {}

        public override void OnEnter()
        {
            if (core.model.currentFood.id == core.model.taskFoodId)
            {
                SoundsManager.Instance.PlayCorrectSound();
                ChangeState(new DropToBasketState(core));
            }
            else
            {
                SoundsManager.Instance.PlayIncorrectSound();
                core.model.currentFood.IsUsePhysics(true);
                core.player.PlayWrong();
                core.player.onMoveDone += OnMoveDone;
            }
        }
        
        private void OnMoveDone()
        {
            core.factory.foods[core.model.currentFood.id].Release(core.model.currentFood);
            core.model.currentFood = null;
            ChangeState(new InputState(core));
        }

        public override void OnExit()
        {
            core.player.onMoveDone -= OnMoveDone;
        }
    }
}