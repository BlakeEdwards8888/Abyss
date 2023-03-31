using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Movement;
using Faller.Damage;
using Faller.Shooting;

namespace Faller.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Knockback kbHandler;   //the Knockback to pair with the controller
        [SerializeField] GunScript myGun;
        // Update is called once per frame
        void Update()
        {
            //return if we are currently stunned
            if (kbHandler.hitStun) return;

            //check for inputs
            CheckForInputs();
        }

        private void CheckForInputs()
        {

            //check for movement inputs
            InteractWithMovement();

            //check for jump inputs
            InteractWithJump();

            //check for gun inputs
            InteractWithGun();
        }

        private void InteractWithGun()
        {
            if (Input.GetButton("Fire1"))
            {
                myGun.Fire();
            }
        }

        private void InteractWithMovement()
        {
            //get the input axis
            float axis = Input.GetAxisRaw("Horizontal");

            if (axis != 0)
            {
                GetComponent<Move_1D>().Move(axis);
            }
            else
            {
                GetComponent<Move_1D>().Stop();
            }

        }

        private void InteractWithJump()
        {
            //check if jump is pressed
            if (Input.GetButtonDown("Jump"))
            {
                GetComponent<JumpScript>().Jump();
            }
            else if(Input.GetButtonUp("Jump"))
            {
                //otherwise check if jump is canceled
                GetComponent<JumpScript>().CancelJump();
            }
        }
    }
}
