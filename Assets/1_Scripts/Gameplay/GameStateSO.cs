using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameState", menuName = "Game State/Game State")]
public class GameStateSO : DescriptionBaseSO
{
	public GameStateTypeSO CurrentGameState => _currentGameState;
	
	[Header("Game states")]
	[SerializeField][ReadOnly] private GameStateTypeSO _currentGameState = default;
	[SerializeField][ReadOnly] private GameStateTypeSO _previousGameState = default;

	public void UpdateGameState(GameStateTypeSO newGameState)
	{
		if (newGameState == CurrentGameState)
			return;
		
		_previousGameState = _currentGameState;
		_currentGameState = newGameState;
	}

	public void ResetToPreviousGameState()
	{
		if (_previousGameState == _currentGameState)
			return;

		GameStateTypeSO stateToReturnTo = _previousGameState;
		_previousGameState = _currentGameState;
		_currentGameState = stateToReturnTo;
	}
	
}