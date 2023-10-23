using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayCanvas thePlayCanvas;

    public GameObject playCanvas;


    public int score = 0;
    public int highScore = 0;

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
    public void Bigyo()
    {

        if (PlayerPrefs.GetInt("1") < highScore)
        {
            PlayerPrefs.SetInt("3", PlayerPrefs.GetInt("2"));
            PlayerPrefs.SetInt("2", PlayerPrefs.GetInt("1"));
            PlayerPrefs.SetInt("1", highScore);

        }
        else if (PlayerPrefs.GetInt("2") < highScore)
        {
            PlayerPrefs.SetInt("3", PlayerPrefs.GetInt("2"));
            PlayerPrefs.SetInt("2", highScore);
        }
        else if(PlayerPrefs.GetInt("3") < highScore)
        {
            PlayerPrefs.SetInt("3", highScore);
        }
    }


}
