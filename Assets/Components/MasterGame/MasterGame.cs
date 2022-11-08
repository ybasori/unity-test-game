using System;
using UnityEngine;

public class MasterGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            Application.Quit(); 
    }
}
