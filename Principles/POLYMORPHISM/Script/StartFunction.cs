using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AgilPolymorphism;

public class StartFunction : MonoBehaviour
{
    public List<Action> actionFinding = new List<Action>();

    public TMP_Text textTime;
    public Button btnAction;

    public void ClickFunction()
    {
        #region Detect Empty Element
        for (int i = 0; i < actionFinding.Count; i++)
        {
            if (actionFinding[i] == null)
            {
                actionFinding.RemoveAt(i);
            }
        }
        #endregion
        foreach (var actionAll in actionFinding)
        {
            actionAll.textSeconds = textTime;
            actionAll.btn = btnAction;
            actionAll.Play();
        }
    }

    public void EndFunction()
    {
        foreach (var actionAll in actionFinding)
        {
            actionAll.EndAction();
        }
    }
}
