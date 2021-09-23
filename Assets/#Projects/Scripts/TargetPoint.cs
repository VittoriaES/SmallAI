using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    [Range (0.1f, 10.0f)]
    public float radius = 1.0f;
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public Vector3 GivePoint() {
        // * Vector3 point = Random.insideUnitSphere * radius;
        // * point.y = 0;
        Vector3 point = Random.insideUnitCircle * radius;
        point.z = point.y;
        point.y = 0;

        point += transform.position;
        return point;
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color( 0.0f, 0.5f, 0.9f, 0.4f);
        Gizmos.DrawSphere(transform.position, radius);
    }
}
