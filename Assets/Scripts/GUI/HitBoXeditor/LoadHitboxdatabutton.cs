using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
namespace Assets.Scripts.GUI.HitBoXeditor
{
    public class LoadHitboxdatabutton:MonoBehaviour
    {

        public void Load()
        {

            BoxCollider2D[] hitboxes = GameObject.Find("HitBoxes").GetComponentsInChildren<BoxCollider2D>();
         
            foreach (BoxCollider2D c in hitboxes)
            {
                HitboxData h = new HitboxData(null, false, Vector3.zero, Vector2.zero);
                string file = string.Format("{0}\\{1}.json", Application.streamingAssetsPath, c.name);
                string json = ReadFile(file);
                JsonUtility.FromJsonOverwrite(json, h);
                c.transform.localPosition = h.position;
                c.name = h.name;
                c.isTrigger = h.IsTrgger;
                c.size = h.Size;
                
            }
           
        }




        string ReadFile(string path)
        {
            string json;
            while (true)
            {

                 

                    try
                    {
                          json = File.ReadAllText(path);
                          
                          return json;
                         
                    }
                    catch (IOException ex)
                    {

                        Debug.Log(ex.Message);
                    }

              

                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
