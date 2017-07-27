using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interfaces;
namespace Assets.Scripts.ComboSystem
{
    public class State_ComboReady:MonoBehaviour,ICombo
    {
        ComboController Context; 
        public State_ComboReady(ComboController context)
        {
            this.Context = context;
        }

        public void Ontrigger(Collider2D collision)
        {
            
        }
        void logic()
        {
           
        }
        public void Reset()
        {
           
        }

        public void UpdateState()
        {
           
            logic();
        }

        public void AssignState()
        {
            Context._state = ComboController.StateToSet.waitroom;
        }
    }
}
