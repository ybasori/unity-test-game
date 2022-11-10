using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceScript : MonoBehaviour
{
    static float t = 0.0f;
    private float posXClose;
    private float posXOpen = 0f;
    private bool isOpenChange = false;
    private bool isFirstTime = true;
    [SerializeField] RectTransform MainOptions;
    [SerializeField] RectTransform GenderOptions;
    private RectTransform isOpen;
    private PlayerController playerController;
    public void OnOpenGender()
    {
        isOpenChange = true;
        isOpen = GenderOptions;
    }
    public void OnGenderMale()
    {
        isOpenChange = true;
        isOpen = MainOptions;
        playerController.gender="male";
    }
    public void OnGenderFemale()
    {
        isOpenChange = true;
        isOpen = MainOptions;
        playerController.gender="female";
    }
    private void OpenOption(RectTransform rt)
    {
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, Mathf.Lerp(posXClose, posXOpen, t), rt.rect.width);
    }
    private void CloseOption(RectTransform rt)
    {
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, Mathf.Lerp(posXOpen, posXClose, t), rt.rect.width);
    }
    // Start is called before the first frame update
    void Start()
    {
        posXClose = -MainOptions.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstTime)
        {
            isOpenChange = true;
            isOpen = MainOptions;
            isFirstTime = false;
        }
        if (isOpenChange)
        {
            if (isOpen == GenderOptions)
            {
                OpenOption(GenderOptions);
            }
            else
            {
                CloseOption(GenderOptions);
            }


            if (isOpen == MainOptions)
            {
                OpenOption(MainOptions);
            }
            else
            {
                CloseOption(MainOptions);
            }

            t += 2f * Time.deltaTime;
            if (t > 1f)
            {
                t = 0;
                isOpenChange = false;
            }
        }


        if(playerController==null && GameObject.FindGameObjectWithTag("Player")){
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }
}
