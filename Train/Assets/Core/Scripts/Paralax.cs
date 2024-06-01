using UnityEngine;

namespace Train.Core
{
    public class Paralax : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        private float _startingPos;
        private float _amountOfParallax;
        private bool isInit = false;

        public void InitParalax(float amountOfParallax)
        {
            _amountOfParallax = amountOfParallax;
            isInit = true;
        }

        private void Start()
        {
            _startingPos = transform.position.x;
        }

        private void LateUpdate()
        {
            if(!isInit)
            {
                return;
            }

            Vector2 CameraPosition = _camera.transform.position;
            float Distance = CameraPosition.x * _amountOfParallax;

            transform.position = Vector2.Lerp(new(_startingPos, transform.position.y),
                                              new(_startingPos + Distance, transform.position.y), 
                                              _amountOfParallax);
        }
    }
}
