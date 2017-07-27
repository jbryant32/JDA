using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Assets.Interfaces;
using Assets.ActiveGameObjects.PlayerOne;
using Assets.ActiveGameObjects.PlayerOne.PlayerStates;
using Assets.Collision;

namespace Assets.Physix
{
    public partial class PlayerPhysics : MonoBehaviour, IActorPhysics
    {

        //TODO change to ground bidel phyics for object 
       // public PlayerOne Playerone;
        public bool HitLeft;
        public bool HitRight;
        public bool InAir;
        public bool Falling;
        private HandleCollision Foot;
        private HandleCollision Head;
        private HandleCollision Body;
        internal bool Onground;
        private Vector2 Force;
        private Vector2 LinearDrag;
        public Vector2 Direction;
        public Vector2 Push;
        private Vector2 CurrentDirection;
        private Vector2 PreviousDirection;
      
        Rigidbody2D rigidbody ;

        //TODO to much slide while running and jumping
        private void Awake()
        {
           
            this.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().freezeRotation = true;
          
            Component[] c = GetComponentsInChildren<HandleCollision>();
            foreach (Component comp in c)
            {
                if (comp.name == "Foot")
                {
                    Foot = comp.GetComponent<HandleCollision>();
                    
                }
                if (comp.name == "Body")
                {
                    Body = comp.GetComponent<HandleCollision>();
                }
                if (comp.name == "Head")
                {
                    Head = comp.GetComponent<HandleCollision>();
                }
            }
           
            intialiazeJump();
            rigidbody = this.GetComponent<Rigidbody2D>();
        }

        public void ClampToFloor( )
        {
            if (!jumping && !Jumped && !Falling && Onground)
            {
                Force.y = Mathf.Clamp(Force.y, 0, 0.1f);
            }
        }

        public void WalkedOffPlatform(Vector2 LastPlatformStoodOn)
        {
            
        }


        public bool ActorFalling()
        {
            return Falling;
        }
 
        public Vector2 force()
        {
            return Force;
        }
            
        public bool Jumping()
        {
            return jumping;
        }

        public bool  ActorOnGround( )
        {
           return Onground;
        }


        public void GroundCheck()
        {

            if (Foot.OnGround)
            {
                Gravity.y = 40;
                Onground = true;
                InAir = false;
                ResetJump();
            }
            else
            {

                InAir = true;
                Onground = false;
                Gravity.y += 0.5f;

            }

         
          
        }
        
        public void ApplyObjectsVelocity()//move me here
        {

             
            if (CurrentDirection != Direction)
            {

                PreviousDirection = CurrentDirection;
                
            }

            CurrentDirection = Direction;

             
            Direction.x = Mathf.Sign(Force.x);//direction
            Direction.y = Mathf.Sign(Force.y);
             

            Force -= Gravity;
             

            Force.y = Mathf.Clamp(Force.y, -maxjumpforce, maxjumpforce);
            Force.x = Mathf.Clamp(Force.x, -MaxRunSpeed   , MaxRunSpeed  );
            Push = Vector2.Lerp(Push, Vector2.zero, 0.2f);

          


            rigidbody.velocity =Force+Push;
            
        }
        
         void Update()
        {
            MonitorJump();
             
        }
        
        void FixedUpdate()
        {
            GroundCheck();
            DoFalling();
            ApplyHorizintalDrag();
            ApplyObjectsVelocity();

            

        }

        public void DoHit()
        {
            if (HitLeft)
            {
                Push.x = 500;
                if (Onground)
                {
                    Force.y = 0;
                    Force.x = -1;
                }
            }
            if (HitRight)
            {
                Push.x = -500;
                if (Onground)
                {
                    Force.y = 0;
                    Force.x =  1;

                }

            }
            Push.x = Mathf.Clamp(Push.x, -1500, 1500);

        }
    }
    #region Player_Y_Movements ////////////////////////////////////////////////////////////////////////

    public partial class PlayerPhysics
    {
        private bool CanJump;
        private bool jumping;
        private bool Jumped;
        private Vector2 InitialJumpPos;
        private float InitialJumpForce;
        private float maxjumpforce = 2000;
        
