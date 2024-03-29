using UnityEngine;

namespace Train.Core
{
    public class MiddleGround : PoolObject
    {
        [SerializeField]
        private Tree[] _trees;

        public event System.Action<MiddleGround> ObjectInvisibled;

        public override void ClearPlaces()
        {
            foreach (var tree in _trees)
            {
                tree.ClearSprite();
            }
        }

        public void Initialize(Sprite[] trees)
        {
            foreach (var tree in _trees)
            {
                if (Random.Range(0, 2) == 1)
                {
                    tree.Initialize(trees[Random.Range(0, trees.Length - 1)]);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("TriggerRemove"))
            {
                gameObject.SetActive(false);
                ObjectInvisibled?.Invoke(this);
            }
        }
    }
}
