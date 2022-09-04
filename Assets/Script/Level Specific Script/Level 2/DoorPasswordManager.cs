using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorPasswordManager : MonoBehaviour
{
    public string password;
    public string passwordOnScreen;

    // Need TMP_Text variable here to integrate passwordOnScreen to actual screen
    public TMP_Text screenText;

    private void Update()
    {
        screenText.text = passwordOnScreen;
        if(passwordOnScreen.Length == 4)
        {
            // Check only if password on screen is 4 character
            Check();
        }
    }

    public void Check()
    {
        // Check if password on screen is the same as password
        if(passwordOnScreen == password)
        {
            // open the door to next level
        }
        else // If not, delete all passwordOnScreen
        {
            // Wrong Beep audio here
            passwordOnScreen = "";
        }
        
    }
}
