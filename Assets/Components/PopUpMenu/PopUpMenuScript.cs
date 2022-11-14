using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class PopUpMenuScript : MonoBehaviour
{

    public void GoToAppearance()
    {
        SceneManager.LoadScene("AppearanceScene");
    }
    public void GoToSample()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnQuit(){
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
