using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView: MonoBehaviour 
{
    private void OnEnable()
    {
        UIController.ActionRotateColor += RotateButton;
    }
    private void OnDisable()
    {
        UIController.ActionRotateColor -= RotateButton;
    }
    public void SwitchStorage(UIData UIData)
    {
        ObjectSwitcher objectSwitcher = new ObjectSwitcher();
        objectSwitcher.SwitchObject(UIData.Storage);
    }
    public void RotateButton(GameObject button, Color color)
    {
        button.GetComponent<Image>().color = color;
    }

}
