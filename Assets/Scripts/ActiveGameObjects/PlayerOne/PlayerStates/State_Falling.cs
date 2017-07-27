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
    public class State_Falling : MonoBehaviour, IState
    {
         
        StateController context;

        public State_Falling(StateController _context)
        {
            this.context = _context;
           
        }

        

        public int Dead()
        {
           
            throw new NotImplementedException();
        }

        public int Falling()
        {
            
            if (GameManager.PlayerOneHit)
            {
                context.SetState(context.GetStateHit());
                return 0;
            }
           context.animationcontroller_.Player("Falling", true);
             
            if (context.Playerone.PlayerOnephysics.ActorOnGround())
            {
               
                context.SetState(context.GetLandingState());
            }
            return 0;
        }

      
        
        public void UpdateState()
        {
            Falling();
           
 
        }

       
    }
}
