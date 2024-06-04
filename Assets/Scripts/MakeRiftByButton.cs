using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Scripts
{
    public class MakeRiftByButton : MonoBehaviour
    {
        public static Action Time_Ends;
        public TextMeshProUGUI Button_Text;
        public TextMeshProUGUI Debug_Text;
        public int Seconds_For_Timer = 3;
        private Renderer RiftRenderer;
        private Color RiftColor;

        void Start()
        {
            RiftRenderer = GetComponent<Renderer>();

        }

        void Update()
        {
            Debug_Text.text = RiftRenderer.material.GetColor("_Color").ToString();
        }

        public void ChangeRiftColor()
        {
            RiftColor = new Color(UnityEngine.Random.Range(0f, 1f),UnityEngine.Random.Range(0f, 1f),UnityEngine.Random.Range(0f, 1f),1f);
            RiftRenderer.material.SetColor("_Color", RiftColor);
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
                    Button_Text.text = "Молния появилась";
                    StopCoroutine(time());
                }
            yield return new WaitForSeconds(1);
            }
        }
    }
}