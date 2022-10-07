using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        nextTeleportTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        HandleControl();
        Teleport();
    }

    void LateUpdate()
    {

    }
    void HandleControl()
    {
        
        var newPos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime ;

        //x? lý th? này ?? tránh vi?c gi?t gi?t khi dùng rigidbody ?? detect t??ng
        if (newPos.x + this.transform.position.x <= 8.42 && newPos.x + this.transform.position.x >= -8.42 && newPos.y + this.transform.position.y<= 4.54 && newPos.y+this.transform.position.y >= -4.54)
        {
            this.transform.Translate(newPos);
        }
    }


    private float nextTeleportTime;
    public float TeleportDelay;
    public float TeleportRange;
    void Teleport()
    {
        if (Input.GetKey(KeyCode.Space) && nextTeleportTime<=Time.time)
        {
            var newPos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * TeleportRange + this.transform.position;
            if (newPos.x <= 8.42 && newPos.x >= -8.42 && newPos.y <= 4.54 && newPos.y>= -4.54)
            {
                this.transform.position=newPos;
                nextTeleportTime = Time.time + TeleportDelay;
            }     
        }
    }
}
