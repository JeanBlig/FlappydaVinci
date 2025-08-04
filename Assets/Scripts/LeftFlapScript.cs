using UnityEngine;

public class LeftFlapScript : MonoBehaviour
{
    public Animator LeftFlap;
    public Animator RightFlap;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSpaceFlap()
    {
    LeftFlap.SetTrigger("Flap");
    }
}
