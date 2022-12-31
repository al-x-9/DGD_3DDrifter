using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCar : MonoBehaviour
{

    public float speed;
    public float turnSpeed;


    public float gravityMuliplier;

    public float rayRange = 1f;
    public Transform groundDetect;
    public LayerMask whatIsGround;

    private bool isGrounded;
    private Rigidbody carRigidbody;


    // Start is called before the first frame update
    void Start()
    {

        carRigidbody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {


        Vector3 rayDirection = Vector3.down;

        Ray carRay = new Ray(groundDetect.position, transform.TransformDirection(rayDirection * rayRange));
        //Debug.DrawRay(groundDetect.position, transform.TransformDirection(rayDirection * rayRange));

        if (Physics.Raycast(carRay, out RaycastHit hit, rayRange, whatIsGround))
        {

            Debug.Log("ON THE GROUND");
            isGrounded = true;

        }
        else
        {

            Debug.Log("CATCHING AIR");
            isGrounded = false;
        }


        /*if (isGrounded)

        {
            //Debug.Log("IS GROUNDED - FREEZE X & Z ROTATION");
            //carRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
       
            
        }
        else if (!isGrounded)

        {
            //Debug.Log("IS NOT GROUNDED - NO CONSTRAINTS");
            //carRigidbody.constraints = RigidbodyConstraints.None;

            

            //Vector3 carRotation = new Vector3(Mathf.Clamp(transform.rotation.x, 345, 0), transform.rotation.y,transform.rotation.z);
            //transform.localEulerAngles += carRotation;

        }**/

    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            carRigidbody.constraints = RigidbodyConstraints.None;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 forceToAdd = transform.forward;
                forceToAdd.y = 0;
                carRigidbody.AddForce(forceToAdd * speed * 10);
            


            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 forceToAdd = -transform.forward;
                forceToAdd.y = 0;
                carRigidbody.AddForce(forceToAdd * speed * 10);
               
            }


            if (Input.GetKey(KeyCode.RightArrow))
            {
                carRigidbody.AddTorque(Vector3.up * turnSpeed * 5);

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                carRigidbody.AddTorque(-Vector3.up * turnSpeed * 5);
            }

        }
        else
        {
            carRigidbody.AddForce(Vector3.down * gravityMuliplier * 10);
            carRigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;

        }

        //carRigidbody.AddForce(Vector3.down * gravityMuliplier * 10);



        Vector3 localVelocity = transform.InverseTransformDirection(carRigidbody.velocity);
        localVelocity.x = 0;
        carRigidbody.velocity = transform.TransformDirection(localVelocity);

        //carRigidbody.AddForce(Vector3.down * gravityMuliplier * 10);
    }
}