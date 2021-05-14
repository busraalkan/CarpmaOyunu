using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SecenekRotateManager : MonoBehaviour
{
    string hangiSecenek;
    GameManager GameManagerObje;

    private void Awake()
    {
        GameManagerObje = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {      
        if(other.tag=="Mermi")
        {
            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);
            Destroy(other.gameObject);
        }
        if (gameObject.name == "DaireA")
        {
            hangiSecenek = GameObject.Find("SecenekAText").GetComponent<Text>().text;
        }
        else if (gameObject.name == "DaireB")
        {
            hangiSecenek = GameObject.Find("SecenekBText").GetComponent<Text>().text;
        }
        else if (gameObject.name == "DaireC")
        {
            hangiSecenek = GameObject.Find("SecenekCText").GetComponent<Text>().text;
        }

        GameManagerObje.CevabiKontrolEt(int.Parse(hangiSecenek));
    }
}
