using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public bool isAffect = false;

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