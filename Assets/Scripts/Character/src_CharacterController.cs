using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private DefaultInput _defaultInput;
    private Vector3 _newCameraRotation;
    private Vector3 _newCharacterRotation;
    
    public Vector2 inputMovement;
    public Vector2 inputView;

    [Header("References")] 
    public Transform cameraHolder;

    [Header("Settings")] 
    public scr_Models.PlayerSettingsModel playerSettings;
    public float viewClampYMin = -70;
    public float viewClampYMax = 80;
    
    private void Awake()
    {
        _defaultInput = new DefaultInput();

        _defaultInput.Character.Movement.performed += e => inputMovement = e.ReadValue<Vector2>();
        _defaultInput.Character.View.performed += e => inputView = e.ReadValue<Vector2>();
        
        _defaultInput.Enable();

        _newCameraRotation = cameraHolder.localRotation.eulerAngles;
        _newCharacterRotation = transform.localRotation.eulerAngles;
    }

    private void Update()
    {
        CalculateView();
        CalculateMovement();
    }

    private void CalculateView()
    {
        _newCharacterRotation.y += playerSettings.ViewSensitivity * inputView.x * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(_newCharacterRotation);
        
        _newCameraRotation.x += playerSettings.ViewSensitivity * -inputView.y * Time.deltaTime;
        _newCameraRotation.x = Mathf.Clamp(_newCameraRotation.x, viewClampYMin, viewClampYMax);
        
        cameraHolder.localRotation = Quaternion.Euler(_newCameraRotation);
    }

    private void CalculateMovement()
    {
        
    }
}
