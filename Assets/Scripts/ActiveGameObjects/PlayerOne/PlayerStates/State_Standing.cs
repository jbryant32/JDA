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
    public class State_Standing : MonoBehaviour, IState
    {
       
       
    
        StateController context;
        

        public State_Standing(StateController _context)
        {
            context = _context;
        }

        private void Awake()
        {
           
            
         
        }

        private void Start()
        {
           
        }

        public int Standing()
        {

            if (GameManager.PlayerOneHit)
            {
                context.SetState(context.GetStateHit());
            }
            context.animationcontroller_.Player("Standing", true);
            //context.animationController.SetAnimateState(context.animationController.GetAnimStateStanding());
            if (!context.Playerone.PlayerOnephysics.ActorOnGround())//fell off platform
            {
                context.Playerone.PlayerOnephysics.WalkedOffPlatform(PlayerOne.Position);
                context.SetState(context.GetFallingState());
                return 0;

            }

            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                context.SetState(context.GetRunningState());

            }


            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                context.SetState(context.GetRunningState());
            }

            if (Input.GetKeyDown(KeyCode.A))
            {

                context.SetState(context.GetState_Attack_A());
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {


                context.SetState(context.GetStateJumped());


            }
            else {  }

            return 0;
        }
 

        public void UpdateState()
        {
            
            Standing();
          
        }

       
    }
}
