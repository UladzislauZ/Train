using UnityEngine;

namespace Train.Core
{
    [CreateAssetMenu(fileName = "TrainConfig")]
    public class TrainConfig : ScriptableObject
    {
        public float TrainSpeed;
    }
}