using Com.Apiomat.Frontend;
using Com.Apiomat.Frontend.AnycubicPrinterConnector;
using Com.Apiomat.Frontend.Basics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateDPController : MonoBehaviour {
    private ThreeDPController controller;

    // Config
    float lastUpdateTime = 0;
    static private bool printerReceived = false;
    public float interval = 20;
    static private IList<Printer> printers;
    static public double temperatur = 0;

    // Use this for initialization
    void Start () {
        controller = GetComponent<ThreeDPController>();
        GetPrinters();
    }

    // Update is called once per frame
    void Update()
    {
        if (printerReceived == true && (lastUpdateTime + interval < Time.deltaTime || lastUpdateTime == 0))
        {
            lastUpdateTime = Time.deltaTime;
            UpdateData();
        }
    }

    private void UpdateData()
    {
        UpdateDPController.printers[0].LoadToolHistoryAsync("order by time limit 1").ContinueWith(x => {
        UpdateDPController.temperatur = x.Result[0].TemperatureActual;
        //textElement.text = string.Format("{0}°C", GetTemperatur.temperatur);
        controller.setCurrentTemperature((float)x.Result[0].TemperatureActual);
        controller.setTargetTemperature((float)x.Result[0].TemperatureTarget );
        });

        UpdateDPController.printers[0].LoadCurrentJobAsync<JobData>(false).ContinueWith(x =>
        {
           
        });
        }


    private void GetPrinters()
    {
        User myUser = new User("johnWWW", "1,618");

        // configure datastore with user credentials
        Datastore.ConfigureWithCredentials(myUser);

        Printer.GetPrintersAsync(null).ContinueWith(x => {
            UpdateDPController.printerReceived = true;
            UpdateDPController.printers = x.Result;
        });
    }

}
