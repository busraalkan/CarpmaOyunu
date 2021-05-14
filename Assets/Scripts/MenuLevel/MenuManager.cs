using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuPanel;
    [SerializeField]
    private GameObject SesAcKapaImage;
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioClip ButonClick;
    bool SesPaneliAcikMi;
    void Start()
    {
        PlayerPrefs.GetInt("SesDurumu", 1);
        SesPaneliAcikMi = false;
        MenuPanel.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        MenuPanel.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutBack);
    }
    public void OynaButonu()
    {
        if (PlayerPrefs.GetInt("SesDurumu") == 1)
        {
            AudioSource.PlayOneShot(ButonClick);
        }
        SceneManager.LoadScene("IkinciMenuLevel");
    }
    public void AyarlarButonu()
    {
        if (PlayerPrefs.GetInt("SesDurumu") == 1)
        {
            AudioSource.PlayOneShot(ButonClick);
        }
        if (!SesPaneliAcikMi)
        {
            SesAcKapaImage.GetComponent<RectTransform>().DOLocalMoveY(-102, 0.4f);
            SesPaneliAcikMi = true;
        }
        else
        {
            SesAcKapaImage.GetComponent<RectTransform>().DOLocalMoveY(-63, -0.4f);
            SesPaneliAcikMi = false;
        }
    }
    public void CıkisButonu()
    {
        if (PlayerPrefs.GetInt("SesDurumu") == 1)
        {
            AudioSource.PlayOneShot(ButonClick);
        }
        Application.Quit();
    }
}
