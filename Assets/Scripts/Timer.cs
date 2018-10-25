using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public float timeLeft = 0f;
    // Use this for initialization
    public void UpdateTime() {
        this.timeLeft -= Time.deltaTime;
    }
    public float GetTime() {
        return this.timeLeft;
    }
    public void SetTime(float time) {
        this.timeLeft = time;
    }
    public void IncrementTime(float value) {
        this.timeLeft += value;
    }
}
