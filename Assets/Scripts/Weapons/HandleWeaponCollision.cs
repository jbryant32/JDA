using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Weapons
{
    public class HandleWeaponCollision:MonoBehaviour
    {
        private FireShot fireshot;

        private void Awake()
        {
            fireshot = GetComponent<FireShot>();
        }
        //TODO ignore Shooters box and level colliders
        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.gameObject.SetActive(false);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (fireshot.tag == "Enemy")
            {
                if (collision.tag == "Player")
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
