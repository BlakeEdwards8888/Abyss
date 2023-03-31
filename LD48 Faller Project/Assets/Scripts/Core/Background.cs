using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faller.Core
{
    public class Background : MonoBehaviour
    {
        [SerializeField] float cameraRange, dropDistance;
        // Update is called once per frame
        void Update()
        {
            if (transform.position.y > Camera.main.transform.position.y + cameraRange)
            {
                //calculate a new position
                Vector2 newPos = transform.position;
                newPos.y -= dropDistance;
                transform.position = newPos;
            }
        }
    }
}
