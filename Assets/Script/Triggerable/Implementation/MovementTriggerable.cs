using System.Collections;
using UnityEngine;

namespace Assets.Script.Triggerable.Implementation
{
    public class MovementTriggerable : ATriggerable
    {
        [SerializeField] private Vector3 m_movement = new Vector3(0, 5, 0);


        public override void onTriggerEnter()
        {
            transform.position += m_movement;
        }

        public override void onTriggerExit()
        {
            transform.position -= m_movement;
        }

    }


}