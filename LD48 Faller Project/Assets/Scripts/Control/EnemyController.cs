using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Movement;
using Faller.Damage;

namespace Faller.Control
{
    
    public class EnemyController : MonoBehaviour
    {
        Transform target;
        [SerializeField] Knockback kbHandler;   //the Knockback to pair with the controller

        // Start is called before the first frame update
        void Awake()
        {
            //set the player as the target
            target = FindObjectOfType<PlayerController>().transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (kbHandler.hitStun) return;

            //keep chasing the player
            ChasePlayer();
        }

        void ChasePlayer()
        {
            //check if player is in range
            if (target != null && Vector2.Distance(transform.position, target.position) > 0.1f)
            {
                //get the direction to the player
                Vector2 dir = (target.position - transform.position).normalized;

                //pass dir into the move script
                GetComponent<Move_2D>().Move(dir);
            }
            else
            {
                GetComponent<Move_2D>().Stop();
            }
        }
    }
}
