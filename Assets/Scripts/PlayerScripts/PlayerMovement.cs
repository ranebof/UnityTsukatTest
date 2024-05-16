using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController ControllerComponent;

    public float moveSpeed = 5f;
    bool isGrounded;
    public int Health = 100;


    Vector3 playerVelocity;
    

    private void Start()
    {
        ControllerComponent = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (ControllerComponent)
        {
            float horizontalInput = Input.GetAxis("HorizontalArrowsInput");
            float verticalInput = Input.GetAxis("VerticalArrowsInput");


            float maxXpos = 40f;
            float maxXposN = -40f;
            
            float maxZpos = 40f;
            float maxZposN = -40f;


            isGrounded = ControllerComponent.isGrounded;

            if (isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            if (gameObject.transform.position.x >= maxXpos && horizontalInput > 0)
            {
                horizontalInput = 0f;
            }
            else if(gameObject.transform.position.x <= maxXposN && horizontalInput < 0)
            {
                horizontalInput = 0f;
            }

            if (gameObject.transform.position.z >= maxZpos && verticalInput > 0)
            {
                verticalInput = 0f;
            }
            else if (gameObject.transform.position.z <= maxZposN && verticalInput < 0)
            {
                verticalInput = 0f;
            }


            Vector3 movePlayer = new Vector3(horizontalInput, 0f, verticalInput);

            ControllerComponent.Move(movePlayer * moveSpeed * Time.deltaTime);

            playerVelocity.y += Physics.gravity.y * Time.deltaTime;
            ControllerComponent.Move(playerVelocity * Time.deltaTime);

            if(Health <= 0)
            {
                Destroy(gameObject);
            }

        }

    }

    public void MakeDamage(int Damage)
    {
        Health -= Damage;
    }
}
