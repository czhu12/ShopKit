using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CategoryListManager : MonoBehaviour {
	ItemListManager currentManager;
	Dictionary<string, ItemListManager> categoriesMap = new Dictionary<string, ItemListManager>();
	string[] categoryTags = {};
	string currentCategory;

	public CategoryListManager(string[] tags) {
		this.categoryTags = tags;
		foreach (string category in categoryTags) {
			GameObject[] categoryItems = GameObject.FindGameObjectsWithTag (category);
			ItemListManager listManager = new ItemListManager();
			
			foreach (GameObject item in categoryItems) {
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
