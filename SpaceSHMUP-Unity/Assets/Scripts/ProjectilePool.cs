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
    static public ProjectilePool projPool;

    #region Pool Singleton
    //Check to make sure only one gm of the GameManager is in the scene
    void CheckPOOLIsInScene()
    {

        //Check if instnace is null
        if (projPool == null)
        {
            projPool = this; //set SHIP to this game object
        }
        else //else if SHIP is not null send an error
        {
            Debug.LogError("ProjectilePool.Awake() - Attempeeted to assign second ProjectilePool.projPool");
        }
    }//end CheckSHIPIsInScene()
#endregion


    [HideInInspector]
    public List<GameObject> projecitles;

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int projectileAmount;

    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        CheckPOOLIsInScene();
    }//end Awake()


    // Start is called before the first frame update
    void Start()
    {
        projecitles = new List<GameObject>();
        

        for(int i = 0; i < projectileAmount; i++)
        {
            GameObject projectileInstance = Instantiate(projectilePrefab); //create prefab instance
            projectileInstance.SetActive(false); //set instance to inactive
            projecitles.Add(projectileInstance); //add object to list
        }



    }//end Start()

    
    public GameObject GetProjectile()
    {
      
        foreach (GameObject projectile in projecitles)
        {
            
            //if the object is not active in the scene
            if (!projectile.activeInHierarchy)
            {  Debug.Log("GetProjectile");
                projectile.SetActive(true);//make the projectile active
                return projectile;  //return the object
            }

        }
        GameObject projectileInstance = Instantiate(projectilePrefab); //create prefab instance
        projecitles.Add(projectileInstance); //add object to list
        return projectileInstance;  //return the object

    }//end GetProjectile()
}
