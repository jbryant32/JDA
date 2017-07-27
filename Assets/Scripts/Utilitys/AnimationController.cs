using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interfaces;
using Assets.Physix;

namespace Assets.Scripts.Utilitys
{
   
    public class AnimationController :MonoBehaviour, IAnimationController
    {

        //TODO use JSON file to get dictionary scene depending on object
        public Dictionary<string, Sprite[]> _DictionaryScenes = new Dictionary<string, Sprite[]>();
        SpriteRenderer _spriterender;
        PlayerPhysics playerphyics;
        private string CurrentScene;
        private int CurrentFrame;
        private float Frametimer;
        private string PreviousScene;
        private int TotalFrames;


        enum PlayerScenes
        {
            Running,
            Jump,
            Attack_A
                , Attack_B
                , Standing
                , Hit
        }

        enum MuderBot
        {


        }
        //TODO add enum call for animation end
        private void Awake()
        {
            _spriterender = GetComponent<SpriteRenderer>();
            playerphyics = GetComponent<PlayerPhysics>();
             
            _DictionaryScenes.Add("Running", Resources.LoadAll<Sprite>("Actors/Player/Animations/Running"));
            _DictionaryScenes.Add("Jump", Resources.LoadAll<Sprite>("Actors/Player/Animations/Jump"));
            _DictionaryScenes.Add("Jumping", Resources.LoadAll<Sprite>("Actors/Player/Animations/Jumping"));
            _DictionaryScenes.Add("Attack_A", Resources.LoadAll<Sprite>("Actors/Player/Animations/Attack_A"));
            _DictionaryScenes.Add("Attack_B", Resources.LoadAll<Sprite>("Actors/Player/Animations/Attack_B"));
            _DictionaryScenes.Add("Standing", Resources.LoadAll<Sprite>("Actors/Player/Animations/Standing"));
            _DictionaryScenes.Add("Hit", Resources.LoadAll<Sprite>("Actors/Player/Animations/Hit"));
            _DictionaryScenes.Add("Falling", Resources.LoadAll<Sprite>("Actors/Player/Animations/Falling"));
          
         //   _DictionaryScenes = GetResources.LoadActorAnimation(this.name);
        }


        public void Player(string Scene, bool Loop)
        {
             
            float I = 24 * Time.deltaTime;
            Frametimer += I;
            if (playerphyics.Direction.x == -1)
            {
                _spriterender.flipX = true;
            }
            else
            { _spriterender.flipX = false; }
            if (CurrentScene != Scene)
            {
                PreviousScene = CurrentScene;
                CurrentFrame = 0;
            }

            CurrentScene = Scene;
            TotalFrames = _DictionaryScenes[CurrentScene].Count();

            if (Frametimer >= 1)
            {
                CurrentFrame++;
                Frametimer = 0;
            }

            _spriterender.sprite = _DictionaryScenes[CurrentScene][CurrentFrame];

           
            if (CurrentFrame == TotalFrames-1)
            {
               HandleEvents.OnAnimationEnded(CurrentScene);
               CurrentFrame = 0;
               
            }
        }
        public void EndAnimation()
        {


        }

        public int Current_Frame()
        {
            return CurrentFrame;
        }
    }
}
