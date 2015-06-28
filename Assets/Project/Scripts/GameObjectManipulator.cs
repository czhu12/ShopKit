using UnityEngine;
using System.Collections;

public class GameObjectManipulator : MonoBehaviour {
	GameObject currentModel;
	float currentRotation = 0;
	public float rotationSpeed = 100f;
	Vector3 currentPosition;

	public GameObjectManipulator(GameObject obj) {
		this.currentModel = obj;
		this.currentPosition = obj.transform.position;
	}

	public void hardMove() {
		//Vector3.Lerp (currentModel.transform.position, currentPosition, Time.deltaTime);
		currentModel.transform.position = currentPosition;
	}

	public string getName() {
		return currentModel.transform.name;
	}

	public GameObject getGameObject() {
		return currentModel;
	}
	/*
	public void moveLeft() {
		currentPosition = currentPosition + (new Vector3 (1, 0, 0) * Time.deltaTime);
		move ();
	}

	public void moveRight() {
		currentPosition = currentPosition + (new Vector3 (-1, 0, 0) * Time.deltaTime);
		move ();
	}

	public void moveUp() {
		currentPosition = currentPosition + (new Vector3 (0, 0, 1) * Time.deltaTime);
		move ();
	}

	public void moveDown() {
		currentPosition = currentPosition + (new Vector3 (0, 0, -1) * Time.deltaTime);
		move ();
	}
	
	public void rotateLeft() {
		currentRotation += rotationSpeed * Time.deltaTime;
		currentModel.transform.localEulerAngles = new Vector3 (0, currentRotation, 0);
	}
	
	public void rotateRight() {
		currentRotation -= rotationSpeed * Time.deltaTime;
		currentModel.transform.localEulerAngles = new Vector3(0, currentRotation, 0);
	}
	*/

	public void show() {
		currentModel.SetActive (true);
	}

	public void setPosition(Vector3 position) {
		this.currentPosition = position;
	}

	public void hide() {
		currentModel.SetActive (false);
	}
}
