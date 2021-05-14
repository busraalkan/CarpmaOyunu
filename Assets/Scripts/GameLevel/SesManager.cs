using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesManager : MonoBehaviour
{
    private void Start()
    {
        SesiAc();
    }
    public void SesiAc()
    {
        PlayerPrefs.SetInt("SesDurumu", 1);
    }
    public void SesiKapa()
    {
        PlayerPrefs.SetInt("SesDurumu", 0);
    }
}
