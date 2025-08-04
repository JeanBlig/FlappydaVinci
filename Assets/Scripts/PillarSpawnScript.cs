using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PillarSpawnScript : MonoBehaviour
{
    public GameObject Pillar;
    private double spawnRate = 5;
    private float speedtimer = 10;
    private float timer = 0;
    private float timer2 = 0;
    private float heightoffset = 25;
    public PillarMove IncreasePillarSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPillar();
        IncreasePillarSpeed = Pillar.GetComponent<PillarMove>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPillar();
            timer = 0;
        }


        if (timer2 < speedtimer)
        {
            timer2 += Time.deltaTime;
        }
        else
        {
          IncreaseSpeed();
          timer2 = 0;
        }


    }

    public void SpawnPillar()
    {
        float lowestpoint = transform.position.y - heightoffset;
        float highestpoint = transform.position.y + heightoffset;
        Instantiate(Pillar, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), 0), transform.rotation);
    }
    private void IncreaseSpeed()
    {
        IncreasePillarSpeed.movespeed += 1;
        if (spawnRate > 2)
        {
            spawnRate -= 0.2;
        }
    }
    
}
