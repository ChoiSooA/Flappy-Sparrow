using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Bird theBird;

    public GameObject[] walls;

    public int moveSpeed=8;

    public int emptyWall = 0;


    private void Start()
    {
        theBird = FindObjectOfType<Bird>();
    }

    private void OnEnable()
    {
        ResetWallActive();

        gameObject.transform.position = new Vector3(0, 0, -16.5f);
        emptyWall = Random.Range(0, 9);
        walls[emptyWall].SetActive(false);

    }
    private void Update()
    {
        if(!theBird.isOver)
            transform.Translate(Vector3.forward * (moveSpeed* 0.5f*Time.deltaTime));
    }

    public void ResetWallActive()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].SetActive(true);
        }
    }
}
