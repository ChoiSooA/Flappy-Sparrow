using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    Bird theBird;

    private void Awake()
    {
        theBird = FindObjectOfType<Bird>();
    }
    private void OnEnable()
    {
        StartCoroutine(WallActive());
    }


    IEnumerator WallActive()
    {
        while (!theBird.isOver)
        {
            GameObject wall= WallPool.Instance.GetPoolOnject();

            if (wall != null)
            {
                wall.SetActive(true);

                yield return new WaitForSeconds(3f);
            }
            yield return null;
        }

    }


}
