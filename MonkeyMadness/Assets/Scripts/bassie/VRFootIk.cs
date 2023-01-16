using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFootIk : MonoBehaviour
{
    public Animator animator;
    [Range(0, 1)]
    public float rightFootPoseWeight = 1;
    [Range(0, 1)]
    public float leftFootPoseWeight = 1;

    public Vector3 footOfset;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnAnimatorIK(int layerIndex)
    {
        Vector3 rightFootPos = animator.GetIKPosition(AvatarIKGoal.RightFoot);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(rightFootPos + Vector3.up, Vector3.down, out hit);
        if (hasHit && hit.transform.gameObject.tag != "IsPlayer")
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootPoseWeight);
            animator.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + footOfset);
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
        }
        Vector3 leftFootPos = animator.GetIKPosition(AvatarIKGoal.LeftFoot);
        
        hasHit = Physics.Raycast(leftFootPos + Vector3.up, Vector3.down, out hit);
        if (hasHit && hit.transform.gameObject.tag != "IsPlayer")
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootPoseWeight);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + footOfset);
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
        }
    }

}
