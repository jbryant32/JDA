using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Interfaces;
namespace Assets
{
    class CameraState_Shake:ICamera
    {

        private CameraController cameraController;
        public string Name
        {
            get
            {
                return "shake";
            }
        }
        public CameraState_Shake(CameraController cameraController)
        {
            this.cameraController = cameraController;
        }

         

        public void UpdateState()
        {
             
        }
    }
}
