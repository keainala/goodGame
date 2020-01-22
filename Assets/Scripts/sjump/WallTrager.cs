using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrager : MonoBehaviour
{
    public GameObject Des;
    public bool State=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Des.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (State)
        {
            Des.SetActive(false);
        }
    }
}
