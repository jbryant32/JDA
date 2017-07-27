
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Interfaces;
using UnityEngine; 
namespace Assets.Scripts.ComboSystem
{
    public class State_AttackB:MonoBehaviour, ICombo
    {
        ComboController Context;
        bool ComboContinue;

        public State_AttackB(ComboController context)
        {
            this.Context = context;
        }

      
        void DoAttack()
        {
            HandleEvents.OnAnimationEnd += HandleEvents_OnAnimationEnd;
            Context.animationcontroller_.Player("Attack_B", false);
           

            if (Context.animationcontroller_.Current_Frame() == 2)
            {
                Context.Attack_B_listner.CheckHit();
                if (Context.Hitinterval < Context.MaxhitInterval)
                {
                     
                    Context.Hitinterval = 1;
                }
                
            }

            

        }

        private void HandleEvents_OnAnimationEnd(string sender)
        {

            if (sender== "Attack_B")
            {
                HandleEvents.OnAnimationEnd -= HandleEvents_OnAnimationEnd;

                if (ComboContinue == false)
                {
                    Context.SetState(Context.GetState(ComboController.StateToSet.comboEnd));//TODO create combo links on hit 
                }
                else
                {
                    Context.SetState(Context.GetState(ComboController.StateToSet.comboEnd));//TODO create combo links on hit 
                }//TODO continue combo here  replace state.comboend
            }
        }

        
        public void OnHit()
        {
            if (Context.Attack_B_listner.HitEnemy == true)
            {
                EffectController.createEffect(EffectController.EffectType.SlashEffect, Context.Attack_B_listner.Collider.transform.position);
                EffectController.sethitstop = true;
                Context.Hitinterval = 1;
                Context.Attack_B_listner.HitEnemy = false;
                ComboContinue = true;
                //TODO continue to attack_b


            }
        }
        public void Reset()
        {
            Context.Hitinterval = 0;
            Context.Attack_B_listner.HitEnemy = false;
        }

        public void UpdateState()
        {

            AssignState();
            DoAttack();
            OnHit();
        }

        public void AssignState()
        {
            Context._state = ComboController.StateToSet.attackB;
        }
    }
}