using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProsesNama : MonoBehaviour
{
    public Encapsulation ProsesTheName;

    void Start()
    {
        ProsesTheName.namaInput = "M Gilbran EP";
        Debug.Log(ProsesTheName.namaInput);
    }
}
