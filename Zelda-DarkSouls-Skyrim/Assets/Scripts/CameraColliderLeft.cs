using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliderLeft : MonoBehaviour {

    GameObject player;
    //playerMovement pm;
    player2Movement pm;
    Vector3 camPos;
    Vector3 newPos;

    Vector3 playerPos;
    Vector3 newPlayerPos;

    public float duration = 1;
    private float currentTime = 0;
    public bool camTransition = false;
    private Vector2 direction = Vector2.zero;

    CameraColliderUp cu;
    CameraColliderDown cd;
    CameraColliderRight cr;

    Collider2D ccu;
    Collider2D ccd;
    Collider2D ccl;
    Collider2D ccr;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //pm = player.GetComponent<playerMovement>();
        pm = player.GetComponent<player2Movement>();

        cu = GameObject.Find("CamColliderUp").GetComponent<CameraColliderUp>();
        cd = GameObject.Find("CamColliderDown").GetComponent<CameraColliderDown>();
        cr = GameObject.Find("CamColliderRight").GetComponent<CameraColliderRight>();

        ccu = GameObject.Find("CamColliderUp").GetComponent<Collider2D>();
        ccd = GameObject.Find("CamColliderDown").GetComponent<Collider2D>();
        ccl = GameObject.Find("CamColliderLeft").GetComponent<Collider2D>();
        ccr = GameObject.Find("CamColliderRight").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (camTransition)
        {
            if (currentTime <= duration)
            {
                currentTime += Time.deltaTime;
                transform.parent.position = Vector3.Lerp(camPos, newPos, currentTime / duration);
                player.transform.position = Vector3.Lerp(playerPos, newPlayerPos, currentTime / duration);
            }
            else
            {
                pm.canMove = true;
                ccu.isTrigger = true;
                ccd.isTrigger = true;
                ccl.isTrigger = true;
                ccr.isTrigger = true;

                transform.parent.position = newPos;
                player.transform.position = newPlayerPos;
                camPos = newPos;
                newPos.x -= 5;
                currentTime = 0;
                camTransition = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Left");
        //Current camera and player position
        camPos = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
        playerPos = player.transform.position;

        //New camera position
        newPos = new Vector3(transform.parent.position.x - 5, transform.parent.position.y, transform.parent.position.z);
        newPlayerPos = new Vector3(playerPos.x - 0.75f, playerPos.y, playerPos.z);

        //Disable player movements
        pm.canMove = false;

        //Disable the remainder colliders
        //ccu.enabled = false;
        //ccd.enabled = false;
        //ccl.enabled = false;
        //ccr.enabled = false;
        ccu.isTrigger = false;
        ccd.isTrigger = false;
        ccl.isTrigger = false;
        ccr.isTrigger = false;

        camTransition = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
