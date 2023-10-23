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
        #region  ��ǻ�� �÷��� �׽�Ʈ ���� �Է�Ű
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
        }
    }

    public void Right()
    {
        if(nowCountPos<2)
        {
            nowCountPos++;
        }
    }

    public void Jump()
    {
        theBird.gameObject.GetComponent<Animator>().Play("Jump");
        theBird.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*250f, ForceMode.Force);
    }


    
}
