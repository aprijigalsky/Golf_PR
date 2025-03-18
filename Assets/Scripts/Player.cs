using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform stick;
        private bool m_isDown = false;
        public float range = 50f;
        public float speed = 1000f;
        public float power = 20f;
        public Transform helper;

        private Vector3 m_lastPosition;
        private void Update()
        {
            m_lastPosition = helper.position;

            m_isDown = Input.GetMouseButton(0);

            Quaternion rot = stick.localRotation;

            Quaternion toRot = Quaternion.Euler(0, 0, m_isDown ? range : -range);

            rot = Quaternion.RotateTowards(rot, toRot, speed * Time.deltaTime);
            stick.localRotation = rot;
        }

        public void SetDown(bool value)
        { 
            m_isDown=value;
        }

        public void OnCollisionStick(Collider collider)
        {
            if (collider.TryGetComponent<Rigidbody>(out Rigidbody body))
            {
                //var dir = m_isDown ? stick.right : -stick.right;
                var dir = (helper.position - m_lastPosition).normalized;
                body.AddForce(dir * power, ForceMode.Impulse);
                if (collider.TryGetComponent(out Stone stone) && !stone.isAffect)
                { 
                    stone.isAffect = true;
                    GameEvents.StickHit();
                }
            }

            //Debug.Log(collider, this);
        }
    }

    
}