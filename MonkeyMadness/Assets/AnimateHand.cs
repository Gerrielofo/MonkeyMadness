using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHand : MonoBehaviour
{
    public InputActionProperty triggerAnimation;

    public InputActionProperty gripAnimation;

    public Animator handAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        float triggerValue = triggerAnimation.action.ReadValue<float>();

        // sets animation state of the "placeholderanimation1" animation if the animation has a different name change this "placeholderanimation1" name
        handAnimator.SetFloat("placeholderanimation1", triggerValue);

        float gripValue = gripAnimation.action.ReadValue<float>();

        // sets animation state of the "placeholderanimation2" animation if the animation has a different name change this "placeholderanimation2" name
        handAnimator.SetFloat("placeholderanimation2", gripValue);
    }
}
