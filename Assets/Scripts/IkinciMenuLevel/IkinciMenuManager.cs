using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class IkinciMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject IkinciMenuPanel;
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioClip ButonClick;
    void Start()
    {
        IkinciMenuPanel.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        IkinciMenuPanel.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutBack);
    }
    public void OyunSec(string hangiOyun)
    {
        if (PlayerPrefs.GetInt("SesDurumu") == 1)
        {
            AudioSource.PlayOneShot(ButonClick);
        }
        PlayerPrefs.SetString("hangiOyun", hangiOyun);
        SceneManager.LoadScene("GameLevel");
    }
    public void GeriDonButonu()
    {
        if (PlayerPrefs.GetInt("SesDurumu") == 1)
        {
            AudioSource.PlayOneShot(ButonClick);
        }
        SceneManager.LoadScene("MenuLevel");
    }
}
