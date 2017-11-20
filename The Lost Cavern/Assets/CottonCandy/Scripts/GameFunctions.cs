using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunctions : MonoBehaviour {

	public static int goal = 4;

	void Start()
	{

	}

	void Update()
	{
		if (goal == 0)
		{
			SugarGenerator.isFinished = true;
		}
	}

	public static void goalScore()
	{
		goal--;
	}

}
