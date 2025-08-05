using UnityEngine;
using TMPro;

public class DoYouKnowScript : MonoBehaviour
{
    public GameObject Works; // parent
    public GameObject Pillar;
    PillarMove DestroyPillar;

    DaVinciWorksScript WorkSpeed; // works script;

    Transform Work1; // child 1
    Transform Work2; // child 2
    Transform Work3; // child 3

    Transform Work1Text;  // child1 > text
    Transform Work2Text;  // child2 > text
    Transform Work3Text;  // child3 > text

    TextMeshPro Text1;
    TextMeshPro Text2;
    TextMeshPro Text3;
    SpriteRenderer FirstWorkRenderer;
    SpriteRenderer SecondWorkRenderer;
    SpriteRenderer ThirdWorkRenderer;
    BoxCollider2D Box1;
    BoxCollider2D Box2;
    BoxCollider2D Box3;

    

    public Sprite[] DaVinciWorks;
    public Sprite[] ForeignWorks;

    private string[] DaVinciNames = new string[]
    {
    "Mona Lisa", "Vitruvian Man", "Annunciation", "Madonna of the Carnation", "The Baptism of Christ", "The Last Supper",
    "Salvator Mundi", "Codex Atlanticus", "Codex Windsor", "Paris Manuscripts", "Codex Forster", "Codex Arundel"
    };
    private string[] ForeignNames = new string[]
    {
    "The School of Athens", "Transfiguration", "The Sistine Madonna", "Sistine Chapel Ceiling", "The Creation of Adam", "Dying Slave",
    "Galilean Telescope", "Galilean Thermometer", "Gutenburg Printing Press", "Florence Cathederal", "Penetent Magndalene", "Saint George"
    };

    private float spawnrate = 30f;
    private float timer = 0;
    private float speedtimer = 10;
    private float timer2 = 0;
    private float destroytimer = 16;
    private float timer3 = 0;

    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Works Script
       WorkSpeed = Works.GetComponent<DaVinciWorksScript>();

        //SPRITES
       Work1 = Works.transform.Find("FirstWork");
       FirstWorkRenderer = Work1.GetComponent<SpriteRenderer>();
       Work2 = Works.transform.Find("SecondWork");
       SecondWorkRenderer = Work2.GetComponent<SpriteRenderer>();
       Work3 = Works.transform.Find("ThirdWork");
       ThirdWorkRenderer = Work3.GetComponent<SpriteRenderer>();

        //TEXT
       Work1Text = Works.transform.Find("FirstWork/Text1");
       Text1 = Work1Text.GetComponent<TextMeshPro>();

       Work2Text = Works.transform.Find("SecondWork/Text2");
       Text2 = Work2Text.GetComponent<TextMeshPro>();

       Work3Text = Works.transform.Find("ThirdWork/Text3");
       Text3 = Work3Text.GetComponent<TextMeshPro>();

        //Box
        Box1 = Work1.GetComponent<BoxCollider2D>();
        Box2 = Work2.GetComponent<BoxCollider2D>();
        Box3 = Work3.GetComponent<BoxCollider2D>();

        DestroyPillar = Pillar.GetComponent<PillarMove>();
        //Match Works
        FigureMatching();
        //Logic Script
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spawnrate
        
        timer += Time.deltaTime;
        
        // Destroy 5 seconds before spawn for 10 seconds long
        if(timer >= 25)
        {
            DestroyPillar.Safe = false;
        }
        if(DestroyPillar.Safe == false)
        {
            timer3 += Time.deltaTime;
        }
        if(timer3 > destroytimer)
        {
            DestroyPillar.Safe = true;
            timer3 = 0;
        }
        // Spawn
        if(timer >= spawnrate)
        {
            SpawnFigure();
            FigureMatching();
            timer = 0;
        }
        // Increase speed at same time
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
    
    private void FigureMatching()
    {
        int RandomPos = Random.Range(0, 3);
        int RandomDaVinci = Random.Range(0, 12);
        int RandomForeing = Random.Range(0, 12);
        int RandomForeing2 = Random.Range(0, 12);

        if (RandomPos == 0)
        {
            //davinci work
            FirstWorkRenderer.sprite = DaVinciWorks[RandomDaVinci];
            Text1.text = DaVinciNames[RandomDaVinci];
            Box1.isTrigger = true;
            //other work
            SecondWorkRenderer.sprite = ForeignWorks[RandomForeing];
            Text2.text = ForeignNames[RandomForeing];
            Box2.isTrigger = false;
            ThirdWorkRenderer.sprite = ForeignWorks[RandomForeing2];
            Box3.isTrigger = false;
            Text3.text = ForeignNames[RandomForeing2];

        }
        else if (RandomPos == 1)
        {
            //davinci work
            SecondWorkRenderer.sprite = DaVinciWorks[RandomDaVinci];
            Text2.text = DaVinciNames[RandomDaVinci];
            Box2.isTrigger = true;
            //other work
            FirstWorkRenderer.sprite = ForeignWorks[RandomForeing];
            Text1.text = ForeignNames[RandomForeing];
            Box1.isTrigger = false;
            ThirdWorkRenderer.sprite = ForeignWorks[RandomForeing2];
            Text3.text = ForeignNames[RandomForeing2];
            Box3.isTrigger = false;
        }
        else
        {
            //davinci work
            ThirdWorkRenderer.sprite = DaVinciWorks[RandomDaVinci];
            Text3.text = DaVinciNames[RandomDaVinci];
            Box3.isTrigger = true;
            //other work
            SecondWorkRenderer.sprite = ForeignWorks[RandomForeing];
            Text2.text = ForeignNames[RandomForeing];
            Box2.isTrigger = false;
            FirstWorkRenderer.sprite = ForeignWorks[RandomForeing2];
            Text1.text = ForeignNames[RandomForeing2];
            Box1.isTrigger = false;
        }
    }

    private void SpawnFigure()
    {
        Instantiate(Works);
    }
    
    private void IncreaseSpeed()
    {
        if (WorkSpeed.movespeed < 20)
        {
            WorkSpeed.movespeed += 1;
        }
        
        /*
        if (spawnRate > 2)
        {
            spawnRate -= 0.2f;
        }
        */
    }

    
}
