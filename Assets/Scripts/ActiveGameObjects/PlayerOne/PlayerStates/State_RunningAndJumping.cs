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
    public class State_RunningAndJumping : MonoBehaviour, IState
    {
        IControllerinput Input;
       
        StateController context;
        

        public State_RunningAndJumping(StateController _context)
        {
            context = _context;
        }
        private void Awake()
        {
            Input = PlayerOne.playerinput;
            
           
          
        }
        private void Start()
        {
          
        }

       

      
        public int RunningJump()
        {
            if (GameManager.PlayerOneHit)
            {
                context.SetState(context.GetStateHit());
                return 0;
            }
            //context.animationController.SetAnimateState(context.animationController.GetAnimStateJumping());
           // if (context.animationController.GetCurrentAnimFrame() == 2) { context.Playerone.PlayerOnephysics.DoJump(); }

            context.Playerone.PlayerOnephysics.MoveAfterJump();

            if (!context.Playerone.PlayerOnephysics.ActorOnGround() && !context.Playerone.PlayerOnephysics.Jumping())
            {
                context.SetState(context.GetFallingState());
                return 1;
            }
            
            return 0;
        }
        public void UpdateState()
        {
            RunningJump();
        }

       
    }
}
