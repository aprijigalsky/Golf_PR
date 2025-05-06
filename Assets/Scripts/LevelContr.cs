using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class LevelContr : MonoBehaviour
    {
        public Spawners spawner;
        public float delay = 0.5f;
        private float m_lastSpawnedTime = 0;

        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;

        public int score = 0;

        public int hightScore = 0;
        private float m_delay = 0.5f;

        private List<GameObject> m_stones = new List<GameObject>(16);

        public void ClearStone()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone);
            }
            m_stones.Clear();
        }

        private void Start()
        {
            m_lastSpawnedTime = Time.time;
            RefreshDelay();
        }
        
        private void GameOver()
        {
            Debug.Log("Game OVER!!!");
            enabled = true;
        }
        
        private void OnStickHit()
        {
            score++;
            hightScore = Mathf.Max(hightScore, score);
            Debug.Log($"score: {score} - hightScore: {hightScore}");
        }
        private void OnEnable()
        {
            GameEvents.onStickHit += OnStickHit;
            score = 0;

        }
        private void OnDisable()
        {
            GameEvents.onStickHit -= OnStickHit;

        }
        private void Update()
        {
            if (Time.time >= m_lastSpawnedTime + m_delay)
            {
              var stone = spawner.Spawn();
             m_stones.Add(stone);
                m_lastSpawnedTime = Time.time;
                RefreshDelay();
            }
        }

        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }
    }
}

       
        