        Vector2 Gravity;
        bool ContinueAccelartion;
        bool JumpAcclerationLock ;
        void intialiazeJump()
        {
            CanJump = true;
            Jumped = false;
            jumping = false;
            JumpAcclerationLock = true;
            InitialJumpForce = 1500;
          
            
        }

        private void ResetJump()
        {
            CanJump = true;
            Jumped = false;
            jumping = false;
            InitialJumpForce = 1500;
            JumpAcclerationLock = false ;
            JumpAccTimer = 0;
            

        }
        public void DoFalling()
        {
             
            if (Onground==false && InAir)
            {
                 Gravity.y = 100;  
               
                if (Force.y < 0)
                {
                    Gravity.y += 1;
                    Falling = true;
                    
                     
                }
                 
            }
            
        }
        
        public void DoJump( )
        {
             
            if (CanJump && !jumping)//initial jump settings
            {
                 
                Force.y = InitialJumpForce;
                
                InitialJumpPos = this.transform.position;
                Jumped = true;
                jumping = true;
                CanJump = false;
                 
                 
            }

            if (jumping)
            {

                Jumped = false;
                if (ContinueAccelartion)
                {

                    Force.y += 100;
                }
               
            }
        }

      
        
       
        float JumpAccTimer;
        float JumpMaxT = 2;
        public void MonitorJump()
        {
             
             

            if (JumpAccTimer > 3)
            {
                JumpAcclerationLock = true;
                ContinueAccelartion = false;
            }
            
            if (jumping)
            {
                float delta = Mathf.Lerp(0,  InitialJumpForce, 0.005f);
                if (jumping) { JumpAccTimer += 0.5f; }

                if (JumpAccTimer < JumpMaxT && Input.GetKey(KeyCode.Space))
                {
                    JumpAcclerationLock = false;
                }

                if (JumpAccTimer > JumpMaxT && !Input.GetKey(KeyCode.Space))
                {
                    JumpAcclerationLock = true;
                    ContinueAccelartion = false;
                }

                if (JumpAcclerationLock == false)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        ContinueAccelartion = true;
                    }
                    if (!Input.GetKey(KeyCode.Space))
                    {
                        ContinueAccelartion = false;

                    }
                }

                if (Mathf.Floor(Force.y) <= 0)//jump done
                {
                    jumping = false;
                }





            }

        }

       
    }

    #endregion
    //TODO burts speed
    #region Playerhorizontal movements////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle Player X Axis Physics
    /// </summary>
    public partial class PlayerPhysics
    {
        
        private float MaxRunSpeed =800;

        public float Moving_X(int Speed)
        {

           return Force.x += Speed;
        }

        public bool checkplayermoving_x()
        {

            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow) || UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                return true;
            }
            else { return false; }

        }
        public void MoveAfterJump()
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                Moving_X(-10);
            }
            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                Moving_X(10);
            }
        }

       
        public void ApplyHorizintalDrag()
        {

            float lerpt = 0.1f;//between 0-1
            float drag;

            if (!checkplayermoving_x())//check if player is moving player object
            {
                drag = Mathf.Lerp(Force.x, 1 * Direction.x, lerpt);


                if (Mathf.Sign(drag) == 1)
                {
                    drag = Mathf.Floor(drag);
                }
                if (Mathf.Sign(drag) == -1)
                {
                    drag = Mathf.Ceil(drag);
                }
                Force.x = drag;
            }
         

        }
         
         
        public void DoRunning()
        {

            
                if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
                {
                if (Force.x >0)//we were running right then pressed left 
                {
                    Force.x = 5;
                }
                Moving_X(-50);
                    Force.y -= 50;
                    Force.y  = Mathf.Clamp(Force.y,-100, 100);


                }

            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                if (Force.x < 0)//we were running left the pressed right 
                {
                    Force.x = 5;
                }
                Moving_X(50);
                Force.y -= 50;
                Force.y = Mathf.Clamp(Force.y, -100, 100);


            }


        }
    }
    #endregion

   
}
