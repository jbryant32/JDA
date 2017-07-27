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
    public class State_Firing:MonoBehaviour,IEnemyState
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
            Player = GameManager.playerone;
            me = GameObject.Find("MurderBot");
            LaserRife = GameObject.Find("FreakinLaser").GetComponent<FreakinLasers>();
            state_moving= this.GetComponent<State_Moving>();
            context = this.GetComponent<StateController_Flyingbot>();
        }
        float lerpt;
        public void AttackingPlayer()
        { 
            lerpt += 0.05f;
            AttackTimer += Time.fixedDeltaTime * 1;
            state_moving.GetVecotrPoints();
             if (lerpt < 1)
            {
               // FlyingBotPhysics.RotateTo(me, Player.transform.position, lerpt);
            }
             
            if(lerpt >= 1)
            { LaserRife.FireLaser(); }
            if (AttackTimer > 8)
            {
                lerpt = 0;
                AttackTimer = 0;
                context.SetState(context.GetState_Moving());
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
