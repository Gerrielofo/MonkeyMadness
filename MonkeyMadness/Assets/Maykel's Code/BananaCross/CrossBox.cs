using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBox : MonoBehaviour
{
    public CrossBoxManager manager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            manager.SpawnBox();
        }
    }
}
