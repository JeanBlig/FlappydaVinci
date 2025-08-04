using UnityEngine;

public class PillarMiddleScript : MonoBehaviour
{
    public LogicScript Logic;
    public AudioSource PillarSpeaker;
    public AudioClip ScoreSound;

    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Logic.addScore(1);
        PillarSpeaker.PlayOneShot(ScoreSound);
    }

}
