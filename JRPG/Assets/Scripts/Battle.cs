using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		SceneManager.sceneLoaded += OnSceneLoaded;
		this.gameObject.SetActive (false);
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		if (scene.name == "Menu") {
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (this.gameObject);
		} else {
			this.gameObject.SetActive (scene.name == "Battle");
		}
	}

}
