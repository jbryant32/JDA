using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Interfaces
{
    public interface ICollidable
    {
        GameObject CollidedObject( );
        GameObject Floor(GameObject obj);
        GameObject Cieling(GameObject obj);
        void HeadCollider2D(out Collider2D collder2d);
        void FootCollider2D(out Collider2D collder2d);
        Collider2D EdgeCollider();
       
        int DistanaceToCieling();
    }
}
