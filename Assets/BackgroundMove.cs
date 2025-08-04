using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float movespeed = 5;
    private float deadzone = -300;

    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * movespeed * Time.deltaTime;
        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    
    }
    
}
