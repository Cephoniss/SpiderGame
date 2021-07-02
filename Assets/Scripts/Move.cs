using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //[SerializeField] ParticleSystem leftpart;
    //[SerializeField] ParticleSystem rightpart;
    //[SerializeField] ParticleSystem jumppart;
    [SerializeField] float jump = 1f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] AudioClip jumpclip;
    Rigidbody rb;
    AudioSource jumpaudio;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        jumpaudio = GetComponent<AudioSource>();
    }
       
    void Update()
    {
        ProcessJump();
        ProcessRotation();
    }

       void ProcessJump()
       {
        if (Input.GetKey(KeyCode.Space))
        {

            rb.AddRelativeForce(Vector3.up * Time.deltaTime * jump);
            //jumppart.Play();

            StartJumpAudio();

        }

    }

    private void StartJumpAudio()
    {
        if (!jumpaudio.isPlaying)
        {
            jumpaudio.PlayOneShot(jumpclip);

        }
        else
        {
            jumpaudio.Stop();

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
