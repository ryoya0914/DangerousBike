using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScroll : MonoBehaviour
{
    [SerializeField]
    float Speed = 1.0f;
    [SerializeField]
    float StartPosition;
    [SerializeField]
    float EndPosition;

    [SerializeField]
    bool StopScroll = false;

    private ObstacleControllerRed ObsController;
    void Start()
    {
        ObsController = GetComponent<ObstacleControllerRed>();
        StartCoroutine(StartScroll());
    }

    void Update()
    {
        if (!StopScroll)
        {
            return;
        }
        transform.Translate(-1 * Speed * Time.deltaTime, 0, 0);
        if (transform.position.x >= EndPosition) ScrollEnd();
    }

    void ScrollEnd()
    {
        transform.Translate(-1 * (EndPosition - StartPosition), 0, 0);
        ObsController.ChangeHeight();
    }

    IEnumerator StartScroll()
    {
        yield return new WaitForSeconds(2);
        StopScroll = true;
    }

}
