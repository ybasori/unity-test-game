using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private bool firstTimeOnAppearanceScene = true;
    private float turnLeft = 0f;
    private float turnRight = 0f;
    private float timeCount = 0f;

    public void OnTurnLeft()
    {

        turnLeft = timeCount + 0.2f;
    }
    public void OnTurnRight()
    {
        turnRight = timeCount + 0.2f;
    }
    private void OnAppearanceScene()
    {
        if (firstTimeOnAppearanceScene)
        {
            firstTimeOnAppearanceScene = false;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (turnRight >= timeCount)
        {
            transform.Rotate(0f, -50f * Time.deltaTime, 0f, Space.Self);
        }
        if (turnLeft >= timeCount)
        {
            transform.Rotate(0f, 50f * Time.deltaTime, 0f, Space.Self);
        }

        timeCount += Time.deltaTime;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            transform.position = player.transform.position;

            if (SceneManager.GetActiveScene().name == "AppearanceScene")
            {

                OnAppearanceScene();

            }

        }
    }
}
