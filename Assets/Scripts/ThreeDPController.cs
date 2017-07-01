using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThreeDPController : MonoBehaviour {
    public TextMesh Name;
    public GameObject Temperature;
    public TextMesh File;
    public TextMesh TimeElapsed;
    public TextMesh TimeRemaining;
    public TextMesh TimeTotal;

    private float currentTemperature = 0;
    private float targetTemperature = 0;
    private string fileName = "";
    private DateTime timeElapsed;
    private DateTime timeRemaining;
    private DateTime timeTotal = new DateTime();
    private TextMeshPro temperatureText;

    //Getter and Setter
    public float getCurrentTemperature()
    {
        return currentTemperature;
    }
    public void setCurrentTemperature(float value)
    {
        currentTemperature = value;
    }

    public float getTargetTemperature()
    {
        return targetTemperature;
    }
    public void setTargetTemperature(float value)
    {
        targetTemperature = value;
    }

    public string getFileName()
    {
        return fileName;
    }
    public void setFileName(string value)
    {
        File.text = value;
        fileName = value;
    }

    public DateTime getTimeElapsed()
    {
        return timeElapsed;
    }
    public void setTimeElapsed(DateTime value)
    {
        value = timeElapsed.Add(new TimeSpan(0,0,1));
        TimeElapsed.text = value.ToString("HH:mm:ss");
        timeElapsed = value;
    }

    public DateTime getTimeRemaining()
    {
        return timeRemaining;
    }
    public void setTimeRemaining(DateTime value)
    {
        value = timeRemaining.Subtract(new TimeSpan(0,0,1));
        TimeRemaining.text = value.ToString("HH:mm:ss");
        timeRemaining = value;
    }

    public DateTime getTimeTotal()
    {
        return timeTotal;
    }
    public void setTimeTotal(DateTime value)
    {
        timeTotal = value = new DateTime(0,0,0,2,0,0);
        TimeTotal.text = value.ToString("HH:mm:ss");
        timeTotal = value;
    }

    // Use this for initialization
    void Start () {
        temperatureText = Temperature.GetComponent<TextMeshPro>();
        timeElapsed = new DateTime(2017, 1, 1, 0, 0, 0);
        timeRemaining = new DateTime(2017, 1, 1, 2, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        temperatureText.text = string.Format("{0:0.0}°/{1:0.0}°", currentTemperature, targetTemperature);

    }
}
