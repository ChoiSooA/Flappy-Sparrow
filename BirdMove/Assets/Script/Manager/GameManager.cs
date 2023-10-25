using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayCanvas thePlayCanvas;

    public GameObject playCanvas;


    public int score = 0;
    public int highScore = 0;

    public string playerName;
    public int playerScore;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (thePlayCanvas == null)
        {
            thePlayCanvas = playCanvas.GetComponent<PlayCanvas>();
        }
    }

    public void ScoreUp()
    {
        score++;
        thePlayCanvas.scoreTxt.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
        }
    }

    


}
