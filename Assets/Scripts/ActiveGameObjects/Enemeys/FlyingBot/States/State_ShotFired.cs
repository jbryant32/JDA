using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityScript;
using Assets.Interfaces.Enemy;
using Assets.Weapons;
namespace Assets.ActiveGameObjects.Enemeys.FlyingBot.States
{
    public class State_ShotFired : MonoBehaviour, IEnemyState
    {

        WeaponsController weapons;
        List<FireShot> _Bullets = new List<FireShot>();
        StateController_Flyingbot context;
        int clip;
        PlayerOne.PlayerOne Player;

        private void Awake()
        {
            Player = GameManager.playerone;
            context = this.GetComponent<StateController_Flyingbot>();
            weapons = this.GetComponent<WeaponsController>();
            
        }

        private void Start()
        {
            foreach (GameObject g in weapons.BulletPrefabs)
            {

                _Bullets.Add(g.GetComponent<FireShot>());
            }
            

        }


        
        public void ShotFired()
        {
            clip++;
            clip = Mathf.Clamp(clip, 0, _Bullets.Count - 1);

            if (clip == _Bullets.Count - 1)//out of bullets
            {
                context.SetState(context.GetState_Moving());
            }

           
             
            _Bullets[clip].Initiliaze(this.transform.position, this.gameObject, 3);//fire shot


            context.SetState(context.GetState_Moving());//exit to state moving

        }

        void ClearAcitvebullets()
        {
            //if bullet out of screen remove 

        }
        
        public void UpdateState()
        {
            ShotFired();
        }
    }
}
