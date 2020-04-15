using System.Collections;
using System.Collections.Generic;
using States.Game;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
	{
		static private TextMeshProUGUI textMesh;
		static int score;

		void Start()
		{
			textMesh = GetComponent<TextMeshProUGUI>();
			score = 0;
		}

		static public void AddScore()
		{
			textMesh.text = "Score: " + score.ToString();
			score += 10;
		}

}

