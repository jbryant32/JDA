using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityScript;
using Assets.Interfaces.Enemy;
namespace Assets.ActiveGameObjects.Enemeys.FlyingBot.States
{
    public class State_Spawning:MonoBehaviour,IEnemyState
    {
        Vector2 SpawnPos;
        PlayerOne.PlayerOne Player;
        StateController_Flyingbot context;

        private void Awake()
        {
            Player = GameManager.playerone;
            context = this.GetComponent<StateController_Flyingbot>();
        }

        public void AttackingPlayer()
        {
            throw new NotImplementedException();
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
            context.SetState(context.GetStateSearchingForPlayer());
        }

        public void UpdateState()
        {
            Spawn();
        }

        public void Moving()
        {
            throw new NotImplementedException();
        }

        public void ShotFired()
        {
            throw new NotImplementedException();
        }
    }
}
