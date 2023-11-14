using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_FireController : MonoBehaviour
{
    [Header("Settings")] 
    public scr_Models.FireModel fireSettings;

    private float[] startIntensities = new float[0];
    
    [SerializeField] 
    private ParticleSystem [] firePSystems = new ParticleSystem[0];

    private void Start()
    {
        startIntensities = new float[firePSystems.Length];

        for (int i = 0; i < firePSystems.Length; i++) {
            startIntensities[i] = firePSystems[i].emission.rateOverTime.constant;
        }
        
    }

    private void Update()
    {
        ChangeIntensity();
    }

    private void ChangeIntensity()
    {
        for (int i = 0; i < firePSystems.Length; i++) {
            var emission = firePSystems[i].emission;
            emission.rateOverTime = fireSettings.FireIntensity * startIntensities[i];
        }
    }
}
