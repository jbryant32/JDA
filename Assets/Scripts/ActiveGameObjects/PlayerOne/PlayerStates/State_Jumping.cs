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
    public class State_Jumping : MonoBehaviour, IState
    {
        
        
         
        private StateController context;


        public State_Jumping(StateController _context)
        {
            context = _context;
        }

        private void Awake()
        {
           
          
           
            context = GameManager.playerone.GetComponent<StateController>();
        }

      //TODO finish removing animation controller and states
        public int Jumping() 
        {

            if (GameManager.PlayerOneHit)
            {
                context.SetState(context.GetStateHit());
                return 0;
            }

           
            context.Playerone.PlayerOnephysics.DoJump(); 
          
         
            context.animationcontroller_.Player("Jumping", true);  
            context.Playerone.PlayerOnephysics.MoveAfterJump();


            if (!context.Playerone.PlayerOnephysics.ActorOnGround() && !context.Playerone.PlayerOnephysics.Jumping())
            {
                context.SetState(context.GetFallingState());
                
            }
            return 0;
        }
          void UpdateJump()
        {

        }

       
        public void UpdateState()
        {
            Jumping();

        }

        

       
    }
}
