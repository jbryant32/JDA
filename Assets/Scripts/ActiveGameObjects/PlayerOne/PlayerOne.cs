using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Physix;
using UnityEngine;
using Assets.Interfaces;
namespace Assets.ActiveGameObjects.PlayerOne
{
    public class PlayerOne:MonoBehaviour
    {
        public IActorPhysics PlayerOnephysics;
      
        
         
        public static StateController StateController;
       
        public int Health;
        public int MaxHealth;
        public int LiteHit;
        public int MediumHit;
        public int HeavyHit; 
        public static Vector2 Position;
        public static bool GotHit;

      

        void Awake()
        {
            MaxHealth = 150;
            Health = 150;
            PlayerOnephysics = GetComponent<PlayerPhysics>();
            
            StateController = GetComponent<StateController>();
          
            LiteHit = 5;
            MediumHit = 10;
            HeavyHit = 20;
        }

         
        

        void Update()
        {
            
            
            
            Position = this.GetComponent<Transform>().position;
       


        }
        void FixedUpdate()
        {
          
        }


    }
}
