using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button button;
    public InstantiateButton instantiateButton;
    public GameObject nameWindow;
    ButtonManager buttonManager;
    [HideInInspector]
    public string inputText;
   
    [HideInInspector]
    public TMP_Text nameText;
   
    public TMP_Text customizedNameText;
    PopUpWindows popupWindows;
    ColorPicker colorPicker;
    TileManager tileManager;
    public bool AddedName;
    
    
    private void Awake()
    {
        buttonManager = GetComponent<ButtonManager>();
        tileManager = GetComponent<TileManager>();
        popupWindows = GetComponent<PopUpWindows>();
        colorPicker = GetComponent<ColorPicker>();
        button.interactable = false;
    }

    public void ReadInput(string s)
    {
        inputText = s;
        inputText = inputField.text;
        AddedName = false;
 
        button.interactable = inputText.Length > 0;
      
    }

    public void ExitWindow(string newName)
    {
        if (popupWindows.popupActive)
        {
            ChangeName(newName);
            buttonManager.OnClickCloseWindow(nameWindow.gameObject);
        }
        else
        {
            buttonManager.OnClickCloseWindow(nameWindow.gameObject);
            CustomizedButtonName(newName);
        }

    }

    public void OnClickGetNameInput()
    {
       ExitWindow(inputText);
    }

    public void CustomizedButtonName(string name)
    {
        AddedName = true;
        customizedNameText.text = name;
    }

    public void ChangeName(string newName)
    {
        if (tileManager.isGrass)
        {
            nameText = buttonManager.grassButton.GetComponentInChildren<TMP_Text>();
            nameText.text = newName;
        }
        if (tileManager.isWater)
        {
            nameText = buttonManager.waterButton.GetComponentInChildren<TMP_Text>();
            nameText.text = newName;
        }
    }

}
