using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor;
using System;

public class CameraController1 : MonoBehaviour
{
    public GameObject freeLookCamera;
    CinemachineFreeLook freeLookComponent;
    public float SpeedV;
    public float SpeedH;

    private void Awake()
    {
        freeLookComponent = freeLookCamera.GetComponent<CinemachineFreeLook>();
    }

    private void FixedUpdate()
    {
        freeLookComponent.m_XAxis.m_MaxSpeed = SpeedH * Time.deltaTime;
        freeLookComponent.m_YAxis.m_MaxSpeed = SpeedV * Time.deltaTime;

    }
}

