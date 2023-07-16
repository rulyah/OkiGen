using Level;
using Utils.StateMachineTool;

namespace States
{
    public class PickUpState : State<Core>
    {
        public PickUpState(Core core) : base(core) {}

        public override void OnEnter()
        {
            core.model.foods.Remove(core.model.currentFood);
            core.model.currentFood.IsUsePhysics(false);
            core.player.PickUp(core.model.currentFood);
            core.player.onMoveDone += OnMoveDone;
        }
        
        public void OnMoveDone()
        {
            ChangeState(new CheckTaskState(core));
        }

        public override void OnExit()
        {
            core.player.onMoveDone -= OnMoveDone;
        }
    }
}