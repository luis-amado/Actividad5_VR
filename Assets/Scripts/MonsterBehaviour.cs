using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

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
			StartCoroutine(Die());
		}
	}

	IEnumerator Die()
	{
		dead = true;
		GetComponents<AudioSource>().All(s => {
			s.Stop();
			return true;
		});
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
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		}
	}
}
