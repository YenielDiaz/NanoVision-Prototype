using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bead : MonoBehaviour
{

    [SerializeField] bool isUV;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isUV)
        {
            //temporarily making UVbeads red for testing purposes
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void SetIsUV(bool val)
    {
        isUV = val;
    }

    public bool GetIsUV()
    {
        return isUV;
    }
}
