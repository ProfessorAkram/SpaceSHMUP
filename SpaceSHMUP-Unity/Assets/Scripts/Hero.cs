/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: March 16, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Hero ship controller
****/

/*** Using Namespaces ***/
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
    }//end CheckSHIPIsInScene()
    #endregion

    GameManager gm; //reference to game manager
    ObjectPool pool;

    [Header("Ship Movement")]
    public float speed = 10;
    public float rollMult = -45;
    public float pitchMult = 30;

    [Space(10)]

    [Header("Projectile Settings")]
   // public GameObject projectilePrefab;
    public float projectileSpeed = 40;

    [Space(10)]

    private GameObject lastTriggerGo; //reference to the last triggering game object
   
    [SerializeField] //show in inspector
    private float _shieldLevel = 1; //level for shields
    public int maxShield = 4; //maximum shield level

    //method that acts as a field (property), if the property falls below zero the game object is destroyed
    public float shieldLevel
    {
        get { return (_shieldLevel); }
        set
        {
            _shieldLevel = Mathf.Min(value, maxShield); //Min returns the smallest of the values, therby making max sheilds 4

            //if the sheild is going to be set to less than zero
            if (value < 0)
            {
                Destroy(this.gameObject);
                Debug.Log(gm.name);
                gm.LostLife();

            }//end  if (value < 0)

        }
    }//end shieldLevel

    /*** MEHTODS ***/

    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        CheckSHIPIsInScene(); //check for Hero SHIP
    }//end Awake()


    //Start is called once before the update
    private void Start()
    {
        gm = GameManager.GM; //find the game manager
        pool = ObjectPool.POOL; //find the game manager
    }//end Start()


   
    // Update is called once per frame (page 551)
        void Update()
    {

        //player input
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //Change the transform based on the axis
        Vector3 pos = transform.position;

        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;

        transform.position = pos;

        //Rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

        //check for space bar (fire)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TempFire();
            FireProjectile();
        }


    }//end Update()



    //Taking Damage
    private void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        //tranform root returens the topmost transfrom in the hierarchy (i.e. parent)

        GameObject go = rootT.gameObject; //game object of parent transform


        if (go == lastTriggerGo) { return; } //don't do anything if it's the same object we last collied with

        lastTriggerGo = go; //set the triger to the last trigger

        if (go.tag == "Enemy")
        {
            Debug.Log("Triggered by Enemy " + other.gameObject.name);
            shieldLevel--;
            Destroy(go);
        }
        else
        {
            Debug.Log("Triggered by non-Enemy " + other.gameObject.name);
        }

    }//end OnTriggerEnter()

    //Shoot projectile
  /*  void TempFire()
    {
        GameObject projGo = Instantiate<GameObject>(projectilePrefab);
        projGo.transform.position = transform.position;
        Rigidbody rb = projGo.GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * projectileSpeed;
    }*/

    void FireProjectile()
    {
        
        GameObject projectile = pool.GetProjectile(); //get object from pool
       
        //if there is a projectile object
        if(projectile != null)
        {
            projectile.transform.position = transform.position; //set position
            Rigidbody rb = projectile.GetComponent<Rigidbody>(); //get rigidbody
            rb.velocity = Vector3.up * projectileSpeed; //use velocity to move projectile
        }//end if(projectile != null)

    }//end FireProjectile()

    //Add to the Score
    public void AddToScore(int value)
    {
        gm.UpdateScore(value);
    }//end AddToScore()

}
