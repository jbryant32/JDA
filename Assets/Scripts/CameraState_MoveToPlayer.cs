using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Interfaces;
namespace Assets
{
    public class CameraState_MoveToPlayer : ICamera
    {
        CameraController context;
        public string Name
        {
            get
            {
                return "move to player";
            }
        }

        public CameraState_MoveToPlayer(CameraController cc)
        {
            context = cc;
        }

       
        void logic()
        {
            
            Vector2 Playerpos = context.player.transform.position;
            Vector2 camerapos = context.Maincamera.transform.position;
            
            int diff = (int)(Playerpos.y - camerapos.y);
            int _diff = (int)(context.BottomEnd - context.CameraBoundsBottom);
            if (diff < 2)
            {  }
            if (context.CameraBoundsBottom > context.BottomEnd)
            {

                Vector3 cameranewpos = Vector2.Lerp(camerapos, Playerpos, 0.05f);
                cameranewpos.z = -50;
                context.Maincamera.transform.position = new Vector3(camerapos.x, cameranewpos.y, -50);

            }
            else
            {
                   context.SetState(context.GetState_statecamerastopped());
            }
               
        }

        void ICamera.UpdateState()
        {
            logic();

        }
    }
}
