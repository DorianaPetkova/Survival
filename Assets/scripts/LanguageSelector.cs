using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageSelector : MonoBehaviour
{
    public GameObject EN;
    public GameObject BG;
    private const string SelectedLanguageKey = "SelectedLanguage";
    void Start()
    {

        int selectedLanguage = PlayerPrefs.GetInt(SelectedLanguageKey, 0);
        SetLanguage(selectedLanguage);

    }
    private void SetLanguage(int languageId)
    {
        if (languageId == 0) // Bulgarian
        {
            BG.SetActive(false);
            EN.SetActive(true);
        }
        else if (languageId == 1) // English
        {
            BG.SetActive(true);
            EN.SetActive(false);
        }
    }
    public void English()
    {
        PlayerPrefs.SetInt(SelectedLanguageKey, 1); // Save English as selected language
        SetLanguage(1);
    }

    public void Bulgarian()
    {
        PlayerPrefs.SetInt(SelectedLanguageKey, 0); // Save Bulgarian as selected language
        SetLanguage(0);
    }
    private bool active = false;
    public void Change(int id)
    {
        if (active == true)
            return;
        StartCoroutine(SetLocale(id));

    }
    IEnumerator SetLocale(int id)
    {
        active = true;

        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
        active = false;
    }
    // Start is called before the first frame update

}
