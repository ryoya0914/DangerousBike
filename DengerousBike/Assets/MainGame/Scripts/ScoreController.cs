using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreLabel;
    float time = 0;
    int previousTime = 0;

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
        if (GameObject.Find("bike") == true)
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
