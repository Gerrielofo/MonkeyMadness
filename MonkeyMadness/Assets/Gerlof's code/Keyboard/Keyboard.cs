using UnityEngine;
using TMPro;

public class Keyboard : MonoBehaviour
{
    public TMP_InputField selectedInputField;
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
                selectedInputField = inputfield;
            }
        }
       
    }
    public void InsertChar(string c)
    {
        selectedInputField.text += c;
        selectedInputField.MoveTextEnd(true);
    }
    public void DeleteChar()
    {
        if (selectedInputField.text.Length > 0)
        {
            selectedInputField.text = selectedInputField.text.Substring(0, selectedInputField.text.Length - 1);
            selectedInputField.MoveTextEnd(true);
        }
       
    }
    public void InsertSpace()
    {
        selectedInputField.text += " ";
        selectedInputField.MoveTextEnd(true);
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
