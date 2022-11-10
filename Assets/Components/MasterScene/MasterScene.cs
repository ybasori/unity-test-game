using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterScene : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Joystick joystick;
    private PlayerController playerController;

    public void GoToAppearance()
    {
        SceneManager.LoadScene("AppearanceScene");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
    public void GoToSample()
    {
        SceneManager.LoadScene("SampleScene");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
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
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            Instantiate(player);
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            if(joystick){
                playerController.joystick=joystick;
            }
        }
    }

}
