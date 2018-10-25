using UnityEngine;
using System.Collections;

public class BasketDetectors : MonoBehaviour {
    private DataGetter data;
    private bool isBasket = false;
    private GvrAudioSource myAudio;
    public GameObject primary, secondary;
	// Use this for initialization
	void Start () {
        this.data = this.gameObject.GetComponent<DataGetter>();
        this.myAudio = this.data.GetObjectGVRAudioSource(this.gameObject);
	}
    void Update() {
        if (this.primary.GetComponent<CollisionDetector>().GetCollider()== this.secondary.GetComponent<CollisionDetector>().GetCollider() && this.primary.GetComponent<CollisionDetector>().DidTriggered()== true && this.secondary.GetComponent<CollisionDetector>().DidTriggered() == true) {
            this.isBasket = true;
            this.ResetDetectorValues();
            BasketSoundFx();
        }
    }
    public bool IsBasket() {
        return this.isBasket;
    }
    public void SetIsBasket(bool value) {
        this.isBasket = value;
    }
    void ResetDetectorValues() {
        this.primary.GetComponent<CollisionDetector>().SetIsTrigger(false);
        this.primary.GetComponent<CollisionDetector>().SetCollider(null);
        this.secondary.GetComponent<CollisionDetector>().SetIsTrigger(false);
        this.secondary.GetComponent<CollisionDetector>().SetCollider(null);
    }
    void BasketSoundFx() {
        myAudio.Play();
    }
}
