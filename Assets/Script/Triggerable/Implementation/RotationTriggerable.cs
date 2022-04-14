
using System;
using UnityEngine;

namespace Assets.Script.Triggerable.Implementation
{
    public class RotationTriggerable : ATriggerable
    {
        [SerializeField] private float m_rotationAngle = 5;
        private bool m_isRotating = false;
        public override void onTriggerEnter()
        {
            Debug.Log("Player enter rotation");
            m_isRotating = true;
        }

        public override void onTriggerExit()
        {
            m_isRotating = false;
        }

        public void Update()
        {
            if (m_isRotating)
            {
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * m_rotationAngle);
            }
        }
    }
}