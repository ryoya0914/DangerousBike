using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text scoreLabel;
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
        time += Time.deltaTime;
        if ((int)time > previousTime)
        {
            previousTime++;
            scoreLabel.text = "Score : " + ((int)time).ToString() + "m";
        }
    }

    public void ScroreSave()
    {
        if (time >PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", (int)time);
        }
    }
}
