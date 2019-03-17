using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField]
    private Button play, secondScene, exit;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(Play);
        secondScene.onClick.AddListener(Options);
		exit.onClick.AddListener(Exit);
    }

    private void Play(){
        SceneManager.LoadScene("Scene1");
    }
    private void Options(){
        SceneManager.LoadScene("Scene2");
    }
    private void Exit(){
        Application.Quit();
    }

    private void OnDestroy() {
		play.onClick.RemoveAllListeners();
		secondScene.onClick.RemoveAllListeners();
        exit.onClick.RemoveAllListeners();
	}
}
