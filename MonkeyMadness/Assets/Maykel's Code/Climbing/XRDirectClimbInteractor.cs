using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class XRDirectClimbInteractor : XRDirectInteractor
{
    public static event Action<string> ClimbHandActivated;
    public static event Action<string> ClimbHandDeactivated;

    private string _controllerName;

    public InputActionProperty grip;

    public bool gripInput;

    public bool canClimb;
    protected override void Start()
    {
        base.Start();
        _controllerName = gameObject.name;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if(args.interactableObject.transform.gameObject.tag == "Climbable")
        {
            canClimb = true;
        }
    }

    public void FixedUpdate()
    {
        if (canClimb)
        {
            if (gripInput)
            {
                ClimbHandActivated?.Invoke(_controllerName);
            }
        }
        else
        {
            ClimbHandDeactivated?.Invoke(_controllerName);
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        canClimb = false;
    }

    private void Update()
    {
        grip.action.performed += hfhi => gripInput = true;
        grip.action.canceled += hfhi => gripInput = false;
    }
}
