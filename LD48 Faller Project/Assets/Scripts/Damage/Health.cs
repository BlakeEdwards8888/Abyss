using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.GUI;

namespace Faller.Damage
{
    [RequireComponent(typeof(DeathScript))]
    public class Health : MonoBehaviour
    {
        [SerializeField] HealthBarPairing hbp;
        [SerializeField] float maxHP;
        float curHP;

        private void Awake()
        {
            //initialize HP
            curHP = maxHP;
        }

        public void TakeDamage(float dmg)
        {
            //reduce hp by damage taken
            curHP -= dmg;

            //if there is a health bar pairing, update the UI
            if (hbp != null)
                hbp.UpdateHP(curHP);

            //if HP reaches 0, die
            if (curHP <= 0) GetComponent<DeathScript>().Die();
        }
    }
}
