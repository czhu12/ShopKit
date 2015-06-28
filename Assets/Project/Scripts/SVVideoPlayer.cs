using UnityEngine;
using System.Collections;

public class SVVideoPlayer : MonoBehaviour {
	Texture2D[] svFrames = new Texture2D[53];
	int framesPerSecond = 20;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 53; i++) {
			string filename = "sv-tmp-" + i;
			Texture2D tex = (Texture2D) Resources.Load(filename, typeof(Texture2D));
			svFrames[i] = tex;
		}
	}
	
	// Update is called once per frame
	void Update () {
		int index = ((int)(Time.time * framesPerSecond)) % svFrames.Length;
		GetComponent<Renderer> ().material.mainTexture = svFrames [index];
	}
}
