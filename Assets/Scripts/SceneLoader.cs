using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour {

    public void LoadScene(int index) {
        SceneManager.LoadScene(index);
    }
}
