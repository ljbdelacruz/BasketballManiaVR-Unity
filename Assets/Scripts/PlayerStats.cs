using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerStats {
    private int score, gold, ballsThrown;
    private float BestAccuracy;


    public int GetScore() {
        return this.score;
    }
    public int GetGold() {
        return this.gold;
    }
    public int GetBallsThrown() {
        return this.ballsThrown;
    }

    public void SetScore(int value) {
        this.score = value;
    }
    public void SetGold(int value) {
        this.gold = value;
    }
    public void SetBallsThrown(int value) {
        this.ballsThrown=value;
    }   
}
