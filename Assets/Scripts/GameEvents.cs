using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public static class GameEvents
    {
        public static event System.Action onCollisionStones;
        public static event System.Action onStickHit;


        public static void CollisonStonesInvoke(Collision collision)
        { 
            onCollisionStones?.Invoke();
        }

        public static void StickHit()
        {
            onStickHit?.Invoke();
        }

    }
}