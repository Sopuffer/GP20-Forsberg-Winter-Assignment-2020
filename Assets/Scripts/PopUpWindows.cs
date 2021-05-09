using UnityEngine;
using UnityEngine.Serialization;

public class PopUpWindows : MonoBehaviour
{

    public bool popupActive;
    public bool editActive;
    public bool renameActive;
    public void OpenClosePopupWindow(GameObject window, bool objectActive)
    {
            if (objectActive)
            {
                window.SetActive(true);
            }
            else
            {
                window.SetActive(false);
            }

    }
  
}
