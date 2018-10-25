using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    private DataGetter data;
    public float time;
    private GameObject basketDetector;

	// Use this for initialization
	void Start () {
        this.data = this.gameObject.GetComponent<DataGetter>();
        this.basketDetector = this.data.GetFindObject("BasketDetectors");
    }
	// Update is called once per frame
	void Update () {
        if (this.data.GetGameState().GetState() == "play")
        {
            this.CheckTimer();
            this.UpdateTimerUI();
            this.UpdateGoalScoreUI();
            this.UpdatePowerGaugeUI();
            if (this.basketDetector.GetComponent<BasketDetectors>().IsBasket())
            {
                this.SetupScoreStatus();
                this.UpdateScoreUI();
                this.UpdateAccuracyUI();
                this.IncreaseGold();
                this.UpdateGoldUI();
                this.basketDetector.GetComponent<BasketDetectors>().SetIsBasket(false);
                //increase combo if basket
                this.data.GetStatus().combo += 1;
            }
            else
            {
                this.MissCombo();
                UpdateAccuracyUI();
            }
        }
	}
    void SetupScoreStatus() {
        this.data.GetStatus().IncrementScore(1);
        this.data.GetStatus().IncrementCombo(1);
    }
    void MissCombo() {
        if (this.data.GetStatus().combo > 1) {
            this.data.GetStatus().IncrementNumberOfCombo(1);
        }
        if (this.data.GetStatus().combo > this.data.GetStatus().highestCombo)
        {
            this.data.GetStatus().SetHighestCombo(this.data.GetStatus().combo);
        }
        this.data.GetStatus().SetCombo(0);
    }
    //UI text updaters
    void UpdateScoreUI() {
        this.data.GetUIManager().UpdateScore(this.data.GetStatus().score);
    }
    void UpdateAccuracyUI() {
        this.data.GetUIManager().UpdateAccuracyRate();
    }
    void UpdateTimerUI() {
        this.data.GetUIManager().UpdateTimer();
    }
    void UpdateGoalScoreUI() {
        this.data.GetUIManager().UpdateGoalScoreUI();
    }
    void UpdatePowerGaugeUI() {
        this.data.GetUIManager().UpdatePowerGaugeUI();
    }
    void UpdateGoldUI() {
        this.data.GetUIManager().UpdateGoldUI();
    }
    void CheckTimer() {
        CheckState();
        //checks if time is greater zero ifitis then update timer
        if (this.data.GetTimer().timeLeft > 0) {
            this.data.GetTimer().UpdateTime();
        }
        //checks state after time runs out
        if (this.data.GetTimer().timeLeft <= 0)
        {
            this.CheckStateIfGameOver();
        }
    }
    void ChangeState(string state) {
        this.data.GetGameState().SetState(state);
    }
    void CheckStateIfGameOver() {
        //checks if the score has reached the goal score for this level
        if (this.data.GetStatus().score < this.data.GetStatus().goalScore) {
            this.data.GetGameState().GameOver();
            this.CompareData();
        }
    }
    void CheckState() {
        //this one checks if the player score reached the quota score for this level
        if (this.data.GetStatus().score >= this.data.GetStatus().goalScore)
        {
            this.data.GetStatus().IncrementGoalScore(4);
            this.data.GetStatus().IncrementLevel(1);
            this.data.GetTimer().IncrementTime(40);
            this.UpdateGoalScoreUI();
        }
    }
    void CompareData() {
        if (this.data.GetGODataHandler().storeCount <= 0)
        {
            CompareScores();
        }
    }
    //this function compares the score of past and current ifits true then store it as a new highscore
    void CompareScores() {
        this.data.GetStatus().CompareScore();
        this.data.GetStatus().AddCurrentGoldEarnedAndGold();
        this.data.GetGODataHandler().StoreData(this.data.GetStatus());
    }
    void CompareAccuracy() {
        this.data.GetStatus().CheckHighestAccuracy();
    }
    void IncreaseGold() {
        this.data.GetStatus().gold += (2 * ((data.GetStatus().combo > 0) ? data.GetStatus().combo : 1));
    }
    void OnDestroy() {
        this.data.GetGODataHandler().storeCount = 0;
    }
}
