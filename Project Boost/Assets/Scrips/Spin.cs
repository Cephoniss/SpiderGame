using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
  
[SerializeField] float xa =0f;
[SerializeField] float ya =1f;
[SerializeField] float za =0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xa,ya,za);
    }
}
