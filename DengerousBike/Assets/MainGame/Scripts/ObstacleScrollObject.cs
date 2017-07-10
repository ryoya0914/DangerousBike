using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScrollObject : MonoBehaviour
{
    [SerializeField] float Speed = 1.0f;
    [SerializeField] float StartPosition;
    [SerializeField] float EndPosition;

    [SerializeField]
    bool StopScroll = false;

    private ObstacleController OC;
    void Start()
    {
        OC = GetComponent<ObstacleController>();
        StartCoroutine(StartScroll());
    }

    void Update()
    {
        if (!StopScroll)
        {
            return;
        }
        transform.Translate(-1 * Speed * Time.deltaTime, 0, 0);
        if (transform.position.x <= EndPosition) ScrollEnd();
    }

    void ScrollEnd()
    {
        transform.Translate(-1 * (EndPosition - StartPosition), 0, 0);
        OC.ChangeHeight();
    }

    IEnumerator StartScroll()
    {
        yield return new WaitForSeconds(2);
        StopScroll = true;
    }

}
