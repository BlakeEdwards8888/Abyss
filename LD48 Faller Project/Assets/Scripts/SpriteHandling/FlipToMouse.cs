using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipToMouse : MonoBehaviour
{
    SpriteRenderer sRenderer;

    private void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the mouse position in world space
        float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

        //check if mouse x position is > or < ours
        if(mouseX > transform.position.x)
        {
            sRenderer.flipX = false;
        }
        else
        {
            sRenderer.flipX = true;
        }
        
    }
}
