using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Hide());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Hide()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
