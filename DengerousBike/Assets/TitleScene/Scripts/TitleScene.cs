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
    [SerializeField] AudioSource ButtonSound;
    [SerializeField] AudioSource MoveSceneSound;
    [SerializeField] AudioSource Maincamera;

    void Start()
    {
        HighScoreLable.text = "HighScore : " + (PlayerPrefs.GetInt("HighScore", 0)).ToString() + "m";
    }

	public void OnStartButtonClicked()
	{
        MoveScene();
        m_transitionAnim.SetBool("start", true);
        ButtonSound.Play();
        Invoke("StartNextScene", 2.5f);

	}

    void StartNextScene()
    {
        SceneManager.LoadScene("Garage");

    }

    void MoveScene()
    {
        Maincamera.GetComponent<AudioSource>().Stop();
        MoveSceneSound.time = 2f;
        MoveSceneSound.Play();
    }

    public void OnOptionButtonClicled()
    {
        SceneManager.LoadScene("Option");
    }
}
