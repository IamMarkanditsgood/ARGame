using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseObjButtonData : MonoBehaviour
{
    [SerializeField] private GameObject _obj;

    public GameObject Obj { get { return _obj; } }
}
