using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SecretCanvasScript : MonoBehaviour
{
    public Button backbutton;
    private bool PasswordActivated = false;
    public GameObject ObjectToActivate;
    private string password = "kebab1234";
    public TMP_InputField inputfield;

    private void Start()
    {
        inputfield.interactable = true;
    }
    public void CheckInput()
    {

        if (inputfield.text == password)
        {
            PasswordActivated = true;
            Debug.Log("Password correct!");
            if (PasswordActivated == true)
            {
                ObjectToActivate.SetActive(true);
            }
            
        }
        if (inputfield.text != password)
        {
            Debug.Log("Password incorrect!");
        }

    }
    public void BackButtonPressed()
    {
        PasswordActivated = false;
    }
    private void OnEnable()
    {
        if (PasswordActivated == false)
        {
            ObjectToActivate.SetActive(false);
        }
    }
   


}
