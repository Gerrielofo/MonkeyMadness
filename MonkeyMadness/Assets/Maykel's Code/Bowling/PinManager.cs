using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public Transform pinTransform;
    public Quaternion pinrot;

    private float pinrotxf;
    private float pinrotzf;

    private int pinrotxi;
    private int pinrotzi;

    public bool down;
    public void CheckPins()
    {
        pinrot = pinTransform.rotation;

        pinrotxf = pinrot.x;
        pinrotzf = pinrot.z;

        pinrotxi = Mathf.RoundToInt(pinrotxf);
        pinrotzi = Mathf.RoundToInt(pinrotzf);

        if (pinrotxi != 0 || pinrotzi != 0)
        {
            down = true;
        }
        else
        {
            down = false;
        }
    }
}
