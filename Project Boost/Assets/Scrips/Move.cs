using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float jump = 1f;
    [SerializeField] float rotationSpeed = 1f;
    Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    

    void Update()
    {
        ProcessJump();
        ProcessRotation();
    }

       void ProcessJump()
       {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up* Time.deltaTime * jump);

        }
       }
       void ProcessRotation()
       {
            if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed);
            
        }
           else if (Input.GetKey(KeyCode.D))
        {
            
            transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
            
        }
       
  
    }

}
