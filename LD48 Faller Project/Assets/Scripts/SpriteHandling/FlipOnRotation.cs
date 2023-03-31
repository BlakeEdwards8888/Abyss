using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipOnRotation : MonoBehaviour
{
    SpriteRenderer sRenderer;

    private void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //flip y when rotation is > 90 and less than 270
        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            sRenderer.flipY = true;
        }
        else
        {
            sRenderer.flipY = false;
        }
    }
}
