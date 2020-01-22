using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public List< GameObject> Ground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Ground.Count; i++)
        {
            Vector3 temp= Ground[i].transform.position;
            if (temp.z < -14)
            {
                temp.z = 42;
                Ground[i].transform.position = temp;
            }
        }
        for (int i = 0; i < Ground.Count; i++)
        {
            Ground[i].transform.Translate(Vector3.back*4*Time.deltaTime );
        }
    }
}
