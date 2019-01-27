using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{

    private bool isDying;
    // Use this for initialization
    void Start()
    {
        if (GameManager.instance != null)
        {
            isDying = false;
            GameManager.instance.Furnitures.Add(this);
            GameManager.instance.IsPopulated = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDying)
        {
            var col = this.GetComponent<MeshRenderer>().material.color;
            this.GetComponent<MeshRenderer>().material.color = Color.Lerp(col, Color.clear, Time.deltaTime * 10f);
            if (this.GetComponent<MeshRenderer>().material.color.a < 0.05f)
            {
                //Debug.LogWarning("died");
                Destroy(this.gameObject);
            }

            return;
        }
        if (GameManager.instance != null)
        {
            if (Vector3.Distance(transform.position, Vector3.zero) > 40f)
            {
                Debug.Log("Goodbye cruel world! " + this.gameObject.name);
                GameManager.instance.Furnitures.Remove(this);
                isDying = true;
            }
        }
        
    }
}
