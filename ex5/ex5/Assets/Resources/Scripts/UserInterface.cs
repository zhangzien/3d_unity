using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class UserInterface : MonoBehaviour
{
	public director _director;
	void Start()
	{
		_director = director.getInstance();
	}

	private void OnGUI()
	{
		int my_round = _director.currentController.factory.round;
		if (my_round == 11)
		{
			GUIStyle style1 = new GUIStyle();
			style1.normal.background = null;
			style1.normal.background = null;
			style1.normal.textColor = Color.red;
			style1.fontSize = 20;
			string ending_score = "Final Score: " + _director.currentController.factory.score.ToString();
			GUI.Label(new Rect(200,250, 200, 200), ending_score, style1);
		}
		else
		{
			string round = my_round.ToString();
			round = "Round: " + round;
			GUIStyle style2 = new GUIStyle();
			style2.normal.background = null;
			style2.normal.textColor = Color.cyan;
			style2.fontSize = 25;
			GUI.Label(new Rect(5, 10, 150, 35), round, style2);
			string score = _director.currentController.factory.score.ToString();
			score = "Score:" + score;
			GUI.Label(new Rect(5, 40, 150, 35), score, style2);
			GUIStyle style3 = new GUIStyle();
			style3.normal.background = null;
			style3.normal.textColor = Color.cyan;
			style3.fontSize = 20;
			GUI.Label(new Rect(5, 70, 150, 35), "White UFO for 1 point(s)", style3);
			GUI.Label(new Rect(5, 95, 150, 35), "Gray  UFO for 2 point(s)", style3);
			GUI.Label(new Rect(5, 120, 150, 35), "Black UFO for 3 point(s)", style3);

		}
	}
}
