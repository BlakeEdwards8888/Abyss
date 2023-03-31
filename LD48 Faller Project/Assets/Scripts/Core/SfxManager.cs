using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faller.Audio
{
    public class SfxManager : MonoBehaviour
    {
        public static SfxManager instance;

        [SerializeField] GameObject sfxPlayerPrefab;

        // Start is called before the first frame update
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayNewSFX(AudioClip clip, Vector2 pos)
        {
            //instantiate the sfx prefab at the given position
            GameObject tempSfx = Instantiate(sfxPlayerPrefab, pos, Quaternion.identity);

            //set its clip
            tempSfx.GetComponent<AudioSource>().clip = clip;

            //play the clip
            tempSfx.GetComponent<AudioSource>().Play();
        }

        
    }
}
