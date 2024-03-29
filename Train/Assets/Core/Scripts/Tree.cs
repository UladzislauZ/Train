using UnityEngine;

namespace Train.Core
{
    public class Tree : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteTree;

        public void Initialize(Sprite sprite)
        {
            _spriteTree.sprite = sprite;
        }

        public void ClearSprite()
        {
            _spriteTree.sprite = null;
        }
    }
}