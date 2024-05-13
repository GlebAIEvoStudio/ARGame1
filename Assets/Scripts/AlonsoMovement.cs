using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlonsoMovement : MonoBehaviour
{
    public GameObject ARP;
    private GameObject Camera;
    public static GameObject FirstARP;
    public GameObject Charachter;
    public TextMeshProUGUI text;
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {

    }
}
