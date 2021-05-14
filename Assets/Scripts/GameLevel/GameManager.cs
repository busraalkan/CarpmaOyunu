using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BaslaYazisiImage, DogruIkonu, YanlisIkonu;
    [SerializeField]
    private Text SoruText;
    [SerializeField]
    private Text[] Cevaplar = new Text[3];
    [SerializeField]
    private Text DogruSayisiText, YanlisSayisiText, PuanText;
    string KacliCarpma;
    int BirinciCarpan, IkinciCarpan;
    int rastgeleDeger1, rastgeleDeger2;
    int DogruCevap, YanlisCevap1, YanlisCevap2;
    public int dogruSayisi, yanlisSayisi, Puan;
    AdMobManager AdMobManagerObje;
    void Start()
    {
        AdMobManagerObje = Object.FindObjectOfType<AdMobManager>();
        IkonlariKapat();
        if (PlayerPrefs.HasKey("hangiOyun"))
        {
            KacliCarpma = PlayerPrefs.GetString("hangiOyun");
        }
        StartCoroutine(BaslaYazisiRoutine());
        AdMobManagerObje.ShowBanner();
    }
    IEnumerator BaslaYazisiRoutine()
    {
        BaslaYazisiImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.5f);
        BaslaYazisiImage.GetComponent<RectTransform>().DOScale(0f, 1f).SetEase(Ease.InBack);
        BaslaYazisiImage.GetComponent<CanvasGroup>().DOFade(0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        OyunaBasla();
    }
    void OyunaBasla()
    {
        SoruyuSor(); 
        PlayerManager.RotateAktifligi = true;
    }
    void BirinciCarpaniAyarla()
    {
        switch (KacliCarpma)
        {
            case "Iki":
                BirinciCarpan = 2;
                break;
            case "Uc":
                BirinciCarpan = 3;
                break;
            case "Dort":
                BirinciCarpan = 4;
                break;
            case "Bes":
                BirinciCarpan = 5;
                break;
            case "Alti":
                BirinciCarpan = 6;
                break;
            case "Yedi":
                BirinciCarpan = 7;
                break;
            case "Sekiz":
                BirinciCarpan = 8;
                break;
            case "Dokuz":
                BirinciCarpan = 9;
                break;
            case "On":
                BirinciCarpan = 10;
                break;
            case "Rastgele":
                BirinciCarpan = Random.Range(2, 11);
                break;
        }
    }
    void SoruyuSor()
    {
        BirinciCarpaniAyarla();
        IkinciCarpan = Random.Range(2, 11);
        rastgeleDeger1 = Random.Range(1, 100);
        if (rastgeleDeger1 <= 50)
        {
            SoruText.text = BirinciCarpan.ToString() + "*" + IkinciCarpan.ToString();
        }
        else
        {
            SoruText.text = IkinciCarpan.ToString() + "*" + BirinciCarpan.ToString();
        }
        DogruCevap = BirinciCarpan * IkinciCarpan;
        SecenekleriDoldur();
    }
    void SecenekleriDoldur()
    {
        YanlisCevap1 = DogruCevap + Random.Range(2, 10);
        YanlisCevap2 = Mathf.Abs(DogruCevap - Random.Range(2, 7));
        rastgeleDeger2 = Random.Range(1, 99);

        if (rastgeleDeger2 <= 33)
        {
            Cevaplar[0].text = DogruCevap.ToString();
            Cevaplar[1].text = YanlisCevap1.ToString();
            Cevaplar[2].text = YanlisCevap2.ToString();
        }
        else if (rastgeleDeger2 > 33 && rastgeleDeger2 <= 66)
        {
            Cevaplar[0].text = YanlisCevap2.ToString();
            Cevaplar[1].text = DogruCevap.ToString();
            Cevaplar[2].text = YanlisCevap1.ToString();
        }
        else if (rastgeleDeger2 > 66 && rastgeleDeger2 <= 99)
        {
            Cevaplar[0].text = YanlisCevap2.ToString();
            Cevaplar[1].text = YanlisCevap1.ToString();
            Cevaplar[2].text = DogruCevap.ToString();
        }
    }
    public void CevabiKontrolEt(int KullaniciCevabi)
    {
        IkonlariKapat();
        if (KullaniciCevabi == DogruCevap)
        {
            dogruSayisi++;
            DogruIkonu.GetComponent<RectTransform>().DOScale(1f, 0.1f).SetEase(Ease.InBack);
            Puan += 10;
        }
        else
        {
            yanlisSayisi++;
            YanlisIkonu.GetComponent<RectTransform>().DOScale(1f, 0.1f).SetEase(Ease.InBack);
        }
        DogruSayisiText.text = dogruSayisi.ToString() + " DOGRU";
        YanlisSayisiText.text = yanlisSayisi.ToString() + " YANLİS";
        PuanText.text = Puan.ToString() + " PUAN";
        SoruyuSor();
    }
    void IkonlariKapat()
    {
        DogruIkonu.GetComponent<RectTransform>().localScale = Vector3.zero;
        YanlisIkonu.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
