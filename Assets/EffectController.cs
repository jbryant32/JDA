using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace Assets
{
    
    public class EffectController:MonoBehaviour
    {

        public static bool sethitstop;
        public static bool setscreenflash;
        private static bool hitstopactive;
        public static float hitstoptimer;
        RawImage screenflash;
        public static Dictionary<EffectType,List<GameObject>> effects;
        public Dictionary<string,List<Sprite>> AnimationFrames;
  
        public  enum EffectType
        {
            SlashEffect,
           HitEffect,
           Flash

        }
       
        //TODO clean up dependences in effect
        private void Awake()
        {
            effects = new Dictionary<EffectType,List<GameObject>>();
            effects.Add(EffectType.SlashEffect, new List<GameObject>());
            effects.Add(EffectType.HitEffect, new List<GameObject>());
            screenflash = GameObject.Find("Screenflash").GetComponent<RawImage>();
            for (int i = 0; i < 4; i++)
            {
                GameObject g = new GameObject("Slash Effect");
                g.SetActive(false);
                g.AddComponent<Effect>();
                g.AddComponent<SpriteRenderer>();
                g.GetComponent<Effect>().frames = LoadFrames("StandardSlash");
                effects[EffectType.SlashEffect].Add(g);

            }


             
            
        }

        public Sprite[] LoadFrames(string scenetoload)
        {

            return Resources.LoadAll<Sprite>(string.Format("Items/Effects/{0}", scenetoload));
        }

        public static void createEffect(EffectType _effect ,Vector3 pos)
        {
           
            if (_effect == EffectType.SlashEffect)
            {
                effects[_effect][0].transform.position = pos;
                effects[_effect][0].layer = 10;
                effects[_effect][0].SetActive(true);
                /*
                for (int i = 0; i < effects[_effect].Count - 1; i++)
                {
                    if (effects[_effect][i].activeSelf == false)
                    {
                        effects[_effect][i].transform.position = pos;
                        effects[_effect][i].layer = 10;
                        effects[_effect][i].SetActive(true);
                    }
                }
                */
            }
          
            

        }
        public static bool HitStop()
        {
            if (sethitstop == true )
            {
                hitstoptimer+=1*Time.deltaTime;
                if (hitstoptimer < 0.45f)
                { return true;  }
                if (hitstoptimer >0.45f)
                {
                    hitstoptimer = 0;
                    sethitstop = false;
                    return false;
                }



            }
          
             return false; 
        }
        //TODO screen flash
        public   void FlashScreen()
        {
            if (setscreenflash)
            {
                if (!screenflash.enabled)
                {

                }
            }
        }

        private void FixedUpdate()
        {
         
        }


    }
}
