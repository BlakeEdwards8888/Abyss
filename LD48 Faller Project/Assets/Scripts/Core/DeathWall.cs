using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    [SerializeField] float fallSpeed, acceleration;   //the initial fall speed and accel

    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //keep moving down

        //calculate the next position
        Vector2 newPos = transform.position;
        newPos.y -= fallSpeed * Time.deltaTime;

        //move to the new position
        rb2d.MovePosition(newPos);

        //increase fallSpeed
        fallSpeed += acceleration * Time.deltaTime;

    }
}
