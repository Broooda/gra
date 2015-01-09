using UnityEngine;
using System.Collections;

public class ActiveCode : MonoBehaviour {
	// Use this for initialization
	public GameObject kodzik;
	void Start () {
		kodzik.SetActive (false);
	}
	void CodeActive(bool active) {
		kodzik.SetActive (active);
	}
}
