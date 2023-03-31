using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faller.Shooting 
{
    public class AimAtMouse : MonoBehaviour
    {
        private void Update()
        {
            //keep pointing to the mouse
            PointToMouse();
        }

        void PointToMouse()
        {
            //get the position of the mouse
            Vector3 mousePos = Input.mousePosition;//Camera.main.ScreenToViewportPoint(Input.mousePosition);

            //convert our position to viewport space
            Vector3 myPos = Camera.main.WorldToScreenPoint(transform.position);

            //get the aim axis
            Vector3 aimAxis = (mousePos - myPos).normalized;

            //rotate the arm
            float myAngle = Mathf.Atan2(aimAxis.x, aimAxis.y) * Mathf.Rad2Deg;

            float bodyRot = myAngle - 90 + Camera.main.transform.eulerAngles.y;

            Quaternion tempRot = Quaternion.Euler(0, 0, -bodyRot);
            transform.rotation = tempRot;
        }

    }
}
