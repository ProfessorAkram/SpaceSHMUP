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

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }//end Awake()

    // Update is called once per frame
    void Update()
    {
        //if off screen up , destroy
        if (bndCheck.offUp)
        {
            Destroy(gameObject);
        }
    }//end Update()
}