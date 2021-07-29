using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform roadBlockObj;
    private Vector3 nextRoadLoc;

    //Obsticle locations
    private Vector3 nextObsLoc0; 
    private Vector3 nextObsLoc1;

    //Obsticles
    public Transform BarrelObj;
    public Transform BoxesStacked;
    public Transform Garbagebags;
    public Transform PropaneTank;
    public Transform WoodenCreats;

    //Spawn obj
    private Transform SpawnObj;
    private Transform prevSpawnObj;

    private int randX;
    private int prevRandX;
    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()

    {   prevSpawnObj = BarrelObj;
        nextRoadLoc.z = (float)-63.8;
        StartCoroutine(spawnRoadBlock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int RandomNum()
    {   
        return rand.Next(100);
    }

    int randomXpos(int prevRandX)
    {
        int randX;

        do
        {
            randX = Random.Range(-1, 2);
        }
        while(randX == prevRandX);

        return randX;
    }

    void SpawnObstacles(Transform SpawnObj, Vector3 nextObsLoc)
    {
        Instantiate(SpawnObj, nextObsLoc, SpawnObj.rotation);
    }

    Transform getSpawnObstacles(Transform prevSpawnObj)
    {   Transform SpawnObj;
        int randomiser; 

        do
        {   
            randomiser = RandomNum();

            if (randomiser<50)
            {   
                if (randomiser<25)
                {   
                    Debug.Log("Garbage");     
                    SpawnObj = Garbagebags;

                }
                else
                {   Debug.Log("Barrel");     
                    SpawnObj = BarrelObj;
                }

            }

            else
            {   
                if (randomiser<65)
                {
                    Debug.Log("propane");     
                    SpawnObj = PropaneTank;
                }
                else if(randomiser<75)
                {   Debug.Log("creates");     
                    SpawnObj = WoodenCreats;
                }
                else
                {   Debug.Log("Boxes");     
                    SpawnObj = BoxesStacked;
                }
            }
        
        }while (SpawnObj == prevSpawnObj);

        return SpawnObj;
    }

    IEnumerator spawnRoadBlock()
    {
        yield return new WaitForSeconds(1);

        //Randomisation of object and x position
        randX = Random.Range(-1,2);
        prevRandX = randX;

        nextObsLoc0 = nextRoadLoc;
        nextObsLoc0.x = randX;
        nextObsLoc0.y = 0.165f;
        
        Instantiate(roadBlockObj, nextRoadLoc, roadBlockObj.rotation);

        SpawnObj = getSpawnObstacles(prevSpawnObj);
        SpawnObstacles(SpawnObj, nextObsLoc0);
        prevSpawnObj = SpawnObj;

        randX = randomXpos(prevRandX);
        nextObsLoc1 = nextRoadLoc;

        nextObsLoc1.x = randX;
        nextObsLoc1.y = 0.165f;

        SpawnObj = getSpawnObstacles(prevSpawnObj);
        SpawnObstacles(SpawnObj, nextObsLoc1);
        prevSpawnObj = SpawnObj;

        nextRoadLoc.z -= (float)5.8;
        StartCoroutine(spawnRoadBlock());
    }
}
