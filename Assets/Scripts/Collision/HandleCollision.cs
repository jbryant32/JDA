using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Physix;
namespace Assets.Collision
{
    public class HandleCollision:MonoBehaviour
    {
        static List<Collider2D> ActiveObjectsArray;
        public bool ObjectGotHit;
        public bool OnGround;
        public bool HitHead;
        public Collider2D Body;
        public PlayerPhysics playeronephysics;
        string myname;
        //list of active obects hitboxes on screen
        private void Awake()
        {
            
            myname = this.name;
            if (myname == "Body")
            {
                Body = GetComponent<Collider2D>();
            }
        }
        private void Start()
        {
            playeronephysics = GameManager.playerone.GetComponent<PlayerPhysics>();
        }
      

        private void OnCollisionEnter2D(Collision2D collisioninfo)
        {
            if (collisioninfo.collider.name == "Bullet")
            {
                if (this.transform.parent == GameManager.playerone.transform)
                {
                    if (this.name == "Body")
                    {
                        GameManager.playerone.Health -= 5;
                        SideHit(collisioninfo);
                       
                        if (GameManager.PlayerOneHit == false && GameManager.PlayerOneCanBeHit == true)
                        {
                            GameManager.PlayerOneHit = true;
                        }

                    }
                }
            }
            if (collisioninfo.collider.GetType() == typeof(EdgeCollider2D))
            {
                if (myname == "Foot")
                {
                    OnGround = true;
                }
            }
            if (collisioninfo.collider.GetType() == typeof(PolygonCollider2D))
            {
                if (myname == "Foot")
                {
                    OnGround = true;
                }
            }

        }

        private void OnCollisionExit2D(Collision2D collisioninfo)
        {
             
            if (collisioninfo.collider.GetType() == typeof(EdgeCollider2D))//floor
            {
                if (myname == "Foot")
                {
                    OnGround = false;
                }
            }
            if (collisioninfo.collider.GetType() == typeof(PolygonCollider2D))//floor
            {
                if (myname == "Foot")
                {
                    OnGround = false;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collisioninfo)
        {
            if (collisioninfo.name == "Bullet")
            {
                if (this.transform.parent == GameManager.playerone.transform)
                {
                    if (this.name == "Body")
                    {
                        if (GameManager.PlayerOneHit == false && GameManager.PlayerOneCanBeHit == true)
                        {
                            GameManager.PlayerOneHit = true;
                        }
                         
                    }
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {

        }
        public void SideHit(Collision2D collision)
        {
            Collider2D collided = GetComponent<Collider2D>();
            Vector2 center = collided.bounds.center;
            Vector2 contactpoint = collision.contacts[0].point;
            if (contactpoint.x > center.x)
            {
                playeronephysics.HitRight = true;
                playeronephysics.HitLeft = false;
            }

            if (contactpoint.x < center.x)
            {
                playeronephysics.HitRight = false;
                playeronephysics.HitLeft = true;
            }
        }
        private void Update()
        {
           
        }
    }
}
