using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    [SerializeField] Animator transitionalScreen;

    public bool sceneHasLoaded;

    public void LoadNewLevel(string scene)
    {
        StartCoroutine(LoadingCoroutine(scene));
    }

    private IEnumerator LoadingCoroutine(string scene)
    {
        //reset sceneHasLoaded
        sceneHasLoaded = false;

        //trigger the scroll in transition
        transitionalScreen.SetTrigger("ScrollIn");

        //wait for the scroll in to complete
        yield return new WaitForSeconds(0.5f);

        //load the new scene
        SceneManager.LoadSceneAsync(scene);

        //wait for the new scene to load
        while (!sceneHasLoaded)
        {
            yield return null;
        }

        //scroll the screen back out
        transitionalScreen.SetTrigger("ScrollOut");

        yield return null;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        //add the OnSceneLoaded method to the sceneLoaded delegate
        SceneManager.sceneLoaded += ConfirmSceneLoad;
    }

    //this is going to be called every time a new scene loads
    public void ConfirmSceneLoad(Scene scene, LoadSceneMode mode)
    {
        sceneHasLoaded = true;
    }

    private void OnDisable()
    {
        //remove from the delegate
        SceneManager.sceneLoaded -= ConfirmSceneLoad;
    }
}
