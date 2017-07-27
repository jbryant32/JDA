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
    public class State_Spawning : MonoBehaviour, IState
    {
       
        
       
        StateController context;

        public State_Spawning(StateController _context)
        {
            context = _context;
        }

        private void Awake()
        {




        }

        private void Start()
        {
          
        }

        public int Spawning()
        {
            bool Onground = context.Playerone.PlayerOnephysics.ActorOnGround();
            //animation here

            if (!Onground)
            {
                context.SetState(context.GetFallingState());

                return 1;
                
            }

            return 0;
        }

       
       
       

        public void UpdateState()
        {
            Spawning();
            
        }

       
    }
}
