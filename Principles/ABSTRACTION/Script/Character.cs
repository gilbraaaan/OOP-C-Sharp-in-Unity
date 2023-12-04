using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgilAbstraction
{
    public abstract class Character : MonoBehaviour
    {
        public Bridge functionAll;
        public float timeDurationFirst = 0.6f, timeDurationSeconds = 0.4f;
        public abstract void TryFunction(bool Activated);
    }
}
