using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Weapons
{
    public class FireShot : MonoBehaviour
    {
        Vector3 Target;
        Rigidbody2D _rigidbody;
        Vector3 _velcoity;
        GameObject shooter;
        private float Speed;

        private void Awake()
        {

            _rigidbody = GetComponent<Rigidbody2D>();
            
        }
        public void Initiliaze(Vector3 location,GameObject Shooter,float speed)
        {

            Vector2 target = GameManager.playerone.transform.position - Shooter.transform.position;

            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

            Quaternion b = Quaternion.AngleAxis(angle, Vector3.forward);
            this.transform.rotation = b;

            this.gameObject.SetActive(true);
            this.transform.position = location;
            this.transform.localRotation = b;
            this.shooter = Shooter;
            Speed = speed;
        }

        
        
        private void FixedUpdate()
        {
             
            Speed =20;
            Speed = Mathf.Clamp(Speed, 0, 20);
           
            transform.Translate(Vector3.right * Speed);
            //_rigidbody.velocity=this.transform.TransformDirection(Vector3.right*Speed);
            
           
        }
    }
}
