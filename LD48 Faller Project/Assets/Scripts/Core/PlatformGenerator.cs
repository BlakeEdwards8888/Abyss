using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Control;

namespace Faller.Core
{
    public class PlatformGenerator : MonoBehaviour
    {
        [SerializeField] GameObject[] platformPrefabs;
        [SerializeField] float distancePerPlatform = 5, xRangeMin, xRangeMax;

        Rigidbody2D playerRb2d;
        float distanceFallen;

        private void Awake()
        {
            playerRb2d = FindObjectOfType<PlayerController>().GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (playerRb2d == null) return;

            //keep track of how far the player has fallen
            distanceFallen -= playerRb2d.velocity.y * Time.deltaTime;

            //try to spawn a new platform
            SpawnNewPlatform();

        }

        private void SpawnNewPlatform()
        {
            //once the player has passed the distance threshold, spawn a new platform
            if (distanceFallen >= distancePerPlatform)
            {
                //first calculate a position for the platform
                Vector2 platPos = transform.position;
                platPos.x = Random.Range(xRangeMin, xRangeMax);

                //instantiate the platform
                GameObject tempPlat = Instantiate(platformPrefabs[Random.Range(0,platformPrefabs.Length)], platPos, Quaternion.identity);

                //reset distance fallen
                distanceFallen = 0;
            }
        }
    }
}
