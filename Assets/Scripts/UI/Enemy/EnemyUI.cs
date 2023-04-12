using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    Transform CameraMain;
    void Start()
    {
        CameraMain = GameObject.Find("MainCamera").transform;  
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 lookAtTransform = new Vector3(CameraMain.position.x, this.transform.position.y, CameraMain.position.z);
        transform.LookAt(CameraMain);
    }
}
