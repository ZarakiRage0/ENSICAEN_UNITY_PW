using Assets.Script.Triggerable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private ATriggerable m_triger;
    [SerializeField] private GameObject m_ObjectCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(m_ObjectCollider))
        {
            m_triger?.onTriggerEnter();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(m_ObjectCollider))
        {
            m_triger?.onTriggerExit();
        }
    }

}
