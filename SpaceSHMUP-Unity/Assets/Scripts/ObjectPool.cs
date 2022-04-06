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

public class ObjectPool : MonoBehaviour
{

    /* VARIABLES */
    static public ObjectPool POOL;

    #region Pool Singleton
    //Check to make sure only one gm of the GameManager is in the scene
    void CheckPOOLIsInScene()
    {

        //Check if instnace is null
        if (POOL == null)
        {
            POOL = this; //set SHIP to this game object
        }
        else //else if SHIP is not null send an error
        {
            Debug.LogError("ProjectilePool.Awake() - Attempeeted to assign second ProjectilePool.projPool");
        }
    }//end CheckSHIPIsInScene()
#endregion


    
    private Queue<GameObject> projecitles = new Queue<GameObject>(); //the queue for the projectiles

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;

    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        CheckPOOLIsInScene();
    }//end Awake()


    // Start is called before the first frame update
    void Start()
    {
        

        for(int i = 0; i < poolStartSize; i++)
        {
            GameObject projectileGO = Instantiate(projectilePrefab); //create prefab instance
            projecitles.Enqueue(projectileGO); //add to queue
            projectileGO.SetActive(false);//hide projectile
            
            
        }



    }//end Start()


    public GameObject GetProjectile()
    {
        //If there are objects in the pool
        if(projecitles.Count > 0)
        {
            GameObject projectileGO = projecitles.Dequeue(); //remove from queue
            projectileGO.SetActive(true); //enable 
            return projectileGO; //return object
        }
        else
        {
            GameObject projectileGO = Instantiate(projectilePrefab); //create prefab instance if none are in queue
            return projectileGO; //return object
        }//end if(projecitles.Count > 0)

    }//end GetProjectile()

    public void ReturnProjectile(GameObject projectileGO)
    {
        projecitles.Enqueue(projectileGO); //add back to queue
        projectileGO.SetActive(false); //disable
    }//end ReturnProjectile()
}
