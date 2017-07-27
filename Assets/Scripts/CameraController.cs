using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Interfaces;
using Assets.ActiveGameObjects.PlayerOne;
namespace Assets
{
    public class CameraController:MonoBehaviour
    {
        internal Camera Maincamera;
        internal float CameraBoundsLeft;
        internal float CameraBoundsRight;
        internal float CameraBoundsTop;
        internal float CameraBoundsBottom;
        internal float LeftEnd;
        internal float RightEnd;
        internal float TopEnd;
        internal float BottomEnd;
        internal  PlayerOne  player;
        ICamera State;
        ICamera CurrentState;
        ICamera PreviousState;
        CameraState_FollowPlayer statefollowplayer;
        CameraState_MoveToPlayer statemovetoplayer;
        CameraState_Stopped statecamerastopped;
        CameraState_Shake statecamerashaking;

        private void Awake()
        {
            Maincamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            
            BottomEnd = GameObject.Find("BottomEnd").transform.position.y;

        }

        private void Start()
        {
            player = GameManager.playerone;
            statemovetoplayer = new CameraState_MoveToPlayer(this);
            statefollowplayer = new CameraState_FollowPlayer(this);
            statecamerastopped = new CameraState_Stopped(this);
            statecamerashaking = new CameraState_Shake(this);
            State = statemovetoplayer;
        }
        void CheckBounds()
        {

        }

        
        public ICamera GetState_statemovetoplayer()
        {
            

            return statemovetoplayer;

        }
        public ICamera GetState_statefollowplayer()
        {


            return statefollowplayer;

        }
        public ICamera GetState_statecamerastopped()
        {


            return statecamerastopped;

        }
        public ICamera GetState_statecamerashaking()
        {


            return statecamerashaking;

        }
        public void SetState(ICamera _state)
        {
            State = _state;
        }
        private void Update()
        {
            


            CameraBoundsBottom = Maincamera.transform.position.y - Maincamera.pixelHeight / 2;
            CameraBoundsTop = Maincamera.transform.position.y + Maincamera.pixelHeight / 2;
            CameraBoundsRight = Maincamera.transform.position.x - Maincamera.pixelWidth / 2;
            CameraBoundsLeft = Maincamera.transform.position.x + Maincamera.pixelWidth / 2;
             Vector3 pos = Maincamera.WorldToScreenPoint(player.transform.position);
        }

        private void FixedUpdate()
        {

            State.UpdateState();
        }

        private void LateUpdate()
        {
            
        }

    }
}
