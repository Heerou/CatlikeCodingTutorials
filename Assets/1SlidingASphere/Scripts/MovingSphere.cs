using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float speed;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;

    [SerializeField]
    Rect area = new Rect(-5f, -5f, 10f, 10f);

    [SerializeField, Range(0f, 1f)]
    float bounciness = 0.5f;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovingTheSphere();
    }

    void MovingTheSphere()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        //playerInput.Normalize();
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        Vector3 desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * speed;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        //if (velocity.x < desiredVelocity.x)
        //{
        //    //velocity.x += maxSpeedChange;
        //    velocity.x = Mathf.Min(velocity.x + maxSpeedChange, desiredVelocity.x);
        //}
        //else if (velocity.x > desiredVelocity.x)
        //{
        //    velocity.x = Mathf.Min(velocity.x - maxSpeedChange, desiredVelocity.x);
        //}

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

        Vector3 displacement = velocity * Time.deltaTime;
        //transform.localPosition += displacement;
        Vector3 newPosition = transform.localPosition + displacement;
        //if (!area.Contains(new Vector2(newPosition.x, newPosition.z)))
        //{
        //    //newPosition = transform.localPosition;
        //    newPosition.x = Mathf.Clamp(newPosition.x, area.xMin, area.xMax);
        //    newPosition.z = Mathf.Clamp(newPosition.z, area.yMin, area.yMax);
        //}

        if (newPosition.x < area.xMin)
        {
            newPosition.x = area.xMin;
            velocity.x = -velocity.x * bounciness;
        }
        else if (newPosition.x > area.xMax)
        {
            newPosition.x = area.xMax;
            velocity.x = -velocity.x * bounciness;
        }
        if (newPosition.z < area.xMin)
        {
            newPosition.z = area.xMin;
            velocity.z = -velocity.z * bounciness;
        }
        else if (newPosition.z > area.xMax)
        {
            newPosition.z = area.xMax;
            velocity.z = -velocity.z * bounciness;
        }
        transform.localPosition = newPosition;
    }
}
