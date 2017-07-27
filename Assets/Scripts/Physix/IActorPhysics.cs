using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Physix;
using UnityEngine;

namespace Assets.Physix
{
    public interface IActorPhysics
    {

        
        bool ActorOnGround();
        bool ActorFalling();
        bool Jumping();
        void DoJump( );
         
        void DoRunning();
      
        void MoveAfterJump();
       
        void WalkedOffPlatform(Vector2 Positsion);
        void DoHit();
    }
}
