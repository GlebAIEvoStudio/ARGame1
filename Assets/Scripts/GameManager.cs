using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Debug_text;
    public GameObject plane;
    public GameObject prefabTOspawn;
    private Quaternion quat = Quaternion.identity;

    private void OnEnable()
    {
        MakeLightByButton.Time_Ends += InstantiateLight;
    }
    private void OnDisable()
    {
        MakeLightByButton.Time_Ends -= InstantiateLight;

    }

    public void InstantiateLight()
    {
        GameObject[] planes = GameObject.FindGameObjectsWithTag("ARPlane");
        var rand = new System.Random();
        int i = rand.Next(planes.Length-1);
        AlonsoMovement.FirstARP = planes[i];
        Instantiate(prefabTOspawn, planes[i].transform.position + planes[i].transform.lossyScale/2 , quat);
    }
}
