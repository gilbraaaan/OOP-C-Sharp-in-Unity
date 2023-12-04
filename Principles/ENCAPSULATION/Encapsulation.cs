using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encapsulation : MonoBehaviour
{
    private string Nama;
    public string namaInput
    {
        get { return Nama; }
        set
        {
            var z = "";
            foreach(char character in value)
                if(char.IsLower(character))
                    z+=char.ToUpper(character);
        }
    }
}
