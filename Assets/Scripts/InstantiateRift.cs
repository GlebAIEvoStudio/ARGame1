using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Scripts;

public class InstantiateRift : MonoBehaviour
{
    public TextMeshProUGUI Debug_text;
    public GameObject Camera;
    public GameObject plane;
    public GameObject prefabToSpawn;
    private Quaternion quat;

    private void Start()
    {
        quat = prefabToSpawn.transform.rotation;
    }

    private void OnEnable()
    {
        MakeRiftByButton.Time_Ends += InstantiateLight;
    }
    private void OnDisable()
    {
        MakeRiftByButton.Time_Ends -= InstantiateLight;

    }

    public void InstantiateLight()
    {
        GameObject[] planes = GameObject.FindGameObjectsWithTag("ARPlane");
        var rand = new System.Random();
        int i = rand.Next(planes.Length-1);
        AlonsoMovement.FirstARP = planes[i];
        Instantiate(prefabToSpawn, planes[i].transform.position + planes[i].transform.lossyScale/2 , Camera.transform.rotation);
    }
}
