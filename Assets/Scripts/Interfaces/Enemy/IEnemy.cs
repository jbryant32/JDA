using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces.Enemy
{
   //TODO create enemy list
    interface IEnemy
    {
        bool isAlive { get; set; }
        int Health { get; set;}
        void UpdateEnemy();
    }
}
