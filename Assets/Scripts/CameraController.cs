using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;

	void Start() {
        offset = transform.position - player.transform.position;
    }

	void LateUpdate() {
        if (player != null) {
            transform.position = player.transform.position + offset;
        }
	}
}
