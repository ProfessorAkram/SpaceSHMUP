/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: April 1, 2022
 * 
 * Last Edited by: Stu Dent
 * Last Edited: April 1, 2022
 * 
 * Description: Creates a pool of objects for reuse
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
            Debug.LogError("POOL.Awake() - Attempeeted to assign second ObjectPool.POOL");
        }
    }//end CheckSHIPIsInScene()
#endregion


    
    private Queue<GameObject> projectiles = new Queue<GameObject>(); //the queue for the projectiles

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
        
 

    }//end Start()

}
