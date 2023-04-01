using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : DescriptionBaseSO, GameInput.IGameplayActions, GameInput.IDialoguesActions, 
	GameInput.IMenusActions, GameInput.ICheatsActions
{
	[Space]
	[SerializeField] private GameStateSO _gameStateManager;
	[SerializeField] private GameStateTypeSO _gameplayStateType;

	
	
	// Assign delegate{} to events to initialise them with an empty delegate
	// so we can skip the null check when we use them

	// Gameplay
	public event UnityAction CrouchEvent = delegate { };
	public event UnityAction CrouchCanceledEvent = delegate { };
	public event UnityAction InteractEvent = delegate { }; // Used to talk, pickup objects, interact with tools like the cooking cauldron
	public event UnityAction SaveActionButtonEvent = delegate { };
	public event UnityAction ResetActionButtonEvent = delegate { };
	public event UnityAction<Vector2> MoveEvent = delegate { };
	public event UnityAction StartedRunning = delegate { };
	public event UnityAction StoppedRunning = delegate { };

	// Shared between menus and dialogues
	public event UnityAction MoveSelectionEvent = delegate { };
	
	// Menus
	public event UnityAction MenuMouseMoveEvent = delegate { };
	public event UnityAction MenuClickButtonEvent = delegate { };
	public event UnityAction MenuUnpauseEvent = delegate { };
	public event UnityAction MenuPauseEvent = delegate { };
	public event UnityAction MenuCloseEvent = delegate { };
	public event UnityAction<float> TabSwitched = delegate { };

	// Cheats (has effect only in the Editor)
	public event UnityAction CheatMenuEvent = delegate { };

	private GameInput _gameInput;
	

	private void OnEnable()
	{
		if (_gameInput == null)
		{
			_gameInput = new GameInput();

			_gameInput.Menus.SetCallbacks(this);
			_gameInput.Gameplay.SetCallbacks(this);
			_gameInput.Dialogues.SetCallbacks(this);
			_gameInput.Cheats.SetCallbacks(this);
		}

#if UNITY_EDITOR
		_gameInput.Cheats.Enable();
#endif
	}
	
	private void OnDisable()
	{
		DisableAllInput();
	}
	
	public void OnMove(InputAction.CallbackContext context)
	{
		MoveEvent.Invoke(context.ReadValue<Vector2>());
	}
	
	public void OnInteract(InputAction.CallbackContext context)
	{
		if ((context.phase == InputActionPhase.Performed)
		    && (_gameStateManager.CurrentGameState == _gameplayStateType )) // Interaction is only possible when in gameplay GameState
			InteractEvent.Invoke();
	}
	
	public void OnCrouch(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			CrouchEvent.Invoke();

		if (context.phase == InputActionPhase.Canceled)
			CrouchCanceledEvent.Invoke();
	}
	
	public void OnRun(InputAction.CallbackContext context)
	{
		switch (context.phase)
		{
			case InputActionPhase.Performed:
				StartedRunning.Invoke();
				break;
			case InputActionPhase.Canceled:
				StoppedRunning.Invoke();
				break;
		}
	}

	public void OnPause(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			MenuPauseEvent.Invoke();
	}
	
	public void OnUnpause(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			MenuUnpauseEvent.Invoke();
	}

	public void OnMoveSelection(InputAction.CallbackContext context)
	{
		Debug.Log("Selection Moved");
		if (context.phase == InputActionPhase.Performed)
			MoveSelectionEvent.Invoke();
	}
	
	public void OnConfirm(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			MenuClickButtonEvent.Invoke();
	}
	
	public void OnCancel(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			MenuCloseEvent.Invoke();
	}
	
	public void OnMouseMove(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			MenuMouseMoveEvent.Invoke();
	}
	
	public void OnOpenCheatMenu(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			CheatMenuEvent.Invoke();
	}

	public void EnableDialogueInput()
	{
		_gameInput.Menus.Enable();
		_gameInput.Gameplay.Disable();
		_gameInput.Dialogues.Enable();
	}

	public void EnableGameplayInput()
	{
		_gameInput.Menus.Disable();
		_gameInput.Dialogues.Disable();
		_gameInput.Gameplay.Enable();
	}

	public void EnableMenuInput()
	{
		_gameInput.Dialogues.Disable();
		_gameInput.Gameplay.Disable();
		_gameInput.Menus.Enable();
	}

	public void DisableAllInput()
	{
		_gameInput.Gameplay.Disable();
		_gameInput.Menus.Disable();
		_gameInput.Dialogues.Disable();
	}
	
	
	public bool LeftMouseDown() => Mouse.current.leftButton.isPressed;

	public void OnClick(InputAction.CallbackContext context)
	{

	}

	public void OnSubmit(InputAction.CallbackContext context)
	{

	}

	public void OnPoint(InputAction.CallbackContext context)
	{

	}
	
	public void OnRightClick(InputAction.CallbackContext context)
	{

	}

	public void OnNavigate(InputAction.CallbackContext context)
	{

	}
}