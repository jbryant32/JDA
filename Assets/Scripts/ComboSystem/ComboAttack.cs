using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.ComboSystem
{
    internal abstract class ComboAttack: MonoBehaviour
    {
        ComboController Context;
        bool ComboContinue;
        private bool CanHit;
        public  abstract string scene { get; set; }
        public abstract ICombo nextAttack { get; set; }

        private void Awake()
        {

        }
        //TODO create combo inheritacne with overload methods

        public ComboAttack(ComboController context)
        {
            this.Context = context;
            CanHit = true;
        }
        void DoAttack()
        {
            HandleEvents.OnAnimationEnd += HandleEvents_OnAnimationEnd;
            Context.animationcontroller_.Player(scene, false);

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
                    Context.SetState(Context.GetState(ComboController.StateToSet.comboEnd)); 
                }
                else
                {
                    SetNextAttack();
                }
            }
        }

        void SetNextAttack()//TODO create enum4444
        {
            if (nextAttack is State_AttackB)
            {
                Context.SetState(Context.GetState(ComboController.StateToSet.attackB));
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

       
    }
}
