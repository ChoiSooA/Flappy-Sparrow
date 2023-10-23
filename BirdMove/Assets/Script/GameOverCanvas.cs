using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    PlayCanvas thePlayCanvas;
    GameManager theGM;

    public Text nowScore;
    public Text highScore;

    private void Awake()
    {
        theGM = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        //나는 행복합니다 ~;

        nowScore.text = theGM.score.ToString();
        highScore.text = theGM.highScore.ToString();


    }

}
