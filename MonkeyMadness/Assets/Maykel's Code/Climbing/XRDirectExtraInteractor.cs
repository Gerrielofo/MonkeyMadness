using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class XRDirectExtraInteractor : XRDirectInteractor
{
    public static event Action<string> ClimbHandActivated;
    public static event Action<string> ClimbHandDeactivated;

    private string _controllerName;

    public InputActionProperty grip;
    public bool gripInput;

    public bool canClimb;
    public bool canMove;
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
        if (args.interactableObject.transform.gameObject.tag == "CrossBox")
        {
            canMove = true;
        }
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        canClimb = false;
        canMove = false;
    }
    public void FixedUpdate()
    {
        if (canClimb && gripInput)
        {
            ClimbHandActivated?.Invoke(_controllerName);
        }
        else
        {
            ClimbHandDeactivated?.Invoke(_controllerName);
        }
    }
    private void Update()
    {
        grip.action.performed += hfhi => gripInput = true;
        grip.action.canceled += hfhi => gripInput = false;
    }
}
