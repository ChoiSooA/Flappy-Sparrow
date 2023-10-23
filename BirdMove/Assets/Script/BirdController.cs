using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public int nowCountPos=1;

    Bird theBird;


    private void Start()
    {
        theBird = FindObjectOfType<Bird>();
    }

    private void Update()
    {
        #region  컴퓨터 플레이 테스트 위한 입력키
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Left();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Right();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        #endregion
    }
     
    public void Left()
    {
        if(nowCountPos>0)
        {
            nowCountPos--;
            StartCoroutine(MoveBird());
        }
    }

    public void Right()
    {
        if(nowCountPos<2)
        {
            nowCountPos++;
            StartCoroutine(MoveBird());
        }
    }

    public void Jump()
    {
        theBird.gameObject.GetComponent<Animator>().Play("Jump");
        theBird.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*250f, ForceMode.Force);
    }

    IEnumerator MoveBird()
    {
        while (theBird.gameObject.transform.position != new Vector3(theBird.xPos[nowCountPos], theBird.gameObject.transform.position.y, theBird.gameObject.transform.position.z))
        {
            theBird.gameObject.transform.position = Vector3.Lerp(theBird.gameObject.transform.position,
                                                     new Vector3(theBird.xPos[nowCountPos], theBird.gameObject.transform.position.y, theBird.gameObject.transform.position.z),
                                                     5f * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(MoveBird());
        yield return null;
    }

}
