using UnityEngine;

namespace Train.Core
{
    [CreateAssetMenu(fileName = "GroundConfig")]
    public class GroundConfig : ScriptableObject
    {
        public Ground groundPrefab;
        public int groundCapacity;
        public MiddleGround middleGroundPrefab;
        public int middleGroundCapacity;
        public Tree treePrefab;
        public Sprite[] trees;
        public float amountOfParallax;
    }
}
