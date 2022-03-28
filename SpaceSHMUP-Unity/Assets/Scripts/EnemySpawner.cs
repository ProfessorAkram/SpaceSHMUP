/**** 
 * Created by: Your Name
 * Date Created: March 28 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 16, 2022
 * 
 * Description: Spawns eniemes
****/

/** Using Namespaces **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*** VARIABLES ***/

    public GameObject[] prefabEnemies;//array of all enemey prefabs
    public float enemySpawnPerSecond;//enemey count to spawn per second
    public float enemyDefaultPadding; //padding postition of each enemy

    private BoundsCheck bndCheck; //reference to the bounds check component


    // Start is called before the first frame update
    void Start()
    {

        bndCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }//end Start()

    public void SpawnEnemy()
    {
        //pick a random enemy to instantiate
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        //Position the enemy above the screen with a random X positon
        float enemyPadding = enemyDefaultPadding; 
        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius); 
        }

        //Set the intial position 
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;

        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;

        go.transform.position = pos;

        //invoke again
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); 

    }//end SpawnEnemy()
}
