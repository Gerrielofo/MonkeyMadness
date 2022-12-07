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

    [SerializeField] private string _controllerName;

    [SerializeField] private InputActionProperty grip;
    [SerializeField] private bool gripInput;

    public bool canClimb;
    public bool canSwing;
    public bool cantMove;
    public bool cantTurn;

    public GameObject heldItem;
    protected override void Start()
    {
        base.Start();
        _controllerName = gameObject.name;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if(args.interactableObject.transform.tag == "Poop")
        {
            
            heldItem = args.interactableObject.transform.gameObject;
            heldItem.GetComponent<MeshRenderer>().enabled = true;
        }
        if(args.interactableObject.transform.tag == "Climbable")
        {
            canClimb = true;
        }
        if (args.interactableObject.transform.tag == "Swingable")
        {
            heldItem = args.interactableObject.transform.gameObject;
            canSwing = true;
            cantMove = true;
            cantTurn = true;
        }
        if (args.interactableObject.transform.tag == "CrossBox")
        {
            cantMove = true;
        }
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        heldItem = null;

        canSwing = false;
        canClimb = false;
        cantMove = false;
        cantTurn = false;
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
