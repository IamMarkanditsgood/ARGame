using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LevelData : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _ARRaycastManager;
    [SerializeField] private Camera _ARCamera;

    [SerializeField] private GameObject _choosedObject;
    [SerializeField] private GameObject _planeMarker;
    [SerializeField] private GameObject _catapultProjectile;

    [SerializeField] private List<GameObject> _listOfGunsOnScene = new List<GameObject>();

    [SerializeField] private bool _rotationRegime;

    private InputScreenData _InputScreenData = new InputScreenData();

    private int _forceForCatapult;

    private bool _isChoosedObject = false;
    private bool _isCatapultPlaced = false;

    public ARRaycastManager ARRaycastManager
    {
        get { return _ARRaycastManager; }
    }

    public Camera ARCamera
    {
        get { return _ARCamera; }
    }

    public GameObject ChoosedObject
    {
        get { return _choosedObject; }
        set { _choosedObject = value; }
    }
    public GameObject PlaneMarker
    {
        get { return _planeMarker; }
    }
    public GameObject CatapultProjectile
    {
        get { return _catapultProjectile; }
    }
    public List<GameObject> ListOfGunsOnScene
    {
        get 
        { 
            return _listOfGunsOnScene; 
        }
    }

    public InputScreenData InputScreenData
    {
        get { return _InputScreenData; }
    }

    public int ForceForCatapult
    {
        get { return _forceForCatapult; }
        set { _forceForCatapult = value; }
    }
    public bool RotationRegime
    {
        get { return _rotationRegime; }
        set { _rotationRegime = value; }
    }
    public bool IsChoosedObject
    {
        get { return _isChoosedObject; }
        set { _isChoosedObject = value; }
    }
    public bool IsCatapultPlaced
    {
        get { return _isCatapultPlaced; }
        set { _isCatapultPlaced = value; }
    }
}
