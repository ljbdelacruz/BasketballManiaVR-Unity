using UnityEngine;
using System.Collections;

[SerializeField]
public class Status : MonoBehaviour {
    public int score, combo, numberOfCombo, highestCombo, ballsThrown, level, goalScore, gold=0;
    public float highestAccuracy;
    private Status myStats;
    private DataGetter data;
	// Use this for initialization
	void Start () {
        this.data = gameObject.GetComponent<DataGetter>();
        this.myStats = this.data.GetGODataHandler().LoadDataPlayer();
	}
    public void IncrementScore(int value) {
        this.score += value;
    }
    public void IncrementCombo(int value) {
        this.combo += value;
    }
    public void IncrementNumberOfCombo(int value) {
        this.numberOfCombo += value;
    }
    public void IncrementBallsThrown(int value) {
        this.ballsThrown += value;
    }
    public void IncrementLevel(int value) {
        this.level += value;
    }
    public void IncrementGoalScore(int value) {
        this.goalScore += value;
    }
    public void IncrementGold(int value) {
        this.gold += value;
    }
    //setter
    public void SetScore(int value) {
        this.score = value;
    }
    public void SetCombo(int value) {
        this.combo = value;
    }
    public void SetNumberOfCombo(int value) {
        this.numberOfCombo = value;
    }
    public void SetHighestCombo(int value) {
        this.highestCombo = value;
    }
    public void CheckHighestAccuracy() {
        this.highestAccuracy = (MyMath.IsN1GreaterN2(this.GetAccuracyRate(), myStats.GetAccuracyRate())) ? this.GetAccuracyRate() : myStats.GetAccuracyRate();
    }
    public float GetAccuracyRate() {
        try
        {
            return ((((float)score/(float)ballsThrown) *100f) >= 0f) ? (((float)score / (float)ballsThrown) * 100f) : 100f;
        }
        catch {
            return 1*100;
        }
    }
    public Status GetMyPastStatus() {
        return this.myStats;
    }
    public void CompareScore()
    {
        this.score = (MyMath.IsN1GreaterN2(this.score, this.myStats.score)) ? this.score : this.myStats.score;
    }
    public void AddCurrentGoldEarnedAndGold() {
        this.gold += this.myStats.gold;
    }
}
