using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; // Add this namespace for scene management
using TMPro;

public class SceneChanger : MonoBehaviour
{
    public InputActionProperty buttonAAction; 
    public InputActionProperty buttonBAction; 


    public string sceneAName; 
    public string sceneBName; 

    private void Start()
    {
    }

    private void Update()
    {
        // Handle any updates if needed
    }

    private void OnEnable()
    {
        EnableInputActions();
        SubscribeToInputEvents();
    }

    private void OnDisable()
    {
        UnsubscribeFromInputEvents();
        DisableInputActions();
    }

    private void EnableInputActions()
    {
        buttonAAction.action.Enable();
        buttonBAction.action.Enable();
    }

    private void DisableInputActions()
    {
        buttonAAction.action.Disable();
        buttonBAction.action.Disable();
    }

    private void SubscribeToInputEvents()
    {
        buttonAAction.action.performed += OnButtonA; // Bind OnButtonA method to button A press
        buttonBAction.action.performed += OnButtonB; // Bind OnButtonB method to button B press
    }

    private void UnsubscribeFromInputEvents()
    {
        buttonAAction.action.performed -= OnButtonA;
        buttonBAction.action.performed -= OnButtonB;
    }

    private void OnButtonA(InputAction.CallbackContext context)
    {
        if(sceneAName!=null)
        {
        //actionText.text= $"{sceneAName}";
        SceneManager.LoadScene(sceneAName);
        }
    }

    private void OnButtonB(InputAction.CallbackContext context)
    {
        if(sceneBName!=null)
        {
        /////actionText.text = $"{sceneBName}";
        SceneManager.LoadScene(sceneBName);
        }
    }
}
