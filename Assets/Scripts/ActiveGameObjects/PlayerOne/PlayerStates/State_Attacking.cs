using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Interfaces;
using Assets.Physix;
using Assets.Scripts.ComboSystem;

namespace Assets.ActiveGameObjects.PlayerOne.PlayerStates
{
    public class State_Attacking : MonoBehaviour, IState
    {
        
        
        StateController context;
        
        

        public State_Attacking(StateController _context)
        {
            context = _context;
        }

       
       
        private void Start()
        {
           
        }
        
       
        public void Logic()
        {
             
            HandleEvents.OnComboEnd += HandleEvents_OnComboEnd;
            if (context.combocontroller._state == ComboController.StateToSet.waitroom)
            {
                context.combocontroller.SetState(context.combocontroller.GetState(ComboController.StateToSet.attackA));
            }
         
             
        }

        private void HandleEvents_OnComboEnd(object sender)
        {
            HandleEvents.OnComboEnd -= HandleEvents_OnComboEnd;
            context.SetState(context.GetStateStanding());
            context.combocontroller.SetState(context.combocontroller.GetState(ComboController.StateToSet.waitroom));
        }

      

        public void UpdateState()
        {
            Logic();
             
        }
    }
}
