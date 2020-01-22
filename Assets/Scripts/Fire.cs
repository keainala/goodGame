using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float cd=0.3f;
    public bool isFire = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cd -= Time.deltaTime;
        //if (cd <= 0)
        {
            //cd = 0.3f;
            if (Input.GetKey( KeyCode.J)) { isFire = true; }
            else { isFire = false; }
            //if (Input.GetMouseButtonDown(0))
            //{
            //    cd = Time.time;
            //}
            if (Input.GetKey(KeyCode.J))
            {
                cd -= Time.deltaTime;
                //RaycastHit hit;
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //if (Physics.Raycast(ray, out hit))
                if(cd<=0)
                {
                    cd = 0.3f;
                    float xuli = Time.time - cd;
                    xuli = Mathf.Min(xuli,3);
                    xuli = Mathf.Max(1,xuli);
                    Debug.Log(xuli);
                    GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    bullet.transform.position = transform.position;
                    Rigidbody bu = bullet.AddComponent<Rigidbody>();
                    bullet.transform.localScale = Vector3.one * 0.3f* xuli;
                    bu.useGravity = false;
                    bullet.AddComponent<Bullet>();
                    bullet.GetComponent<SphereCollider>().isTrigger = true;
                    bu.AddForce(transform.forward * 30, ForceMode.VelocityChange);
                }
            }


        }
 
    }
}
