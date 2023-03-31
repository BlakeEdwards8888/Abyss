using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faller.Core
{
    public class SelfDestruct : MonoBehaviour
    {
        [SerializeField] float aliveTime;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, aliveTime);
        }

    }
}
