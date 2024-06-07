using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Scripts;
using Unity.VisualScripting;

public class InstantiateRift : MonoBehaviour
{
    public TextMeshProUGUI Debug_Text;
    public TextMeshProUGUI Button_Text;
    public GameObject Rift;
    private GameObject Camera;
    private RaycastHit hit;
    [SerializeField] private int RandomRangeOfRiftSpawn;

    private void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera");
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
        var rand = new System.Random();       
        GameObject[] planes = GameObject.FindGameObjectsWithTag("ARPlane");
        int i = rand.Next(planes.Length-1);
        Vector3 RayPos = new Vector3(GetRandomFloat(0,RandomRangeOfRiftSpawn), 3, GetRandomFloat(0,RandomRangeOfRiftSpawn));
        while(true)
        {
            if(CheckTheGround(RayPos+planes[i].transform.position))
            {
                Instantiate(Rift, hit.point + Rift.transform.lossyScale/2, Rift.transform.rotation);
                break;
            }
            RayPos = new Vector3(GetRandomFloat(0,RandomRangeOfRiftSpawn), 3, GetRandomFloat(0,RandomRangeOfRiftSpawn));
        }
    }

    private float GetRandomFloat(int min, int max)
    {
        var floatrand = new System.Random();
        float frand = floatrand.Next(min, max);
        return frand;
    }

    private bool CheckTheGround(Vector3 position)
    {
        Ray ray = new Ray(position, -transform.up*5f);

        return Physics.Raycast(ray, out hit);
    }
}