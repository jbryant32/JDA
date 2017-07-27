using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace Assets
{
    public class HandelGameCamera:MonoBehaviour
    {
        Camera camera;
        Assets.ActiveGameObjects.PlayerOne.PlayerOne player;
        public Vector3 ViewPortToWorldPos;
        public Vector3 camerapos;
        public Vector2 Margin;
        public RectTransform CameraBounds;
       

        void Start()
        {

            Display.displays[0].Activate();
            
        }
        void Awake()
        {
             

            player = GameManager.playerone;
            camera = GameObject.Find("Main Camera").GetComponent<Camera>();
            Margin.x = 200f;
            Margin.y = 200f;
        }
        
        void smartcam()
        {
             
        }
        float lerpmove;
        //TODO stop camera at y bound edge collider
        void FixedUpdate()
        {
           
           
            //TODO STOP CAMERA AT BOUNDS RECTANGLE IF BOTTOM OF CAMERA PASSES TOP PF RECTANGLE
            //CREATE CAMERA MOVEMENT STATES
           
            
        }
    }
}
