using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour {
    [SerializeField]
    Animator m_transitionAnim;
    [SerializeField]
    Text HighScoreLable;

	public void OnStartButtonClicked()
	{
        m_transitionAnim.SetBool("start", true);
        Invoke("StartNextScene", 1.0f);
	}

    void StartNextScene()
    {
        SceneManager.LoadScene("Garage");
    }

    public void OnOptionButtonClicled()
    {
        SceneManager.LoadScene("Option");
    }

    void Start()
    {
        HighScoreLable.text = "HighScore : " + (PlayerPrefs.GetInt("HighScore", 0)).ToString() + "m";
    }
}
