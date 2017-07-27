using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.Interfaces
{
    interface IattackListner
    {

        bool HitEnemy { get; set; }
        Collider2D Collider { get; set; }
        bool CheckHit();
    }
}
