using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Physix;
using UnityEngine;
using Assets.ActiveGameObjects;
using Assets.Interfaces;

namespace Assets.ActiveGameObjects.PlayerOne
{
    public class PlayerInput:MonoBehaviour, IControllerinput
    {
        

         
        public void InputState()
        {
            

            

            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                
                
            }
             
            
            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                

            }
            if (Input.GetKey(KeyCode.Space))
            {


                


            }
            if (Input.GetKeyUp(KeyCode.H))
            {
              

            }
            

            /*
            if (UnityEngine.Input.anyKey != true && !PlayerOne.PlayerOnephysics.Jumping())
            {
                PlayerOneState.state = PlayerOneState.State.Standing;
            }
            if (PlayerOne.PlayerOnephysics.Jumping())
            { PlayerOneState.state = PlayerOneState.State.Jumping;  }
            */
        }
     
        void Update()
        {

        }

        private void FixedUpdate()
        {
            InputState();
        }

         
    }
}
