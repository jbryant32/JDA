using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.ActiveGameObjects.Enemeys.FlyingBot
{
    public class FlyingBotPhysics:MonoBehaviour
    {
        
        

        PlayerOne.PlayerOne Player;
        private void Awake()
        {
            Player = GameManager.playerone;
        }
         

        public static void RotateTo(GameObject obja,Vector3 Target)
        {
           
            Vector3 vectorToTarget = Target  - obja.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            obja.transform.rotation =  Quaternion.Slerp(obja.transform.rotation, q,0.5f);


        }
         
        public static void RotateTo(GameObject obja, Vector3 Target ,   float lerpt)
        {
            lerpt += 0.002f;
            
            Vector3 vectorToTarget = Target - obja.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            obja.transform.rotation = Quaternion.Slerp(obja.transform.rotation, q, lerpt);
           

        }


        public static Vector2 Movetoplayer(Vector2 startpos,Vector2 endpos)
        {
            Vector2 pos = startpos - endpos;

            float dir_y = Mathf.Sign(startpos.y - endpos.y);

            float dir_x = Mathf.Sign(startpos.x - endpos.x);

            return pos;
        }
    }
}
