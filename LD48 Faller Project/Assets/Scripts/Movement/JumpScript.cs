using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Audio;

namespace Faller.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpScript : MonoBehaviour
    {
        [SerializeField] float jumpForce;
        [SerializeField] ContactFilter2D contactFilter;
        [SerializeField] Animator anim;
        Rigidbody2D rb2d;

        [SerializeField] AudioClip jumpSfx, landSfx;

        bool prevGroundCheck;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            if (GroundCheck())
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

                //play the sound effect at this location
                if(jumpSfx != null)
                SfxManager.instance.PlayNewSFX(jumpSfx, transform.position);
            }
        }

        public void CancelJump()
        {
            if(rb2d.velocity.y > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y / 2);
            }
        }

        bool GroundCheck()
        {
            //check for ground on the ground layer
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            rb2d.Cast(Vector2.down, contactFilter, hits, 0.1f);

            //return the results as a bool
            return hits.Count > 0;
        }

        private void Update()
        {
            //keep the animator updated
            UpdateAnimator();

            //check for landing
            if (landSfx != null)
            CheckForLanding();
        }

        private void CheckForLanding()
        {
            if (GroundCheck() && !prevGroundCheck)
            {
                SfxManager.instance.PlayNewSFX(landSfx, transform.position);
            }

            prevGroundCheck = GroundCheck();
        }

        private void UpdateAnimator()
        {
            if (anim != null)
            {
                anim.SetFloat("yVelocity", rb2d.velocity.y);
                anim.SetBool("IsGrounded", GroundCheck());
            }
        }
    }
}
