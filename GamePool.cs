using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


///<summary>
///<para>Author : Arash Rasoulzadeh (arashrasoulzadeh@gmail.com)</para>
///<para>Last Update : jan 2016</para>
///</summary>
public class GamePool : MonoBehaviour
{
	public static GamePool	current;
	// a refrence to current class
	public GameObject pooledObject;
	//gameobject you want to be created and pre-reserved in a list
	public int totalAmount;
// total amounts of pre-reserved gameobjects
	public bool isdynamic = true;
	// should we create another reserved gameobject if list does not have free one ?

	public List<GameObject> pooledObjects;
	// the list used to hold pre-reserved game objects

	void Awake ()
	{
		current = this;//set  refrence
	}
	// Use this for initialization
	void Start ()
	{
		pooledObjects = new List<GameObject> (); // create new list
		for (int i = 0; i < totalAmount; i++) {
			AddtoList ();// add pre-reserved gameobjects to list
		}
	}

	public GameObject AddtoList (bool isActive = false)// add items function , isActive tells script to add or return active/inactive gameobject
	{
		GameObject go = (GameObject)Instantiate (pooledObject);//create new instance
		go.SetActive (isActive);//set to inactive (default)
		pooledObjects.Add (go);//add to list
		return go; // and return it (if needed)

	
	}

	///<summary>
	///<para>free the GameObject and return it to list</para>
	/// <paramref name="Request"> = get free item using  </paramref>
	///</summary>
	public void Free (GameObject item)// free and item , simply disable it
	{
		item.SetActive (false);//disable a game object


	}

 
	 
	///<summary>
	///<para>use this to get free object from pool list</para>
	///<para>remember to setActive(false) insted of Destroy()</para>
	/// <paramref name="Free"> = to free object   </paramref>
	///</summary>
	public GameObject Request (bool isActive = false)
	{
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (pooledObjects [i] != null) {// *
				if (!pooledObjects [i].activeInHierarchy) {//check to find and return an inactive item
					pooledObjects [i].SetActive (isActive);//set to requested state
					//pooledObjects [i].name = Time.timeSinceLevelLoad + "";
 
					return pooledObjects [i]; //return it to game

				}
			} else { // * if the item in index i is accidently destroyed
				return AddtoList (isActive); // create new one and return it

			}
		}
		if (isdynamic) {// if isdynamic is true, add new spot to list dynamicaly
			return AddtoList (isActive);
		}
		return null;// if isdynamic is not true , and there is no free slot in list , return null;
	}
}
