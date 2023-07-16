using Level;
using Processes;
using Utils.StateMachineTool;

namespace States
{
    public class PrepareLevelState : State<Core>
    {
        public PrepareLevelState(Core core) : base(core) {}

        public override void OnEnter()
        {
            var player = core.factory.player.Produce();
            player.transform.position = core.config.playerSpawnPosition;
            core.player = player;

            var conveyor = core.factory.conveyor.Produce();
            conveyor.transform.position = core.config.conveyorSpawnPosition;
            core.conveyor = conveyor;

            var spawnProcess = new SpawnFoodProcess(core).Start();
            core.processManager.AddProcess(spawnProcess);
            var despawnProcess = new DespawnFoodProcess(core).Start();
            core.processManager.AddProcess(despawnProcess);
            
            ChangeState(new SetLevelTaskState(core));
        }
    }
}