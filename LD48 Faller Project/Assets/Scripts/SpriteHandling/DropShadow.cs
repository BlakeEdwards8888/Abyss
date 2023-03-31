using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadow : MonoBehaviour
{

    [SerializeField] SpriteRenderer shadowTarget;
    SpriteRenderer mySR;
    [SerializeField] Vector3 shadowOffset;

    // Start is called before the first frame update
    void Awake()
    {
        mySR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mySR.sprite = shadowTarget.sprite;

        //handle flipping
        mySR.flipX = shadowTarget.flipX;
        mySR.flipY = shadowTarget.flipY;
    }
}
