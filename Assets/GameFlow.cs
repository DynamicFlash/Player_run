using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform roadBlockObj;
    private Vector3 nextRoadLoc;

    public Transform BarrelObj;
    private Vector3 nextBarrelLoc;

    private int randX;

    // Start is called before the first frame update
    void Start()
    {
        nextRoadLoc.z = (float)-63.8;
        StartCoroutine(spawnRoadBlock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnRoadBlock()
    {
        yield return new WaitForSeconds(1);

        randX = Random.Range(-1,2);
        nextBarrelLoc = nextRoadLoc;
        nextBarrelLoc.x = randX;

        Instantiate(roadBlockObj, nextRoadLoc, roadBlockObj.rotation);
        Instantiate(BarrelObj, nextBarrelLoc, BarrelObj.rotation);

        nextRoadLoc.z -= (float)5.8;
        StartCoroutine(spawnRoadBlock());
    }
}
