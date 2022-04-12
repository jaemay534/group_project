using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Peterson, Jaela]
 * Date: [02/24/2022]
 * [This will solve doors lab 1 by creating doors and keys]
 */

public class Player : MonoBehaviour
{
	public int orb_green_count = 0;
	public int orb_blue_count = 0;
	public int orb_red_count = 0;
	public int orb_gold_count = 0;
	public int orb_cyan_count = 0;
	public int orb_purple_count = 0;

	private void OnTriggerEnter(Collider other)
	{
		//print("Trigger");
		//Green objects
		if(other.gameObject.tag == "Orb Green")
		{
			orb_green_count++;
			print("Orb Green " + orb_green_count);
			other.gameObject.SetActive(false);
		}
		if(other.gameObject.tag == "Door Green")
		{
			print("Dummy where are the keys?");
			if(orb_green_count >= other.gameObject.GetComponent<Door>().number_of_locks_green && orb_gold_count >= other.gameObject.GetComponent<Door>().number_of_locks_gold && orb_cyan_count >= other.gameObject.GetComponent<Door>().number_of_locks_cyan)
			// if x >= 3
			{
				print("*ff fanfare*");
				orb_green_count -= other.gameObject.GetComponent<Door>().number_of_locks_green;
				//orb_gold_count -= other.gameObject.GetComponent<Door>().number_of_locks_gold;
				orb_cyan_count -= other.gameObject.GetComponent<Door>().number_of_locks_cyan;
				other.gameObject.SetActive(false);
			}
		}
		

		// gold objects
		if(other.gameObject.tag == "Orb Gold")
		{
			orb_gold_count++;
			print("Orb Gold " + orb_gold_count);
			other.gameObject.SetActive(false);
		}

		//cyan objects
		if(other.gameObject.tag == "Orb Cyan")
		{
			orb_cyan_count++;
			print("Orb Cyan " + orb_cyan_count);
			other.gameObject.SetActive(false);
		}

		//purple objects
		if(other.gameObject.tag == "Orb Purple")
		{
			orb_purple_count++;
			print("Orb Purple " + orb_purple_count);
			other.gameObject.SetActive(false);
		}

		// blue objects
		if(other.gameObject.tag == "Orb Blue")
		{
			orb_blue_count++;
			print("Orb Blue " + orb_blue_count);
			other.gameObject.SetActive(false);
		}
		//blue DOOR
		if(other.gameObject.tag == "Door Blue")
		{
			print("Dummy where are the keys?");
			if(orb_blue_count >= other.gameObject.GetComponent<Door>().number_of_locks_blue && orb_red_count >= other.gameObject.GetComponent<Door>().number_of_locks_red && orb_purple_count >= other.gameObject.GetComponent<Door>().number_of_locks_purple)
			// if x >= 
			{
				print("*ff fanfare*");
				orb_blue_count -= other.gameObject.GetComponent<Door>().number_of_locks_blue;
				orb_red_count-= other.gameObject.GetComponent<Door>().number_of_locks_red;
				orb_purple_count-= other.gameObject.GetComponent<Door>().number_of_locks_purple;
				other.gameObject.SetActive(false);
			}
		}

		if(other.gameObject.tag == "Orb Red")
		{
			orb_red_count++;
			print("Orb Red " + orb_red_count);
			other.gameObject.SetActive(false);
		}
		//red DOOR
		if(other.gameObject.tag == "Door Red")
		{
			print("Dummy where are the keys?");
			if(orb_red_count >= other.gameObject.GetComponent<Door>().number_of_locks_red && orb_gold_count >= other.gameObject.GetComponent<Door>().number_of_locks_gold)
			// if x >= 3
			{
				print("*ff fanfare*");
				orb_red_count-= other.gameObject.GetComponent<Door>().number_of_locks_red;
				orb_gold_count -= other.gameObject.GetComponent<Door>().number_of_locks_gold;
				other.gameObject.SetActive(false);
			}
		}
	}

}  // end of Player Script
