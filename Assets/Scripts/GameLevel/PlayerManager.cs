using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Roket;
    float angle;
    [SerializeField]
    private int DonusHizi;
    [SerializeField]
    private Transform MermiPosition;
    [SerializeField]
    private GameObject[] Mermi = new GameObject[5];
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioClip MermiSesi;
    public int hiz;
    float IkiMermiArasiSure = 0.5f;
    float atisZamani;
    float sonrakiAtisZamani;
    public static bool RotateAktifligi;
    private void Start()
    {
        RotateAktifligi = false;
    }
    void Update()
    {
        if (RotateAktifligi)
        {
           RoketRotasyonunuAyarla();
        }
    }
    void RoketRotasyonunuAyarla()
    {
        atisZamani = Time.time;
        Vector2 Yon = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Roket.transform.position;
        angle = Mathf.Atan2(Yon.y, Yon.x) * Mathf.Rad2Deg - 90;
        if (angle > -40 && angle < 38)
        {
            Quaternion rotasyon = Quaternion.AngleAxis(angle, Vector3.forward);
            Roket.transform.rotation = Quaternion.Slerp(Roket.transform.rotation, rotasyon, DonusHizi * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (atisZamani >= sonrakiAtisZamani)
            {
                MermiAt();
                sonrakiAtisZamani = atisZamani + IkiMermiArasiSure;
            }
        }
    }
    void MermiAt()
    {
        if (PlayerPrefs.GetInt("SesDurumu") == 1)
        {
            AudioSource.PlayOneShot(MermiSesi);
        }
        GameObject MermiInsatiate = Instantiate(Mermi[Random.Range(0, Mermi.Length)], MermiPosition.position, Roket.transform.rotation);
    }
}
