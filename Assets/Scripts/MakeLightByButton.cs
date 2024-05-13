using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MakeLightByButton : MonoBehaviour
{
    //public GameObject Light_Prefab;
    public static Action Time_Ends;
    public TextMeshProUGUI Button_Text;
    public int Seconds_For_Timer = 10;
    public GameObject light;

    private float yAngle = 0.0f;
    private float multiplier = -5.0f;
    public void Update()
    {
        light?.transform.Rotate(0.0f,yAngle*multiplier, 0.0f, Space.Self);
    }

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
                Button_Text.text = "Появляется молния";
                StopCoroutine(time());
            }
            yield return new WaitForSeconds(1);
        }
    }
}
