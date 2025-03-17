using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameButton : MonoBehaviour {

    public string level;

    private void OnMouseDown()
    {
        GlobalVar.score = 0;
        SceneManager.LoadScene(level);
    }
}
