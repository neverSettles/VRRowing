using UnityEngine;
using System.Collections;

public class RowingMovement : MonoBehaviour {

	public float force_scale = 1.0f;
	public float drag_scale = 0.20f;
    public float rotational_force_scale = 0.10f;

    public GameObject waterObject;

    public GameObject leftPaddle;
    public GameObject rightPaddle;

    Vector3 leftPrevPaddlePosition;
    Vector3 rightPrevPaddlePosition;

    Vector3 velocity = Vector3.zero;

    private void Start()
    {
        leftPrevPaddlePosition = leftPaddle.transform.position;
        rightPrevPaddlePosition = rightPaddle.transform.position;
    }

    // Update is called once per frame
    void Update() {
        //float velocity_magnitude = velocity.magnitude;

        //// add to velocity based on displaced sin wave
        //if (velocity_magnitude < 5.0f) {
        //		velocity += direction * (Mathf.Sin(Time.time * 2.0f) + 0.5f) * force_scale * Time.deltaTime;
        //		transform.position += velocity * Time.deltaTime;
        //}

        Vector3 leftOarVelocity = -(leftPaddle.transform.position - leftPrevPaddlePosition) / Time.deltaTime;
        Vector3 rightOarVelocity = -(rightPaddle.transform.position - rightPrevPaddlePosition) / Time.deltaTime;


        Vector3 boatAccelerationLeft = velocity*0.0f / Time.deltaTime;
        Vector3 boatAccelerationRight = velocity*0.0f / Time.deltaTime;
        if (leftPaddle.transform.position.y < waterObject.transform.position.y)
        {
            boatAccelerationLeft = (leftOarVelocity - velocity) / Time.deltaTime;
        }
        if (rightPaddle.transform.position.y < waterObject.transform.position.y)
        {
            boatAccelerationRight = (rightOarVelocity - velocity) / Time.deltaTime;
            Debug.Log("Time.deltaTime: " + Time.deltaTime);
            Debug.Log("rightPaddle.transform.position.z:" + rightPaddle.transform.position.z);
            Debug.Log("rightPrevPaddlePosition.z:" + rightPrevPaddlePosition.z);
            Debug.Log("rightOarVelocity:" + rightOarVelocity);
            Debug.Log("velocity:" + velocity);
            Debug.Log("boatAccelerationRight:" + boatAccelerationRight);
        }
        //Debug.Log(rightPaddle.transform.position.y);
        //Debug.Log(waterPosition.position.y);
        velocity.x += force_scale * (boatAccelerationLeft.x + boatAccelerationRight.x) * Time.deltaTime;
        velocity.z += force_scale * (boatAccelerationLeft.z + boatAccelerationRight.z) * Time.deltaTime;

        // crap drag simulation
        if (velocity.magnitude > 0.0f) {
			velocity -= velocity * drag_scale * Time.deltaTime;
		}
        transform.position += velocity * Time.deltaTime;
        //transform.eulerAngles += new Vector3(0, velocity.normalized.y, 0) * Time.deltaTime ;
        //transform.forward += rotational_force_scale * velocity.normalized * Time.deltaTime;

        leftPrevPaddlePosition = leftPaddle.transform.position;
        rightPrevPaddlePosition = rightPaddle.transform.position;

        if (Vector3.Distance(transform.position, waterObject.transform.position) > 50)
        {
            waterObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
