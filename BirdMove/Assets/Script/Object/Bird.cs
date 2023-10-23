using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    BirdController theBirdController;
    PlayCanvas thePlay;
    GameManager theGM;
    WallManager theWallManager;

    public Vector3 startPos;

    public float[] xPos= new float[3];  //»õ ÁÂ¿ì À§Ä¡ ÁÂÇ¥ 

    public bool isOver = false;

    private void Start()
    {
        theBirdController = FindObjectOfType<BirdController>();
        thePlay = FindObjectOfType<PlayCanvas>();
        theGM = FindObjectOfType<GameManager>();
        theWallManager = FindObjectOfType<WallManager>();

        startPos = transform.position;

        PositionSetting();
    }
    public void Init()
    {
        theGM.score = 0;
        gameObject.transform.position = startPos;
        isOver = false;
        theBirdController.nowCountPos=1;
    }

    

    public void PositionSetting()
    {
        xPos[0] = 1.2f;
        xPos[1] = 0;
        xPos[2] = -1.2f;
    }


    private void OnTriggerEnter(Collider other) //º®¿¡ ºÎµúÈú¶§
    {
        if (other.CompareTag("Wall"))   //GameOver Collider
        {
            other.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            isOver = true;
            gameObject.GetComponent<Animator>().Play("Death");
            thePlay.gameoverCanvas.SetActive(true);
            thePlay.controllerCanvas.SetActive(false);

            Debug.Log("GameOver");
            theGM.Bigyo();
        }
        else if (other.CompareTag("ScoreUp"))   //ScoreUp Collider
        {
            StartCoroutine(RemoveAll(other));
            theGM.ScoreUp();
        }
    }

    IEnumerator RemoveAll(Collider obj)
    { 
        yield return new WaitForSeconds(0.2f);
        obj.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
    }


}
