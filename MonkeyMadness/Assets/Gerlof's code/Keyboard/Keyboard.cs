using UnityEngine;
using TMPro;

public class Keyboard : MonoBehaviour
{
    public TMP_InputField sellectedInputField;
    public TMP_InputField[] inputfields;
    public GameObject normalButtons;
    public GameObject capsButtons;
    bool caps;
    void Start()
    {
        caps = false;
    }

    private void Update()
    {
        foreach (TMP_InputField inputfield in inputfields) {
            if (inputfield.isFocused) {
                sellectedInputField = inputfield;
            }
        }
       
    }
    public void InsertChar(string c)
    {
        sellectedInputField.text += c;
    }
    public void DeleteChar()
    {
        if (sellectedInputField.text.Length > 0)
        {
            sellectedInputField.text = sellectedInputField.text.Substring(0, sellectedInputField.text.Length - 1);
        }
    }
    public void InsertSpace()
    {
        sellectedInputField.text += " ";
    }

    public void CapsPressed()
    {
        if (!caps)
        {
            normalButtons.SetActive(false);
            capsButtons.SetActive(true);
            caps = true;
        }
        else
        {
            normalButtons.SetActive(true);
            capsButtons.SetActive(false);
            caps = false;
        }
        
    }
}
