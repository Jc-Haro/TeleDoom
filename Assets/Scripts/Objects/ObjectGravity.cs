using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    [SerializeField] float fallSpeed;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y * fallSpeed*Time.deltaTime,transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        //3 == ground, 6 == wall

        if(other.gameObject.layer == 3 || other.gameObject.layer == 6)
        {
            fallSpeed = 0;
        }
    }
}
