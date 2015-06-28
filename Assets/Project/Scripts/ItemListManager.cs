using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemListManager : MonoBehaviour {
	int currentIndex = 0;
	List<GameObjectManipulator> objectList;
	Vector3 currentPosition = new Vector3(0f, 0f, 0f);

	public ItemListManager(List<GameObjectManipulator> list) {
		objectList = list;
	}

	public ItemListManager() {
		objectList = new List<GameObjectManipulator>();
	}

	public void add(GameObjectManipulator item) {
		this.objectList.Add (item);
	}

	public GameObjectManipulator showPrevious() {
		if (shouldntChangePrevious ()) {
			return getCurrentObject();
		}

		currentIndex--;
		if (currentIndex < 0) {
			currentIndex = objectList.Count - 1;
		}
		hideAll ();

		GameObjectManipulator previous = objectList [currentIndex];
		showCurrentItem ();
		checkAndUpdateTelevision (2);
		return previous;
	}

	bool shouldntChangePrevious() {
		GameObjectManipulator current = getCurrentObject ();
		string name = current.getName ();
		if (name == "television") {
			GameObject obj = current.getGameObject();
			VideoPlayer vp = obj.GetComponentInChildren<VideoPlayer>();
			return vp.toPreviousVideo();
		}
		return false;
	}

	bool shouldntChangeAdvance() {
		GameObjectManipulator current = getCurrentObject ();
		string name = current.getName ();
		if (name == "television") {
			GameObject obj = current.getGameObject();
			VideoPlayer vp = obj.GetComponentInChildren<VideoPlayer>();
			return vp.toNextVideo();
		}
		return false;
	}

	public GameObjectManipulator showNext() {
		// This is TV specific behavior. Basically, it if is currently showing LeBron, 
		// we will not switch the channel. Rather, we will update the channel to SV

		if (shouldntChangeAdvance()) {
			return getCurrentObject();
		}

		currentIndex++;
		if (currentIndex >= objectList.Count) {
			currentIndex = 0;
		}

		hideAll ();

		GameObjectManipulator next = objectList [currentIndex];
		showCurrentItem ();
		checkAndUpdateTelevision (0);

		return next;
	}

	void checkAndUpdateTelevision(int newVal) {
		GameObjectManipulator current = getCurrentObject ();
		string name = current.getName ();
		if (name == "television") {
			GameObject obj = current.getGameObject();
			VideoPlayer vp = obj.GetComponentInChildren<VideoPlayer>();
			vp.setCurrentVideo(newVal);
		}
	}

	public void showCurrent() {
		hideAll ();
		showCurrentItem ();
	}
		
	public void moveLeft() {
		currentPosition = currentPosition + (new Vector3 (1, 0, 0) * Time.deltaTime);
		positionCurrentItem ();
	}
	
	public void moveRight() {
		currentPosition = currentPosition + (new Vector3 (-1, 0, 0) * Time.deltaTime);
		positionCurrentItem ();
	}
	
	public void moveUp() {
		currentPosition = currentPosition + (new Vector3 (0, 0, 1) * Time.deltaTime);
		positionCurrentItem ();
	}
	
	public void moveDown() {
		currentPosition = currentPosition + (new Vector3 (0, 0, -1) * Time.deltaTime);
		positionCurrentItem ();
	}

	void positionCurrentItem() {
		GameObjectManipulator current = getCurrentObject ();
		current.setPosition (currentPosition);
		current.hardMove ();
	}

	GameObjectManipulator getCurrentObject() {
		return objectList [currentIndex];
	}

	void showCurrentItem() {
		GameObjectManipulator current = getCurrentObject ();
		showItem (current);
	}

	void showItem(GameObjectManipulator gameObject) {
		gameObject.setPosition (currentPosition);
		gameObject.hardMove ();
		gameObject.show ();
	}

	public void hideAll() {
		foreach (GameObjectManipulator obj in objectList) {
			obj.hide ();
		}
	}

	public void reset() {
		currentIndex = 0;
		this.currentPosition = new Vector3 (0f, 0f, 0f);
	}
}
