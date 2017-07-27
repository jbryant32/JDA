using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public  interface ICombo
    {
        void AssignState();
        void UpdateState();
        void Reset();
         
    }
}
