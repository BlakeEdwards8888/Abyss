using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadGrabber : MonoBehaviour
{
    public void LocalLevelLoad(string scene)
    {
        LevelLoader.instance.LoadNewLevel(scene);
    }
}
