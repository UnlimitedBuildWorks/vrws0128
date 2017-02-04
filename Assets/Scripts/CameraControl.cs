using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		#endif
		#if UNITY_IOS || UNITY_ANDROID
		Input.gyro.enabled = true;
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (Vector3.up * -Time.deltaTime * 100, Space.World);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (Vector3.up * Time.deltaTime * 100, Space.World);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Rotate (Vector3.left * Time.deltaTime * 100);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Rotate (Vector3.left * -Time.deltaTime * 100);
		}
		#endif
		#if UNITY_IOS || UNITY_ANDROID
		transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.right) * Input.gyro.attitude * Quaternion.AngleAxis(180.0f, Vector3.forward);
		#endif
	}
}
