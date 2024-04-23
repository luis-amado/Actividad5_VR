using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    public Transform player;
    public GameObject monster;
    public DaytimeController daytime;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(true)
        {
            if(daytime.IsNight())
            {
                Vector2 pos = Random.insideUnitCircle;
                Vector3 position = new Vector3(player.position.x + pos.x * 20, transform.position.y, player.position.y + pos.y * 20);

                GameObject spawned = Instantiate(monster, position, Quaternion.identity, transform);
                spawned.GetComponent<MonsterBehaviour>().player = player;
            }
            yield return new WaitForSeconds(Random.Range(3.0f, 8.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
