using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizedText : MonoBehaviour {

    //Singleton stuff-----------------------------------------------------------
    private static LocalizedText m_instance;
    public static LocalizedText Instance { get { return m_instance; } }

    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            m_instance = this;
            Initialize();
            DontDestroyOnLoad(this.gameObject);
        }
    }

    //LocalizedText ------------------------------------------------------------

    private int m_currentLanguage = 0;
    //For playerprefs
    private string m_languageKey = "currentLanguage";

    public enum LANGUAGES
    {
        NONE,
        ENGLISH,
        JAPANESE,
        SPANISH,
        LANGUAGE_MAX
    };

    struct UIWord
    {
        private string english;
        private string japanese;
        private string spanish;

        public UIWord(string en, string jp, string es)
        {
            english = en;
            japanese = jp;
            spanish = es;
        }

        public string GetWord(LANGUAGES lang)
        {
            switch (lang)
            {
                case LANGUAGES.ENGLISH:
                    return english;

                case LANGUAGES.JAPANESE:
                    return japanese;

                case LANGUAGES.SPANISH:
                    return spanish;
            }

            return " ";
        }
    };


    public enum WORDS
    {
        ACCEL,
        BRAKE
    };

    private UIWord[] m_words = new UIWord[]
    {
        new UIWord("ACCEL", "アクセル", "ACELERAR"),
        new UIWord("BRAKE", "ブレーキ", "FRENAR")
    };

	private void Initialize ()
    {
        if (m_currentLanguage != (int)LANGUAGES.NONE)
            return;

        m_currentLanguage = PlayerPrefs.GetInt(m_languageKey, 0);

        if (m_currentLanguage == (int)LANGUAGES.NONE || m_currentLanguage >= (int)LANGUAGES.LANGUAGE_MAX)
        {
            SetLanguageToSystem();
        }
    }

    private void SetLanguageToSystem()
    {
        var sysLang = Application.systemLanguage;
        switch (sysLang)
        {
            case SystemLanguage.English:
                m_currentLanguage = (int)LANGUAGES.ENGLISH;
                break;

            case SystemLanguage.Japanese:
                m_currentLanguage = (int)LANGUAGES.JAPANESE;
                break;

            case SystemLanguage.Spanish:
                m_currentLanguage = (int)LANGUAGES.SPANISH;
                break;

            default:
                m_currentLanguage = (int)LANGUAGES.ENGLISH;
                break;
        }

        PlayerPrefs.SetInt(m_languageKey, m_currentLanguage);
    }

    public void ChangeLanguage(LANGUAGES lang)
    {
        m_currentLanguage = (int)lang;
    }

    public string GetWord(WORDS word)
    {
        return m_words[(int)word].GetWord((LANGUAGES)m_currentLanguage);
    }
}
