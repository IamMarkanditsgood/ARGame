using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIData : MonoBehaviour
{
    [SerializeField] private GameObject _storage;

    [SerializeField] private GameObject _rotateButton;
    [SerializeField] private GameObject _shootButton;
    [SerializeField] private GameObject _storageButton;
    [SerializeField] private GameObject _mainMenuButton;
    [SerializeField] private GameObject _inputField;
    [SerializeField] private List<Button> _objectButtons;

    public GameObject Storage 
    { 
        get { return _storage; } 
    }  

    public GameObject RotateButton
    { 
        get { return _rotateButton; } 
    }

    public GameObject ShootButton
    {
        get { return _shootButton; }
    }
    public GameObject StorageButton
    {
        get { return _storageButton; }
    }
    public GameObject MainMenuButton
    {
        get { return _mainMenuButton; }
    }
    public GameObject InputField
    {
        get { return _inputField; }
    }
    public List<Button> ObjectButtons
    {
        get { return _objectButtons; }
        set { _objectButtons = value; }
    }
}
