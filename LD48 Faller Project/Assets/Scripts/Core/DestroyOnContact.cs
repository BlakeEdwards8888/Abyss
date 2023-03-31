using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faller.Core
{
    public class DestroyOnContact : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }
    }
}
