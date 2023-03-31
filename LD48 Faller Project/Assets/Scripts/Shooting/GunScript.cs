using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faller.Audio;

namespace Faller.Shooting
{
    public class GunScript : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] float bulletForce, fireRate;
        [SerializeField] Transform firePoint;

        float timetilFire;

        [SerializeField] AudioClip shootSfx;

        // Update is called once per frame
        void Update()
        {
            timetilFire -= Time.deltaTime;
        }

        public void Fire()
        {
            if (timetilFire <= 0) {
                //fire a bullet
                GameObject tempBullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);

                //get the final velocity
                tempBullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletForce;

                //reset fire time
                timetilFire = fireRate;

                //play the sfx
                if (shootSfx != null)
                    SfxManager.instance.PlayNewSFX(shootSfx, transform.position);

            }
        }
    }
}
