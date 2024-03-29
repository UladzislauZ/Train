using UnityEngine;

namespace Train.Core
{
    public class BootStart : MonoBehaviour
    {
        [SerializeField]
        private MoveButton _moveButton;

        [SerializeField]
        private TrainEngine _trainEngine;

        [SerializeField]
        private Transform _groundParent;

        [SerializeField]
        private Transform _middleGroundParent;

        [SerializeField]
        private Paralax _paralax;

        private TrainModel _trainModel;
        private SpawnService _spawnService;
        private PoolObjects<MiddleGround> _poolMiddleGround;
        private PoolObjects<Ground> _poolGround;

        private void Awake()
        {
            var config = Resources.Load<GroundConfig>("GroundConfig");
            _poolGround = new PoolObjects<Ground>(config.groundPrefab, config.groundCapacity, _groundParent);
            _poolMiddleGround = new PoolObjects<MiddleGround>(config.middleGroundPrefab, config.middleGroundCapacity, _middleGroundParent);
            _spawnService = new SpawnService(_poolGround, _poolMiddleGround, config);
            _paralax.InitParalax(config.amountOfParallax);

            _trainModel = new TrainModel();
            _moveButton.Initialize(_trainModel);
            _trainEngine.Initialize(_trainModel);
        }
    }
}
