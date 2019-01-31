using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public GameObject boole;
    // Use this for initialization
    int second;
    float hour = 0.0f;
    float day = 0.0f;
    float month = 0.0f;
    float year = 6.0f;
    float nextSecond = 25f;

    void Update()
    {

        if (nextSecond < 0)
        {

            nextSecond += Time.deltaTime;

        }

        else
        {

            nextSecond = 25;

            hour += 5;

        }

        if (hour >= 24)
        {

            hour = 0;

            day += 10;

        }

        if (day >= 30)
        {

            day = 0;

            month += 5;

        }

        if (month >= 60)
        {

            month = 0;

            year += 1;

        }
        
            OnGUI();
    }
    private void OnGUI()
    {
        string h;
        if (year < 10)
        {
            h = "0" + year;
        }
        else {
            h = "" + year;
        }
        string m;
        if (month < 10)
        {
            m = "0" + month;
        }
        else
        {
            m = "" + month;
        }
        GUI.contentColor = Color.black;
        if (year < 24.0f)
        {
            GUI.Label(new Rect(100, 100, 100, 50), "Time" + "  " + h + ":" + m, "color");
        }
        else
        {
            bool b = GUI.Button(new Rect(200, 200, 200, 200), "go check your transmissions");
            Time.timeScale = 0f;
            if (b)
            {
                boole.SetActive(false);
                year = 6f;
                Time.timeScale = 1f;
            }
        }
    }
}