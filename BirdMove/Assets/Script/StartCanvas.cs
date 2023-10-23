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
        if (nameField.text != null) //�̸� ������� unknown
        {
            playerName = "Unknown";
        }else if (nameField.text.Length >= 10)  //�̸� �������� ��ư ��Ȱ���� �ұ�
        {
            startBT.interactable = false;
        }
        else
        {
            playerName = nameField.text;
        }
    }

}