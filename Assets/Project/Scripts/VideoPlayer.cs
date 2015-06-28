using UnityEngine;
using System.Collections;

public class VideoPlayer : MonoBehaviour {
	Texture2D[] lebronFrames = new Texture2D[54];
	Texture2D[] svFrames = new Texture2D[53];
	Texture2D[] stephFrames = new Texture2D[59];

	int framesPerSecond = 20;
	int stephsPerSecond = 10;

	int currentVideo;
	// 1 = lebron
	// 2 = sv
	// 3 = steph

	public int getCurrentVideo() {
		return currentVideo;
	}

	public void setCurrentVideo(int cur) {
		currentVideo = cur;
	}

	public bool toNextVideo() {
		if (currentVideo == 0) {
			currentVideo = 1;
			return true;
		} else if (currentVideo == 1) {
			currentVideo = 2;
			return true;
		} else if (currentVideo == 2) {
			currentVideo = 0;
			return false;
		}
		return true;
	}

	public bool toPreviousVideo() {
		if (currentVideo == 0) {
			currentVideo = 2;
			return false;
		} else if (currentVideo == 1) {

			currentVideo = 0;
			return true;
		} else if (currentVideo == 2) {
			currentVideo = 1;
			return true;
		}
		return true;
	}

	void Start () {
		for (int i = 0; i < 54; i++) {
			string filename = "tmp-" + i;
			Texture2D tex = (Texture2D) Resources.Load(filename, typeof(Texture2D));
			lebronFrames[i] = tex;
		}

		for (int i = 0; i < 53; i++) {
			string filename = "sv-tmp-" + i;
			Texture2D tex = (Texture2D) Resources.Load(filename, typeof(Texture2D));
			svFrames[i] = tex;
		}
		for (int i = 0; i < 59; i++) {
			string filename = "steph-tmp-" + i;
			Texture2D tex = (Texture2D) Resources.Load(filename, typeof(Texture2D));
			stephFrames[i] = tex;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (currentVideo == 0) {
			int index = ((int)(Time.time * framesPerSecond)) % lebronFrames.Length;
			GetComponent<Renderer> ().material.mainTexture = lebronFrames [index];
		} else if (currentVideo == 1) {
			int index = ((int)(Time.time * framesPerSecond)) % svFrames.Length;
			GetComponent<Renderer> ().material.mainTexture = svFrames [index];
		} else if (currentVideo == 2) {
			int index = ((int)(Time.time * stephsPerSecond)) % stephFrames.Length;
			GetComponent<Renderer> ().material.mainTexture = stephFrames [index];
		}
	}
}
