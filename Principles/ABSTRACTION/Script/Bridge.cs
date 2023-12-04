using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AgilAbstraction;

public class Bridge : MonoBehaviour
{
    public Button btn;
    public List<Character> CharArray = new List<Character>();
    public void Call()
    {
        btn.interactable = false;
        foreach (Character Char in CharArray)
        {
            Char.TryFunction(true);
        }
    }
}
