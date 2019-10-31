using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float ForwardSpeed;
    public float StrafeSpeed;
    public Transform env;
    public float RotateSpeed;
    public bool isGrounded = true;

    private void FixedUpdate()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
            case 2:
                GetComponent<Rigidbody>().AddForce(new Vector3(CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * StrafeSpeed, 0f, ForwardSpeed * Time.deltaTime), ForceMode.VelocityChange);
                break;
            case 3:
                GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, ForwardSpeed * Time.deltaTime), ForceMode.VelocityChange);
                env.Rotate(new Vector3(0f, 0f, CrossPlatformInputManager.GetAxis("Horizontal") * RotateSpeed * Time.deltaTime));
                break;
        }
    }

    private void LateUpdate()
    {
        if (isGrounded)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                Physics.gravity = new Vector3(0f, Physics.gravity.y * -1, 0f);
                if (FindObjectOfType<AudioManager>() != null)
                {
                    FindObjectOfType<AudioManager>().Play("GravSwap");
                }

                isGrounded = false;
            } 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}
