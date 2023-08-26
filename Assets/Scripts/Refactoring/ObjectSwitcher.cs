using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitcher
{
    public void SwitchObject(GameObject obj)
    {
        bool currentState = obj.activeSelf;
        obj.SetActive(!currentState);
    }
}
