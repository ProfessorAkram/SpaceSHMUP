/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: April 1, 2022
 * 
 * Last Edited by: Stu Dent
 * Last Edited: April 1, 2022
 * 
 * Description: Pool for the projectiles
****/

/** Using Namespaces **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{

    /* VARIABLES */
    [Header("Pool Settings")]
    public static ProjectilePool projectilesPool;
    private List<GameObject> projecitlesList;
    public GameObject projectilePrefab;
    public int projectilePoolCount;

    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        projectilesPool = this; 
    }//end Awake()


    // Start is called before the first frame update
    void Start()
    {
        projecitlesList = new List<GameObject>();
        GameObject tmpGo; //temporary object

        for(int i = 0; i < projectilePoolCount; i++)
        {
            tmpGo = Instantiate(projectilePrefab); //create prefab instance
            tmpGo.SetActive(false); //set instance to inactive
            projecitlesList.Add(tmpGo); //add object to list
        }



    }//end Start()

    
    public GameObject GetProjectile()
    {
        for (int i = 0; i < projectilePoolCount; i++)
        {
            //if the object is active in the scene
            if (!projecitlesList[i].activeInHierarchy)
            {
                return projecitlesList[i];  //return the object
            }

        }
        return null; 

    }//end GetProjectile()
}
