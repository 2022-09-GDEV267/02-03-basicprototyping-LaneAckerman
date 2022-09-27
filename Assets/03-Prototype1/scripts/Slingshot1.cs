using UnityEngine;

using System.Collections;



public class Slingshot1 : MonoBehaviour
{
    static private Slingshot1 S;

    // fields set in the Unity Inspector pane

    [Header("Set in Inspector")]                                            

    public GameObject cue;

    public float velocityMult = 8f;

    bool isSet = true;


    // fields set dynamically

    [Header("Set Dynamically")]                                             

    public GameObject launchPoint;

    public Vector3 launchPos;                                   

    //public GameObject projectile;                                  

    public bool aimingMode;

    private Rigidbody cueRigidbody;


    static public Vector3 LAUNCH_POS
    {                                        

        get
        {

            if (S == null) return Vector3.zero;

            return S.launchPos;

        }

    }

    void Awake()
    {
        S = this;

        Transform launchPointTrans = transform.Find("LaunchPoint");              

        launchPoint = launchPointTrans.gameObject;

        launchPoint.SetActive(false);

        launchPos = launchPointTrans.position;

        cueRigidbody = cue.GetComponent<Rigidbody>();

    }



    void OnMouseEnter()
    {

        //print("Slingshot:OnMouseEnter()");

        launchPoint.SetActive(true);                                           

    }



    void OnMouseExit()
    {

        //print("Slingshot:OnMouseExit()");

        launchPoint.SetActive(false);                                          

    }

    void OnMouseDown()
    {
        if (isSet == true)
        {

            // The player has pressed the mouse button while over Slingshot

            aimingMode = true;

            // Instantiate a Projectile

            //projectile = cue;

            // Start it at the launchPoint

            //cue.transform.position = launchPos;

            // Set it to isKinematic for now

            //cueRigidbody = cue.GetComponent<Rigidbody>();

            cueRigidbody.isKinematic = true;
        }

        else
        {
            return;
        }
   


    }

    void Update()
    {

        // If Slingshot is not in aimingMode, don't run this code

        if (!aimingMode) return;                                                   



        // Get the current mouse position in 2D screen coordinates

        Vector3 mousePos2D = Input.mousePosition;                                  

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);



        // Find the delta from the launchPos to the mousePos3D

        Vector3 mouseDelta = mousePos3D - launchPos;

        // Limit mouseDelta to the radius of the Slingshot SphereCollider          

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        if (mouseDelta.magnitude > maxMagnitude)
        {

            mouseDelta.Normalize();

            mouseDelta *= maxMagnitude;

        }
         if (Mathf.Approximately(cueRigidbody.velocity.x, 0) && Mathf.Approximately(cueRigidbody.velocity.z, 0))
        {
            isSet = true;
        }

        else
        {
            isSet = false;
        }



        // Move the projectile to this new position

        //Vector3 projPos = launchPos + mouseDelta;

        //cue.transform.position = projPos;



        if (Input.GetMouseButtonUp(0))
        {                                         

            // The mouse has been released

            aimingMode = false;

            cueRigidbody.isKinematic = false;

            cueRigidbody.velocity = -mouseDelta * velocityMult;

            //FollowCam.POI = cue;

            //cue = null;

            //MissionDemolition.ShotFired();                             

            ProjectileLine1.S.poi = cue;

        }

    }


}
