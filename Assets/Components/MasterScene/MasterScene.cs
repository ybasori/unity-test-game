using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterScene : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Joystick joystick;
    private PlayerController playerController;
    private GameObject playerGO;

    public void GoToAppearance()
    {
        SceneManager.LoadScene("AppearanceScene");
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
    public void GoToSample()
    {
        SceneManager.LoadScene("SampleScene");
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
    public void SetIsJumping()
    {
        
        playerController.SetIsJumping(true);
    }
    // Start is called before the first frame update
    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {if (SceneManager.GetActiveScene().name != "AppearanceScene") { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            Instantiate(playerPrefab);
        }
        if(!playerGO){
            playerGO = GameObject.FindGameObjectWithTag("Player");
            playerController = playerGO.GetComponent<PlayerController>();
        }
        if(!playerController.joystick && joystick){
                playerController.joystick=joystick;
        }
    }

}
