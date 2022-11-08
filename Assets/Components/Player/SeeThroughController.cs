using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughController : MonoBehaviour
{
    [SerializeField] private LayerMask mylayermask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            if(hit.transform.gameObject.name != "Player"){
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(4f,4f,4f), Time.deltaTime * 10);
            }
            else{
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0f,0f,0f), Time.deltaTime * 10);
            }
        }
        else{
            transform.localScale = new Vector3(0f,0f,0f);
        }
    }
}
