using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreLabel;
    float time = 0;
    int previousTime = 0;
    [SerializeField] BikeController bike;

    void Start()
    {
        scoreLabel.text = "Score : " + ((int)time).ToString() + "m";

    }

    void Update()
    {
        StartCoroutine(TimeStart());
    }

    IEnumerator TimeStart()
    {
        yield return new WaitForSeconds(2);
        if (!bike.Stopped)
        {
            time += Time.deltaTime;
            if ((int)time > previousTime)
            {
                previousTime++;
                scoreLabel.text = "Score : " + ((int)time).ToString() + "m";
            }
        }
        else
        {
            time = Time.deltaTime;
            if ((int)time > previousTime)
            {
                previousTime++;
                scoreLabel.text = "Score : " + ((int)time).ToString() + "m";
            }
        }
    }
}
