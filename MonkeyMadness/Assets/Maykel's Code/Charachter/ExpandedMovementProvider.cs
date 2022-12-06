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

    public CharacterController charachter;
    public InputActionProperty velocityRight;
    public InputActionProperty velocityLeft;

    public InputActionProperty gripLeft;
    public InputActionProperty gripRight;

    public bool gripLeftInput;
    public bool gripRightInput;

    private bool _rightActive = false;
    private bool _leftActive = false;

    public XRDirectExtraInteractor extrainteractorLeft;
    public XRDirectExtraInteractor extrainteractorRight;

    public ContinuousMoveProviderBase movementprovider;

    private bool isStunned;
    [SerializeField] private float stunTime;

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
        gripLeft.action.performed += hfhi => gripLeftInput = true;
        gripLeft.action.canceled += hfhi => gripLeftInput = false;

        gripRight.action.performed += hfhi => gripRightInput = true;
        gripRight.action.canceled += hfhi => gripRightInput = false;

        if (!extrainteractorLeft.canMove && !extrainteractorRight.canMove && !extrainteractorLeft.canClimb && !extrainteractorRight.canClimb)
        {
            Debug.Log("both is true");
            EnableMovement();
        }
        else
        {
            Debug.Log("one is false");
            DisableMovement();
        }


        if (!gripRightInput)
        {
            _rightActive = false;
        }
        if (!gripLeftInput)
        {
            _leftActive = false;
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

            movementprovider.useGravity = false;
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
            if (!extrainteractorLeft.canMove && !extrainteractorRight.canMove)
            {
                EnableMovement();
            }
            else
            {
                return;
            }
            
            movementprovider.useGravity = true;
        }
    }
    private void EnableMovement()
    {
        movementprovider.enabled = true;
        isStunned = false;
    }
    private void DisableMovement()
    {
        movementprovider.enabled = false;
        isStunned = true;
    }
    private void Climb()
    {
        Vector3 velocity = _leftActive ? velocityLeft.action.ReadValue<Vector3>() : velocityRight.action.ReadValue<Vector3>();
        Debug.Log(velocity);
        charachter.Move(charachter.transform.rotation * -velocity * Time.fixedDeltaTime);
    }
    private void Swing()
    {
        if (_leftActive)
        {
            Vector3 velocity = extrainteractorLeft.swingableVelocity.GetComponent<Rigidbody>().velocity;
            charachter.Move(charachter.transform.rotation * velocity * Time.fixedDeltaTime);
        }
        else
        {
            Vector3 velocity = extrainteractorRight.swingableVelocity.GetComponent<Rigidbody>().velocity;
            charachter.Move(charachter.transform.rotation * velocity * Time.fixedDeltaTime);
        }
    }

    public void Stun()
    {
        if (isStunned)
            return;
        else
        {
            DisableMovement();
            StartCoroutine(Stunned());
        }
    }

    private IEnumerator Stunned()
    {
        yield return new WaitForSeconds(stunTime);
        EnableMovement();
    }
}
