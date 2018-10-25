using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
    public float rotationSpeed=0;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	public void MouseLookAround () {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        this.transform.localRotation = Quaternion.Euler(0, mouseX, 0) * transform.localRotation;
        Camera cam = GetComponentInChildren<Camera>();
        cam.transform.localRotation = Quaternion.Euler(-mouseY, 0, 0) * cam.transform.localRotation;
    }
}
