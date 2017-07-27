using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interfaces;
namespace Assets
{
    public class Effect:MonoBehaviour, IEffect
    {

        SpriteRenderer spriterenderer;
        public Sprite[] frames;
        internal bool done;
        private bool Done;
        private int CurrentFrame;
        private int TotalFrames;
        private int Fps;
        private int Timer;
        private float SetRandom;
        private float GetRandom;

        private void Awake()
        {
            spriterenderer = GetComponent<SpriteRenderer>();
            spriterenderer.sortingLayerName = "PlayerSortingLayer";
            spriterenderer.sortingOrder = 10;
            
        }

        private void FixedUpdate()
        {
            spriterenderer.sprite =  frames[CurrentFrame];
            GetRandom = UnityEngine.Random.Range(0, 90);
            TotalFrames =frames.Length;
            
            spriterenderer.transform.localRotation = Quaternion.AngleAxis( SetRandom, Vector3.forward);

            Timer++;
            if (Timer > 1.0f)
            {
                Timer = 0;

                if (CurrentFrame < TotalFrames - 1)
                { CurrentFrame++; }


                if (CurrentFrame == TotalFrames-1)
                {
                    SetRandom = GetRandom;
                    this.gameObject.SetActive(false);
                    CurrentFrame = 0;
                    Done = true;
                }
                else { Done = false; }

            }
        }

    }
}
