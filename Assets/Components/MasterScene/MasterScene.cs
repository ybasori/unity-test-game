using System;
using UnityEngine;

public class MasterScene : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject PopUpMenu;
    private PlayerController playerController;
    private GameObject playerGO;
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
            PopUpMenu.SetActive(true);
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
