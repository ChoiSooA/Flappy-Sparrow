using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RankCanvas : MonoBehaviour
{
    DB theDB;
    
    [SerializeField] Text[] scoreTXT;

    private void Start()
    {
        theDB = FindObjectOfType<DB>();
    }
    public void InitScore()
    {
        scoreTXT[0].text = "None : 0";
        scoreTXT[1].text = "None : 0";
        scoreTXT[2].text = "None : 0";
    }
    public void ResetData()
    {
        InitScore();
    }

    private void OnEnable()
    {
        StartCoroutine(Delay());
    }

    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);

        var target = theDB.data.ToList();

        for (int i = 0; i < (theDB.data.Count >= 3 ? 3 : theDB.data.Count); i++)    //����� ���� ������ ����� ���� 3���� �۴ٸ� ����� ���� ������ŭ�� ���
        {
            scoreTXT[i].text = target[i].Key + " : " + target[i].Value.ToString();
        }
        StopCoroutine(Delay());

    }
}
