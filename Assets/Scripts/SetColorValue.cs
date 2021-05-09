using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorValue : MonoBehaviour
{
    int colorValue;
    Tile tile;

    private void Start()
    {
        tile = GetComponent<Tile>();
    }
    public int boolToInt(bool val, bool editedTile)
    {
        if (val == tile.blueTile)
        {
            if (editedTile)
            {
                colorValue = 1;

            }
            else
            {
                colorValue = 2;
            }

            return colorValue;
        }

        if (val == tile.greenTile)
        {
            if (editedTile)
            {
                colorValue = 3;

            }
            else
            {
                colorValue = 4;
            }
            return colorValue;
        }

        if (val == tile.customizedTile)
        {
            if (editedTile)
            {
                colorValue = 5;
            }
            else
            {
                colorValue = 6;
            }

            return colorValue;
        }
        else
        {
            colorValue = 0;
            return colorValue;
        }

    }

    public bool IntToGreenTile(int val)
    {
        if (val != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IntToBlueTile(int val)
    {
        if (val != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IntToCustomizedGreenTile(int val)
    {
        if (val != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IntToCustomizedBlueTile(int val)
    {
        if (val != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IntToCustomizedTile(int val)
    {
        if (val != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
