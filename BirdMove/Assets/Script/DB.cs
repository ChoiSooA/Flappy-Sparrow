using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;

public class DB : MonoBehaviour
{
    GameManager theGM;
    DataSave theData;
    public static MySqlConnection SqlConn;

    static string ipAddress = "127.0.0.1";
    static string db_id = "root";
    static string db_pw = "1234";
    static string db_name = "flappy";

    /*string strConn = string.Format("server={0};uid={1};pwd={2};database={3};charset=utf8;",
                                    ipAddress,db_id,db_pw,db_name);*/

    
    void IsConnect()
    {
        if (SqlConn.State != ConnectionState.Open)
        {
            SqlConn.Open();
        }
    }

    private void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        theData = GetComponent<DataSave>();
        string strConn = string.Format("server={0};uid={1};pwd={2};database={3};charset=utf8;",
                                       ipAddress, db_id, db_pw, db_name);
        try
        {
            SqlConn = new MySqlConnection(strConn);     //sql 연결이고
        }
        catch(System.Exception e)
        {
            Debug.Log(e.ToString());
        }
        IsConnect();
        Debug.Log(SqlConn.State);
        Get_Data();
    }


    public static bool OnInsertOrUpdateRequest(string str_query)    //데이터 삽입, 업데이트시 사용
    {
        try
        {
            Debug.Log(SqlConn.State);
            MySqlCommand sqlCommand = new MySqlCommand();
            sqlCommand.Connection = SqlConn;
            sqlCommand.CommandText = str_query;


            sqlCommand.ExecuteNonQuery();
            Debug.Log("here");

            return true;
        }
        catch(System.Exception e)
        {
            Debug.Log(e.ToString());
            return false;
        }
    }
    public static bool OnInsertOrUpdateRequest(MySqlCommand sqlCommand)    //데이터 삽입, 업데이트시 사용
    {
        try
        {
            sqlCommand.ExecuteNonQuery();
            Debug.Log("here");

            return true;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            return false;
        }
    }


    
    public static List<KeyValuePair<string, int>> OnSelectRequest(string p_query)    //쿼리와 새로 받아올 테이블 이름을 받아옴
    {
        MySqlCommand cmd;
        MySqlDataReader rd = null;
        try
        {
            cmd = new MySqlCommand(p_query, SqlConn);

            Debug.Log("0");
            rd = cmd.ExecuteReader();
            Debug.Log("1");
/*
            List<string> userName = null;
            List<int> userScore = null;*/

            List<KeyValuePair<string, int>> list=new List<KeyValuePair<string, int>>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int idx = 0;
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    
                    Debug.Log((string)rd["UserName"]);
                    /*userName.Add((string)rd["UserName"]);
                    userScore.Add((int)rd["UserScore"]);*/

                    list.Insert(idx++, new KeyValuePair<string, int>((string)rd["UserName"], (int)rd["UserScore"]));

                    //dict.Add((string)rd["UserName"], (int)rd["UserScore"]);
                    
                }
            }
            list= list.OrderByDescending(y => y.Value).ToList();
            return list;
        }
        catch(System.Exception e)
        {
            Debug.Log(e.ToString());
            return null;
        }
        finally
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
    /*public static Dictionary<string, int> OnSelectRequest(string p_query)    //쿼리와 새로 받아올 테이블 이름을 받아옴
    {
        MySqlCommand cmd;
        MySqlDataReader rd = null;
        try
        {
            cmd = new MySqlCommand(p_query, SqlConn);

            Debug.Log("0");
            rd = cmd.ExecuteReader();
            Debug.Log("1");

            Dictionary<string, int> dict = new Dictionary<string, int>();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    Debug.Log((string)rd["UserName"]);
                    dict.Add((string)rd["UserName"], (int)rd["UserScore"]);
                }
            }

            return dict;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            return null;
        }
        finally
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }*/

    public void SetData()
    {
        //string p_name = theGM.playerName;
        //int p_score = theGM.playerScore;
        //string sql2 = "INSERT INTO score(UserName,UserScore) VALUES(" + p_name + "," + p_score + ");";


        string sql = "INSERT INTO score(UserName,UserScore) VALUES(@userName, @userScore);";
        MySqlCommand cmd = new MySqlCommand(sql,SqlConn);


        cmd.Parameters.AddWithValue("@userName", theGM.playerName);
        cmd.Parameters.AddWithValue("@userScore",theGM.score);

        OnInsertOrUpdateRequest(cmd);
    }

    public List<KeyValuePair<string, int>> data;

    public void Get_Data()
    {

        /*if (File.Exists(Application.dataPath + "/Record.json"))     //시작할 때 json파일 불러와 data에 넣어줌
        {
            data = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(Application.persistentDataPath + "/Record.json"));
        }*/


        data = new List<KeyValuePair<string, int>>(OnSelectRequest("SELECT Idx,UserName,UserScore FROM score;"));
        //Debug.Log(data["A"]);
    }

    private void OnApplicationQuit()
    {

        if (SqlConn != null&&SqlConn.State==ConnectionState.Open)
        {
            SqlConn.Close();
        }  
    }
}
