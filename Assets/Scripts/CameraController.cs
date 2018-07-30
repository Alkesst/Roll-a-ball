using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;
    private const float EPSILON = 0.001f;

	void Start() {
        offset = transform.position - player.transform.position;
    }

	void LateUpdate() {
        if ((player != null)) {
            transform.position = player.transform.position + offset;
        }
	}
}