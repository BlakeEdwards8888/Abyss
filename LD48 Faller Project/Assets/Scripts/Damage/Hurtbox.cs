using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faller.Damage
{
    public class Hurtbox : MonoBehaviour
    {
        [SerializeField] Health myHealth;

        public void OnTriggerEnter2D(Collider2D other)
        {
            Hitbox hBox = other.GetComponent<Hitbox>();
            //if (hBox == null) return;
            if (hBox != null) myHealth.TakeDamage(hBox.damage);

            //myHealth.TakeDamage(hBox.damage);

            if(GetComponent<Knockback>() != null)
            {
                //get the direction opposite of the contact
                Vector2 dir = (other.transform.position - transform.position).normalized * -1;

                //pass it to the Knockback script
                StartCoroutine(GetComponent<Knockback>().ApplyKnockback(dir));
            }
        }
    }
}
