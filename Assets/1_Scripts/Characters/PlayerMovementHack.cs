using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHack : MonoBehaviour
{
	//Component references
        private PlayerCharacter _protagonistScript;
        private CharacterController _characterController;

        public void Awake()
        {
            _protagonistScript = GetComponent<PlayerCharacter>();
            _characterController = GetComponent<CharacterController>();
            Debug.Log("Player Character= " +_protagonistScript);
            Debug.Log("Character Controller = " +_characterController);
        }

        public void LateUpdate()
        {
	        Debug.Log("Lets Dip" + _protagonistScript.movementVector);
	        _characterController.Move(_protagonistScript.movementVector * Time.deltaTime);
	        _protagonistScript.movementVector = _characterController.velocity;
        }
}
