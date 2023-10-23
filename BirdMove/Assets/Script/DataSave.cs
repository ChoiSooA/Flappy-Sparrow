using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataSave : MonoBehaviour
{
    [SerializeField] Text txt_gold;
    [SerializeField] Text txt_silver;
    [SerializeField] Text txt_bronze;
    private void OnEnable()
    {
        txt_gold.text = PlayerPrefs.HasKey("1") ? PlayerPrefs.GetInt("1").ToString() : "0";

        txt_silver.text = PlayerPrefs.HasKey("2") ? PlayerPrefs.GetInt("2").ToString() : "0";
        
        txt_bronze.text = PlayerPrefs.HasKey("3") ? PlayerPrefs.GetInt("3").ToString() : "0";
        
    }

    void InitScore()
    {
        txt_gold.text = "0";
        txt_silver.text = "0";
        txt_bronze.text = "0";
    }


    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        InitScore();
    }
}
