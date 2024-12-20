using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Control : MonoBehaviour
{
    public InputActionProperty leftGrabAction; 
    public InputActionProperty leftTriggerAction; 
    public InputActionProperty rightGrabAction; 
    public InputActionProperty rightTriggerAction; 
    public InputActionProperty buttonXAction; 
    public InputActionProperty buttonYAction; 
    public InputActionProperty buttonAAction; 
    public InputActionProperty buttonBAction; 

    public GunManager gunManager;

    public CollectorManager collectorManager;
    public TextMeshProUGUI actionText;
    public GameObject gun;
    public GameObject collector;

    public RayCast leftLaser;
    public RayCast rightLaser;

    public LevelManager levelManager;

    public HintManager hintManager;

    private bool isRightGrabPressed, isLeftGrabPressed, isRightTriggerPressed, isleftTriggerPressed;
    private bool isBpressed, isApressed,isXpressed,isYpressed;

    public GameObject hand_UI;
    public GameObject hint_UI;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI attemptsText;
    public TextMeshProUGUI constellationsText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI warningText;

    public TextMeshProUGUI hintText;

    BoundaryLogger boundaryLogger ;

    public AudioSource correct_audio;
    public AudioSource incorrect_audio;
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

    private void Start()
    {
        UpdateGunVisibility(false); 
        UpdateCollectorVisibility(false);
        UpdateUIVisibility(false);
        UpdateHintVisibility(false);
        isRightGrabPressed=false;
        isLeftGrabPressed=false;
        isleftTriggerPressed=false;
        isRightTriggerPressed=false;
        isBpressed=false;
        isApressed=false;
        isXpressed=false;
        isYpressed=false;
        boundaryLogger = FindObjectOfType<BoundaryLogger>();
    }

    private void Update()
    {
        if(isApressed)
        {
            updateUI();
        }
        if(levelManager.winAndGameOver())
        {
            //finish game
            actionText.text="YOU WON";
            UnsubscribeFromInputEvents();
            DisableInputActions();
        }
        else if(levelManager.loseAndGameOver() || boundaryLogger.getWarning()==2 || boundaryLogger.getHealth()<=0)
        {
            //finish game
            actionText.text="YOU LOST";
            UnsubscribeFromInputEvents();
            DisableInputActions();
        }
    }

    private void OnLeftGrab(InputAction.CallbackContext context)
    {
        if(context.performed && isleftTriggerPressed==false)
        {
            UpdateCollectorVisibility(true);
            isLeftGrabPressed=true;
        }
        else if(context.canceled && isleftTriggerPressed==false)
        {
            UpdateCollectorVisibility(false);
            isLeftGrabPressed=false;
        }
    }

    private void OnLeftTrigger(InputAction.CallbackContext context)
    {
        if(isLeftGrabPressed==false)
        {
            if(context.performed)
            {
                leftLaser.ToggleLaser(true);
                leftGrabAction.action.Disable();
                isleftTriggerPressed=true;
            }
            else if(context.canceled)
            {
                leftLaser.ToggleLaser(false);
                leftGrabAction.action.Enable();
                isleftTriggerPressed=false;
            }
        }
        else if(isLeftGrabPressed==true)
        {
            if(context.performed)
            {
                //actionText.text = "collector fired";
                collectorManager.Fire();
            }
        }
    }

    private void OnRightGrab(InputAction.CallbackContext context)
    {
        if(context.performed && isRightTriggerPressed==false)
        {
            UpdateGunVisibility(true);
            isRightGrabPressed=true;
        }
        else if(context.canceled && isRightTriggerPressed==false)
        {
            UpdateGunVisibility(false);
            isRightGrabPressed=false;
        }

    }

    private void OnRightTrigger(InputAction.CallbackContext context)
    {
        if(isRightGrabPressed==false)
        {
            if(context.performed)
            {
                rightLaser.ToggleLaser(true);
                rightGrabAction.action.Disable();
                isRightTriggerPressed=true;
            }
            else if(context.canceled)
            {
                rightLaser.ToggleLaser(false);
                rightGrabAction.action.Enable();
                isRightTriggerPressed=false;
            }
        }
        else if(isRightGrabPressed==true)
        {
            if(context.performed)
            {
                //actionText.text="gun fired";
                gunManager.Fire();
            }
        }

    }


    private void UpdateGunVisibility(bool isVisible)
    {
        if (gun != null)
        {
            gun.SetActive(isVisible); 
        }
    }

    private void UpdateCollectorVisibility(bool isVisible)
    {
        if (collector != null)
        {
            collector.SetActive(isVisible); 
        }
    }

    public void UpdateUIVisibility(bool isVisible)
    {
        if(hand_UI != null)
        {
            hand_UI.SetActive(isVisible); 
        }
    }
    public void UpdateHintVisibility(bool isVisible)
    {
        if(hint_UI != null)
        {
            hint_UI.SetActive(isVisible); 
        }
    }


    private void EnableInputActions()
    {
        leftGrabAction.action.Enable();
        leftTriggerAction.action.Enable();
        rightGrabAction.action.Enable();
        rightTriggerAction.action.Enable();
        buttonXAction.action.Enable();
        buttonYAction.action.Enable();
        buttonAAction.action.Enable();
        buttonBAction.action.Enable();
    }

    private void DisableInputActions()
    {
        leftGrabAction.action.Disable();
        leftTriggerAction.action.Disable();
        rightGrabAction.action.Disable();
        rightTriggerAction.action.Disable();
        buttonXAction.action.Disable();
        buttonYAction.action.Disable();
        buttonAAction.action.Disable();
        buttonBAction.action.Disable();
    }

    private void DisableButtonActions(InputActionProperty action)
    {
        action.action.Disable();
    }

    private void SubscribeToInputEvents()
    {
        leftGrabAction.action.performed += OnLeftGrab;
        leftGrabAction.action.canceled += OnLeftGrab;
        leftTriggerAction.action.performed += OnLeftTrigger;
        leftTriggerAction.action.canceled += OnLeftTrigger;
        rightGrabAction.action.performed += OnRightGrab;
        rightGrabAction.action.canceled += OnRightGrab; 
        rightTriggerAction.action.performed += OnRightTrigger;
        rightTriggerAction.action.canceled += OnRightTrigger;
        buttonXAction.action.performed += OnButtonX;
        buttonYAction.action.performed += OnButtonY;
        buttonAAction.action.performed += OnButtonA;
        buttonBAction.action.performed += OnButtonB;
    }

    private void UnsubscribeFromInputEvents()
    {
        leftGrabAction.action.performed -= OnLeftGrab;
        leftGrabAction.action.canceled -= OnLeftGrab;
        leftTriggerAction.action.performed -= OnLeftTrigger;
        leftTriggerAction.action.canceled -= OnLeftTrigger;
        rightGrabAction.action.performed -= OnRightGrab;
        rightGrabAction.action.canceled -= OnRightGrab; 
        rightTriggerAction.action.performed -= OnRightTrigger;
        rightTriggerAction.action.canceled -= OnRightTrigger;
        buttonXAction.action.performed -= OnButtonX;
        buttonYAction.action.performed -= OnButtonY;
        buttonAAction.action.performed -= OnButtonA;
        buttonBAction.action.performed -= OnButtonB;
    }
    public void UpdateHintUI()
    {
        string text_To_show=hintManager.GetCurrentHint();
        hintText.text = text_To_show;
        //actionText.text=text_To_show;
    }
    private void OnButtonY(InputAction.CallbackContext context)
    {
        if(isYpressed==false)
        {
            buttonAAction.action.Disable();
            buttonBAction.action.Disable();
            isYpressed=true;
            UpdateHintVisibility(true);
            if(levelManager.isHintAvailable() == false)
            {
                hintText.text = "NO HINTS AVAILABLE";
            }
            else
            {
                hintText.text = "PRESS Y TO USE HINT\nPRESS X TO CANCEL";
            }
        }
        else
        {
            if(levelManager.isHintAvailable() == true)
            {
                levelManager.UseHint();
                hintManager.AddLastHint();
                hintManager.AddCurrentHint();
            }
            isYpressed=false;
            UpdateHintVisibility(false);
            buttonAAction.action.Enable();
            buttonBAction.action.Enable();
        }
        //actionText.text = "Button Y pressed!";
    }

    private void OnButtonX(InputAction.CallbackContext context)
    {
        //actionText.text = $"isYpressed: {isYpressed}, isXpressed: {isXpressed}";
        if(isYpressed==true)
        {
            isYpressed=false;
            UpdateHintVisibility(false);
            buttonAAction.action.Enable();
            buttonBAction.action.Enable();
            actionText.text = "1";
        }
        else
        {
            //actionText.text="here";
            if(isXpressed==false)
            {
                //actionText.text = "2";
                UpdateHintUI();
                UpdateHintVisibility(true);
                isXpressed=true;
                buttonYAction.action.Disable();
                
            }
            else
            {
                //actionText.text = "3";
                UpdateHintVisibility(false);
                isXpressed=false;
                buttonYAction.action.Enable();
                
            }
        }
    }


    public void updateUI()
    {
        
        if (boundaryLogger != null)
        {
            Debug.Log("SUCCESS");
        }
        else
        {
            Debug.LogError("BoundaryLogger not found in the scene!");
        }

        float health=boundaryLogger.getHealth();
        int point=boundaryLogger.getPoint();
        int attemptsLeft=levelManager.getAttempts();
        int constellationRemaining=levelManager.getRemainingContellationsCount();
        float dist=boundaryLogger.getDistance();
        int warning=boundaryLogger.getWarning();
        healthText.text= "Health: "+$"{health}";
        pointsText.text="Points: "+$"{point}";
        attemptsText.text="Attempts: "+$"{attemptsLeft}";
        constellationsText.text="Remaining: "+$"{constellationRemaining}";
        distanceText.text="Distance: "+$"{dist:F2}";
        if(warning==0)
        {
            warningText.text="SAFE";
        }
        else if(warning==1)
        {
            warningText.text="ON EDGE";
        }
        else
        {
            warningText.text = "LOST";
        }
    }
    private void OnButtonA(InputAction.CallbackContext context)
    {
        if(isXpressed==true)
        {
            actionText.text = "turning right";
            if(hintManager.showNextHint())
            {
                actionText.text = "turned right";
                hintManager.AddCurrentHint();
                UpdateHintUI();
            }
        }
        else if(isApressed==false)
        {
            UpdateUIVisibility(true);
            isApressed=true;
            updateUI();
        }
        else
        {
            UpdateUIVisibility(false);
            isApressed=false;
        }
        
    }

    private void OnButtonB(InputAction.CallbackContext context)
    {
        if(isXpressed==true)
        {
            actionText.text = "turning left";
            if(hintManager.showPreviousHint())
            {
                actionText.text = "turned left";
                hintManager.SubtractCurrentHint();
                UpdateHintUI();
            }
        }
        else if(isleftTriggerPressed || isRightTriggerPressed)
        {
            string constellationLeft=leftLaser.GetConstellationName();
            string constellationRight=rightLaser.GetConstellationName();
            string currentConstellation=levelManager.getCurrentConstellation();
            if(constellationLeft==currentConstellation || constellationRight==currentConstellation)
            {   
                levelManager.goToNextTask();
                levelManager.ResetHint();
                hintManager.last_hint=levelManager.getCurrentTask()*3;
                if (correct_audio != null && correct_audio.clip != null)
                {
                    correct_audio.Play();
                }
            }
            else
            {
                levelManager.Attempt();
                if (incorrect_audio != null && incorrect_audio.clip != null)
                {
                    incorrect_audio.Play();
                }
            }
        }
        else
        {
            //actionText.text = "Button B pressed!";
        }
    }
}
