using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesMAnager : MonoBehaviour
{   public void SesAc()
    {
        PlayerPrefs.SetInt("SesDurumu", 1);
    }
    public void SesKapa()
    {
        PlayerPrefs.SetInt("SesDurumu", 0);
    }
}
