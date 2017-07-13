using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScrollObject : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float StartPosition;
    [SerializeField] float EndPosition;
    [SerializeField] bool StopScroll = false;
    [SerializeField] GameController gameController;
    private ObstacleController OC;
    void Start()
    {
        OC = GetComponent<ObstacleController>();
        StartCoroutine(StartScroll());
    }

    void Update()
    {
        if (gameController.Level == 1) { speed = 1; }
        if (gameController.Level == 2) { speed = 2; }
        if (gameController.Level == 3) { speed = 4; }
        if (gameController.Level == 4) { speed = 6; }
        if (gameController.Level == 5) { speed = 8; }

        if (!StopScroll)
        {
            return;
        }
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
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
