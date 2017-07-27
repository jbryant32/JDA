using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Interfaces
{
    public interface ICamera
    {
        string Name { get; }
         
        void UpdateState();
    }
}
