using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Control;

namespace Faller.Core
{
    public class CameraFocus : MonoBehaviour
    {
        Transform target;
        [SerializeField] float ceiling;

        private void Awake()
        {
            target = FindObjectOfType<PlayerController>().transform;

            //align with the target
            if(target != null)
                transform.position = target.position;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (target != null)
            {
                //if there is a target, follow it on the y axis only
                Vector3 tempPos = transform.position;
                tempPos.y = Mathf.Clamp(target.position.y, Mathf.NegativeInfinity, ceiling);
                transform.position = tempPos;
            }
        }
    }
}
