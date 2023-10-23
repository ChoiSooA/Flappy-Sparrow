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


        Debug.Log("1등 데이터는 : " + PlayerPrefs.GetInt("1"));
        Debug.Log("2등 데이터는 : " + PlayerPrefs.GetInt("2"));
        Debug.Log("3등 데이터는 : " + PlayerPrefs.GetInt("3"));
    }
}
