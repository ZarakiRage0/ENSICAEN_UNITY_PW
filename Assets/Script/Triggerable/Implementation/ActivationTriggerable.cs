using Assets.Script.Triggerable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTriggerable : ATriggerable
{
    [SerializeField] private GameObject m_ObjectToActivate;
    public override void onTriggerEnter()
    {
        m_ObjectToActivate.SetActive(true);
    }

    public override void onTriggerExit()
    {
        m_ObjectToActivate.SetActive(false);
    }

}
