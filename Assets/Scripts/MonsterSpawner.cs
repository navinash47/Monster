using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    private GameObject SpawnedMonster;
    private int randomIndex;
    private int randomSide;
    [SerializeField]
    private Transform leftPos,rightPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }
    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            SpawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                //left
                SpawnedMonster.transform.position = leftPos.position;
                SpawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                //right
                SpawnedMonster.transform.position = rightPos.position;
                SpawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                SpawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
