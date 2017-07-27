using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Interfaces.Enemy;
namespace Assets.ActiveGameObjects.Enemeys.FlyingBot.States
{
    public class State_SearchingForPlayer : MonoBehaviour, IEnemyState
    {
        Vector2 SpawnPos;
        PlayerOne.PlayerOne Player;
        StateController_Flyingbot context;
        private void Awake()
        {
            Player = GameManager.playerone;
            context = this.GetComponent<StateController_Flyingbot>();
        }


       

        public void SearchForPlayer()
        {
            context.SetState(context.GetState_Moving());
        }

       
        public void UpdateState()
        {
            SearchForPlayer();
        }

        public void ShotFired()
        {
            throw new NotImplementedException();
        }
    }
}
       
