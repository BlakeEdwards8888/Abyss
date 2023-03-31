using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faller.Damage
{
    public class PlayerDeath : DeathScript
    {
        [SerializeField] Animator gameOverScreen;

        public override void Die()
        {
            base.Die();
            gameOverScreen.SetTrigger("Enter");
        }
    }
}
