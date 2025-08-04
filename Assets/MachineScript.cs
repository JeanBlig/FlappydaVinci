
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float FlapStrength;
    public LogicScript Logic;
    bool MachineIsAlive = true;
    public LeftFlapScript Flap;
    public RightwingScript Flap2;
    public AudioSource MachineSpeaker;
    public AudioClip FlapSound;
    
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Flap = GameObject.FindGameObjectWithTag("LeftWing").GetComponent<LeftFlapScript>();
        Flap2 = GameObject.FindGameObjectWithTag("RightWing").GetComponent<RightwingScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && MachineIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * FlapStrength;
            Flap.OnSpaceFlap();
            Flap2.OnSpaceFlap2();
            MachineSpeaker.PlayOneShot(FlapSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision0)
    {
        Logic.GameOver();
        MachineIsAlive = false;
    }
}
