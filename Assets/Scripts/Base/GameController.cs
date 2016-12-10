﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.SaveSystem;

public class GameController : IGame {

	public void Init() {}

	public void PostInit() {}

	GameMode _currentMode;
	int      _currentScore;

	public void SelectMode(GameMode mode) {
		_currentMode = mode;
		Log.MessageFormat("Select mode: {0}", -1, mode);
	}

	public GameMode GetCurrentMode() {
		return _currentMode;
	}

	public void CalculateScore(float time) {
		_currentScore = Mathf.FloorToInt(time) * 50;
		if( GetBestScore() < _currentScore ) {
			var saveNode = Save.GetNode<SaveNode>();
			if( saveNode == null ) {
				saveNode = new SaveNode();
			}
			saveNode.BestScore = _currentScore;
			Save.SaveNode(saveNode);
		}
	}

	public int GetCurrentScore() {
		return _currentScore;
	}

	public int GetBestScore() {
		var saveNode = Save.GetNode<SaveNode>();
		return saveNode != null ? saveNode.BestScore : 0;
	}
}
