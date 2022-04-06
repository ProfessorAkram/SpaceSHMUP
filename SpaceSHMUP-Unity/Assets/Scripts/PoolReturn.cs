/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: April 1, 2022
 * 
 * Last Edited by: Stu Dent
 * Last Edited: April 1, 2022
 * 
 * Description: Return objects back into the pool
****/

/** Using Namespaces **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    private ObjectPool pool;

    //Start is called once before the update
    private void Start()
    {
        pool = ObjectPool.POOL; //find the game manager
    }//end Start()

    private void OnDisable()
     {
        //if the pool is not empty
         if ( pool != null)
         { 
            pool.ReturnProjectile(this.gameObject); //return to pool 

         }//end if ( pool != null)

    }//end OnDisable()
    
}
