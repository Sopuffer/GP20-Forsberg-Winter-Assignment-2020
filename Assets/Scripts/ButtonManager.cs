using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject pickedTileWindow;
    public GameObject editWindow;
    public GameObject renameWindow;
    public GameObject grassButton;
    public GameObject waterButton;
    public GameObject newTypeButton;
    TileManager tileManager;
    PopUpWindows popupWindows;
    Image grassButtonImage;
    Image waterButtonImage;
    Image newTypeButtonImage;
    private void Awake()
    {
        pickedTileWindow.SetActive(false);
        editWindow.SetActive(false);
        renameWindow.SetActive(false);
        grassButtonImage = grassButton.GetComponent<Image>();
        waterButtonImage = waterButton.GetComponent<Image>();
        newTypeButtonImage = newTypeButton.GetComponent<Image>();

        tileManager = GetComponent<TileManager>();
        popupWindows = GetComponent<PopUpWindows>();
        grassButtonImage.color = Color.white;
        waterButtonImage.color = Color.white;
        newTypeButtonImage.color = Color.white;
      

    }
    public void OnClickChooseTile()
    {
        if (!popupWindows.editActive && !popupWindows.renameActive)
        {
            popupWindows.popupActive = false;
            popupWindows.OpenClosePopupWindow(pickedTileWindow, popupWindows.popupActive);
        }

        if (tileManager.isGrass)
        {
            if (!tileManager.hasBeenEdited)
            {
                ChangeButtonColor(grassButton, tileManager.isGrass, tileManager.green);
            }
            else
            {
                ChangeButtonColor(grassButton, tileManager.isGrass, tileManager.newColor);

            }
        }
        if (tileManager.isWater)
        {
            if (!tileManager.hasBeenEdited)
            {
                ChangeButtonColor(waterButton, tileManager.isWater, tileManager.blue);
            }
            else
            {
                ChangeButtonColor(waterButton, tileManager.isWater, tileManager.newColor);
            }
        }
    }

    public void OnClickOpenTileType()
    {
        popupWindows.popupActive = true;
        popupWindows.OpenClosePopupWindow(pickedTileWindow, popupWindows.popupActive);
    }
    public void OnClickOpenEdit()
    {
        popupWindows.editActive = true;
        popupWindows.OpenClosePopupWindow(editWindow, popupWindows.editActive);
    }
    public void OnClickOpenRename()
    {
        popupWindows.renameActive = true;
        popupWindows.OpenClosePopupWindow(renameWindow, popupWindows.renameActive);
    }

   

      public void ChangeButtonColor(GameObject button, bool buttonActive, Color chosenColor)
    {
        Image image = button.GetComponent<Image>();
        if (buttonActive)
        {
            image.color = chosenColor;
        }
    }

    public void OnClickCloseWindow(GameObject Window)
    {
        WindowResetBool(Window);
    }

    void WindowResetBool(GameObject window)
    {
        switch (window.name)
        {
            case "EditTileWindow":
                if (!popupWindows.renameActive)
                {
                    popupWindows.editActive = false;
                    popupWindows.OpenClosePopupWindow(window, popupWindows.editActive);
                }
                break;

            case "RenameTileWindow":
                popupWindows.renameActive = false;
                popupWindows.OpenClosePopupWindow(window, popupWindows.renameActive);
                break;
        }
    }
}
