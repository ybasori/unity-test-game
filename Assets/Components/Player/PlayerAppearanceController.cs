using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearanceController : MonoBehaviour
{

    [Header("Appearance Options")]
    [SerializeField] private GameObject maleGameObject;
    [SerializeField] private GameObject femaleGameObject;

    [Header("Appearance Material")]
    [SerializeField] private Material SkinMaterial;
    [SerializeField] private Material HairMaterial;
    [SerializeField] private Material EyesMaterial;
    [SerializeField] private Material ShirtMaterial;
    [SerializeField] private Material ShirtExtraMaterial;
    [SerializeField] private Material PantsMaterial;
    [SerializeField] private Material PantsExtraMaterial;
    [SerializeField] private Material ShoesMaterial;

    [Header("Appearance")]
    public string shirtSleeveType = "short";
    public string pantsType = "long";
    public string gender = "female";
    private PlayerController playerController;
    private Animator animator;

    public void OnChangeSleeveType(string value)
    {
        shirtSleeveType = value;
        if (value == "short")
        {
            ShirtExtraMaterial.SetColor("_BaseColor", SkinMaterial.color);
        }
        if (value == "long")
        {
            ShirtExtraMaterial.SetColor("_BaseColor", ShirtMaterial.color);
        }
    }
    public void OnChangePantsType(string value)
    {
        pantsType = value;
        if (value == "short")
        {
            PantsExtraMaterial.SetColor("_BaseColor", SkinMaterial.color);
        }
        if (value == "long")
        {
            PantsExtraMaterial.SetColor("_BaseColor", PantsMaterial.color);
        }
    }
    public void OnSkin(int value)
    {
        if (value == 0)
        {
            SkinMaterial.SetColor("_BaseColor", new Color32(231, 191, 121, 1));
        }
        if (value == 1)
        {
            SkinMaterial.SetColor("_BaseColor", new Color32(231, 159, 85, 1));
        }
        if (value == 2)
        {
            SkinMaterial.SetColor("_BaseColor", new Color32(114, 78, 42, 1));
        }

        
        OnChangeSleeveType(shirtSleeveType);
        OnChangePantsType(pantsType);
    }
    public void OnChangeColor(string attribute, int value)
    {
        Material material = null;
        if (attribute == "hair")
        {
            material = HairMaterial;
        }
        if (attribute == "eyes")
        {
            material = EyesMaterial;
        }
        if (attribute == "shirt")
        {
            material = ShirtMaterial;
        }
        if (attribute == "pants")
        {
            material = PantsMaterial;
        }
        if (attribute == "shoes")
        {
            material = ShoesMaterial;
        }

        Color32 color = new Color32(255, 255, 255, 255);

        if (value == 1)
        {
            color = new Color32(148, 0, 121, 1);
        }
        if (value == 2)
        {
            color = new Color32(75, 0, 130, 1);
        }
        if (value == 3)
        {
            color = new Color32(0, 0, 255, 1);
        }
        if (value == 4)
        {
            color = new Color32(0, 255, 0, 1);
        }
        if (value == 5)
        {
            color = new Color32(255, 255, 0, 1);
        }
        if (value == 6)
        {
            color = new Color32(255, 127, 0, 1);
        }
        if (value == 7)
        {
            color = new Color32(255, 0, 0, 1);
        }
        if (value == 8)
        {
            color = new Color32(0, 0, 0, 1);
        }
        if (value == 9)
        {
            color = new Color32(255, 255, 255, 255);
        }
        material.SetColor("_BaseColor", color);
        if (attribute == "pants")
        {
            OnChangePantsType(pantsType);
        }
        if (attribute == "shirt")
        {
            OnChangeSleeveType(shirtSleeveType);
        }
    }

    public void OnChangeGender(string pGender)
    {
        gender = pGender;
        if (gender == "female")
        {
            femaleGameObject.SetActive(true);
            maleGameObject.SetActive(false);

            animator.avatar = femaleGameObject.GetComponent<Animator>().avatar;
            femaleGameObject.transform.SetSiblingIndex(1);
        }
        else
        {
            maleGameObject.SetActive(true);
            femaleGameObject.SetActive(false);
            animator.avatar = maleGameObject.GetComponent<Animator>().avatar;
            maleGameObject.transform.SetSiblingIndex(1);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        OnChangeGender(gender);
        OnChangeSleeveType(shirtSleeveType);
        OnChangePantsType(pantsType);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController == null && GameObject.FindGameObjectWithTag("Player"))
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }
}
