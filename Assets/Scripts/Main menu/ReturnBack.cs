using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for
/// the switching back to the main menu
/// </summary>
public class ReturnBack : MonoBehaviour
{
    GameObject[] otherMenu;
    GameObject mmui;

    public void ReturnToMenu()
    {
        mmui = GameObject.Find("MMUI");
        otherMenu = GameObject.FindGameObjectsWithTag("OtherMenu");

        mmui.transform.localScale = new Vector3(1,1,1);

        foreach (var OMObject in otherMenu)
        {
            OMObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
