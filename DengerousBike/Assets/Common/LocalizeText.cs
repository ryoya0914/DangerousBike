using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour {
    private Text m_text;
    public Localization.WORDS word;

    void Awake()
    {
        m_text = GetComponent<Text>();
        if (m_text)
            m_text.text = Localization.Instance.GetWord(word);
    }
}
