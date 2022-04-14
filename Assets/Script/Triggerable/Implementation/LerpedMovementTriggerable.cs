using System.Collections;
using UnityEngine;

namespace Assets.Script.Triggerable.Implementation
{
    public class LerpedMovementTriggerable : ATriggerable
    {
        [SerializeField] private Vector3 m_movement = new Vector3(0, 5, 0);
        private Vector3 m_startVector;
        private Vector3 m_endVector;
        private Vector3 m_currentPosition;
        private bool m_isOpening = false;
        private bool m_isClosing = false;

        [SerializeField]private int interpolationFramesCount = 120;
        private int elapsedFrames = 0;

        public void Start()
        {
            m_startVector = transform.position;
            m_endVector = m_startVector + m_movement;
        }

        public override void onTriggerEnter()
        {
            m_isOpening = true;
            m_isClosing = false;
            m_currentPosition = transform.position;
        }

        public override void onTriggerExit()
        {
            m_isOpening = false;
            m_isClosing = true;
            m_currentPosition = transform.position;
        }
        private void Update()
        {
            if (m_isOpening)
            {
                float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

                transform.position = Vector3.Lerp(m_currentPosition, m_endVector, interpolationRatio);

                elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
                if (elapsedFrames == 0)
                {
                    m_isOpening = false;
                    m_isClosing = false;
                }
            } else if (m_isClosing)
            {
                float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

                transform.position = Vector3.Lerp(m_currentPosition, m_startVector, interpolationRatio);

                elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
                if (elapsedFrames == 0)
                {
                    m_isOpening = false;
                    m_isClosing = false;
                }
            }
        }



        // Use this for initialization

    }
}