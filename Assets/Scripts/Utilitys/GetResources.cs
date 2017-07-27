using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
namespace Assets.Scripts.Utilitys
{
    class GetResources:MonoBehaviour
    {



        public static Dictionary<string,Sprite[]> LoadActorAnimation(string actor_name)
        {
            Dictionary<string, Sprite[]> temp = new Dictionary<string, Sprite[]>();
            var path = Application.streamingAssetsPath;
            string[] scenes =  Directory.GetDirectories(string.Format("{0}//Animations//{1}", path, actor_name));
            foreach (string s in scenes)
            {
               var scene_name = Path.GetFileNameWithoutExtension(s);
                var loadpath = string.Format("{0}//Animations//{1}//{2}", path, actor_name, scene_name);
               Sprite[] frames =  Resources.LoadAll<Sprite>(loadpath);
               
               temp.Add(scene_name, frames);
              
            }
            
            return temp;
        }

    }
}
