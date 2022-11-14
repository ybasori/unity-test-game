using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearanceScript : MonoBehaviour
{
    static float t = 0.0f;
    private float posXClose;
    private float posXOpen = 0f;
    private bool isOpenChange = false;
    private bool isFirstTime = true;
    [SerializeField] private Button buttonClose;
    [SerializeField] RectTransform MainOptions;
    [SerializeField] RectTransform GenderOptions;
    [SerializeField] RectTransform SkinOptions;
    [SerializeField] RectTransform HairOptions;
    [SerializeField] RectTransform EyesOptions;
    [SerializeField] RectTransform ShirtOptions;
    [SerializeField] RectTransform PantsOptions;
    [SerializeField] RectTransform ShoesOptions;
    private RectTransform isOpen;
    private RectTransform isOpenPrev;
    private PlayerController playerController;
    private PlayerAppearanceController playerAppearanceController;
    public void OnClose()
    {
        isOpenChange = true;
        isOpenPrev = isOpen;
        isOpen = MainOptions;
    }
    public void OnSkin(int value)
    {
        playerAppearanceController.OnSkin(value);
    }
    public void OnChangeHair(int value)
    {
        playerAppearanceController.OnChangeColor("hair", value);
    }
    public void OnChangeEyes(int value)
    {
        playerAppearanceController.OnChangeColor("eyes", value);
    }
    public void OnChangeShirt(int value)
    {
        playerAppearanceController.OnChangeColor("shirt", value);
    }
    public void OnChangeSleeveType(string value)
    {
        playerAppearanceController.OnChangeSleeveType(value);
    }
    public void OnChangePantsType(string value)
    {
        playerAppearanceController.OnChangePantsType(value);
    }
    public void OnChangePants(int value)
    {
        playerAppearanceController.OnChangeColor("pants", value);
    }
    public void OnChangeShoes(int value)
    {
        playerAppearanceController.OnChangeColor("shoes", value);
    }
    public void OnOpenMenuOption(string attribute)
    {
        RectTransform menuoption = null;
        if (attribute == "skin")
        {
            menuoption = SkinOptions;
        }
        if (attribute == "hair")
        {
            menuoption = HairOptions;
        }
        if (attribute == "eyes")
        {
            menuoption = EyesOptions;
        }
        if (attribute == "shirt")
        {
            menuoption = ShirtOptions;
        }
        if (attribute == "pants")
        {
            menuoption = PantsOptions;
        }
        if (attribute == "shoes")
        {
            menuoption = ShoesOptions;
        }
        isOpenChange = true;
        isOpenPrev = isOpen;
        isOpen = menuoption;
    }
    public void OnOpenGender()
    {
        isOpenChange = true;
        isOpenPrev = isOpen;
        isOpen = GenderOptions;
    }
    public void OnGenderMale()
    {
        playerAppearanceController.OnChangeGender("male");
    }
    public void OnGenderFemale()
    {
        playerAppearanceController.OnChangeGender("female");
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen == MainOptions)
            {
                Application.Quit();
            }
            else
            {
                isOpenChange = true;
                isOpenPrev = isOpen;
                isOpen = MainOptions;
            }
        }
        if(isOpen!= MainOptions){
            buttonClose.gameObject.SetActive(true);
        }
        else{
            buttonClose.gameObject.SetActive(false);
        }
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

            if (isOpen == HairOptions)
            {
                OpenOption(HairOptions);
            }
            else
            {
                CloseOption(HairOptions);
            }

            if (isOpen == EyesOptions)
            {
                OpenOption(EyesOptions);
            }
            else
            {
                CloseOption(EyesOptions);
            }

            if (isOpen == ShirtOptions)
            {
                OpenOption(ShirtOptions);
            }
            else
            {
                CloseOption(ShirtOptions);
            }

            if (isOpen == PantsOptions)
            {
                OpenOption(PantsOptions);
            }
            else
            {
                CloseOption(PantsOptions);
            }

            if (isOpen == ShoesOptions)
            {
                OpenOption(ShoesOptions);
            }
            else
            {
                CloseOption(ShoesOptions);
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
        if (playerAppearanceController == null && GameObject.FindGameObjectWithTag("Player"))
        {
            playerAppearanceController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAppearanceController>();
        }
    }
}
