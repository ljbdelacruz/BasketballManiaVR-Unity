using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private GameObject ScoreUI, accuracyRate, TimerUI, GoalScoreUI, GoldUI;
    private DataGetter data;
	// Use this for initialization
	void Start () {
        this.data = this.gameObject.GetComponent<DataGetter>();
        this.ScoreUI = this.data.GetFindObject("ScoreUI");
        this.accuracyRate = this.data.GetFindObject("AccuracyUI");
        this.TimerUI = this.data.GetFindObject("TimerUI");
        this.GoalScoreUI = this.data.GetFindObject("GoalScoreUI");
        this.GoldUI = this.data.GetFindObject("GoldUI");
    }
    public void UpdateScore(int value) {
        this.ScoreUI.GetComponent<Text>().text = "" + value;
    }
    public void UpdateAccuracyRate() {
        this.accuracyRate.GetComponent<Text>().text = "Accuracy: " + Mathf.Round(this.data.GetStatus().GetAccuracyRate()) + "%";
    }
    public void UpdateTimer() {
        this.TimerUI.GetComponent<Text>().text = "" + Mathf.Round(this.data.GetTimer().GetTime());
    }
    public void UpdateGoalScoreUI()
    {
        this.GoalScoreUI.GetComponent<Text>().text = ""+this.data.GetStatus().goalScore;
    }
    public void UpdatePowerGaugeUI() {
        this.data.GetObjectWithTypePowerMeter().UpdateUI();
    }
    public void UpdateGoldUI() {
        this.GoldUI.GetComponent<Text>().text = "" + this.data.GetStatus().gold+" G";
    }
    public void Goto(int index) {
        SceneManager.LoadScene(index);
    }
    //gameover ui
    public void ShowGameOverUI() {
        foreach (Transform child in GameObject.Find("Panel").transform) {
            if (child.gameObject.name == "GameoverUI" || child.gameObject.name == "RetryButton") {
                child.gameObject.SetActive(true);
            }
        }
    }
    //next level ui
    public void ShowNextLevelUI() {
        foreach (Transform child in GameObject.Find("Panel").transform)
        {
            if (child.gameObject.name == "CongratulationUI" || child.gameObject.name == "NextLevelButton")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
