using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CategoryListManager : MonoBehaviour {
	ItemListManager currentManager;
	Dictionary<string, ItemListManager> categoriesMap = new Dictionary<string, ItemListManager>();
	string[] categoryTags = {};
	string currentCategory;

	int compareByTag(GameObject a, GameObject b) {
		bool aIsTV = false;
		bool bIsTV = false;

		foreach (Transform child in a.transform) {
			if (child.tag == "television") {
				aIsTV = true;
			}
		}

		foreach (Transform child in b.transform) {
			if (child.tag == "television") {
				bIsTV = true;
			}
		}
		if (aIsTV && bIsTV) {
			return 0;
		} else if (aIsTV && !bIsTV) {
			return 1;
		} else if (!aIsTV && bIsTV) {
			return -1;
		} else {
			return 0;
		}
	}

	public CategoryListManager(string[] tags) {
		this.categoryTags = tags;
		foreach (string category in categoryTags) {
			GameObject[] categoryItems = GameObject.FindGameObjectsWithTag (category);
			List<GameObject> l = new List<GameObject>();

			for (int i = 0; i < categoryItems.Length; i++) {
				l.Add(categoryItems[i]);
			}

			l.Sort (compareByTag);

			ItemListManager listManager = new ItemListManager();
			
			foreach (GameObject item in l) {
				GameObjectManipulator itemManipulator = new GameObjectManipulator(item);
				listManager.add (itemManipulator);
			}
			
			categoriesMap.Add(category, listManager);
			listManager.hideAll();
		}
	}

	public void SetCategory(string newCategory) {		
		if (categoriesMap.ContainsKey(newCategory)) {
			currentCategory = newCategory;
			hideAll ();
			currentManager = categoriesMap [newCategory];
			currentManager.reset ();
			currentManager.showCurrent ();
		}
	}


	public void hideAll() {
		foreach (string key in categoriesMap.Keys) {
			ItemListManager item = categoriesMap[key];
			item.hideAll ();
		}
	}

	public void showNext() {
		currentManager.showNext ();
	}
	
	public void showPrevious() {
		currentManager.showPrevious ();
	}
	
	public void moveLeft() {
		currentManager.moveLeft ();
	}
	
	public void moveRight() {
		currentManager.moveRight ();
	}
	
	public void moveUp() {
		currentManager.moveUp ();
	}
	
	public void moveDown() {
		currentManager.moveDown ();
	}

	public void showCurrent() {
		currentManager.showCurrent ();
	}

	public void nextCollection() {
		int currentIndex = 0;
		for (int i = 0; i < categoryTags.Length; i++) {
			if (categoryTags[i] == currentCategory) {
				currentIndex = i;
				break;
			}
		}
		currentIndex++;

		if (currentIndex >= categoryTags.Length) {
			currentIndex = 0;
		}

		string newCategory = categoryTags [currentIndex];
		this.SetCategory (newCategory);
	}

}
