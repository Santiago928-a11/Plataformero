using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject VirtualGuy;

    void Update()
    {
        if (VirtualGuy != null)
        {

            Vector3 position = transform.position;
            position.x = VirtualGuy.transform.position.x;
            //position.x += 5;
            transform.position = position;
        }




    }
}
