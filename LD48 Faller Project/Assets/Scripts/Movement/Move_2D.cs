using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faller.Movement
{
    public class Move_2D : MoveScript
    {
        public void Move(Vector2 dir)
        {
            //adjust the velocity of the rigidbody according to the direction
            rb2d.velocity = dir * moveSpeed;
        }
    }
}
