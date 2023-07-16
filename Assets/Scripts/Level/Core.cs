using Services.Factory;
using States;
using UI;
using UnityEngine;
using Utils.ProcessTool;
using Utils.StateMachineTool;
using Views;

namespace Level
{
    public class Core : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private ScreenManager _screenManager;
        [SerializeField] private FactoryService _factory;
        [SerializeField] private CameraController _camera;
        
        public ScreenManager screenManager => _screenManager;
        public FactoryService factory => _factory;
        public CameraController camera => _camera;
        
        [HideInInspector] public Player player;
        [HideInInspector] public Conveyor conveyor;
        public ProcessManager processManager;
        public LevelConfig config { get; private set; }
        public LevelModel model;

        private StateMachine<Core> _stateMachine;
        private void Start()
        {
            config = Resources.Load<LevelConfig>("Configs/LevelConfig");
            model = new LevelModel();
            processManager = new ProcessManager(this);
            _stateMachine = new StateMachine<Core>(new MainMenuState(this));
        }
    }
}