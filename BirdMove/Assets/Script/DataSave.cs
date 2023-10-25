using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

public class DataSave : MonoBehaviour
{

    //public Dictionary<string, int> data =null;
    public List<KeyValuePair<string, int>> data;

    /*public void Get_Data()
    {

        if (File.Exists(Application.dataPath + "/Record.json"))     //시작할 때 json파일 불러와 data에 넣어줌
        {
            data = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(Application.persistentDataPath + "/Record.json"));
        }


        data = new List<KeyValuePair<string, int>>(DB.OnSelectRequest("SELECT Idx,UserName,UserScore FROM score;"));
        //Debug.Log(data["A"]);
    }*/


    string jsonStr;
    private void OnApplicationQuit()                                //게임 종료될 때 data 기록들 json에 넣어줌
    {
        jsonStr = JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.persistentDataPath + "/Record.json", jsonStr);
    }
}
