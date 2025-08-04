using UnityEngine;

public class RightwingScript : MonoBehaviour
{
    public Animator RightWing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSpaceFlap2()
    {
        RightWing.SetTrigger("Flap2");
    }
}
