//
//  WatchKitBridge.cs
//
//  Created by Nikos Chagialas - http://devgallery.com on 10/04/2015
//
//

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class WatchKitBridge : MonoBehaviour {

	/* Interface to native implementation */

	[DllImport ("__Internal")]
	private static extern void _InitialiseWithGroup (string group);

	[DllImport ("__Internal")]
	private static extern void _RegisterListenerFor (string identifier);

	[DllImport ("__Internal")]
	private static extern void _SendMessage (string value, string theObject, string identifier);

	
	public static void InitialiseWithGroup(string group)
	{
		_InitialiseWithGroup(group);
	}

	public static void RegisterListenerFor(string identifier)
	{
		_RegisterListenerFor(identifier);
	}

	public static void SendMessage(string value, string theObject, string identifier)
	{
		_SendMessage(value, theObject, identifier);
	}
	
}
