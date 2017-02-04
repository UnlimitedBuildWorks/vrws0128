using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
//		Debug.Log(Screen.width);
//		Debug.Log(Screen.height);
		#endif
		#if UNITY_IOS || UNITY_ANDROID
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Input.gyro.enabled = true;
		}
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
//		Debug.Log ("Updated");
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
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.right) * Input.gyro.attitude * Quaternion.AngleAxis(180.0f, Vector3.forward);
		}
		#endif

		// Level 2
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Ray ray = new Ray();
		ray.direction = Camera.main.transform.TransformDirection(Vector3.forward);
		ray.origin = Vector3.zero;
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			//Debug.Log(Input.mousePosition);
			Debug.Log (hit.transform.name);
			Vector3 pos = hit.transform.position;
			pos.y -= 0.001f;
			hit.transform.position = pos;
		}
	}
}
