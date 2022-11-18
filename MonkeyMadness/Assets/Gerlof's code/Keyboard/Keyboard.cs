using UnityEngine;
using TMPro;

public class Keyboard : MonoBehaviour
{
    public TMP_InputField createInputfield, joinInputfield, inputfield;
    public GameObject normalButtons;
    public GameObject capsButtons;
    bool caps;
    void Start()
    {
        caps = false;
    }

    private void Update()
    {
        if (joinInputfield.isFocused)
        {
            inputfield = joinInputfield;
        }
        else
        {
            inputfield = createInputfield;
        }
       
    }
    public void InsertChar(string c)
    {
        inputfield.text += c;
    }
    public void DeleteChar()
    {
        if (inputfield.text.Length > 0)
        {
            inputfield.text = inputfield.text.Substring(0, inputfield.text.Length - 1);
        }
    }
    public void InsertSpace()
    {
        inputfield.text += " ";
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
