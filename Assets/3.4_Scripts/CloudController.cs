using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class CloudController : MonoBehaviour
    {
        private int m_targetIndex = 0;
        private bool m_moved = false;
        public float moveSpeed = 10f;
        public Cloud cloud;
        public Transform[] targets;
        public void Action()
        {
            Debug.Log("Cloud", this);

            if (m_moved)
            {
                return;
            }
            m_moved = true;
            cloud.StopFX();
            m_targetIndex++;
            if (m_targetIndex >= targets.Length) { m_targetIndex = 0; }
        }
        public void Update()
        {
            if (!m_moved)
            { return; }

            Transform target = targets[m_targetIndex]; 
            Vector3 targetPosition = new Vector3(target.position.x, cloud.transform.position.y, target.position.z);
            Vector3 offset = (targetPosition - cloud.transform.position).normalized * Time.deltaTime * moveSpeed;

            if (Vector3.Distance(cloud.transform.position, targetPosition) < 0.1f)
            {
                cloud.transform.position = targetPosition;
                m_moved = false;
                cloud.PlayFX();
            }
            else
            {
                cloud.transform.Translate(offset, Space.World);
            }
        }
    }
}