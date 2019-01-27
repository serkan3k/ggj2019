using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{

	private Text txt;

	private float txtBlinkCounter = 0.0f, txtBlinkTimer = 0.5f;
	// Use this for initialization
	void Start ()
	{
		txt = GetComponent<Text>();
		txtBlinkCounter = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		txtBlinkCounter += Time.deltaTime;
		if (txtBlinkCounter >= txtBlinkTimer)
		{
			txtBlinkCounter = 0f;
			txt.enabled = !txt.enabled;
		}
	}
}
