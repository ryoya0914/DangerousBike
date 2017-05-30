using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Localization : MonoBehaviour {
    private Text m_text;

    void Awake()
    {
        m_text = GetComponent<Text>();
        if(m_text)
            m_text.text = LocalizedText.Instance.GetWord(LocalizedText.WORDS.ACCEL);
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
