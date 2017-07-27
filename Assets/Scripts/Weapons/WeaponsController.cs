using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Weapons
{
    //TODO add projectiles to projectiles container
    public class WeaponsController:MonoBehaviour
    {

        public List<GameObject> BulletPrefabs = new List<GameObject>();

        private void Awake()
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject a = Instantiate(Resources.Load("Items/Projectiles/Bullet")) as GameObject;
                a.SetActive(false);
                a.name = "Bullet";
                if (this.tag == "Enemy")
                {
                    a.tag = "Enemy";
                }
                if (this.tag == "Player")
                {
                    a.tag = "Player";
                }
                BulletPrefabs.Add(a);
            }

        }

        private void FixedUpdate()
        {



        }

    }
}
