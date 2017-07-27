using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;
namespace Assets
{
    public class HandleEvents
    {
        public delegate void DelegateAnimeEnd(string sender);
        public delegate void DelegeateComboEnd( object sender);
        internal static event DelegeateComboEnd OnComboEnd;
        internal static event DelegateAnimeEnd OnAnimationEnd;

        public static void OnComboEnded(object sender)
        {
            if (OnComboEnd != null)
            {
                OnComboEnd(sender);
            }
        }
        public static void OnAnimationEnded(string sender)
        {
            if(OnAnimationEnd!=null)
            OnAnimationEnd(sender);
        }
    }
}
