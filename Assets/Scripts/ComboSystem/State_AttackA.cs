
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using UnityEngine; 
namespace Assets.Scripts.ComboSystem
{
    public class State_AttackA : MonoBehaviour, ICombo
    {
        ComboController Context;
        bool ComboContinue;
        private bool CanHit;

        private void Awake()
        {

        }
        //TODO create combo inheritacne with overload methods

        public State_AttackA(ComboController context)
        {
            this.Context = context;
            CanHit = true;
        }
        void DoAttack()
        {
            HandleEvents.OnAnimationEnd += HandleEvents_OnAnimationEnd;
            Context.animationcontroller_.Player("Attack_A",false);

            Context.Attack_A_listner.CheckHit();
            if (Context.Attack_A_listner.HitEnemy == true)
            {
                if (Context.animationcontroller_.Current_Frame() == 1 && CanHit)
                {
                  
                    OnHit();
                    CanHit = false;

                }
            }
            

        }

        private void HandleEvents_OnAnimationEnd(string sender)
        {
            
            if (sender == "Attack_A")
            {
                HandleEvents.OnAnimationEnd -= HandleEvents_OnAnimationEnd;

                if (ComboContinue == false)
                {
                  Context.SetState(Context.GetState(ComboController.StateToSet.comboEnd));//TODO create combo links on hit 
                }
                else
                {
                    Context.SetState(Context.GetState(ComboController.StateToSet.attackB));
                }
            }
        }

        public void OnHit()
        {
           
                EffectController.createEffect(EffectController.EffectType.SlashEffect, Context.Attack_A_listner.Collider.transform.position);
                EffectController.sethitstop = true;
                ComboContinue = true;
        }

        public void Reset()
        {
            CanHit = true;
            ComboContinue = false;
            Context.Attack_A_listner.HitEnemy = false;
        }

        public void UpdateState()
        {
             
            AssignState();
            DoAttack();
        }

        public void AssignState()
        {
            Context._state = ComboController.StateToSet.attackA;
        }

        public void Ontrigger(Collider2D collision)
        {
            throw new NotImplementedException();
        }
    }
}
