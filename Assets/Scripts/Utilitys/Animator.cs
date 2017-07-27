using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utilitys
{
   public  class Animator:MonoBehaviour
    {
        public bool loop;
        public string path;
       
        public Sprite[] animations ;
        SpriteRenderer _spriterenderer;
        public int CurrentFrame;
        public int FrameSpeed;
        int TotalFrames;
        float Timer;
        string CurrentScene;
        string PreviousScene;
        enum scene { }

        private void Awake()
        {
            _spriterenderer = GetComponent<SpriteRenderer>();
        }
        public void LoadFrames()
        {
            animations = Resources.LoadAll<Sprite>(string.Format("/{0}", this.path));

        }

        private void FixedUpdate()
        {
            TotalFrames = animations.Length;

            _spriterenderer.sprite = animations[CurrentFrame];

            Timer++;
            if (Timer > FrameSpeed)
            {
                Timer = 0;

                if (CurrentFrame < TotalFrames  )
                { CurrentFrame++; }


                if (CurrentFrame == TotalFrames )
                {
                    
                     
                    CurrentFrame = 0;
                   
                }
               

            }
        }

    }
}
