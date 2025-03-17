using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TZ 
{
    public class Refresh : MonoBehaviour
    {
        public List<GameObject> tools;

        private void Start()
        {
            ChangeTool();
        }
        public void ChangeTool() 
        {
            var index = Random.Range(0, tools.Count);
            SetActiveTool(index);
        }
        private void SetActiveTool(int index)
        {
            for (int i = 0; i < tools.Count; i++)
            {
                tools[i].SetActive(i == index);
            }
        }
    }
}