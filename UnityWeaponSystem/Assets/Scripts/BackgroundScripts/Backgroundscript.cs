using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundscript : MonoBehaviour
{
    public int Cameraspeed = 5;
    Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.gameObject.transform;
    }


    // Update is called once per frame
    void Update()
    {
        cameraTransform.Rotate(Vector3.up * Cameraspeed * Time.deltaTime);
       

    }
}

