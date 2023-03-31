using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Movement;
using Faller.Damage;

namespace Faller.Control
{
    public class FloorchompController : MonoBehaviour
    {
        [SerializeField] LayerMask layerMask; //contact filter for moving
        [SerializeField] Knockback kbHandler;   //paired knockback script
        [SerializeField] SpriteRenderer mySprite;   //sprite renderer paired with this script
        Rigidbody2D rb2d;
        float myAxis = 1;

        // Start is called before the first frame update
        void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (kbHandler.hitStun) return;
            HandleMovement();
        }

        private void HandleMovement()
        {
            //check if there is ground in front
            if (CheckForWalk() && !GetComponent<Move_1D>().WallCheck(transform.right * myAxis))
            {
                //keep moving forward
                GetComponent<Move_1D>().Move(myAxis);
            }
            else
            {
                //if there is nowhere to go, flip the axis
                myAxis *= -1;

                //flip the sprite
                mySprite.flipX = !mySprite.flipX;
            }
        }

        bool CheckForWalk()
        {
            //calculate an origin for the raycast
            Vector2 origin = transform.position;
            origin.x += 0.5f * myAxis;

            //return the results as a bool
            return Physics2D.Raycast(origin, Vector2.down, 0.6f, layerMask);
        }

    }
}
