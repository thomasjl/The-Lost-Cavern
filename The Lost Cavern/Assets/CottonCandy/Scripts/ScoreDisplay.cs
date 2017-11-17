using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

	Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}

	void Update()
	{
		text.text = "Il vous manque " + GameFunctions.goal + " sucre(s)";
		if (GameFunctions.goal == 0)
		{
			text.text = "Vous avez collectés assez de sucres, versez les dans la machine";
		}
	}
}