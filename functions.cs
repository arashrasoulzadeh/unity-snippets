using UnityEngine;
using System.Collections;
using System;

 

///<summary>
///<para>Author : Arash Rasoulzadeh (arashrasoulzadeh@gmail.com)</para>
///<para>Last Update : 7 DEC 2015</para>
///</summary>

public class functions : MonoBehaviour
{
	
	///<summary>
	///<para>Using this function you can calculate if two values are near enugh or not.</para>
	///<para>eg. : check for x or y of a vector ...</para>
	///</summary>
	public static bool CloseEnoughForMe (double value1, double value2, double acceptableDifference)
	{
		return Math.Abs (value1 - value2) <= acceptableDifference; 
	}

	///<summary>
	///<para>Using this function you can calculate if two values are near enugh or not.</para>
	///<para>eg. : check for x or y of a vector ...</para>
	///</summary>
	public static bool CloseEnoughForMe (float value1, float value2, float acceptableDifference)
	{
		return Math.Abs (value1 - value2) <= acceptableDifference; 
	}
	public static string ConvertNumber(int num)
	{
		if (num>= 1000)
			return string.Concat(Math.Round( float.Parse(num+"")/ 1000,2), "k");
		else
			return num.ToString();
 	}

}
