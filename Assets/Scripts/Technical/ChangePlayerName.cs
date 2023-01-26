using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerName : MonoBehaviour
{
    public Text PNInputPlaceholder;

    void Start()
    {
        var changePNInput = gameObject.GetComponent<InputField>();
        var savePN = new InputField.SubmitEvent();

        PNInputPlaceholder.text = PlayerPrefs.GetString("PlayerName");
        changePNInput.onEndEdit.AddListener(SubmitName);
        changePNInput.characterLimit = 10;
    }

    private void SubmitName(string playerName)
    {
        PlayerPrefs.SetString("PlayerName", playerName);
    }
}
