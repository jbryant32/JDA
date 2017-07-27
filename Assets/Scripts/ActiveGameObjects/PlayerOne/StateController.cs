using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;
using Assets.Physix;
using UnityEngine;
using Assets.ActiveGameObjects.PlayerOne.PlayerStates;
using Assets.Scripts.ComboSystem;
using Assets.Scripts.Interfaces;

namespace Assets.ActiveGameObjects.PlayerOne
{
    public class StateController:MonoBehaviour
    {
        internal PlayerOne Playerone;
        internal ComboController combocontroller;
        internal IAnimationController animationcontroller_;
        private  IState  State;
        private  IState State_Spawning;
        private  IState State_Running;
        private  IState State_Jumping;
        private  IState State_Jumped;
        private  IState State_RunJumping;
        private  IState State_Standing;
        private  IState State_Hit;
        private  IState State_Falling;
        private  IState State_Landing;
        private  IState State_Dead;
        private  IState State_Attacking;

        public  State_enum PreviousState;
        public State_enum CurrentState;
        public State_enum _state;
        public enum State_enum
        {
            State_Spawning,
            State_Running,
            State_Jumping,
            State_RunJumping,
            State_Standing,
            State_Hit,
            State_Falling,
            State_Landing,
            State_Dead,
            State_Attacking,
            State_Jumped
        }

        
        public void Awake()
        {
            Playerone = GetComponent<PlayerOne>();
            animationcontroller_ = GetComponent<IAnimationController>();
            combocontroller = GameObject.Find("HitBoxes").GetComponent<ComboController>();
            State_Spawning = new State_Spawning(this);
            State_Running = new State_Running(this);
            State_Standing = new State_Standing(this);
            State_Hit = new State_Hit(this);
            State_Falling = new State_Falling(this);
            State_Landing = new State_Landing(this);
            State_Dead = new State_Died(this);
            State_Jumping = new State_Jumping(this);
            State_RunJumping = new State_RunningAndJumping(this);
            State_Attacking = new State_Attacking(this);
            State_Jumped = new State_Jumped(this);
            State = State_Spawning;
            _state = State_enum.State_Spawning;
            CurrentState = _state;
        }

        

        internal IState GetStateStanding()
        {
            return State_Standing;
        }

        internal IState GetStateRunningJump()
        {
            return State_RunJumping;
        }

        internal IState GetStateHit()
        {
            return State_Hit;
        }

        internal IState GetStateJumping()
        {
            return State_Jumping;
        }

        internal IState GetStateJumped()
        {
            return State_Jumped;
        }


        public void SetState(IState state)
        {
            if (state is State_Attacking)
            {
                _state = State_enum.State_Attacking;

            }
            if (state is State_Died)
            {

                _state = State_enum.State_Dead;
            }
            if (state is State_Falling)
            {
                _state = State_enum.State_Falling;

            }
            if (state is State_Hit)
            {

                _state = State_enum.State_Hit;
            }
            if (state is State_Jumped)
            {

                _state = State_enum.State_Jumped;
            }
            if (state is State_Jumping)
            {

                _state = State_enum.State_Jumping;
            }
            if (state is State_Landing)
            {

                _state = State_enum.State_Landing;
            }
            if (state is State_Running)
            {

                _state = State_enum.State_Running;
            }
            if (state is State_RunningAndJumping)
            {

                _state = State_enum.State_RunJumping;
            }

            if (state is State_Spawning)
            {
                _state = State_enum.State_Spawning;
            }

            if (state is State_Standing)
            {
                _state = State_enum.State_Standing;

            }

            State = state;
        }

        public IState GetState_Attack_A()
        {

            return State_Attacking;
        }


        public IState GetCurrentState()
        {

            return State;
        }

        internal IState GetLandingState()
        {
            return State_Landing;
        }

        internal IState GetFallingState()
        {
            return State_Falling;
        }

        internal IState GetRunningState()
        {
            return State_Running;
        }

        public void Update()
        {

             

            if (CurrentState != _state)
            {
                
                PreviousState = CurrentState;
            }
            CurrentState = _state;


           


        }
        public void _update()
        {
            State.UpdateState();
        }

        

    }
}
