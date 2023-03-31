using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faller.Core
{
    public class Cleaner : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }

    }
}
