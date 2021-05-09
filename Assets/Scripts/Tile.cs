using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    SetColorValue setColorValue;
    TileManager tileManager;
    Renderer tileRenderer;
    private PopUpWindows popUpWindows;
    public bool customizedTile;
    public bool greenTile;
    public bool blueTile;
    public GameObject uiObject;
    bool popUpActive;
    public bool hasBeenEdited;
   

    GameObject resourceUIHolder;
    void Awake()
    {
        tileRenderer = GetComponent<Renderer>();
        resourceUIHolder = GameObject.FindGameObjectWithTag("ResourceUIHolder");
        popUpWindows = resourceUIHolder.GetComponent<PopUpWindows>();
        tileManager = resourceUIHolder.GetComponent<TileManager>();
        setColorValue = GetComponent<SetColorValue>();
    }


    void ChangeColor()
    {
        hasBeenEdited = tileManager.hasBeenEdited;

        if (tileManager.hasBeenEdited)
        {
            Debug.Log("has been edited: " + hasBeenEdited);

            if (blueTile)
            {
                tileRenderer.material.SetColor("_Color", tileManager.newColor);
                setColorValue.boolToInt(blueTile, hasBeenEdited);
                PlayerPrefs.SetInt("blueTile", setColorValue.boolToInt(blueTile, hasBeenEdited));

            }
            if (greenTile)
            {
                tileRenderer.material.SetColor("_Color", tileManager.newColor);
                setColorValue.boolToInt(greenTile, !hasBeenEdited);
                PlayerPrefs.SetInt("greenTile", setColorValue.boolToInt(greenTile, hasBeenEdited));
            }

        }
        else
        {
            Debug.Log("has been edited: " + hasBeenEdited);

            if (greenTile)
            {
                tileRenderer.material.SetColor("_Color", tileManager.green);
                setColorValue.boolToInt(greenTile, hasBeenEdited);
                PlayerPrefs.SetInt("greenTile", setColorValue.boolToInt(greenTile, hasBeenEdited));

            }
            if (blueTile)
            {
                tileRenderer.material.SetColor("_Color", tileManager.blue);
                setColorValue.boolToInt(blueTile, hasBeenEdited);
                PlayerPrefs.SetInt("blueTile", setColorValue.boolToInt(blueTile, hasBeenEdited));
            }

            if (customizedTile)
            {
                setColorValue.boolToInt(customizedTile, hasBeenEdited);
                PlayerPrefs.SetInt("blueTile", setColorValue.boolToInt(customizedTile, hasBeenEdited));
                tileRenderer.material.SetColor("_Color", tileManager.customizedColor);
            }
        }

    }
    private void OnMouseOver()
    {
        popUpActive = popUpWindows.popupActive || popUpWindows.editActive || popUpWindows.renameActive;

        if (tileManager.pressedTypeButton && !popUpActive)
        {
                if (Input.GetMouseButtonDown(0))
                {
                    int type = (int)tileManager.type;
                    switch (type)
                    {
                        case 0:
                            greenTile = true;
                            blueTile = false;
                            customizedTile = false;
                            ChangeColor();
                            break;
                        case 1:
                            blueTile = true;
                            greenTile = false;
                            customizedTile = false;
                            ChangeColor();
                            break;
                        case 2:
                            customizedTile = true;
                            greenTile = false;
                            blueTile = false;
                            ChangeColor();
                        break;
                    }
                }
            
        }
       
    }
}
