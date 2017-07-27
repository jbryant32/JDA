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
    public class State_Attacking:MonoBehaviour,IEnemyState
    {
        Vector2 SpawnPos;
        PlayerOne.PlayerOne Player;
        State_Moving state_moving;
        StateController_Flyingbot context;
        
        FreakinLasers LaserRife;
        GameObject me;
        float AttackTimer;

        private void Awake()
        {
            
            me = GameObject.Find("MurderBot");
            state_moving= this.GetComponent<State_Moving>();
            context = this.GetComponent<StateController_Flyingbot>();
             
        }

        private void Start()
        {

            Player = GameManager.playerone;


        }
        float lerpt;
        
        public void AttackingPlayer()//look at player
        { 
            lerpt += 0.05f;
            AttackTimer += Time.fixedDeltaTime * 1;
            state_moving.GetVecotrPoints();
            
            if (lerpt < 1)
            {
               // FlyingBotPhysics.RotateTo(me, Player.transform.position, lerpt);
            }
             
            if(lerpt >= 1)
            {
                lerpt = 0;
                context.SetState(context.GetState_ShotFiring());
            }
            
            if (AttackTimer > 8)
            {
                AttackTimer = 0;
                 
                
            }
            
        }

        public bool Dying()
        {
            throw new NotImplementedException();
        }

        public int Hit()
        {
            throw new NotImplementedException();
        }

        public void SearchForPlayer()
        {
            throw new NotImplementedException();
        }

        public void Spawn()
        {
            throw new NotImplementedException();
        }
        
        public void Moving()
        {
            throw new NotImplementedException();

        }
        
        public void UpdateState()
        {
            AttackingPlayer();
        }

        public void ShotFired()
        {
            throw new NotImplementedException();
        }
    }
}
