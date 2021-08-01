using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            GetComponent<Animator>().SetBool("IsJumping", true);
            StartCoroutine(stopJump());
        }
    }

    IEnumerator stopJump()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetBool("IsJumping", false);
    }
}
