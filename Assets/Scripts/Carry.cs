using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour
{

    public Camera cam;
    public Joint childJoint;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log(Input.mousePosition);
            Vector3 pos = Input.mousePosition;
            pos.z = 20;
            pos = cam.ScreenToWorldPoint(pos);
            var ray = new Ray(pos, Vector3.down);
            Debug.Log(pos);
            transform.position = pos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (childJoint != null)
            {
                childJoint.breakForce = 0f;
            }
        }
        
    }
}
