using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerMeter : MonoBehaviour {
    private DataGetter data;
    private GameObject gaugeUI;
	// Use this for initialization
	void Start () {
        this.data = GetComponent<DataGetter>();
        this.gaugeUI = data.GetFindObject("Label");
	}
    void Update() {
        if (this.data.GetGameState().GetState() == "play")
        {
            this.UpdateMeterUI(this.CalculateByPercentage(this.data.FindInputGetter().GetTimeReleased() * this.data.GetObjectTypeCannonBall().Bullet_Forward_Force, 500f));
        }
    }
    public float CalculateByPercentage(float current, float maxPower) {
        float result = current / maxPower;
        return result;
    }
    public float GetPercentEquivalent(float current, float maxPower) {
        return Mathf.Round((current / maxPower) * 100);
    }
    void UpdateMeterUI(float percentage) {
        this.data.GetImageScript().fillAmount = percentage;
    }
    public void UpdateUI() {
        this.gaugeUI.GetComponent<Text>().text = "" + this.GetPercentEquivalent(this.data.FindInputGetter().GetTimeReleased() * this.data.GetObjectTypeCannonBall().Bullet_Forward_Force, 500f)+"%";
    }
}
