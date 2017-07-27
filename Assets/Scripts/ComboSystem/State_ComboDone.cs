using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.ComboSystem
{
    public class State_ComboDone : MonoBehaviour, ICombo
    {
        ComboController Context;
        public State_ComboDone(ComboController context)
        {
            Context = context;
        }

        void logic()
        {
            HandleEvents.OnComboEnded(this);
        }
        public void AssignState()
        {
            throw new NotImplementedException();
        }

        public void Ontrigger(Collider2D collision)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
          
        }

        public void UpdateState()
        {
            logic();
        }
    }
}
