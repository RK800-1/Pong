using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class is responsible for
/// the UI freeze & behaviour before start
/// </summary>
public class PrepareForStart : MonoBehaviour
{
    TextUI textUI;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public void PrepareStart()
    {
        Time.timeScale = 0;
        textUI = FindObjectOfType<TextUI>();

        StartCoroutine(WaitForUserToStart());
    }

    public IEnumerator WaitForUserToStart()
    {
        textUI.WinMessage.SetActive(true);
        textUI.WinText.text = "Press any key to start";
        yield return new WaitUntil(() => Input.anyKeyDown);
        Time.timeScale = 1;
        textUI.WinMessage.SetActive(false);
    }
}
