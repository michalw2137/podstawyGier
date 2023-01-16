using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToGravityFields : MonoBehaviour
{

    private float fallDir = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GravityHorizontal")
        {
            if (Mathf.Abs(transform.rotation.w) > Mathf.Abs(transform.rotation.z))
            {
                fallDir = 0.5f;
            }
            else
            {
                fallDir = -0.5f;
            }
            if (transform.rotation.z < 0.0f)
            {
                fallDir *= -1.0f;
            }
            Head.instance.isJumping = true;
        }


        if (other.tag == "GravityVertical")
        {
            if (transform.rotation.z < 0.0f)
            {
                fallDir = 0.5f;
            }
            else
            {
                fallDir = -0.5f;
            }
            if (Mathf.Abs(transform.rotation.w) < Mathf.Abs(transform.rotation.z))
            {
                fallDir *= -1.0f;
            }
            Head.instance.isJumping = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.tag == "GravityHorizontal" || other.tag == "GravityVertical") && Head.instance.isMoving)
        {
            Head.instance.transform.Rotate(Vector3.back * fallDir * Head.instance.SteerSpeed * Time.deltaTime);
            Head.instance.isJumping = true; // Added to prevent bug while changing gravity areas
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "GravityHorizontal" || other.tag == "GravityVertical")
        {
            Head.instance.isJumping = false;
        }
    }

    
    
}
