using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityScript;
using Assets.Interfaces.Enemy;
namespace Assets.ActiveGameObjects.Enemeys.FlyingBot.States
{
    public class State_Moving:MonoBehaviour,IEnemyState
    {

        PlayerOne.PlayerOne Player;
        StateController_Flyingbot context;
        GameObject me;
        Vector2[] MoveToPoint = new Vector2[4];
        int currentPoint;

        private void Awake()
        {
             
             
            me = GameObject.Find("MurderBot");
            currentPoint = UnityEngine.Random.Range(0, 3);
            context = this.GetComponent<StateController_Flyingbot>();
            

        }
        private void Start()
        {
            Player = GameManager.playerone;
            GetVecotrPoints();
        }

        float lerpT;
        public void Moving()
        {

            lerpT += 0.01f;
           // FlyingBotPhysics.RotateTo(me, MoveToPoint[currentPoint]);
            me.transform.position = Vector2.Lerp(me.transform.position,MoveToPoint[currentPoint], lerpT);
             
            
            if (lerpT>=1)
            {
                 

                 lerpT = 0;
                 currentPoint++;
                 currentPoint %= 4;//array index is only 4 0-3
                 context.SetState(context.GetState_Attacking());
                
            }
             
        }
        /// <summary>
        /// grab our next movement points
        /// </summary>
        public void GetVecotrPoints()
        {
            MoveToPoint[0] = new Vector2(Player.transform.position.x, Player.transform.position.y+200);
            MoveToPoint[1] = new Vector2(Player.transform.position.x+200, Player.transform.position.y);
            MoveToPoint[2] = new Vector2(Player.transform.position.x, Player.transform.position.y-200);
            MoveToPoint[3] = new Vector2(Player.transform.position.x-200, Player.transform.position.y);
        }

        public void UpdateState()
        {
          
            Moving();
        }

        public void ShotFired()
        {
            throw new NotImplementedException();
        }
    }
}
