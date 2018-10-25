using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DataGetter : MonoBehaviour {
    public MouseLook GetMouseLook() {
        return this.gameObject.GetComponent<MouseLook>();
    }
    public InputGetter GetInputGetter() {
        return this.gameObject.GetComponent<InputGetter>();
    }
    public CannonBall GetCannonBall() {
        return this.gameObject.GetComponent<CannonBall>();
    }
    public CannonBall GetObjectTypeCannonBall() {
        return GameObject.FindObjectOfType<CannonBall>();
    }
    public Status GetStatus() {
        return this.gameObject.GetComponent<Status>();
    }
    public Status GetObjectStatus(GameObject obj) {
        return obj.GetComponent<Status>();
    }
    public GameObject GetFindObject(string objectName) {
        return GameObject.Find(objectName).gameObject;
    }
    public CollisionDetector GetSpecificCollisionDetector(GameObject obj) {
        return obj.GetComponent<CollisionDetector>();
    }
    public UIManager GetUIManager() {
        return this.gameObject.GetComponent<UIManager>();
    }
    public AudioSource GetObjectAudioSource(GameObject obj) {
        return obj.GetComponent<AudioSource>();
    }
    public GvrAudioSource GetObjectGVRAudioSource(GameObject obj) {
        return obj.GetComponent<GvrAudioSource>();
    }
    public StateManager GetGameState() {
        return GameObject.FindObjectOfType<StateManager>();
    }
    public Timer GetTimer() {
        return this.gameObject.GetComponent<Timer>();
    }
    public InputGetter FindInputGetter() {
        return GameObject.FindObjectOfType<InputGetter>();
    }
    public Image GetImageScript() {
        return this.gameObject.GetComponent<Image>();
    }
    public PowerMeter GetObjectWithTypePowerMeter() {
        return GameObject.FindObjectOfType<PowerMeter>();
    }
    public Animator GetAnimator() {
        return this.gameObject.GetComponent<Animator>();
    }
    public MenuPlayer GetGOMenuPlayer() {
        return GameObject.FindObjectOfType<MenuPlayer>();
    }
    public DataHandler GetGODataHandler() {
        return GameObject.FindObjectOfType<DataHandler>();
    }
}
