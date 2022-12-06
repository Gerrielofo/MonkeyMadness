using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class HandInputs : MonoBehaviour
{
    public InputActionProperty trigger;
    public InputActionProperty grip;
    public InputActionProperty primaryB;
    public InputActionProperty secondaryB;

    [Header("inputs")]
    #region
    public bool primaryInput;
    public bool secondaryInput;
    #endregion
    private void Update()
    {
        primaryB.action.performed += ctx => primaryInput = true;
        primaryB.action.canceled += ctx => primaryInput = false;

        secondaryB.action.performed += ctx => secondaryInput = true;
        secondaryB.action.canceled += ctx => secondaryInput = false;
    }


}