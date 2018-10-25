using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private DataGetter data;
    private GvrAudioSource myAudio;

	// Use this for initialization
	void Start () {
        this.data = this.gameObject.GetComponent<DataGetter>();
        this.myAudio = this.data.GetObjectGVRAudioSource(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
        if (this.data.GetSpecificCollisionDetector(this.gameObject).DidCollided()) {
            this.data.GetSpecificCollisionDetector(this.gameObject).SetIsCollided(false);
            this.BounceSoundFx();
        }
	}
    void BounceSoundFx() {
        this.myAudio.Play();
    }
}
