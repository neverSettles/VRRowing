using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotOar : MonoBehaviour
{
    public Transform target;
    public Transform zPivot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target, target.up);
        transform.LookAt(target, Vector3.up);
        float zOffset = Vector3.Distance(target.position, transform.position) + 0.1f;
        zPivot.localPosition = new Vector3(0, 0, zOffset);
    }
}
