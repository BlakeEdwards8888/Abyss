using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //calculate a new position
        Vector2 newPos = transform.position;
        newPos.y += scrollSpeed * Time.deltaTime;
        rb2d.MovePosition(newPos);
    }
}
