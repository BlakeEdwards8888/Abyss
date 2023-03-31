using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Control;

namespace Faller.Core
{
    public class EyebatSpawner : MonoBehaviour
    {
        [SerializeField] GameObject eyebatPrefab;
        [SerializeField] float waitToSpawn;
        [SerializeField] Transform[] spawnPoints;

        float timeTilNextSpawn;

        // Start is called before the first frame update
        void Awake()
        {
            //initialize timeTilSpawn
            timeTilNextSpawn = waitToSpawn;
        }

        // Update is called once per frame
        void Update()
        {
            if (FindObjectOfType<PlayerController>() == null) return;
            SpawnEyebat();
        }

        private void SpawnEyebat()
        {
            //if an eyebat is already spawned, do nothing
            if (FindObjectOfType<EnemyController>() != null) return;

            //count down spawn time
            if (timeTilNextSpawn <= 0)
            {
                //if wait time is up, spawn a bat
                Instantiate(eyebatPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

                //reset wait time
                timeTilNextSpawn = waitToSpawn;

            }
            else
            {
                //otherwise, count down wait time
                timeTilNextSpawn -= Time.deltaTime;
            }
        }
    }
}
