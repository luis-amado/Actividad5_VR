using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaytimeController : MonoBehaviour
{

	public Transform sun;
	public float speed = 2.0f;

	bool day = false;
	bool wasBelow = false;

	// Update is called once per frame
	void Update()
	{
		if(sun.eulerAngles.x >= 350 && wasBelow)
		{
			day = !day;
		}

		sun.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));

		wasBelow = sun.eulerAngles.x < 350;
	}

	public bool IsNight()
	{
		return !day;
	}
}
