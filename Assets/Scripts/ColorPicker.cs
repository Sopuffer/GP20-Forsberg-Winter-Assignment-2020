using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ColorPicker : MonoBehaviour
{
    public Image image;
    public GameObject instantiatedButton;
    public GameObject editWindow;
  
    
    public Button button;
    
    float r = 1f;
    float g = 1f;
    float b = 1f;
    int type = 2;
    Color currentColor;
    TileManager tileManager;
    PopUpWindows popupWindows;
    NameManager nameManager;

    public bool newButton;
    private void Awake()
    {
        nameManager = GetComponent<NameManager>();
        popupWindows = GetComponent<PopUpWindows>();
        tileManager = GetComponent<TileManager>();
    }
    private void Start()
    {
        SetColor();
    }
    private void Update()
    {
       button.interactable = popupWindows.popupActive || nameManager.AddedName;
    }
    public void SetRed(float red)
    {
        r = red;
        SetColor();
        tileManager.hasBeenEdited = true;
    }
    public void SetGreen(float green)
    {
        g = green;
        SetColor();
        tileManager.hasBeenEdited = true;
    }
    public void SetBlue(float blue)
    {
        b = blue;
        SetColor();
        tileManager.hasBeenEdited = true;
    }

    void SetColor()
    {
        currentColor = new Color(r,g,b);
        image.color = currentColor;
    }

    public Color getColor()
    {
        return currentColor;
    }

    public void OnClickChooseColor()
    {
        if (popupWindows.popupActive)
        {
            tileManager.newColor = currentColor;
            tileManager.UpdateExistingTiles();
        }
        else
        {

            tileManager.InstantiateTileButton();
            nameManager.AddedName = false;
        }
        popupWindows.editActive = false;
        popupWindows.OpenClosePopupWindow(editWindow.gameObject, popupWindows.editActive);
    }
    

 

}
