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
    public class State_Landing : MonoBehaviour, IState
    {
       
        private StateController context;

        public State_Landing(StateController _context)
        {
            context = _context;
        }

        private void Awake()
        {
           
        }

       

        public int Landing()
        {
            //TODO laning sequence play landing animation
           
             
            context.SetState(context.GetStateStanding());
            return 0;
        }

       
        public void UpdateState()
        {
            Landing();
           
        }

      
    }
}
