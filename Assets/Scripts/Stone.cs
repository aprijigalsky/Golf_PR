using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public bool isAffect = false;

        public static System.Action onCollisionStones;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out Stone other))
            { 
                if (!other.isAffect) 
                {
                    GameEvents.CollisonStonesInvoke(collision);
                }
            }
        }
    }

}