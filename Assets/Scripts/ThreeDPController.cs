using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDPController : MonoBehaviour {
    public TextMesh Name;
    public TextMesh Temperature;
    public TextMesh File;
    public TextMesh TimeData;

    private float currentTemperature = 0;
    private float targetTemperature = 0;
    private string fileName = "";
    private DateTime timeElapsed = new DateTime();
    private DateTime timeRemaining = new DateTime();
    private DateTime timeTotal = new DateTime();

    //Getter and Setter
    public float getCurrentTemperature()
    {
        return currentTemperature;
    }
    public void setCurrentTemperature(float value)
    {
        Temperature.text = value.ToString() + "°/" + targetTemperature.ToString() + "°";
        currentTemperature = value;
    }

    public float getTargetTemperature()
    {
        return targetTemperature;
    }
    public void setTargetTemperature(float value)
    {
        Temperature.text = currentTemperature.ToString() + "°/" + value.ToString() + "°";
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
    public void setTimeElapsed()
    {
        DateTime value = new DateTime();
        TimeData.text = value.ToString("hh:mm:ss");
        timeElapsed = value;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
