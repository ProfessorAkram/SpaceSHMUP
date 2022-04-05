/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: March 30, 2022
 * 
 * Last Edited by: Stu Dent
 * Last Edited: March 30, 2022
 * 
 * Description: Projectile behaviors
****/

/** Using Namespaces **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    /*** Variables***/
    private BoundsCheck bndCheck; //reference to the bounds check
    ProjectilePool pool; 
    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }//end Awake()

    //Start is called once before the update
    private void Start()
    {
        pool = ProjectilePool.projPool; //find the game manager
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        //if off screen up , destroy
        if (bndCheck.offUp)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false); //set the project to deactivate and return to pool
        }
    }//end Update()

    private void OnDisable()
    {
        Debug.Log("disabled");

        if ( pool != null)
        {
           
            pool.ReturnProjectile(this.gameObject); 
        }
    }//end OnDisable()


}