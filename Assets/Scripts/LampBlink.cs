using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlink : MonoBehaviour 
{
	[SerializeField] private Light lightComponent;

	private const float blinkTimeMin = 0.1f,
						blinkTimeMax = 0.25f;
	
	private float blinkTimer = 0.0f, blinkCounter = 0.0f;

	private void Awake()
	{
		lightComponent = GetComponent<Light>();
		blinkTimer = Random.Range(blinkTimeMin, blinkTimeMax);
	}

	private void Update()
	{
		blinkCounter += Time.deltaTime;
		if (blinkCounter >= blinkTimer)
		{
			blinkCounter = 0.0f;
			if (lightComponent.intensity > 0)
			{
				lightComponent.intensity = 0.0f;
			}
			else
			{
				lightComponent.intensity = Random.Range(3, 4);
			}

			blinkTimer = Random.Range(blinkTimeMin, blinkTimeMax);
		}
	}
}
