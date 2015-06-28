//
//  WatchKitUnityManager.cs
//
//  Created by Nikos Chagialas - http://devgallery.com on 10/04/2015
//
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WatchKitUnityManager : MonoBehaviour
{
	[SerializeField]
	private string m_appleGroup = "group.shopkit";
	public GameObject globalManager;
	private GlobalScript script;

	void Start () {
		WatchKitBridge.InitialiseWithGroup(m_appleGroup);

		Invoke("RegisterListeners", 2f);
	}

	void Update() {
		script = globalManager.GetComponent<GlobalScript> ();
	}

	private void RegisterListeners() {
		WatchKitBridge.RegisterListenerFor("testcommand");
		WatchKitBridge.RegisterListenerFor("move_left");
		WatchKitBridge.RegisterListenerFor("move_right");
		WatchKitBridge.RegisterListenerFor("move_up");
		WatchKitBridge.RegisterListenerFor("move_down");
		WatchKitBridge.RegisterListenerFor("next_item");
		WatchKitBridge.RegisterListenerFor("previous_item");
		WatchKitBridge.RegisterListenerFor("next_collection");

		WatchKitBridge.SendMessage("ready", "state", "state");
	}

	public void onMessageReceived(string identifier) {
		switch (identifier) {
		case "testcommand":
			script.debug();
			break;
		case "move_left":
			script.moveLeft();
			break;
		case "move_right":
			script.moveRight();
		
			break;
		case "move_up":
			script.moveUp();
			break;
		case "move_down":
			script.moveDown();
			break;
		case "next_item":
			script.nextItem();
			break;
		case "previous_item":
			script.previousItem();
			break;
		case "next_collection":
			script.nextCollection();
			break;
		default: 
			break;
		}

		//WatchKitBridge.SendMessage(identifier + " pressed", "state", "state");
	}
}

