using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionScene : MonoBehaviour {

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    GameObject LangSelPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnLanguageButtonClicked()
    {
        Instantiate(LangSelPrefab, canvas.transform);
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("Title");
    }
}
