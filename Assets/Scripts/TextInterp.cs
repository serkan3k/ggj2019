using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInterp : MonoBehaviour
{
	private RectTransform rt;

	private Vector3 targetPos;
	// Use this for initialization
	void Start ()
	{
		rt = GetComponent<RectTransform>();
		targetPos = Vector3.zero + Vector3.up * 75f;
	}
	
	// Update is called once per frame
	void Update () {
		if (rt.anchoredPosition.y < 75f)
		{
			rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, targetPos,  Time.deltaTime * Time.deltaTime * 50f);
		}
		else if (rt.anchoredPosition.y < 75f - Mathf.Epsilon)
		{
			rt.anchoredPosition = targetPos;
		}
	}
}
