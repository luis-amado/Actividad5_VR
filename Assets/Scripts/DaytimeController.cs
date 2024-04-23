using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaytimeController : MonoBehaviour
{

	public AudioSource daytimeAudio;
	public AudioSource nighttimeAudio;

	public Transform sun;
	public float speed = 2.0f;

	bool day = true;
	bool wasBelow = false;

	// Update is called once per frame
	void Update()
	{
		if(sun.eulerAngles.x >= 350 && wasBelow)
		{
			day = !day;
			if(day)
			{
				daytimeAudio.Play();
				nighttimeAudio.Stop();
			}
			else
			{
				nighttimeAudio.Play();
				daytimeAudio.Stop();
			}
		}

		wasBelow = sun.eulerAngles.x < 350;
		sun.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
	}

	public bool IsNight()
	{
		return !day;
	}
}
