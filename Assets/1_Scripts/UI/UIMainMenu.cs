﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
	[SerializeField] private Button _exitGameButton = default;
	[SerializeField] private Button _newGameButton = default;

	public UnityAction NewGameButtonAction;
	public UnityAction ContinueButtonAction;
	public UnityAction SettingsButtonAction;
	public UnityAction CreditsButtonAction;
	public UnityAction ExitButtonAction;

	public void SetMenuScreen()
	{
		_newGameButton.Select();
	}

	public void NewGameButton()
	{
		NewGameButtonAction.Invoke();
	}

	public void ContinueButton()
	{
		ContinueButtonAction.Invoke();
	}

	public void SettingsButton()
	{
		SettingsButtonAction.Invoke();
	}

	public void CreditsButton()
	{
		CreditsButtonAction.Invoke();
	}

	public void ExitButton()
	{
		ExitButtonAction.Invoke();
	}
}