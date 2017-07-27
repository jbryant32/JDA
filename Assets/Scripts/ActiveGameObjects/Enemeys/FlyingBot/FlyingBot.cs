using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using Assets.Scripts.Interfaces;

namespace Assets.ActiveGameObjects.Enemeys.FlyingBot
{
    public class FlyingBot : MonoBehaviour,IHealth
    {
        int health;
        public int Health
        {
            get { return health; }
             
            set { health = value; }
        }
        GameObject healthbar;
        private SpriteRenderer healthbar_SR;
        private int healthmax;

        private void Awake()
        {
            Health = 100;
            healthmax = health;
            healthbar =  GameObject.Find("Healthbar") ;
        }
        private void FixedUpdate()
        {
            float scaler = 1f / healthmax;
            healthbar.transform.localScale = new Vector3(scaler* health, 0.3f, 1);
        }
    }
}
