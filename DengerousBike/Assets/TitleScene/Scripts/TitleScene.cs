using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour {
    [SerializeField]
    Animator m_transitionAnim;

	public void OnStartButtonClicked()
	{
        m_transitionAnim.SetBool("start", true);
        Invoke("StartNextScene", 1.0f);
	}

    void StartNextScene()
    {
        SceneManager.LoadScene("main");
    }

    public void OnOptionButtonClicled()
    {
        SceneManager.LoadScene("Option");
    }
}
