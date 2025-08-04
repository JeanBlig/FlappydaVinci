using UnityEngine;

public class DaVinciWorksScript : MonoBehaviour
{
    public float movespeed = 10;
    private float deadzone = -180;
    
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
    }
}
