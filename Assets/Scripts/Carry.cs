using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
        using System.Collections.Generic;
using System.Linq;
using Random = System.Random;

public class Carry : MonoBehaviour
{

    public Camera cam;
    public Joint childJoint;

    public AudioSource tvsetAudio, wcAudio;

    private List<AudioSource> whistlelist;
    // Use this for initialization
    private void Awake()
    {
        tvsetAudio = GameObject.Find("TVAudio").GetComponent<AudioSource>();
        wcAudio = GameObject.Find("Toilet").GetComponent<AudioSource>();
         whistlelist = new List<AudioSource>();
        whistlelist.Add(GameObject.Find("Whistle").GetComponent<AudioSource>());
        
        whistlelist.Add(GameObject.Find("Whistle2").GetComponent<AudioSource>());
        
        whistlelist.Add(GameObject.Find("Whistle3").GetComponent<AudioSource>());
    }
    

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
                        if (hitInfo.collider.gameObject.name.Contains("TV_Material"))
                        {
                            if (tvsetAudio.isPlaying == false)
                            {
                                tvsetAudio.Play();
                            }
                        }
                        else if (hitInfo.collider.gameObject.name.Contains("WC_Material"))
                        {
                            if (wcAudio.isPlaying == false)
                            {
                                wcAudio.Play();
                            }
                        }
                        else
                        {
                            bool isPlaying = false;
                            for (int i = 0; i < whistlelist.Count; ++i)
                            {
                                if (whistlelist[i].isPlaying)
                                {
                                    isPlaying = true;
                                    break;
                                }
                            }

                            if (!isPlaying)
                            {
                                whistlelist[UnityEngine.Random.Range(0, whistlelist.Count - 1)].Play();
                            }
                        }

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

        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
