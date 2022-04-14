using System.Collections;
using UnityEngine;

namespace Assets.Script.Triggerable
{
    public abstract class ATriggerable : MonoBehaviour
    {

        public abstract void onTriggerEnter();
        public abstract void onTriggerExit();
    }
}