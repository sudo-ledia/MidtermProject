using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    public GameObject cameraPosObj;
    // Start is called before the first frame update
    void Start()
    {
        cameraPosObj = GameObject.FindGameObjectWithTag("CameraPos");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosObj.transform.position;
    }
}
