using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstantiateButton : PopUpWindows
{
    public GameObject customizedButton;
    public GameObject editWindow;
    public GameObject resourceUIHolder;
    PopUpWindows popUpWindows;
    private void Awake()
    {
        popUpWindows = resourceUIHolder.GetComponent<PopUpWindows>();
    }

    public bool TileWindowActive()
    {
        if (popUpWindows.popupActive)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void OnCLickOpenEdit()
    {
        popUpWindows.editActive = true;
        popUpWindows.OpenClosePopupWindow(editWindow, popUpWindows.editActive);
    }
  
}
