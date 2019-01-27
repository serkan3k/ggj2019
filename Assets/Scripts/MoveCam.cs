using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public MeshRenderer rend1, rend2;

    public MeshFilter meshFilter1, meshFilter2;
   
    void FixedUpdate ()
    {
        var pos = transform.position;
        float am = 1.5f;
        Vector3 delta = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            delta += transform.forward * am;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            delta -= transform.forward * am;
        }
        if (Input.GetKey(KeyCode.S))
        {
            delta -= transform.right * am;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            delta += transform.right * am;
        }
        if (Input.GetKey(KeyCode.E))
        {
            delta += transform.up * am;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            delta -= transform.up * am;
        }
        //Vector3.ClampMagnitude(delta, am);
        transform.position += delta;
//        Vector3 meshSpace1 = rend1.transform.InverseTransformPoint(transform.position);
//        Vector3 meshSpace2 = rend2.transform.InverseTransformPoint(transform.position);
//        Boolean isContained = meshFilter1.sharedMesh.bounds.Contains(meshSpace1)
//            || meshFilter2.sharedMesh.bounds.Contains(meshSpace2);
//        if (!isContained)
//        {
//            var d1 = meshFilter1.sharedMesh.bounds.SqrDistance(meshSpace1);
//            var d2 = meshFilter2.sharedMesh.bounds.SqrDistance(meshSpace2);
//            if (d1 > d2)
//            {
//                transform.position = rend2.transform.TransformPoint(meshFilter2.sharedMesh.bounds.ClosestPoint(meshSpace2));
//            }
//            else if (d2 > d1)
//            {
//                transform.position = rend1.transform.TransformPoint(meshFilter1.sharedMesh.bounds.ClosestPoint(meshSpace1));
//            }
//
//        }
    }
}
