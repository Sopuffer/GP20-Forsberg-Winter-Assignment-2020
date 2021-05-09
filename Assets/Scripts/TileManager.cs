using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TileManager : MonoBehaviour
{
    public GameObject customizedButton;
    public ButtonManager buttonManager;
    public Color blue;
    public Color green;
    [HideInInspector]
    public Color newColor;
    [HideInInspector]
    public Color customizedColor;
    [HideInInspector]
    public TMP_Text customizedNameText;

    public bool isGrass;
    public bool isWater;
    public bool isCustomized;
    public bool hasBeenEdited;
    public bool pressedTypeButton;
    public Vector3 customizedButtonPos;
    public Transform buttonsParent;

    NameManager nameManager;
    PopUpWindows popupWindows;
    ColorPicker colorPicker;
    Image grassColor;
    Image waterColor;
    Image testColor;
    public bool hasCreatedButton;
    public enum TileTypes
    {
        Grass = 0,
        Water = 1,
        Customized = 2
    }


    public TileTypes type;
    public List<GameObject> tiles;
    public List<Tile> tileScripts;
    private void Awake()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            tileScripts.Add(tiles[i].GetComponent<Tile>());
        }

        popupWindows = GetComponent<PopUpWindows>();
        nameManager = GetComponent<NameManager>();
        colorPicker = GetComponent<ColorPicker>();
        grassColor = buttonManager.grassButton.GetComponent<Image>();
        waterColor = buttonManager.waterButton.GetComponent<Image>();
        grassColor.color = Color.white;
        waterColor.color = Color.white;

    }

    private void Start()
    {
        isGrass = false;
        isWater = false;
    }

    public void UpdateExistingTiles()
    {
        if (hasBeenEdited)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                SpriteRenderer tileRenderer = tiles[i].GetComponent<SpriteRenderer>();

                if (isGrass && tileScripts[i].greenTile)
                {
                    tileRenderer.material.color = newColor;
                }

                if (isWater && tileScripts[i].blueTile)
                {
                    tileRenderer.material.color = newColor;
                }
            }
        }
    }

    public void OnClickAssignTileType(int state)
    {
        type = (TileTypes)state;

        if (!pressedTypeButton)
            pressedTypeButton = true;
        if (hasBeenEdited)
            hasBeenEdited = false;
             
        switch (type)
               {
                case TileTypes.Grass:
                    if (!popupWindows.editActive)
                    {
                        grassColor.color = Color.yellow;
                        waterColor.color = Color.white;
                        popupWindows.popupActive = true;
                        popupWindows.OpenClosePopupWindow(buttonManager.pickedTileWindow, popupWindows.popupActive);
                        if (testColor != null)
                        {
                            testColor.color = Color.white;
                        }
                        isGrass = true;
                        isWater = false;
                    }
                    break;

                case TileTypes.Water:

                    if (!popupWindows.editActive)
                    {
                        waterColor.color = Color.yellow;
                        grassColor.color = Color.white;
                        popupWindows.popupActive = true;
                        popupWindows.OpenClosePopupWindow(buttonManager.pickedTileWindow, popupWindows.popupActive);
                        if (testColor != null)
                        {
                            testColor.color = Color.white;
                        }
                        isWater = true;
                        isGrass = false;

                    }
                    break;

                case TileTypes.Customized:
                    grassColor.color = Color.white;
                    waterColor.color = Color.white;
                    if (testColor != null)
                    {
                        testColor.color = customizedColor;
                    }
                    isCustomized = true;
                    isGrass = false;
                    isWater = false;
                    break;

        }
    
    }

    public void CustomizedTypeButton(GameObject go)
    {
        if (!hasCreatedButton)
        {
            hasCreatedButton = true;
        }
        go.transform.SetParent(buttonsParent);
        go.transform.localPosition = new Vector3(customizedButtonPos.x, customizedButtonPos.y, customizedButtonPos.z);
        Image image = go.gameObject.GetComponent<Image>();
        testColor = image;
        image.color = customizedColor;
        if (nameManager.AddedName)
        {
            customizedNameText = go.GetComponentInChildren<TMP_Text>();
            customizedNameText.text = CustomizedName();
        }
        Button button = go.gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => OnClickAssignTileType((int)TileTypes.Customized));
        OnClickAssignTileType((int)TileTypes.Customized);
    }

    public void InstantiateTileButton()
    {
        if (hasCreatedButton)
        {
            GameObject lastGameObject = buttonsParent.transform.GetChild(buttonsParent.childCount - 1).gameObject;
            Destroy(lastGameObject.gameObject);
            GameObject g = Instantiate(customizedButton);
            CustomizedButtonContent(g);
        }
        else
        {
            GameObject go = Instantiate(customizedButton);
            CustomizedButtonContent(go);
        }
    }

    public string CustomizedName()
    {
        string name = nameManager.customizedNameText.text;
        return name;
    }
    void CustomizedButtonContent(GameObject customizedButton)
    {
        customizedColor = colorPicker.getColor();
        CustomizedTypeButton(customizedButton);
    }
}
