using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class Enemy : MonoBehaviour
    {
        private GameObject m_target;
        Vector3 destination;
        NavMeshAgent agent;

        void Update()
        {
            if (m_target != null)
            {
                if (Vector3.Distance(destination, m_target.transform.position) > 1.0f)
                {
                    destination = m_target.transform.position;
                    agent.destination = destination;
                }
            }
        }

        public void SetTarget(GameObject target)
        {
            m_target = target;
            agent = GetComponent<NavMeshAgent>();
            agent.destination = m_target.transform.position;
            destination = agent.destination;
        }
    }
}