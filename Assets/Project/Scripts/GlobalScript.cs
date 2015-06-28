using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {
	ItemListManager listManager = new ItemListManager();

	void Start() {
		GameObject[] items = GameObject.FindGameObjectsWithTag ("Item");
		foreach (GameObject item in items) {
			GameObjectManipulator itemManipulator = new GameObjectManipulator(item);
			listManager.add (itemManipulator);
		}

		listManager.showNext ();
	}

	void Update () {
		if (Input.GetKeyDown ("space")) {
			listManager.showNext ();
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			listManager.moveLeft();
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			moveRight();
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			moveUp();
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			moveDown();
		}

		if (Input.GetKey (KeyCode.U)) {
			listManager.showNext ();
		}

		if (Input.GetKeyDown (KeyCode.I)) {
			listManager.showPrevious ();
		}

		if (Input.GetKeyDown (KeyCode.H)) {
			listManager.hideAll ();
		}

		if (Input.GetKey (KeyCode.J)) {
			listManager.showNext ();
		}
	}
	public void nextItem() {
		listManager.showNext ();
	}

	public void previousItem() {
		listManager.showPrevious ();
	}

	public void moveUp() {
		listManager.moveUp ();
	}

	public void moveDown() {
		listManager.moveDown ();
	}

	public void moveLeft() {
		listManager.moveLeft ();
	}

	public void moveRight() {
		listManager.moveRight ();
	}

	public void debug() {
		listManager.hideAll ();
	}
}
