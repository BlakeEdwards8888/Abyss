using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Shooting;

namespace Faller.Control
{
    public class TurretController : MonoBehaviour
    {
        [SerializeField] GunScript myGun;
        [SerializeField] float rangeToFire; //how close the player should be before we try to fire

        Transform target;

        private void Awake()
        {
            target = FindObjectOfType<PlayerController>().transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (myGun == null || target == null) return;

            //rotate gun to point at the player
            AimAtPlayer();

            //keep firing if the player is in range
            if(Vector2.Distance(target.position, transform.position) <= rangeToFire)
            myGun.Fire();
        }

        private void AimAtPlayer()
        {
            if (target == null) return;

            //get the aim axis
            Vector3 aimAxis = (target.position - transform.position).normalized;

            //rotate the arm
            float myAngle = Mathf.Atan2(aimAxis.x, aimAxis.y) * Mathf.Rad2Deg;

            float bodyRot = myAngle - 90 + Camera.main.transform.eulerAngles.y;

            Quaternion tempRot = Quaternion.Euler(0, 0, -bodyRot);
            myGun.transform.rotation = tempRot;
        }
    }
}
