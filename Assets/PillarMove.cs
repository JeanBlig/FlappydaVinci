using UnityEngine;

public class PillarMove : MonoBehaviour
{
    public float movespeed = 15;

    public float deadzone = -80;

    public bool Safe = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * movespeed * Time.deltaTime;
        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
        else if (Safe == false && transform.position.x > 70)
        {
            Destroy(gameObject);
        }
        
    }

}
