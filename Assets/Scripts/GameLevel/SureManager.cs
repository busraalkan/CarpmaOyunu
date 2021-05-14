using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SureManager : MonoBehaviour
{
    int kalanSure;
    bool SureAksinMi;
    [SerializeField]
    private Text SureText;
    [SerializeField]
    private GameObject BaslaYazisiImage, SureImage, DogruYanlisIkonImage, PuanImage, PlayerObje, SeceneklerObje, SonucPaneli;
    void Start()
    {       
        kalanSure = 60;
        SureAksinMi = true;
        SonucPaneli.SetActive(false);
        StartCoroutine(SureRoutine());
    }
    IEnumerator SureRoutine()
    {
        while (SureAksinMi)
        {
            yield return new WaitForSeconds(1f);
            if (kalanSure < 10)
            {
                SureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                SureText.text = kalanSure.ToString();
            }
            if (kalanSure <= 0)
            {
                SureAksinMi = false;
                SonucIcinEkranTemizle();
                SonucPaneli.SetActive(true);
            }
            kalanSure--;
        }
    }
    void SonucIcinEkranTemizle()
    {
        BaslaYazisiImage.SetActive(false);
        PuanImage.SetActive(false);
        SureImage.SetActive(false);
        DogruYanlisIkonImage.SetActive(false);
        PlayerObje.SetActive(false);
        SeceneklerObje.SetActive(false);
    }
}
