using UnityEngine;
using System.Collections;

public class ScrollEffect : MonoBehaviour {

	public float scrollSpeed = 5f;

	void Update () {
		renderer.material.mainTextureOffset = new Vector2 (Time.time * scrollSpeed, 0);
	}
}
