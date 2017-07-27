using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Physix;
using Assets.ActiveGameObjects.PlayerOne;
using Assets.ActiveGameObjects.Enemeys.FlyingBot;
using Assets.Scripts.ComboSystem;

namespace  Assets
{
    public class GameManager:MonoBehaviour
    {
       
        public static bool PlayerOneHit;
        public static bool PlayerOneCanBeHit;
        public static PlayerOne playerone;
        StateController statecontroller_playerone;
        ComboController statecontroller_comboplayerone;
        StateController_Flyingbot statecontroller_flyingbot;

        public enum GameDifficulty { hard ,Normal, easy  }
        public GameDifficulty gamedifficulty;

        
        private void Awake()
        {
            Application.targetFrameRate = 50;
            QualitySettings.vSyncCount = 0;
            playerone = GameObject.Find("Player").GetComponent<PlayerOne>();
            statecontroller_comboplayerone = GameObject.Find("HitBoxes").GetComponent<ComboController>();
            statecontroller_playerone = playerone.GetComponent<StateController>();
          //statecontroller_flyingbot = GameObject.Find("MurderBot").GetComponent<StateController_Flyingbot>();
        }

        private void Start()
        {
          
          
            
        }
        private void FixedUpdate()
        {
            if (!EffectController.HitStop())
            {

               
            }
        }

        private void Update()
        {
            if (!EffectController.HitStop())
            {

                statecontroller_playerone._update();
                statecontroller_comboplayerone._update();
                
            }

        }

    }
}
