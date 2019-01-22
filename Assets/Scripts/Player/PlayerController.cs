using Survive;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;

    void Update()
    {
        Vector3 movement = new Vector3(InputController.Instance.MoveDirection.x, 0, 
            InputController.Instance.MoveDirection.y);

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

    }
}
