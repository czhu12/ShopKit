using UnityEngine;
using System.Collections;

public class VideoPlayer : MonoBehaviour {
	Texture2D[] frames = new Texture2D[54];
	int framesPerSecond = 20;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 54; i++) {
			string filename = "tmp-" + i;
			Texture2D tex = (Texture2D) Resources.Load(filename, typeof(Texture2D));
			frames[i] = tex;
		}
	}
	
	// Update is called once per frame
	void Update () {
		int index = ((int)(Time.time * framesPerSecond)) % frames.Length;
		GetComponent<Renderer>().material.mainTexture = frames [index];
	}
}
