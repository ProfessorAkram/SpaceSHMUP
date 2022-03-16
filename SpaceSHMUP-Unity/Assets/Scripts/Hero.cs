/**** 
 * Created by: Your Name
 * Date Created: March 16, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 16, 2022
 * 
 * Description: Hero ship controller
****/

/** Using Namespaces **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase] //forces selection of parent object
public class Hero : MonoBehaviour
{
    /*** VARIABLES ***/

    #region PlayerShip Singleton
    static public Hero SHIP; //refence GameManager
   
    //Check to make sure only one gm of the GameManager is in the scene
    void CheckSHIPIsInScene()
    {

        //Check if instnace is null
        if (SHIP == null)
        {
            SHIP = this; //set SHIP to this game object
        }
        else //else if SHIP is not null send an error
        {
            Debug.LogError("Hero.Awake() - Attempeeted to assign second Hero.SHIP");
        }
    }//end CheckGameManagerIsInScene()
    #endregion

    [Header("Ship Movement")]
    public float speed = 10;
    public float rollMult = -45;
    public float pitchMult = 30;

    [Space(10)]

    [SerializeField] //show in inspector
    private float shieldLevel = 1;

    /*** MEHTODS ***/

    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        CheckSHIPIsInScene(); //check for Hero SHIP
    }//end Awake()


    // Update is called once per frame (page 551)
    void Update()
    {

        //Ship input controls

    }//end Update()

}
