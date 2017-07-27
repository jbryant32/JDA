using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.ComboSystem
{
    public class Attack_Listner:MonoBehaviour,IattackListner
    {

        public bool hit;
        private Collider2D Colliderinfo;
        public Collider2D HitCollider;
        float CheckIO;

        public bool HitEnemy
        {
            get
            {
              return hit;
            }

            set
            {
                hit=value;
            }
        }

        public Collider2D Collider
        {
            get
            {
                return HitCollider;
            }

            set
            {
                value = HitCollider;
            }
        }

        private void Awake()
        {
            Colliderinfo = GetComponent<BoxCollider2D>();
            Colliderinfo.enabled = false;
            CheckIO = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                hit = true;
                HitCollider = collision;
            }
           
        }


        private void  Update()
        {
            CustomDevTools.PrintVariables.printvar(1, CheckIO.ToString());
             
            if (CheckIO == 1 )
            {
                Colliderinfo.enabled = true;
            }
            if (CheckIO == 0)
            {
                Colliderinfo.enabled = false;
            }
            if (CheckIO  > 0)
            {
                CheckIO  = 0;
            }
        }
        public bool CheckHit()//go on frame and check for hit
        {
            CheckIO = 1  ;
                        
            return hit;
        }
      
    }
}
