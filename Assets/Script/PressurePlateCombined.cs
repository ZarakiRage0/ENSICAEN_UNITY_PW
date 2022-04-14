using Assets.Script.Triggerable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateCombined : MonoBehaviour
{
    [SerializeField] private List<ATriggerable> m_trigerList = new List<ATriggerable>();
    [SerializeField] private GameObject m_ObjectCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(m_ObjectCollider))
        {
            foreach (ATriggerable triggerable in m_trigerList)
            {
                triggerable.onTriggerEnter();
            }
        }
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(m_ObjectCollider))
        {
            foreach (ATriggerable triggerable in m_trigerList)
            {
                triggerable.onTriggerExit();
            }
        }
    }
}
