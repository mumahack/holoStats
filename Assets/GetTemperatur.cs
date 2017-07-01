using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Apiomat.Frontend.AnycubicPrinterConnector;
using System.Threading.Tasks;
using Com.Apiomat.Frontend.Basics;
using Com.Apiomat.Frontend;
using TMPro;

public class GetTemperatur : MonoBehaviour {
    float lastUpdateTime = 0;
    static private bool printerReceived = false;
    public float interval = 20;
    static private IList<Printer> printers;
    static public double temperatur = 0;

    public TextMeshPro textElement;

    void Start()
    {
        textElement = GetComponent<TextMeshPro>();
        GetPrinters();
    }
	
	// Update is called once per frame
	void Update () {
		if (printerReceived == true && (lastUpdateTime+interval<Time.deltaTime || lastUpdateTime == 0))
        {
            lastUpdateTime = Time.deltaTime;
            UpdateData();
        }
	}

    private void UpdateData()
    {
        GetTemperatur.printers[0].LoadToolHistoryAsync("order by time limit 1").ContinueWith(x => {
            GetTemperatur.temperatur = x.Result[0].TemperatureActual;
            textElement.text = string.Format("{0}°C", GetTemperatur.temperatur);
        });
    }


    private void GetPrinters()
    {
        User myUser = new User("johnWWW", "1,618");

        // configure datastore with user credentials
        Datastore.ConfigureWithCredentials(myUser);

        Printer.GetPrintersAsync(null).ContinueWith(x => {
            GetTemperatur.printerReceived = true;
            GetTemperatur.printers = x.Result;
        });
    }

}
