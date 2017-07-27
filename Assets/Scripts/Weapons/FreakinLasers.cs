using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Weapons
{
    public class FreakinLasers : MonoBehaviour
    {
        public LineRenderer linerender;
        public Transform pos;
        private void Awake()
        {
           
            
            pos = GameObject.Find("MurderBot").transform;
            linerender = this.GetComponent<LineRenderer>();
        }

        public void FireLaser()
        {
           
            

        }
        private void Update()
        {

            // Debug.DrawRay(pos.position, transform.TransformDirection(pos.position), Color.green);
           

        }
    }
}
