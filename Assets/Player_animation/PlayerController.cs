using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -5.8f);
            StartCoroutine(stopLane());
        }

        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -5.8f);
            StartCoroutine(stopLane());
        }
    }

    IEnumerator stopLane()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5.8f);
    }
}
