using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    string playerName;
    int playerScore;

    [SerializeField] InputField nameField;
    [SerializeField] Button startBT;
    void Update()
    {
        if (nameField.text != null) //이름 비었으면 unknown
        {
            playerName = "Unknown";
        }else if (nameField.text.Length >= 10)  //이름 넘쳤으면 버튼 비활성을 할까
        {
            startBT.interactable = false;
        }
        else
        {
            playerName = nameField.text;
        }
    }

}