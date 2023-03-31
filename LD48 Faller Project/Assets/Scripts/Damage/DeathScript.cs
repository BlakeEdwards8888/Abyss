using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Audio;

namespace Faller.Damage
{
    public class DeathScript : MonoBehaviour
    {
        [SerializeField] AudioClip deathSfx;
        [SerializeField] GameObject deathEffect;

        public virtual void Die()
        {
            //play the death sfx
            if (deathSfx != null)
                SfxManager.instance.PlayNewSFX(deathSfx, transform.position);

            //instantiate the death particle system
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            //this function is intended to be overwritten by child classes
            Destroy(gameObject);
        }
    }
}
