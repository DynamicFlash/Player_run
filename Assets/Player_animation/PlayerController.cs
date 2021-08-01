using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool laneChange = false;
    private bool midJump = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") && (laneChange==false) && (transform.position.x>- 0.9)&& (midJump==false))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -5.8f);
            laneChange = true;
            StartCoroutine(stopLane());
        }

        if (Input.GetKey("a")  && (laneChange==false) && (transform.position.x<0.9) && (midJump==false))
        {

            GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -5.8f);
            laneChange = true;
            StartCoroutine(stopLane());
        }

        if (Input.GetKey("space") && (midJump==false))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 1,  -5.8f);
            StartCoroutine(stopJump());
        }

    }

    IEnumerator stopLane()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5.8f);
        laneChange = false;
    }

    IEnumerator stopJump()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, -1, -5.8f);
        yield return new WaitForSeconds(.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5.8f);
        midJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Obstacles")
        {
            Debug.Log("hit");
        }
    }

}
