using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    PlayCanvas thePlayCanvas;
    GameManager theGM;
    //DataSave theData;
    DB theDB;

    public Text nowScore;
    public Text highScore;

    private void Awake()
    {
        theGM = FindObjectOfType<GameManager>();
        //theData = FindObjectOfType<DataSave>();
        theDB = FindObjectOfType<DB>();
    }

    private void OnEnable()
    {
        //나는 행복합니다 ~;

        nowScore.text = theGM.score.ToString();

        highScore.text = theDB.data[0].Value.ToString();

    }

}
