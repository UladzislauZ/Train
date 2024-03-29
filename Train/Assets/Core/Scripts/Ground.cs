using System;
using UnityEngine;

namespace Train.Core
{
    public class Ground : PoolObject
    {
        public event Action<Ground> ObjectInvisibled;

        public override void ClearPlaces()
        {
            return;
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