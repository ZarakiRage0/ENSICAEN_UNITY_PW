using System;
using Script;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Script.Triggerable.Implementation
{
    public class SpawnerTriggerable : ATriggerable
    {
        [SerializeField] private Enemy m_enemyType;
        [SerializeField] private int m_enemyCount = 1;
        [SerializeField] private int m_spwanArea = 10;
        [SerializeField] private int m_spawnTimeInSeconds = 1;
        [SerializeField] private GameObject m_target;
        private int m_currentSpawnedEnemyCount;
        private bool m_shouldSpawnEnemy;
        private int cx;
        private int cy;
        private float spawnTimeCounter;
        private void Awake()
        {
            m_currentSpawnedEnemyCount = 0;
            m_shouldSpawnEnemy = false;
            var position = transform.position;
            cx = (int) position.x;
            cy = (int) position.y;
            spawnTimeCounter = 0;
        }

        public override void onTriggerEnter()
        {
            m_shouldSpawnEnemy = true;
        }

        public override void onTriggerExit()
        {
            
        }

        private void Update()
        {
            if (m_shouldSpawnEnemy)
            {
                if (m_currentSpawnedEnemyCount == m_enemyCount)
                {
                    m_shouldSpawnEnemy = false;
                }
                else
                {
                    spawnTimeCounter += Time.deltaTime;
                    if (spawnTimeCounter >= m_spawnTimeInSeconds)
                    {
                        spawnTimeCounter = 0;
                        m_currentSpawnedEnemyCount++;
                        int x = Random.Range(cx-m_spwanArea, cx+m_spwanArea);
                        int y = Random.Range(cy-m_spwanArea, cy+m_spwanArea);
                        Vector3 spawnOffset = new Vector3(x, 0, y);
                        (Instantiate(m_enemyType, transform.position + spawnOffset, Quaternion.identity)).SetTarget(m_target);
                    }
                }
            }
        }
    }
}