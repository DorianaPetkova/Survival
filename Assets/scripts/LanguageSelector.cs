using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageSelector : MonoBehaviour
{
    public GameObject EN;
    public GameObject BG;
    void Start()
    {
        EN.SetActive(false);
        BG.SetActive(true);
    }
    public void English()
    {
        BG.SetActive(true);
        EN.SetActive(false);
    }
    public void Bulgarian()
    {
        BG.SetActive(false);
        EN.SetActive(true);
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
