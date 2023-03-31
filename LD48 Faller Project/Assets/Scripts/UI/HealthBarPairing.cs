using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Faller.GUI
{
    public class HealthBarPairing : MonoBehaviour
    {
        [SerializeField] Sprite heartFull, heartHalf, heartEmpty;
        [SerializeField] Image[] myHearts;

        public void UpdateHP(float curHP)
        {
            float sHealth = (curHP / 5);

            for(int i = 0; i < myHearts.Length; i++)
            {
                int remainderHealth = (int)Mathf.Clamp(sHealth - (i * 2), 0, 2);

                switch (remainderHealth)
                {
                    case 0:
                        myHearts[i].sprite = heartEmpty;
                        break;
                    case 1:
                        myHearts[i].sprite = heartHalf;
                        break;
                    case 2:
                        myHearts[i].sprite = heartFull;
                        break;
                }
            }

        }

    }
}
