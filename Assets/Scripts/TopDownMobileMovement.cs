using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMobileMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 5f; // Speed of movement
    [SerializeField]private Transform headTransform; // Reference to the head/forward direction of the GameObject
    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private EnemyAutoShoot enemyautoshoot;
    private Vector3 direction;
    
   
    private Vector2 movementInput;

    void Update()
    {


        MoveInput(joystick.Direction);
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y) * moveSpeed * Time.deltaTime;

        // Move the GameObject in the determined direction
        transform.position += movement;

        // Rotate the head/forward direction of the GameObject towards the movement direction
        if (movement.magnitude > 0.01f)
        {
            if (!enemyautoshoot.EnemyInRange)
            {
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(movement.x, 0f, movement.z));
                transform.localRotation = Quaternion.Slerp(headTransform.rotation, newRotation, Time.deltaTime * 10f);

            }
        }
    }

        /* public void OnMove(InputAction.CallbackContext context)
         {
             movementInput = context.ReadValue<Vector2>();
         }*/

        void MoveInput(Vector2 newMovw)
        {
            movementInput = newMovw;
        }

        /* void OnEnable()
         {
             // Enable the "Move" action
             InputAction moveAction = new InputAction(type: InputActionType.Value, binding: "<Gamepad>/leftStick");
             moveAction.AddBinding("<Touchscreen>/primaryTouch/position");
             moveAction.performed += OnMove;
             moveAction.Enable();
         }

         void OnDisable()
         {
             // Disable the "Move" action
             InputAction moveAction = new InputAction(type: InputActionType.Value, binding: "<Gamepad>/leftStick");
             moveAction.AddBinding("<Touchscreen>/primaryTouch/position");
             moveAction.performed -= OnMove;
             moveAction.Disable();
         }
     */

    }


