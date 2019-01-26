using System;
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
        if (childJoint == null)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hitInfo;

                if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo))
                {
                    if (hitInfo.collider.tag == "Furniture")
                    {
                        ConnectObject(hitInfo.collider.gameObject);
                       
                    }
                    
                }
            }
        }
        else
        {

            if (Input.GetMouseButton(0))
            {
                //Debug.Log(Input.mousePosition);
                Vector3 pos = Input.mousePosition;
                pos.z = 20;
                
                pos = cam.ScreenToWorldPoint(pos);
                var ray = new Ray(pos, Vector3.down);
                if (pos.y < 3f) pos.y = 3f;
                transform.position = pos;
            }

            if (Input.GetMouseButtonUp(0))
            {
                childJoint.breakForce = 0f;
            }
        }
        
    }

    private void ConnectObject(GameObject gameObject)
    {
        SpringJoint joint = gameObject.AddComponent<SpringJoint>();
        joint.spring = 10f;
        joint.damper = 0.02f;
        joint.minDistance = 0.1f;
        joint.maxDistance = 1f;
        joint.tolerance = 0.025f;
        joint.enableCollision = true;
        joint.enablePreprocessing = false;
        joint.massScale = 10f;
        joint.connectedMassScale = 1f;
        joint.autoConfigureConnectedAnchor = false;
        joint.anchor = Vector3.zero;
        joint.connectedAnchor = Vector3.zero;
        joint.connectedBody = this.GetComponent<Rigidbody>();


        childJoint = joint;
    }
}
