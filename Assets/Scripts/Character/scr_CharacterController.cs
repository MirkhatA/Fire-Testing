using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class scr_CharacterController : MonoBehaviour
{
    private DefaultInput _defaultInput;
    private Vector3 _newCameraRotation;
    private Vector3 _newCharacterRotation;
    private CharacterController _characterController;
    private Vector2 _inputMovement;
    private Vector2 _inputView;

    [Header("References")] 
    public Transform cameraHolder;

    [Header("Settings")] 
    public scr_Models.PlayerModel playerSettings;
    public float viewClampYMin = -70;
    public float viewClampYMax = 80;
    
    private void Awake()
    {
        _defaultInput = new DefaultInput();

        _defaultInput.Character.Movement.performed += e => _inputMovement = e.ReadValue<Vector2>();
        _defaultInput.Character.View.performed += e => _inputView = e.ReadValue<Vector2>();
        
        _defaultInput.Enable();

        _newCameraRotation = cameraHolder.localRotation.eulerAngles;
        _newCharacterRotation = transform.localRotation.eulerAngles;

        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CalculateView();
        CalculateMovement();
    }

    private void CalculateView()
    {
        _newCharacterRotation.y += playerSettings.ViewSensitivity * _inputView.x * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(_newCharacterRotation);
        
        _newCameraRotation.x += playerSettings.ViewSensitivity * -_inputView.y * Time.deltaTime;
        _newCameraRotation.x = Mathf.Clamp(_newCameraRotation.x, viewClampYMin, viewClampYMax);
        
        cameraHolder.localRotation = Quaternion.Euler(_newCameraRotation);
    }

    private void CalculateMovement()
    {
        var verticalSpeed = playerSettings.WalkingSpeed * _inputMovement.y * Time.deltaTime;
        var horizontalSpeed = playerSettings.StrafeSpeed * _inputMovement.x * Time.deltaTime;

        var movementSpeed = new Vector3(horizontalSpeed, 0, verticalSpeed );

        movementSpeed = transform.TransformDirection(movementSpeed);

        _characterController.Move(movementSpeed);
    }
}
