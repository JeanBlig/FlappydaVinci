using UnityEngine;

public class SecondWorkScript : MonoBehaviour
{
    public LogicScript Logic;
    public AudioSource SecondSpeaker;
    public AudioClip SecondSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       Logic.addScore(2);
       SecondSpeaker.PlayOneShot(SecondSound);
    }
}
