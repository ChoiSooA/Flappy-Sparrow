using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCanvas : MonoBehaviour
{
    GameManager theGM;

    public GameObject controllerCanvas;
    public GameObject gameoverCanvas;

    public Text scoreTxt;

    private void Start()
    {
        theGM = FindObjectOfType<GameManager>();

    }
    private void OnEnable()
    {
        scoreTxt.text = "0";

    }
}
