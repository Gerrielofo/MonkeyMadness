using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class ExpandedMovementProvider : MonoBehaviour
{
    public static event Action ClimbActive;
    public static event Action ClimbInActive;

    [SerializeField] private CharacterController charachter;
    [SerializeField] private ContinuousMoveProviderBase movementProvider;
    [SerializeField] private SnapTurnProviderBase turnProvider;

    [Header("Inputs")]
    #region
    [SerializeField] private InputActionProperty velocityRight;
    [SerializeField] private InputActionProperty velocityLeft;

    [SerializeField] private InputActionProperty gripLeft;
    [SerializeField] private InputActionProperty gripRight;

    [SerializeField] private bool gripLeftInput;
    [SerializeField] private bool gripRightInput;

    [SerializeField] private bool _rightActive = false;
    [SerializeField] private bool _leftActive = false;
    #endregion
    [Header("Interactors")]
    #region
    [SerializeField] private XRDirectExtraInteractor extrainteractorLeft;
    [SerializeField] private XRDirectExtraInteractor extrainteractorRight;
    #endregion
    [Header("Stun")]
    #region
    [SerializeField] private bool isStunned;
    public float stunTime;
    [SerializeField] private float stunDelay;
    #endregion
    [Header("Swing")]
    #region
    public Vector3 velocity;
    #endregion

    private void Start()
    {
        XRDirectExtraInteractor.ClimbHandActivated += HandActivated;
        XRDirectExtraInteractor.ClimbHandDeactivated += HandDeactivated;
    }
    private void OnDestroy()
    {
        XRDirectExtraInteractor.ClimbHandActivated += HandActivated;
        XRDirectExtraInteractor.ClimbHandDeactivated += HandDeactivated;
    }
    private void Update()
    {
        //INPUTS
        #region
        gripLeft.action.performed += hfhi => gripLeftInput = true;
        gripLeft.action.canceled += hfhi => gripLeftInput = false;

        gripRight.action.performed += hfhi => gripRightInput = true;
        gripRight.action.canceled += hfhi => gripRightInput = false;

        if (!gripRightInput)
        {
            _rightActive = false;
        }
        if (!gripLeftInput)
        {
            _leftActive = false;
        }
        #endregion

        //ENABLE, DISABLE MOVEMENT, TURNING
        if (!extrainteractorLeft.cantMove && !extrainteractorRight.cantMove && !extrainteractorLeft.canClimb && !extrainteractorRight.canClimb)
        {
            EnableMovement();
        }
        else
        {
            DisableMovement();
        }
        if (!extrainteractorLeft.cantTurn && !extrainteractorRight.cantTurn)
        {
            EnableTurning();
        }
        else
        {
            DisableTurning();
        }

        //STUN
        if (isStunned)
        {
            stunDelay -= Time.deltaTime;
        }

        //SWING
        if (extrainteractorLeft.GetComponent<XRDirectExtraInteractor>().canSwing)
        {
            Swing();
        }
        else if (extrainteractorRight.GetComponent<XRDirectExtraInteractor>().canSwing)
        {
            Swing();
        }
    }
    private void HandActivated(string _controllerName)
    {
        if (_controllerName == "LeftHand Controller")
        {
            _leftActive = true;
            _rightActive = false;
        }
        else
        {
            _leftActive = false;
            _rightActive = true;
        }

        ClimbActive?.Invoke();
    }
    private void HandDeactivated(string _controllerName)
    {
        if (_rightActive && _controllerName == "RightHand Controller")
        {
            _rightActive = false;
            ClimbActive?.Invoke();
        }
        else if (_leftActive && _controllerName == "LeftHand Controller")
        {
            _leftActive = false;
            ClimbActive?.Invoke();
        }
    }
    private void FixedUpdate()
    {
        if (_rightActive || _leftActive)
        {
            DisableMovement();

            movementProvider.useGravity = false;
            if (extrainteractorLeft.canClimb || extrainteractorRight.canClimb)
            {
                Climb();
            }
            if (extrainteractorLeft.canSwing || extrainteractorRight.canSwing)
            {
                Swing();
            }
        }
        else
        {
            if (!extrainteractorLeft.cantMove && !extrainteractorRight.cantMove)
            {
                EnableMovement();
            }
            else
            {
                return;
            }
            
            movementProvider.useGravity = true;
        }
    }
    private void EnableMovement()
    {
        movementProvider.enabled = true;
    }
    private void DisableMovement()
    {
        movementProvider.enabled = false;
    }
    private void EnableTurning()
    {
        turnProvider.enabled = true;
    }
    private void DisableTurning()
    {
        turnProvider.enabled = false;
    }
    private void Climb()
    {
        Vector3 velocity = _leftActive ? velocityLeft.action.ReadValue<Vector3>() : velocityRight.action.ReadValue<Vector3>();
        charachter.Move(charachter.transform.rotation * -velocity * Time.fixedDeltaTime);
    }
    private void Swing()
    {
        if (_leftActive)
        {
            velocity = extrainteractorLeft.GetComponent<XRDirectExtraInteractor>().heldItem.GetComponent<Rigidbody>().velocity;
            charachter.Move(charachter.transform.rotation * velocity * Time.fixedDeltaTime);
        }
        else
        {
            velocity = extrainteractorRight.GetComponent<XRDirectExtraInteractor>().heldItem.GetComponent<Rigidbody>().velocity;
            charachter.Move(charachter.transform.rotation * velocity * Time.fixedDeltaTime);
        }
    }
    public void Stun()
    {
        if (isStunned)
        {
            return;
        }
        else if(stunDelay <= 0)
        {
            stunDelay = 2f;
            isStunned = true;
            DisableMovement();
            StartCoroutine(Stunned());
        }
    }
    private IEnumerator Stunned()
    {
        yield return new WaitForSeconds(stunTime);

        EnableMovement();
        isStunned = false;
    }
}
