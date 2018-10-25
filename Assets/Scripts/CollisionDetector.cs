using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {
    private bool isCollided, isTrigger = false;
    private Collider myCol;
    //colliders
    void OnCollisionEnter(Collision col) {
        this.isCollided = true;
    }
    public bool DidCollided() {
        return this.isCollided;
    }
    public void SetIsCollided(bool value) {
        this.isCollided = value;
    }
    //triggers
    void OnTriggerEnter(Collider col)
    {
        this.myCol = col;
        this.isTrigger = true;
    }
    public bool DidTriggered() {
        return this.isTrigger;
    }
    public void SetIsTrigger(bool value) {
        this.isTrigger = value;
    }
    public Collider GetCollider() {
        return this.myCol;
    }
    public void SetCollider(Collider col) {
        this.myCol = col;
    }
}
