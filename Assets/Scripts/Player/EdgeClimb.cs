using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeClimb : MonoBehaviour
{
    private int EdgeClimbLayer;
    public Camera camera;
    private float playerHeight = 2f;
    private float playerRadius = 0.5f;

    [SerializeField] float mantleBufferTime;
    float mantleBufferCounter;

    // Start is called before the first frame update
    void Start()
    {
        // Since it is using raycast and raycast ignore specific layers, we tell the raycast to ignore everything but EdgeClimbLayer
        EdgeClimbLayer = LayerMask.NameToLayer("EdgeClimbLayer");
        EdgeClimbLayer = ~EdgeClimbLayer; // The "~" is the exception we want
    }

    // Update is called once per frame
    void Update()
    {
        Vault();
    }

    private void Vault()
    {
        if(InputManager.instance.JumpMantle)
        {
            mantleBufferCounter = mantleBufferTime;
            // Creates a raycast forward from the camera position, with a distance of 1, checking if it hits EdgeClimgLayer and storing the value in firstHit
        }
        else
        {
            mantleBufferCounter -= Time.deltaTime;
        }
        if (mantleBufferCounter > 0)
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out var firstHit, 1f, EdgeClimbLayer))
            {
                // Creates a raycast forward from firstHit + playerRadius + playerHeight * 0.6 upwards, then creates a raycast downwards with playerHeight/2 and saving the value in secondHit
                if (Physics.Raycast(firstHit.point + (camera.transform.forward * playerRadius) + (Vector3.up * 0.6f * playerHeight * 2), Vector3.down, out var secondHit, (playerHeight))) // 0.6 is how the height where the player can vault/edge climb
                {
                    mantleBufferCounter = 0;
                    StartCoroutine(LerpEdgeClimb(secondHit.point, 0.5f));
                }
            }
        }
    }

    IEnumerator LerpEdgeClimb(Vector3 targetPosition, float duration) // Duration is how much it takes to vault/edge climb
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while(time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time/duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
