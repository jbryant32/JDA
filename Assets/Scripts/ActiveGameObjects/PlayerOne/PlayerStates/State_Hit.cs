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
    public class State_Hit : MonoBehaviour, IState
    {
        
        
        StateController context;
       
        float hittimer;
        float maxhittime;

        public State_Hit(StateController _context)
        {
            context = _context;
        }

        private void Awake()
        {
            GameManager.PlayerOneCanBeHit = true;
           
          
             
            hittimer = 0;
            maxhittime = 30;
        }
        private void Start()
        {
             
        }
        public int Dead()
        {
           
            throw new NotImplementedException();
        }

        public int Falling()
        {
            throw new NotImplementedException();
        }

        public int Hit()
        {
       
            hittimer += 0.5f;
            if (GameManager.PlayerOneHit == true)
            {
                context.Playerone.PlayerOnephysics.DoHit();
            }
            GameManager.PlayerOneHit = false;
            

            if ( hittimer<maxhittime)
            {
                
                 
                GameManager.PlayerOneCanBeHit = false;
                return 0;
            }
            hittimer = 0;
            GameManager.PlayerOneCanBeHit = true;
            context.SetState(context.GetStateStanding());
             
            return  0;
        }

       
       
        public void UpdateState()
        {
            Hit();
        }

       
    }
}
