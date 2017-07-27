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
    public class State_Jumped : MonoBehaviour, IState
    {
        
        
         
        private StateController context;


        public State_Jumped(StateController _context)
        {
            context = _context;
        }

        private void Awake()
        {
           
          
           
            context = GameManager.playerone.GetComponent<StateController>();
        }

      
        public int Jumping() 
        {

            if (GameManager.PlayerOneHit)
            {
                context.SetState(context.GetStateHit());
                return 0;
            }
          
            context.animationcontroller_.Player("Jump", false);
            if ( context.animationcontroller_.Current_Frame() == 1)
            {
                context.SetState(context.GetStateJumping());
                
            }
            return 0;
        }
          void UpdateJump()
        {

        }

       
        public void UpdateState()
        {
            CustomDevTools.PrintVariables.printvar(1, "frame" + context.animationcontroller_.Current_Frame().ToString());
            Jumping();

        }

        

       
    }
}
