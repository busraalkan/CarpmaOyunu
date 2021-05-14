using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Image SonucBackgroundImage;
    [SerializeField]
    private Text SonucDogruText, SonucYanlisText, PuanText;
    [SerializeField]
    private GameObject TekrarOynaBtn, MenuyeDonBtn;
    float AnimasyonGecisOrani;
    bool ResimAcilsinMi;
    GameManager GameManagerObje;

    private void Awake()
    {
        GameManagerObje = Object.FindObjectOfType<GameManager>();
    }
    void OnEnable()
    {
        AnimasyonGecisOrani = 0f;
        ResimAcilsinMi = true;
        SonucDogruText.text = "";
        SonucYanlisText.text = "";
        PuanText.text = "";
        TekrarOynaBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        MenuyeDonBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        StartCoroutine(ResimRoutine());
    }
    IEnumerator ResimRoutine()
    {
        while (ResimAcilsinMi)
        {
            AnimasyonGecisOrani += 0.15f;
            SonucBackgroundImage.fillAmount = AnimasyonGecisOrani;
            yield return new WaitForSeconds(0.1f);
            if (AnimasyonGecisOrani >= 1)
            {
                AnimasyonGecisOrani = 1;
                ResimAcilsinMi = false;
                SonucDogruText.text = GameManagerObje.dogruSayisi + "DOGRU";
                SonucYanlisText.text = GameManagerObje.yanlisSayisi + "YANLIS";
                PuanText.text = GameManagerObje.Puan + "PUAN";
                TekrarOynaBtn.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
                MenuyeDonBtn.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }
    public void TekrarOynaButonu()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void MenuyeDonButonu()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
