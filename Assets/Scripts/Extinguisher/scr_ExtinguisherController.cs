using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ExtinguisherController : MonoBehaviour
{
    [Header("Settings")] 
    public scr_Models.ExtinguisherModel extinguisherSettings;
    
    private float _startIntensity = 5.0f;

    [SerializeField] 
    private ParticleSystem extinguisherPS = null;
    
    private bool isMouseButtonDown = false;

    private void Start()
    {
        _startIntensity = extinguisherPS.emission.rateOverTime.constant;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            isMouseButtonDown = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            isMouseButtonDown = false;
        }
        
        ChangeIntensity();

        if (isMouseButtonDown) {
            extinguisherSettings.CurrentIntensity = 1f;
        } else {
            extinguisherSettings.CurrentIntensity = 0f;
        }
    }

    private void ChangeIntensity()
    {
        var emission = extinguisherPS.emission;
        emission.rateOverTime = extinguisherSettings.CurrentIntensity * _startIntensity;
    }
}
