using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiManager : MonoBehaviour
{
    int MermiHizi = 10;
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * MermiHizi * Time.deltaTime);
    }
}
