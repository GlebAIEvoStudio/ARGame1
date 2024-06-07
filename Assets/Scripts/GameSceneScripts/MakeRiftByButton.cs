using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Scripts
{
    public class MakeRiftByButton : MonoBehaviour
    {
        public TextMeshProUGUI Button_Text;
        public TextMeshProUGUI Debug_Text;
        public int Seconds_For_Timer = 3;

        public static Action Time_Ends;


        public void MakeLight()
        {
            StartCoroutine(time());
        }

        IEnumerator time()
        {
            while (true)
            {
                Button_Text.text = Seconds_For_Timer.ToString();
                Seconds_For_Timer--;
                if (Seconds_For_Timer < 1)
                {
                    Time_Ends?.Invoke();
                    Time_Ends=null;
                    Button_Text.text = "Rift has been spawned";
                    StopCoroutine(time());
                    break;
                }
                yield return new WaitForSeconds(1);
            }
        }
    }
}