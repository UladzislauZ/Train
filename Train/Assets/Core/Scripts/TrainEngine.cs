using UnityEngine;

namespace Train.Core
{
    public class TrainEngine : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidBody;

        private TrainModel _trainModel;
        private TrainConfig _trainConfig;


        public void Initialize(TrainModel trainModel)
        {
            _trainModel = trainModel;
            _trainConfig = Resources.Load<TrainConfig>("TrainConfig");
        }

        void Update()
        {
            if (_trainModel == null || _trainConfig == null)
            {
                return;
            }

            if (_trainModel.OnMove)
            {
                _trainModel.CurrentSpeed = _trainConfig.TrainSpeed * Time.deltaTime * Vector2.right;
                _rigidBody.AddForce(_trainModel.CurrentSpeed);
            }
        }
    }
}
