using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private UIModel _UIModel;
    [SerializeField] private Test test;

    private LevelView _levelView = new LevelView();
    private LevelModel _levelModel = new LevelModel();
    private InputUserController _inputUserController = new InputUserController();

    private RaycastController _raycastController = new RaycastController();

    private void Update()
    {
        List<ARRaycastHit> hits = _raycastController.GetPointOfReycast(_levelData.ARRaycastManager);

        if (_levelData.IsChoosedObject)
        {
            _levelView.ShowMarker(_levelData.PlaneMarker, hits);
           
        }
        else
        {
            _levelData.PlaneMarker.SetActive(false);
        }
        if (_inputUserController.Is—lickOnScreen(_levelData.InputScreenData))
        {
            ETypeOfChoosedObj eTypeOfChoosedObj = _levelData.ChoosedObject.GetComponent<ChoosedObjData>().TypeOfChoosedObject;
            _levelModel.ObjectsInteraction(test ,eTypeOfChoosedObj, _levelData, hits, _levelData.ARRaycastManager);
        }
    }
    private void OnEnable()
    {
        UIController.ActionChoseObject += ChangeObject;
        UIController.ActionRotate += RotateObject;
        UIController.ActionShoot += _levelModel.Shoot;

    }

    private void OnDisable()
    {
        UIController.ActionChoseObject -= ChangeObject;
        UIController.ActionRotate -= RotateObject;
        UIController.ActionShoot -= _levelModel.Shoot;
    }
    public void ChangeObject(Button button)
    {
        
        _levelData.ChoosedObject = button.GetComponent<ChooseObjButtonData>().Obj;
        _levelData.IsChoosedObject = true;
    }
    public void RotateObject()
    {
        if (_levelData.RotationRegime)
        {
            _levelData.RotationRegime = false;
        }
        else
        {
            _levelData.RotationRegime = true;
        }
    }
}
