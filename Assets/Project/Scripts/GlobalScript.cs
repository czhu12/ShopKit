using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {
	CategoryListManager categoryManager;
	string[] categoryTags = {"Category_1", "Category_2", "Category_3"};
	int categoryIndex = 0;
	void Start() {
		categoryManager = new CategoryListManager (categoryTags);
		categoryManager.SetCategory (categoryTags[categoryIndex]);
		categoryIndex++;
	}

	void Update () {
		if (Input.GetKeyDown ("space")) {
			categoryManager.showNext ();
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			categoryManager.moveLeft();
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
			categoryManager.showNext ();
		}

		if (Input.GetKeyDown (KeyCode.I)) {
			categoryManager.showPrevious ();
		}

		if (Input.GetKeyDown (KeyCode.H)) {
			categoryManager.hideAll ();
		}

		if (Input.GetKeyDown(KeyCode.R)) {
			categoryManager.SetCategory(categoryTags[categoryIndex]);
			categoryIndex++;
			if (categoryIndex >= categoryTags.Length) {
				categoryIndex = 0;
			}
		}

		if (Input.GetKeyDown (KeyCode.N)) {
			nextCollection ();
		}
	}

	public void nextItem() {
		categoryManager.showNext ();
	}

	public void nextCollection() {
		categoryManager.nextCollection ();
	}

	public void previousItem() {
		categoryManager.showPrevious ();
	}

	public void moveUp() {
		categoryManager.moveUp ();
	}

	public void moveDown() {
		categoryManager.moveDown ();
	}

	public void moveLeft() {
		categoryManager.moveLeft ();
	}

	public void moveRight() {
		categoryManager.moveRight ();
	}

	public void debug() {
		categoryManager.hideAll ();
	}
}
