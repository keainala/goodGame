using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss : MonoBehaviour
{
    public GameObject player;
    public int hp = 1;
    Transform tar;
    // Start is called before the first frame update
    void Start()
    {

        //   player = GameObject.Find("Basic Motions Dummy");
        //tar = player.transform;
    }
    public void SetTarget(GameObject _tar)
    {
        player = _tar;
        transform.LookAt(player.transform);
    }
    float cd = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Translate( (player.transform.position - transform.position ).normalized/80,Space.World);
    }
    public void ButtleHit(BulletInfo info)
    {
        hp -= info.damanage;
        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }
}
