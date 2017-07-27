using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilitys;

namespace Assets.Scripts.ComboSystem
{
    public class ComboController:MonoBehaviour
    {
        internal Collider2D Collider_Attack;
        internal int MaxhitInterval;
        internal int Hitinterval;
       
        ICombo state_waitingroom;
        ICombo state_comboA;
        ICombo state_comboB;
        ICombo state_comboEnd;
        ICombo State;
        internal IattackListner Attack_A_listner;
        internal IattackListner Attack_B_listner;
        internal IattackListner Attack_C_listner;
        public StateToSet _state;
        StateToSet CurrentState;
        StateToSet PreviousState;
        internal IAnimationController animationcontroller_;
        public enum StateToSet
        {
            attackA,
            attackB,
            waitroom,
            comboEnd
        }
        public StateToSet statesetter; 

        private void Awake()
        {
            animationcontroller_ = GameObject.Find("Player").GetComponent<AnimationController>();
            Attack_A_listner = GameObject.Find("attack_A_box").GetComponent<Attack_Listner>();
            Attack_B_listner = GameObject.Find("attack_b_box").GetComponent<Attack_Listner>();
            Attack_C_listner = GameObject.Find("attack_c_box").GetComponent<Attack_Listner>();
            state_comboA = new State_AttackA(this);
            state_comboB = new State_AttackB(this);
            state_comboEnd = new State_ComboDone(this);
            state_waitingroom = new State_ComboReady(this);
            Collider_Attack =  GetComponent<Collider2D>();
            State = state_waitingroom;
            _state = StateToSet.waitroom;
            CurrentState = _state;
            Hitinterval = 0;
            MaxhitInterval = 1;
        }

        public void SetState(ICombo state)
        {
            State = state;
        }

        public ICombo GetState(StateToSet stateset)
        {

            if (stateset == StateToSet.attackA)
            {
                _state =   stateset;
                return state_comboA;
            }
            if (stateset == StateToSet.attackB)
            {
                _state = stateset;
                return state_comboB;
            }
            if (stateset == StateToSet.waitroom)
            {
                _state = stateset;
                return state_waitingroom;
            }
            if (stateset == StateToSet.comboEnd)
            {
                _state = stateset;
                return state_comboEnd ;
            }
            _state  = StateToSet.waitroom;
            return state_waitingroom;
        }

      
        public void _update()
        {
             

            if (CurrentState != _state)
            {
                PreviousState = CurrentState;
                State.Reset();
            }
            CurrentState = _state;

            State.UpdateState();
        }
    }
}
