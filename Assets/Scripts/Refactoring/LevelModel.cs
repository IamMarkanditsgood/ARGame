using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class LevelModel
{
    private GameObject _selectedObject;
    private Quaternion _yRotation;
    private Touch _touch;

    public void Shoot(LevelData levelData)
    {
        foreach(GameObject Obect in levelData.ListOfGunsOnScene)
        {
            if(Obect.activeInHierarchy)
            {
                Obect.GetComponent<IShoot>().ShootFromGun(levelData, Obect);
            }
        }
    }
    public void ObjectsInteraction( Test test,ETypeOfChoosedObj typeOfSelectedObj, LevelData levelData, List<ARRaycastHit> hits, ARRaycastManager ARRaycastManager)
    {
        _touch = levelData.InputScreenData.Touch;


        if (_touch.phase == TouchPhase.Began)
        {
            Ray ray = levelData.ARCamera.ScreenPointToRay(_touch.position);
            RaycastHit hitObject;

            if (levelData.IsChoosedObject)
            {
                test.SetGenericValue("1");
                PutObject(test, typeOfSelectedObj, levelData, hits);
            }

            else if (Physics.Raycast(ray, out hitObject))
            {
                if (hitObject.collider.CompareTag("Unselected"))
                {
                    hitObject.collider.gameObject.tag = "Selected";
                }
            }
        }

        _selectedObject = GameObject.FindWithTag("Selected");

        if (_touch.phase == TouchPhase.Moved && Input.touchCount == 1)
        {
            if (levelData.RotationRegime)
            {
                Rotate();
            }
            else
            {
                Move(levelData, hits, ARRaycastManager);
            }
        }
        if (_touch.phase == TouchPhase.Ended)
        {
            if (_selectedObject.CompareTag("Selected"))
            {
                _selectedObject.tag = "Unselected";
            }
        }

    }
    public void PutObject(Test test,ETypeOfChoosedObj typeOfSelectedObj, LevelData levelData, List<ARRaycastHit> hits)
    {
        test.SetGenericValue("2");
        if (typeOfSelectedObj == ETypeOfChoosedObj.Catapulte)
        {
            test.SetGenericValue("3,1");
            if (!levelData.IsCatapultPlaced)
            {
                test.SetGenericValue("4");
                GameObject obj = Object.Instantiate(levelData.ChoosedObject, hits[0].pose.position, levelData.ChoosedObject.transform.rotation);
                levelData.ListOfGunsOnScene.Add(obj);

                levelData.IsCatapultPlaced = true;
                
                levelData.IsChoosedObject = false;
            }
        }
        else
        {
            test.SetGenericValue("3,2");
            Object.Instantiate(levelData.ChoosedObject, hits[0].pose.position, levelData.ChoosedObject.transform.rotation);

            levelData.IsChoosedObject = false;
        }
        
    }
    public void Rotate()
    {
        _yRotation = Quaternion.Euler(0f, -_touch.deltaPosition.x * 0.1f, 0f);
        _selectedObject.transform.rotation = _yRotation * _selectedObject.transform.rotation;
    }
    public void Move(LevelData levelData, List<ARRaycastHit> hits, ARRaycastManager ARRaycastManager)
    {
        ARRaycastManager.Raycast(levelData.InputScreenData.TouchPosition, hits, TrackableType.Planes);
        _selectedObject.transform.position = hits[0].pose.position;
    }
}
