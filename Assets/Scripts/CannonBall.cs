using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {
    private DataGetter data;
    public GameObject BulletRotation;
    public GameObject EmitterPosition;
    public GameObject Bullet;
    public float Bullet_Forward_Force;
    private GameObject collidedGO;
    // Use this for initialization
    void Start () {
        this.data = this.gameObject.GetComponent<DataGetter>();
	}
    public void Fire() {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, EmitterPosition.transform.position, BulletRotation.transform.rotation) as GameObject;
        Temporary_Bullet_Handler.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
        Temporary_Bullet_Handler.transform.Rotate(this.BulletRotation.transform.forward * 90);
        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();



        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
        //this randomize the bullet force
        //        Temporary_RigidBody.AddForce(this.BulletRotation.transform.forward * Random.Range(Bullet_Forward_Force-30f, Bullet_Forward_Force));
        //this force depends how long you hold mouse down
        Temporary_RigidBody.AddForce(this.BulletRotation.transform.forward * this.data.FindInputGetter().CalculateBallForcePower(Bullet_Forward_Force));
        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
        if (Temporary_Bullet_Handler != null)
            Destroy(Temporary_Bullet_Handler, 3.0f);
    }
}
