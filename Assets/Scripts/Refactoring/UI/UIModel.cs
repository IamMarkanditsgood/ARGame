using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIModel : MonoBehaviour
{
    private void OnEnable()
    {
        UIController.ActionMainMenu += MainMenu;
    }

    private void OnDisable()
    {
        UIController.ActionMainMenu -= MainMenu;
    }
    public void MainMenu()
    {

    }
    public void SetForceForCatapults(LevelData levelData, TMP_InputField TMPInputField)
    {
        levelData.ForceForCatapult = Int32.Parse(TMPInputField.text);

    }    
}
