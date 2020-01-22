using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject m_boosObj;
    public float m_Boss=0.2f;
    //public GameObject pos;
    public List<GameObject> path;
    public GameObject target;
    public GameObject dragen;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        return;
        m_Boss -= Time.deltaTime;
        if (m_Boss<=0)
        {
            m_Boss = 0.2f;
            GameObject temp = Instantiate(dragen);
            int index = Random.Range(0,5);
            temp.transform.position = path[index].transform.position;
            temp.GetComponent<Boss>().SetTarget(target);
        }
    }
}
