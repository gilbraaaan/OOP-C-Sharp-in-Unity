using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace AgilPolymorphism
{
    public class Action : MonoBehaviour
    {
        bool theTime = false;
        public Button btn;
        public TMP_Text textSeconds;
        public float secondsTime = 3f;
        float timeRemaining = 0f;
        public StartFunction functionAll;

        public void Play()
        {
            StartAction();
        }

        public virtual void StartAction()
        {
            timeRemaining = secondsTime;
            theTime = true;
            btn.interactable = false;
        }

        protected void Update()
        {
            if(theTime == true)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                    Ended();
                    timeRemaining = 0;
                    theTime = false;
                }
            }
        }

        protected void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            textSeconds.text = string.Format("{00}", seconds);
        }

        void Ended()
        {
            functionAll.EndFunction();
        }

        public virtual void EndAction()
        {
            btn.interactable = true;
            textSeconds.text = "Action";
        }
    }
}
