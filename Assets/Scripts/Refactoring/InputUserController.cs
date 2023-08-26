using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InputUserController
{
    public bool IsÑlickOnScreen(InputScreenData inputScreenData) 
    {
        if (Input.touchCount > 0)
        {
            inputScreenData.Touch = Input.GetTouch(0);
            inputScreenData.TouchPosition = inputScreenData.Touch.position;
            return true;
        }
        return false;
    }
}
