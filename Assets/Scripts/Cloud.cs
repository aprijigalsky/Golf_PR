using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Cloud : MonoBehaviour
    {
        [SerializeField] private ParticleSystem m_particleSystem;

        public void PlayFX()
        { 
            m_particleSystem.Play();
        }

        public void StopFX()
        { 
            m_particleSystem.Stop();
        }

        private void Start()
        {
            m_particleSystem.Stop();
        }
    }
}