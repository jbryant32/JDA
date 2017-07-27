using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts.GUI.HudGui
{
    public class InGameGui:MonoBehaviour
    {
        RawImage EnergySlider;
        private void Awake()
        {
            
            EnergySlider =GameObject.Find("Energyslider").GetComponent<RawImage>();
        }
        private void Update()
        {
            float scaler = (1f / GameManager.playerone.MaxHealth);
            EnergySlider.rectTransform.localScale = new Vector3( scaler*GameManager.playerone.Health,1,1);
            float ratio = scaler * 100;//percentage
        }
    }
}
