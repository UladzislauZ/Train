using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Train.Core
{
    public class MoveButton : Button
    {
        private TrainModel _trainModel;

        public void Initialize(TrainModel trainModel)
        {
            _trainModel = trainModel;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (_trainModel != null)
            {
                _trainModel.OnMove = true;
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (_trainModel != null)
            {
                _trainModel.OnMove = false;
            }
        }
    }
}
