using Level;
using UI.Screens;
using UnityEngine;
using Utils.StateMachineTool;

namespace States
{
    public class SetLevelTaskState : State<Core>
    {
        public SetLevelTaskState(Core core) : base(core) {}

        public override void OnEnter()
        {
            var randomFoodId = Random.Range(0, core.factory.foods.Count);
            var randomFoodCount = Random.Range(1, core.config.maxTaskCount);
            
            core.model.SetTask(randomFoodId, randomFoodCount);

            var screen = core.screenManager.GetCurrentScreen() as GameScreen;
            screen.SetLevelTask(core.config.foodSprites[randomFoodId], randomFoodCount);
            
            ChangeState(new InputState(core));
        }
    }
}