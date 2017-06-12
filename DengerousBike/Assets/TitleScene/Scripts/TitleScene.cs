using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour {

	public void OnStartButtonClicked()
	{
		SceneManager.LoadScene ("main");
	}

    public void OnOptionButtonClicled()
    {
        SceneManager.LoadScene("Option");
    }
}
