using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    GameManager theGM;

    [SerializeField] InputField nameField;
    [SerializeField] Button startBT;

    private void Start()
    {
        theGM = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (nameField.text.Length == 0) //이름 비었으면 unknown
        {
            startBT.interactable = false;
        }
        else
        {
            startBT.interactable = true;
            theGM.playerName = nameField.text;
        }
    }
    private void OnEnable()
    {
        nameField.text = "";
    }

}