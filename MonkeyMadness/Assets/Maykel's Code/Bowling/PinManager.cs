using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{


    public Transform pinTransform;

    public bool up;
    public bool balling;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (balling)
        {
            if (pinTransform.rotation.x != 0)
            {
                up = false;
            }
            else
            {
                up = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            balling = true;
        }
    }

    public IEnumerator ResetPinTime()
    {
        yield return new WaitForSeconds(1);

        balling = false;
    }
}
