using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.Furnitures.Add(this);
            GameManager.instance.IsPopulated = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance != null)
        {
            if (Vector3.Distance(transform.position, Vector3.zero) > 40f)
            {
                Debug.Log("Goodbye cruel world! " + this.gameObject.name);
                GameManager.instance.Furnitures.Remove(this);
                Destroy(this.gameObject);
            }
        }
    }
}
