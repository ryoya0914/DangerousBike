using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScroll : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float StartPosition;
    [SerializeField] float EndPosition;
    [SerializeField] GameController gameController;
    [SerializeField] bool StopScroll = false;

    private ObstacleControllerRed ObsController;
    void Start()
    {
        ObsController = GetComponent<ObstacleControllerRed>();
        StartCoroutine(StartScroll());
    }

    void Update()
    {
        if (gameController.Level == 3) { speed = -1f; }
        if (gameController.Level == 4) { speed = -2f; }
        if (gameController.Level == 5) { speed = -3f; }

        if (!StopScroll)
        {
            return;
        }
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
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
