using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanguageSelection : MonoBehaviour {

    [SerializeField]
    Button englishButton;
    [SerializeField]
    Button japaneseButton;
    [SerializeField]
    Button spanishButton;

    void Awake()
    {
        UpdateSelection();
    }	

    void UpdateSelection()
    {
        englishButton.interactable = true;
        spanishButton.interactable = true;
        japaneseButton.interactable = true;

        var currentLang = Localization.Instance.GetCurrentLanguage();

        switch(currentLang)
        {
            case (int)Localization.LANGUAGES.ENGLISH:
                englishButton.interactable = false;
                break;

            case (int)Localization.LANGUAGES.SPANISH:
                spanishButton.interactable = false;
                break;

            case (int)Localization.LANGUAGES.JAPANESE:
                japaneseButton.interactable = false;
                break;
        }
    }

    public void OnEnglishButtonClicked()
    {
        Localization.Instance.ChangeLanguage(Localization.LANGUAGES.ENGLISH);
        UpdateSelection();
    }

    public void OnSpanishButtonClicked()
    {
        Localization.Instance.ChangeLanguage(Localization.LANGUAGES.SPANISH);
        UpdateSelection();
    }

    public void OnJapaneseButtonClicked()
    {
        Localization.Instance.ChangeLanguage(Localization.LANGUAGES.JAPANESE);
        UpdateSelection();
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("Option");
    }
}
