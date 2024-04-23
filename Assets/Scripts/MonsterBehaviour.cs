using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{

	public Transform player;
	public Rigidbody rb;

	bool dead;

	public float speed = 2.0f;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Bullet"))
		{
			dead = true;
		}
	}

	IEnumerator Die()
	{
		dead = true;
		rb.constraints = RigidbodyConstraints.None;
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update()
	{
		if(!dead)
		{
			transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
			transform.LookAt(player);
		}
	}
}
