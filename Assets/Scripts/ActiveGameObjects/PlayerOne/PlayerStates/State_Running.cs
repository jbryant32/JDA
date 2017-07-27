using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.ActiveGameObjects.PlayerOne;
using Assets.Physix;
using Assets.Interfaces;

using UnityEngine;

namespace Assets.ActiveGameObjects.PlayerOne.PlayerStates
{
    public class State_Running : MonoBehaviour, IState  
    {
       
        
        
        StateController context;
         

        public State_Running(StateController _context)
        {
            context = _context;
        }

        
       
        public int Running()
        {
            if (GameManager.PlayerOneHit)
            {
                context.SetState(context.GetStateHit());
                return 0;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {

                context.SetState(context.GetState_Attack_A());
            }
            context.Playerone.PlayerOnephysics.DoRunning();
            if (!context.Playerone.PlayerOnephysics.ActorOnGround())//fell off platform
            {
                context.Playerone.PlayerOnephysics.WalkedOffPlatform(PlayerOne.Position);
                context.SetState(context.GetFallingState());
                 

            }

                if (UnityEngine.Input.GetKey(KeyCode.LeftArrow) )
            {

                context.animationcontroller_.Player("Running", true);

                if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                {
                    context.SetState(context.GetStateJumped());

                }
            }
             
            if (UnityEngine.Input.GetKey(KeyCode.RightArrow) )
            {

                context.animationcontroller_.Player("Running", true);


                if (UnityEngine.Input.GetKey(KeyCode.Space))
                {
                    context.SetState(context.GetStateJumped());
                }
            }
            if (!UnityEngine.Input.GetKey(KeyCode.LeftArrow) && !UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                context.SetState(context.GetStateStanding());
            }

            
            return 0;
        }

        
        
        public void UpdateState()
        {
            
            Running();
          
        }

       

       
    }
}
