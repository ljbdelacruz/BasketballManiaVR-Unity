using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private DataGetter data;
    // Use this for initialization
    private Status playerStats;
	void Start () {
        this.data = this.gameObject.GetComponent<DataGetter>();
        this.playerStats = this.data.GetObjectStatus(GameObject.Find("GameManager"));
	}
	
	// Update is called once per frame
	void Update () {
        //this allows player to look around (mouse Input)
        this.data.GetMouseLook().MouseLookAround();
        //this functionality determines if player pressed the button it will fire the ball
//        if (this.data.GetInputGetter().isTouched && this.data.GetGameState().GetState()=="play") {
//        }
        //this functionality waits until button is released then fire the ball
        if (this.data.FindInputGetter().IsMouseUp() && this.data.GetGameState().GetState() == "play") {
            this.Fire();
            this.data.FindInputGetter().SetIsMouseUp(false);
        }
	}
    void Fire() {
        this.data.GetCannonBall().Fire();
        //increment balls thrown each time it throws balls by 1
        this.playerStats.IncrementBallsThrown(1);
    }
}
