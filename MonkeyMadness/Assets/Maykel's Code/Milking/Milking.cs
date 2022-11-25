using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milking : MonoBehaviour
{
    public Transform schudObject;

    public Transform resetPoint;

    public float distance;

    public bool up;
    public bool down;

    public int points;

    private void Update()
    {
        distance = Vector3.Distance(schudObject.position, resetPoint.position);

        if (distance < 0.2f)
        {
            up = true;
            down = false;
        }

        if (up)
        {
            if (distance > 0.3f)
            {
                down = true;

                points++;

                up = false;
            }
        }
    }
}
