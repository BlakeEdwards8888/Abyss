using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Audio;

namespace Faller.Movement
{
    public class Move_1D : MoveScript
    {
        [SerializeField] ContactFilter2D contactFilter;
        [SerializeField] Animator anim;

        public void Move(float axis)
        {
            //check for walls
            if (!WallCheck(Vector2.right * axis))
            {
                //adjust the velocity of the rigidbody according to the axis
                rb2d.velocity = new Vector2(axis * moveSpeed, rb2d.velocity.y);

                //update the animator
                if (anim != null)
                    anim.SetBool("IsIdle", false);
            }
            else
            {
                //if there are walls, just stop
                Stop();
            }
        }

        public override void Stop()
        {
            //stop the rb2d from moving
            rb2d.velocity = new Vector2(0 * moveSpeed, rb2d.velocity.y);

            //update the animator
            if (anim != null)
                anim.SetBool("IsIdle", true);
        }

        public bool WallCheck(Vector2 dir)
        {
            //check for ground on the ground layer
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            rb2d.Cast(dir, contactFilter, hits, 0.1f);

            //return the results as a bool
            return hits.Count > 0;
        }
    }
}
