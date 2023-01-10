using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPosOffset;
    public Vector3 trackingRotOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPosOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotOffset);
    }
};
public class NewVRRig : MonoBehaviour
{
    public float turnSmoothness;

    public VRMap head;
    public VRMap lHand;
    public VRMap rHand;

    public Transform headConstraint;
    public Vector3 headBodyOffest;

    public Transform mainC;
    // Start is called before the first frame update
    void Start()
    {
        headBodyOffest = transform.position - headConstraint.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = headConstraint.position + headBodyOffest;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(mainC.forward, Vector3.up).normalized, Time.deltaTime * turnSmoothness);
        
        head.Map();
        lHand.Map();
        rHand.Map();
    }
}
