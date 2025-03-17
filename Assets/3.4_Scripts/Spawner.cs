using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class Spawner : MonoBehaviour
    {
        public GameObject prefab;

        public void Spawn()
        {
            Debug.Log("Spawn");
            if (prefab == null)
            {
                Debug.LogError("Spawner - prefab == null");
                return;
            }
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}