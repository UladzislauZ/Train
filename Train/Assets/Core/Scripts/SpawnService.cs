using UnityEngine;

namespace Train.Core
{
    public class SpawnService
    {
        private GroundConfig _groundConfig;
        private PoolObjects<MiddleGround> _poolMiddleGround;
        private PoolObjects<Ground> _poolGround;

        private float _startPosXGround = -16f;
        private float _posYGround = -5f;
        private float _currentPosXGround;
        private float _stepGround = 7f;

        private float _startPosXMiddleGround = -15f;
        private float _posYMiddleGround = -0.85f;
        private float _currentPosXMiddleGround;
        private float _stepMiddleGround = 8f;

        private int _countSpawnGround = 8;

        public SpawnService(PoolObjects<Ground> poolGround,
                            PoolObjects<MiddleGround> poolMiddleGround,
                            GroundConfig groundConfig)
        {
            _poolMiddleGround = poolMiddleGround;
            _poolGround = poolGround;
            _groundConfig = groundConfig;
            Start();
        }

        private void Start()
        {
            _currentPosXGround = _startPosXGround;
            _currentPosXMiddleGround = _startPosXMiddleGround;
            for (var i = 0; i < _countSpawnGround; i++)
            {
                SpawnGround();
                SpawnMiddleGround();
            }
        }

        private void SpawnGround()
        {
            _currentPosXGround += _stepGround;
            var ground = _poolGround.GetObject();
            ground.transform.position = new Vector2(_currentPosXGround, _posYGround);
            ground.gameObject.SetActive(true);
            ground.ObjectInvisibled += OnGroundInvisible;
        }

        private void SpawnMiddleGround()
        {
            _currentPosXMiddleGround += _stepMiddleGround;
            var middleGround = _poolMiddleGround.GetObject();
            middleGround.transform.localPosition = new Vector2(_currentPosXMiddleGround, _posYMiddleGround);
            middleGround.gameObject.SetActive(true);
            middleGround.Initialize(_groundConfig.trees);
            middleGround.ObjectInvisibled += OnMiddleGroundInvisible;
        }

        private void OnGroundInvisible(Ground poolObject)
        {
            poolObject.ObjectInvisibled -= OnGroundInvisible;
            _poolGround.PushObject(poolObject);
            SpawnGround();
        }

        private void OnMiddleGroundInvisible(MiddleGround poolObject)
        {
            poolObject.ObjectInvisibled -= OnMiddleGroundInvisible;
            _poolMiddleGround.PushObject(poolObject);
            SpawnMiddleGround();
        }
    }
}
