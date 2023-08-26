using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIData _UIData;
    [SerializeField] private UIModel _UIModel;
    [SerializeField] private UIView _UIView;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private LevelData _levelData;

    public static event Action ActionMainMenu;
    public static event Action<LevelData> ActionShoot;
    public static event Action ActionRotate;
    public static event Action<GameObject, Color> ActionRotateColor;
    public static event Action<Button> ActionChoseObject;

    

    void Start()
    {
        _UIData.StorageButton.GetComponent<Button>().onClick.AddListener(delegate { _UIView.SwitchStorage(_UIData); });
        _UIData.MainMenuButton.GetComponent<Button>().onClick.AddListener(MainMenu);
        _UIData.ShootButton.GetComponent<Button>().onClick.AddListener(Shoot);
        _UIData.RotateButton.GetComponent<Button>().onClick.AddListener(Rotate);

        TMP_InputField TMPInputField = _UIData.InputField.GetComponent<TMP_InputField>();
        TMPInputField.onValueChanged.AddListener(delegate { _UIModel.SetForceForCatapults(_levelData,TMPInputField); });

        List<Button> list = _UIData.ObjectButtons;
        for(int i = 0;i < list.Count; i++)
        {
            int index = i;
            list[i].onClick.AddListener(delegate { CahngeObject(list[index]); });
            
        }
    }

    private void MainMenu()
    {
        ActionMainMenu?.Invoke();
    }
    private void Shoot()
    {
        ActionShoot?.Invoke(_levelData);
    }
    private void Rotate()
    {
        if (_UIData.RotateButton.GetComponent<Image>().color == Color.red)
        {
            ActionRotateColor?.Invoke(_UIData.RotateButton, Color.green);
        }
        else
        {
            ActionRotateColor?.Invoke(_UIData.RotateButton, Color.red);
        }
        ActionRotate?.Invoke();
    }
    private void CahngeObject(Button button) 
    {
        ActionChoseObject?.Invoke(button);
    }
}
