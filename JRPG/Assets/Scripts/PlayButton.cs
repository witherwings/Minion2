﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	public void Play(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
}
