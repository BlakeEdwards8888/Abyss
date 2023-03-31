using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        HideCursor();
    }

    private void HideCursor()
    {
        //make the cursor invisible
        Cursor.visible = false;

        //confine the cursor to the screen
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //keep the cursor hidden
        HideCursor();

        //match the cursor's position
        transform.position = Input.mousePosition;
    }
}
