using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backgroundscript : MonoBehaviour
{
    
    public int Cameraspeed = 5;
    Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        


    }


    // Update is called once per frame
    void Update()
    {
        cameraTransform = Camera.main.gameObject.transform;
        cameraTransform.Rotate(Vector3.up * Cameraspeed * Time.deltaTime);
        

       

    }

    


}

