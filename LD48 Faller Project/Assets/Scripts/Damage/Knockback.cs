using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faller.Damage
{
    [RequireComponent(typeof(Hurtbox))]
    public class Knockback : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb2d;  //the rb2d to be manipulated by this script
        [SerializeField] float kbForce; //how much to knock back the rb2d
        [SerializeField] float stunTime;

        [HideInInspector] public bool hitStun;

        public IEnumerator ApplyKnockback(Vector2 dir)
        {
            //set hitStun to true
            hitStun = true;

            //knock back the rb2d according to the passed direction
            rb2d.velocity = dir * kbForce;

            //wait for stunTime
            yield return new WaitForSeconds(stunTime);

            //reset hitStun
            hitStun = false;

            yield return null;
        }
    }
}
