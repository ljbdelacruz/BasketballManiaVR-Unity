using UnityEngine;
using System.Collections;

public class InputGetter : MonoBehaviour {
    public bool isTouched = false;
    private bool isPressed, isMouseUp = false;
    private float timeRelease = 0f;

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
        this.CheckMouse();
        this.IdentifyMouseReleaseTime();
	}
    void CheckTouch() {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
            }
        }
    }
    void CheckMouse() {
        if (Input.GetMouseButtonDown(0))
        {
            this.isTouched = true;
        }
        else {
            this.isTouched = false;
        }
    }
    void IdentifyMouseReleaseTime() {
        if (this.isPressed) {
            this.timeRelease += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0)) {
            this.isPressed = true;
            this.timeRelease = 0f;
        }
        if (Input.GetMouseButtonUp(0)) {
            this.isPressed = false;
            this.isMouseUp = true;
        }
    }
    public bool IsPressed() {
        return this.isPressed;
    }
    public float GetTimeReleased() {
        return this.timeRelease;
    }
    public bool IsMouseUp() {
        return this.isMouseUp;
    }
    public void SetIsMouseUp(bool value) {
        this.isMouseUp = value;
    }
    public float CalculateBallForcePower(float value) {
        return ((value * this.timeRelease) >= 500f) ? 500f : (value * this.timeRelease);
    }
}
