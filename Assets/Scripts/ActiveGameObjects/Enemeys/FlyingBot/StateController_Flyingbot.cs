using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.ActiveGameObjects.Enemeys;
using Assets.Interfaces.Enemy;
using Assets.ActiveGameObjects.Enemeys.FlyingBot.States;
using Assets.Scripts.ActiveGameObjects.Enemeys.FlyingBot.States;

namespace Assets.ActiveGameObjects.Enemeys.FlyingBot
{
    public class StateController_Flyingbot:MonoBehaviour
    {


        private IEnemyState State;
        private IEnemyState FlyingBot_StateSpawning;
        private IEnemyState FlyingBot_StateSearchForPlayer;
        private IEnemyState Flyingbot_StateMoving;
        private IEnemyState Flyingbot_StateFiring;
        private IEnemyState Flyingbot_StateShotFired;
        private State_Hit Flyingbot_StateHit;
        internal FlyingBot flyboy;
        public void Awake()
        {
            flyboy = GetComponent<FlyingBot>();
            FlyingBot_StateSpawning = GameObject.Find("MurderBot").GetComponent<State_Spawning>();
            FlyingBot_StateSearchForPlayer = GameObject.Find("MurderBot").GetComponent<State_SearchingForPlayer>();
            Flyingbot_StateMoving = this.GetComponentInParent<State_Moving>();
            Flyingbot_StateFiring = this.GetComponentInParent<State_Attacking>();
            Flyingbot_StateShotFired = this.GetComponent<State_ShotFired>();
            Flyingbot_StateHit = new State_Hit(this);
            State = FlyingBot_StateSpawning;
        }

        public IEnemyState GetStateSpawning()
        {
            return FlyingBot_StateSpawning;
        }
        public IEnemyState GetStateSearchingForPlayer()
        {
            return FlyingBot_StateSearchForPlayer;
        }

        public IEnemyState GetState_Moving()
        {
            return Flyingbot_StateMoving;
        }
        public IEnemyState GetState_ShotFiring()
        {
            return Flyingbot_StateShotFired;
        }
        internal IEnemyState GetState_Attacking()
        {
            return Flyingbot_StateFiring;
        }
        internal IEnemyState GetState_Hit()
        {
            return Flyingbot_StateHit; 
        }
        public void SetState(IEnemyState state)
        {
            State = state;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Flyingbot_StateHit.OnTrigger2d(collision);
        }

        public void _fixedupdate()
        {
            State.UpdateState();
        }

       
        
    }
}
