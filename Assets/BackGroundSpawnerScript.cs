using UnityEngine;

public class BackGroundSpawnerScript : MonoBehaviour
{
    public GameObject Back;
    private float spawnRate = 60;
    private float timer = 0;
    public int currentSpriteIndex = 0;
    private float heightoffset = 18;
    private float speedtimer = 0;

    public BackgroundMove IncreaseBackgroundSpeed;

    public Sprite[] Sprites;
    public SpriteRenderer DifferentPainting;

    
    void Start()
    {
        DifferentPainting = Back.GetComponent<SpriteRenderer>();
        DifferentPainting.sprite = Sprites[currentSpriteIndex];
        IncreaseBackgroundSpeed = Back.GetComponent<BackgroundMove>();
        SpawnBack();
    }

    
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            ToggleSprite();
            SpawnBack();
            timer = 0;
        }
        
        speedtimer += Time.deltaTime;
        if (speedtimer > 10)
        {
            IncreaseSpeed();
            speedtimer = 0;
        }
        

    }

    public void SpawnBack()
    {
        float lowestpoint = transform.position.y - heightoffset;
        float highestpoint = transform.position.y + heightoffset;
        float randomScale = Random.Range(10f, 30f);
        Back.transform.localScale = new Vector3(randomScale, randomScale, 1f);
        Instantiate(Back, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), 0), transform.rotation);
    }

    public void ToggleSprite()
    {
        currentSpriteIndex++;

        if (currentSpriteIndex >= Sprites.Length)
        {
            currentSpriteIndex = 0;
        }
        DifferentPainting.sprite = Sprites[currentSpriteIndex];
    }

    private void IncreaseSpeed()
    {
        IncreaseBackgroundSpeed.movespeed += 0.5f;
        if (spawnRate > 10)
        {
          spawnRate -= 2;
        }
        
    }
    
}
