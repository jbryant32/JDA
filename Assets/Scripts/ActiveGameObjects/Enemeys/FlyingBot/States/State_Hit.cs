using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.ActiveGameObjects.Enemeys.FlyingBot;
using UnityEngine;

using Assets.Interfaces.Enemy;

namespace Assets.Scripts.ActiveGameObjects.Enemeys.FlyingBot.States 
{
    public class State_Hit:IEnemyState
    {
        StateController_Flyingbot context;
         
        public State_Hit(StateController_Flyingbot c)
        {
            context = c;

        }
        float count; 
        public void OnTrigger2d(Collider2D info)
        {
            if (info.name == "AttackBox")
            {
                 
                
                if (context.flyboy.Health - GameManager.playerone.LiteHit < 0)
                {
                    context.flyboy.Health = 0;
                    return;//we dead
                }
                context.flyboy.Health -= GameManager.playerone.LiteHit;
            }

        }

        public void UpdateState()
        {
             
        }
    }
}
