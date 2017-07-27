using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Interfaces;
namespace Assets
{
     
    public class CameraState_Stopped:ICamera
    {


        CameraController context;

        public string Name
        {
            get
            {
                return "stop";
            }
        }

        public CameraState_Stopped(CameraController cc)
        {
            context = cc;
        }
        float lerp;
        void logic()
        {
            //TODO player above center
             
            
            if (context.player.transform.position.y > context.Maincamera.transform.position.y)
            {
                lerp += 0.003f;
                Vector3 campos = context.Maincamera.transform.position;
                campos.z = -50;
                Vector3 newpos = new Vector3(campos.x, context.player.transform.position.y, -50);
               
                context.Maincamera.transform.position = Vector3.Lerp(campos, newpos, lerp);
                
                   
                if (context.CameraBoundsBottom > context.BottomEnd)
                {
                    lerp=0;
                    context.SetState(context.GetState_statemovetoplayer());

                }

            }
        }
        public void UpdateState()
        {
            logic();
        }
    }
}
