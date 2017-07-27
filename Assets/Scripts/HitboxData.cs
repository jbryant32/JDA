using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts
{
    [Serializable]
    public class HitboxData:MonoBehaviour
    {
        public string name;
        public bool IsTrgger;
        public Vector3 position;
        public Vector2 Size;

        public HitboxData(string Name,bool istrigger,Vector3 Position,Vector2 size)
        {
            this.name = Name;
            this.IsTrgger = istrigger;
            this.position = Position;
            this.Size = size;
        }

    }
}
