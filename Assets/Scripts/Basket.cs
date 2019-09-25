﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    void Update()
    {
        //Get the current screen pos of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //The Camera's z position sets how far to push the mouse i
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D Game World
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of this Basket to the x position of
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        //find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }
    }
}
