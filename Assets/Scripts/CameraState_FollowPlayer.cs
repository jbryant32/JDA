using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Interfaces;
namespace Assets
{
    public class CameraState_FollowPlayer:ICamera
    {
        CameraController context;

        public string Name
        {
            get
            {
                return "follow player";
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CameraState_FollowPlayer(CameraController _cameracontroller)
        {
            context = _cameracontroller;
        }

        void logic()
        {

            Vector2 pos = context.Maincamera.WorldToScreenPoint(context.player.transform.position);
            Vector2 Playerpos = context.player.transform.position;
            Vector2 camerapos = context.Maincamera.transform.position;
           
            int diff = (int)(Playerpos.y - camerapos.y);

            if (diff > 2)
            {
                 
                Vector3 cameranewpos = Vector2.Lerp(camerapos, Playerpos, 0.05f);
                cameranewpos.z = -50;
                float pos_y = cameranewpos.y;
                context.Maincamera.transform.position = new Vector3(camerapos.x, pos_y, -50);
            }
        }

        public void UpdateState()
        {
            logic();
        }
    }
}
