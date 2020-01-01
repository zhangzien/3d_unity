using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class UFOfactory : MonoBehaviour
{
	public List<GameObject> used;
	public List<GameObject> notUsed;
	public List<actions> actions;
	public int round = 0;
	public int score = 0;

	private void Start()
	{
		used = new List<GameObject>();
		notUsed = new List<GameObject>();
		actions = new List<actions>();
		for(int i = 0; i < 10; i++)
		{
			notUsed.Add(Object.Instantiate(Resources.Load("Prefabs/UFO1", typeof(GameObject)), new Vector3(0, -20, 0), Quaternion.identity, null) as GameObject);
			//Debug.Log ("prefabes");
			actions.Add(ScriptableObject.CreateInstance<actions>());
		}
		for(int i = 0; i < 10; i++)
		{
			actions[i].ufo = notUsed[i];
		}
	}

	private void OnGUI()
	{
		if (round <= 10) {
			for (int i = 0; i < 10; i++) {
				actions [i].Update ();
			}
			if (notUsed.Count == 10) {
				round += 1;
				if (round <= 10)
					newRound (round);
			}
		} else {
			GUIStyle style1 = new GUIStyle();
			style1.normal.background = null;
			style1.normal.background = null;
			style1.normal.textColor = Color.red;
			style1.fontSize = 20;
			GUI.Label(new Rect(200,200, 200, 200), "游戏结束！",style1);
		}
	}
	public void hitted(GameObject g)
	{
		Debug.Log (g.tag);
		if (g.gameObject.GetComponent<MeshRenderer>().material.color==Color.white) {
			Debug.Log ("1");
			score += 1;
		} else if (g.gameObject.GetComponent<MeshRenderer>().material.color==Color.gray) {
			Debug.Log ("2");
			score += 2;
		} else if (g.gameObject.GetComponent<MeshRenderer>().material.color==Color.black) {
			Debug.Log ("3");
			score += 3;
		}
		this.used.Remove(g);
		g.transform.position = new Vector3(0, -20, 0);
		for(int i = 0; i < 10; i++)
		{
			if (actions[i].ufo == g)
				actions[i].running = false;
		}
		this.notUsed.Add(g);
	}
	public void miss(GameObject g)
	{
		this.used.Remove(g);
		g.transform.position = new Vector3(0, -20, 0);
		for (int i = 0; i < 10; i++)
		{
			if (actions[i].ufo == g)
				actions[i].running = false;
		}
		this.notUsed.Add(g);
	}

	public void newRound(int round)
	{
		for(int i = 0; i < 10; i++)
		{
			used.Add(notUsed[0]);
			notUsed.Remove(notUsed[0]);
			actions[i].speed = round + 2;
			actions[i].Start();
			actions[i].running = true;
		}
	}
}
