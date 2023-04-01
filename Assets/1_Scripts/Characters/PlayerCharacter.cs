using System;
using UnityEngine;

/// <summary>
/// <para>This component consumes input on the InputReader and stores its values. The input is then read, and manipulated, by the StateMachines's Actions.</para>
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader = default;
   // [SerializeField] private TransformAnchor _gameplayCameraTransform = default;

    private Vector2 _inputVector;
    private float _previousSpeed;

    //These fields are read and manipulated by the StateMachine actions
    [NonSerialized] public bool crouchInput;
    [NonSerialized] public bool extraActionInput;
    [NonSerialized] public Vector3 movementInput; //Initial input coming from the Protagonist script
    [NonSerialized] public Vector3 movementVector; //Final movement vector, manipulated by the StateMachine actions
    [NonSerialized] public ControllerColliderHit lastHit;
    [NonSerialized] public bool isRunning; // Used when using the keyboard to run, brings the normalised speed to 1
    
    // Movement hack
    private CharacterController _characterController;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        lastHit = hit;
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    //Adds listeners for events being triggered in the InputReader script
    private void OnEnable()
    {
        _inputReader.CrouchEvent += OnCrouchInitiated;
        _inputReader.CrouchCanceledEvent += OnCrouchCanceled;
        _inputReader.MoveEvent += OnMove;
        _inputReader.StartedRunning += OnStartedRunning;
        _inputReader.StoppedRunning += OnStoppedRunning;
        //...
    }
    
    //Removes all listeners to the events coming from the InputReader script
    private void OnDisable()
    {
        _inputReader.CrouchEvent -= OnCrouchInitiated;
        _inputReader.CrouchCanceledEvent -= OnCrouchCanceled;
        _inputReader.MoveEvent -= OnMove;
        _inputReader.StartedRunning -= OnStartedRunning;
        _inputReader.StoppedRunning -= OnStoppedRunning;
    }
    
    private void RecalculateMovement()
    {
        float targetSpeed;
        Vector3 adjustedMovement;
        
        adjustedMovement = new Vector3(_inputVector.x, 0f, _inputVector.y);
        
        
        //Fix to avoid getting a Vector3.zero vector, which would result in the player turning to x:0, z:0
        if (_inputVector.sqrMagnitude == 0f)
            adjustedMovement = transform.forward * (adjustedMovement.magnitude + .01f);

        //Accelerate/decelerate
        targetSpeed = Mathf.Clamp01(_inputVector.magnitude);
        if (targetSpeed > 0f)
        {
            // This is used to set the speed to the maximum if holding the Shift key,
            // to allow keyboard players to "run"
            if (isRunning)
                targetSpeed = 1f;
        }
        targetSpeed = Mathf.Lerp(_previousSpeed, targetSpeed, Time.deltaTime * 4f);
        
        //Debug.Log("before " +adjustedMovement.normalized * targetSpeed);

        movementInput = adjustedMovement.normalized * targetSpeed;
        Debug.Log("after "  + movementInput);
        
        _previousSpeed = targetSpeed;
    }
    
    private void Update()
    {
        RecalculateMovement();
        Debug.Log("Lets Dip " + movementInput);
        _characterController.Move(movementVector * Time.deltaTime);
        // movementVector = _characterController.velocity;
    }

    //---- EVENT LISTENERS ----

    private void OnMove(Vector2 movement)
    {
        _inputVector = movement;
    }

    private void OnCrouchInitiated()
    {
        crouchInput = true;
    }

    private void OnCrouchCanceled()
    {
        crouchInput = false;
    }

    private void OnStoppedRunning() => isRunning = false;

    private void OnStartedRunning() => isRunning = true;
}
