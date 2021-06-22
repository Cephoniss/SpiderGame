using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer renderer;
    Rigidbody body;
    [SerializeField] float ttw =1f;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > ttw)
        {
            renderer.enabled = true;
            body.useGravity = true;
        }
    }




}
