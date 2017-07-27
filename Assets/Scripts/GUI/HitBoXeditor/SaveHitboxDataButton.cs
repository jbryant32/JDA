using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
namespace Assets.Scripts.GUI.HitBoXeditor
{
    public class SaveHitboxDataButton:MonoBehaviour
    {

        private void Awake()
        {
        
        }

        public void Save()
        {
            
            
            string path = string.Format("{0}\\PlayerHitboxdata.json", Application.streamingAssetsPath);

            if (File.Exists(path))
            {
                File.Create(path);

            }
            
            GameObject boxes = GameObject.Find("HitBoxes");
            BoxCollider2D[] col = boxes.GetComponentsInChildren<BoxCollider2D>();
           
            foreach (BoxCollider2D c in col)
            {
                string file = string.Format("{0}\\{1}.json", Application.streamingAssetsPath, c.name);
                HitboxData data = new HitboxData(c.name,c.isTrigger,c.transform.localPosition,c.size);
                if (!File.Exists(file))
                {
                    File.Create(file);
                }
                else
                {
                    string json = JsonUtility.ToJson(data, true);
                    File.WriteAllText(string.Format("{0}\\{1}.json", Application.streamingAssetsPath, c.name), json);

                }
          
              
            }
           
            

        }

        public void WritetoFile()
        {

            while (true)
            {

            }
        }
    }
}
