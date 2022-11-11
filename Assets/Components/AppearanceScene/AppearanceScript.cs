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
    [SerializeField] RectTransform SkinOptions;
    private RectTransform isOpen;
    private RectTransform isOpenPrev;
    private PlayerController playerController;
    public void OnSkinThree()
    {
        isOpenChange = true;
        isOpenPrev = isOpen;
        isOpen = MainOptions;
    }
    public void OnSkinTwo()
    {
        isOpenChange = true;
        isOpenPrev = isOpen;
        isOpen = MainOptions;
    }
    public void OnSkinOne()
    {
        isOpenChange = true;
        isOpenPrev = isOpen;
        isOpen = MainOptions;
    }
    public void OnOpenSkin()
    {
        isOpenChange = true;
        isOpenPrev = isOpen;
        isOpen = SkinOptions;
    }
    public void OnOpenGender()
    {
        isOpenChange = true;
        isOpenPrev = isOpen;
        isOpen = GenderOptions;
    }
    public void OnGenderMale()
    {
        isOpenChange = true;
        isOpenPrev = isOpen;
        isOpen = MainOptions;
        playerController.gender = "male";
    }
    public void OnGenderFemale()
    {
        isOpenChange = true;
        isOpenPrev = isOpen;
        isOpen = MainOptions;
        playerController.gender = "female";
    }
    private void OpenOption(RectTransform rt)
    {
        if (rt == isOpen)
        {
            rt.gameObject.SetActive(true);
        }
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
        isOpen = MainOptions;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenChange)
        {

            if (isOpen == MainOptions)
            {
                OpenOption(MainOptions);
            }
            else
            {
                CloseOption(MainOptions);
            }

            if (isOpen == GenderOptions)
            {
                OpenOption(GenderOptions);
            }
            else
            {
                CloseOption(GenderOptions);
            }

            if (isOpen == SkinOptions)
            {
                OpenOption(SkinOptions);
            }
            else
            {
                CloseOption(SkinOptions);
            }
            if (isOpen.anchoredPosition.x == posXOpen)
            {
                Debug.Log("Opened");
            }
            if (t > 1f)
            {

                isOpenChange = false;
                t = 0;
                if (isOpenPrev)
                {
                    isOpenPrev.gameObject.SetActive(false);
                }
            }
            t += 2f * Time.deltaTime;


        }
        else
        {


            // Debug.Log(isOpen.anchoredPosition.x);
            // if(isOpen.anchoredPosition.x == posXOpen){
            //     if(isOpen!=MainOptions){
            //         MainOptions.gameObject.SetActive(false);
            //     }
            //     if(isOpen!=GenderOptions){
            //         GenderOptions.gameObject.SetActive(false);
            //     }
            //     if(isOpen!=SkinOptions){
            //         SkinOptions.gameObject.SetActive(false);
            //     }
            // }
        }


        if (playerController == null && GameObject.FindGameObjectWithTag("Player"))
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }
}
