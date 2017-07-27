using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces
{
    interface IAnimationController
    {
        void Player(string Scene, bool Loop);
        int Current_Frame();
    }
}
