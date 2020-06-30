using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    int speed;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        DestroyCar();
    }

    private void FixedUpdate()
    {
        characterController.Move(Vector3.right * speed * Time.fixedDeltaTime);
    }

    void DestroyCar()
    {
        if(transform.position.x >= 35)
        {
            //destroy
            Destroy(gameObject);
        }
    }
}
