using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalBehavior : MonoBehaviour
{

    public bool shaking = false;

    public IEnumerator Shake()
    {
        shaking = true;
        yield return new WaitForSeconds(1);
        shaking = false;
    }

    public void StartShaking()
    {
        shaking = true;
    }

    public void StopShaking()
    {
        shaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shaking)
        {
            transform.localEulerAngles = new Vector3(0, 2.5f * Mathf.Sin(19.6f * Time.time), 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
		}
	}
}
