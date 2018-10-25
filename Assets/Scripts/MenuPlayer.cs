using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuPlayer : MonoBehaviour {
    private DataGetter data;
    private GameObject InstructionButtonUI, PlayButtonUI, BackInsButtonUI, BackTrophyButtonUI, TrophyButtonUI, GoldTextUI;
	// Use this for initialization
	void Start () {
        this.data = this.gameObject.GetComponent<DataGetter>();
        this.InstructionButtonUI = this.data.GetFindObject("InstructionButton");
        this.BackInsButtonUI = this.data.GetFindObject("InstructionBackButton");
        this.PlayButtonUI = this.data.GetFindObject("Play");
        this.TrophyButtonUI = this.data.GetFindObject("TrophiesButton");
        this.BackTrophyButtonUI = this.data.GetFindObject("TrophyBackButton");
        this.GoldTextUI = this.data.GetFindObject("GoldUI");
	}
	// Update is called once per frame
	void Update () {
        this.data.GetMouseLook().MouseLookAround();
        this.UpdateHighScoreUI();
        this.UpdateGoldUI();
    }
    public void SetCamAction(int number) {
        this.data.GetAnimator().SetInteger("camAction", number);
    }
    void UpdateHighScoreUI() {
        this.data.GetFindObject("HighScoreUI").GetComponent<Text>().text = "" + this.data.GetStatus().GetMyPastStatus().score;
    }
    void UpdateGoldUI() {
        this.GoldTextUI.GetComponent<Text>().text = "" + this.data.GetStatus().GetMyPastStatus().gold+" G";
    }
    public void ClickedButtonInstruction() {
        this.ModifyButtonInteractible(this.InstructionButtonUI, false);
        this.ModifyButtonInteractible(this.PlayButtonUI, false);
        this.ModifyButtonInteractible(this.TrophyButtonUI, false);
        this.ModifyButtonInteractible(this.BackInsButtonUI, true);
        this.SetCamAction(1);
    }
    public void ClickedBackInstructionButton() {
        this.ModifyButtonInteractible(this.InstructionButtonUI, true);
        this.ModifyButtonInteractible(this.PlayButtonUI, true);
        this.ModifyButtonInteractible(this.TrophyButtonUI, true);
        this.ModifyButtonInteractible(this.BackInsButtonUI, false);
        this.SetCamAction(0);
    }
    public void ClickedButtonTrophy()
    {
        this.ModifyButtonInteractible(this.InstructionButtonUI, false);
        this.ModifyButtonInteractible(this.PlayButtonUI, false);
        this.ModifyButtonInteractible(this.TrophyButtonUI, false);
        this.ModifyButtonInteractible(this.BackTrophyButtonUI, true);
        this.SetCamAction(3);
    }
    public void ClickedBackTrophyButton()
    {
        this.ModifyButtonInteractible(this.InstructionButtonUI, true);
        this.ModifyButtonInteractible(this.PlayButtonUI, true);
        this.ModifyButtonInteractible(this.TrophyButtonUI, true);
        this.ModifyButtonInteractible(this.BackTrophyButtonUI, false);
        this.SetCamAction(0);
    }

    void ModifyButtonInteractible(GameObject obj, bool value) {
        obj.GetComponent<Button>().interactable = value;
    }
}

