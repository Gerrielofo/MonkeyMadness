using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchScript : MonoBehaviour
{
    bool canClick;
    private void OnTriggerEnter(Collider other) {
        if (canClick) {
            StartCoroutine(CoolDown(other));
        }
    }
    public IEnumerator CoolDown(Collider other) {
        if(other.tag == "Hands") {
            this.GetComponent<Button>().onClick.Invoke();
            Debug.Log("Click");
            canClick = false;
        }
        yield return new WaitForSeconds(2);
        canClick = true;
        yield return null;
    }
}
