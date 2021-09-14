using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Cinemachine.CinemachineImpulseSource source;
    void Start()
    {
        source = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        
    }

    void Targeted()
    {

    }
}
