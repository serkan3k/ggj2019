using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVSet : MonoBehaviour
{
	[SerializeField] private Light lightComponent;

	private const float rangeMin = 20f,
		rangeMax = 25f,
		intensityMin = 5f,
		intensityMax = 7.5f,
		channelChangeTimeMin = 0.5f,
		channelChangeTimeMax = 1.0f;

	private float channelChangeTimeCounter = 0.0f;
	private float channelChangeTimer = 0.0f;
	
	private void Awake ()
	{
		channelChangeTimer = Random.Range(channelChangeTimeMin,
										  channelChangeTimeMax);
		channelChangeTimeCounter = 0.0f;
		lightComponent = GetComponentInChildren<Light>();
	}
	
	private void Update ()
	{
		channelChangeTimeCounter += Time.deltaTime;
		if (channelChangeTimeCounter >= channelChangeTimer)
		{
			channelChangeTimeCounter = 0.0f;
			channelChangeTimer = Random.Range(channelChangeTimeMin,
											  channelChangeTimeMax);
			lightComponent.range = Random.Range(rangeMin, rangeMax);
			lightComponent.intensity = Random.Range(intensityMin, intensityMax);
			lightComponent.color = new Color(Random.value, Random.value, Random.value);
		}
	}
}
