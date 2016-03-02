using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallCounter : MonoBehaviour {

	static int counter;

	static string textPrefix = "Ball created: ";

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = textPrefix + counter;
	}

	public static void add()
	{
		counter = counter + 1;
	}
}
