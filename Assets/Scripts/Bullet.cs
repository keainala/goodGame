using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
        BulletInfo info = new BulletInfo();
        info.damanage = 1;
        if (other.tag=="Boss")
        {
            other.GetComponent<Boss>().ButtleHit(info);
        }
        Destroy(gameObject);
    }
}
