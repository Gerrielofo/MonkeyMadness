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
            if (gripInput)
            {
                ClimbHandActivated?.Invoke(_controllerName);
            }
        }
    }

    public void FixedUpdate()
    {
        if (gripInput)
        {
            ClimbHandActivated?.Invoke(_controllerName);
        }
        else
        {
            ClimbHandDeactivated?.Invoke(_controllerName);
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        ClimbHandActivated?.Invoke(_controllerName);
    }

    private void Update()
    {
        grip.action.performed += hfhi => gripInput = true;
        grip.action.canceled += hfhi => gripInput = false;
    }
}
