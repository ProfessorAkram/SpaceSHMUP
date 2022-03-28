/**** 
<<<<<<< Updated upstream
 * Created by: Your Name
 * Date Created: March 28 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 16, 2022
 * 
 * Description: Spawns eniemes
=======
 * Created by: Stu Dent
 * Date Created: March 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 28, 2022
 * 
 * Description: Spawn enemies
>>>>>>> Stashed changes
****/

/** Using Namespaces **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*** VARIABLES ***/
<<<<<<< Updated upstream

    public GameObject[] prefabEnemies;//array of all enemey prefabs
    public float enemySpawnPerSecond;//enemey count to spawn per second
    public float enemyDefaultPadding; //padding postition of each enemy

    private BoundsCheck bndCheck; //reference to the bounds check component
=======
    [Header("Enemy settings")]
    public GameObject[] prefabEnemies; //array of all enemy prefabs
    public float enemySpawnPerSecond; //enemy count to spawn per second
    public float enemyDefaultPadding;//padding positon of each enemy

    private BoundsCheck bndCheck; //reference to the bounds check componet

>>>>>>> Stashed changes


    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream

        bndCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }//end Start()

    public void SpawnEnemy()
=======
        bndCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); 
    }//end Start()

  
    void SpawnEnemy()
>>>>>>> Stashed changes
    {
        //pick a random enemy to instantiate
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

<<<<<<< Updated upstream
        //Position the enemy above the screen with a random X positon
        float enemyPadding = enemyDefaultPadding; 
=======
        //Position the enemy above the screne with a random x position
        float enemyPadding = enemyDefaultPadding; 

>>>>>>> Stashed changes
        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius); 
        }

<<<<<<< Updated upstream
        //Set the intial position 
=======
        //Set the intial position
>>>>>>> Stashed changes
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;

<<<<<<< Updated upstream
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;

=======
        pos.x = Random.Range(xMin, xMax); //range between the xmin and xmax
        pos.y = bndCheck.camHeight + enemyPadding; // height plus padding, off screen
>>>>>>> Stashed changes
        go.transform.position = pos;

        //invoke again
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); 

<<<<<<< Updated upstream
=======
        
>>>>>>> Stashed changes
    }//end SpawnEnemy()
}
