using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 moveVect;
    [SerializeField] [Range(0,1)]float moveFact;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; //constant growth
        const float tau = Mathf.PI * 2; // constant value of tau
        float rawSinWave = Mathf.Sin(cycles * tau); // -1 to 1

        moveFact = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1
        
        Vector3 offset = moveVect * moveFact;
        transform.position = startingPos + offset;
    }
}
