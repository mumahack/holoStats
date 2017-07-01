using Com.Apiomat.Frontend;
using Com.Apiomat.Frontend.Basics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apiotest1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pressButton()
    {
        test();
    }
    async void test()
    {
        User myUser = new User("johnWilhelm", "1,618");

        // configure datastore with user credentials
        Datastore.ConfigureWithCredentials(myUser);
        // and save it
        await myUser.SaveAsync();
    }
}
