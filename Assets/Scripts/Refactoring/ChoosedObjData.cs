using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosedObjData : MonoBehaviour
{
    [SerializeField] private ETypeOfChoosedObj _typeOfChoosedObject;
    public ETypeOfChoosedObj TypeOfChoosedObject { get { return _typeOfChoosedObject; } set { _typeOfChoosedObject = value;  } }
}
