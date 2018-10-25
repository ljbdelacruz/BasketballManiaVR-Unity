using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {
    private string state = "play";
    private DataGetter data;
	// Use this for initialization
	void Start () {
        this.data = this.gameObject.GetComponent<DataGetter>();
	}
    public string GetState() {
        return this.state;
    }
    //state has 3 parts pause, play and gameover
    public void SetState(string value) {
        this.state = value;
    }
    public void GameOver() {
        this.state = "gameover";
        this.GameoverSound();
        this.data.GetUIManager().ShowGameOverUI();
    }
    public void Play() {
        this.state = "play";
    }
    
    void GameoverSound() {
        this.data.GetObjectGVRAudioSource(this.gameObject).Play();
    }
    
    
}
