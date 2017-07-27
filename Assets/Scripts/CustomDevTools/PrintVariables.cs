using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace CustomDevTools
{
    public class PrintVariables:MonoBehaviour
    {

        Dictionary<string, string> variables;
        public static void printvar(int index, string varToPrint)
        {

            Text[] vars = GameObject.FindObjectsOfType<Text>();
            vars[index].text = varToPrint;


        }


    }

}
