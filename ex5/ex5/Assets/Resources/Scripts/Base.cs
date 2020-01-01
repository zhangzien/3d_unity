namespace Base{
	
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	//Director
	public class director : System.Object
	{
		private static director _instance;
		public FirstController currentController { get; set; }
		public static director getInstance()
		{
			if (_instance == null)
			{
				_instance = new director();
			}
			return _instance;
		}
	}

	//Actions
	public class actions : ScriptableObject
	{
		public director director;
		public GameObject ufo;
		Vector3 start;
		Vector3 end;
		public int speed=5;
		public bool running = true;
		public int recordType;

		public void Start()
		{
			director = director.getInstance();
			start = new Vector3(Random.Range(-6,6), Random.Range(-6,6), 0);
			if (start.x < 10 && start.x > -10)
				start.x *= 5;
			if (start.y < 10 && start.y > -10)
				start.y *= 5;
			end = new Vector3(-start.x, -start.y, 0);
			ufo.transform.position = start;
			foreach (Transform child in ufo.transform)
			{
				child.gameObject.GetComponent<MeshRenderer>().material=Material.Instantiate(Resources.Load("Prefabs/body", typeof(Material))) as Material;
			}
			int typeOfUFO = Random.Range(1, 4);
			recordType = typeOfUFO;
			switch (typeOfUFO)
			{
			case 1:
				//ufo.tag="easy";
				//ufo.GetComponent<MeshRenderer>().material =Material.Instantiate(Resources.Load("Prefabs/easy", typeof(Material))) as Material;
				ufo.GetComponent<MeshRenderer>().material.color=Color.white;
				break;
			case 2:
				//ufo.tag="middle";
				//ufo.GetComponent<MeshRenderer>().material = Material.Instantiate(Resources.Load("Prefabs/middle", typeof(Material))) as Material;
				ufo.GetComponent<MeshRenderer>().material.color=Color.gray;
				break;
			case 3:
				//ufo.tag="tough";
				//ufo.GetComponent<MeshRenderer>().material = Material.Instantiate(Resources.Load("Prefabs/tough", typeof(Material))) as Material;
				ufo.GetComponent<MeshRenderer>().material.color=Color.black;
				break;
			default:
				break;
			}
		}

		public void Update()
		{
			if (running)
			{
				ufo.transform.position = Vector3.MoveTowards(ufo.transform.position, end, speed * Time.deltaTime);
				if (ufo.transform.position == end)
				{
					this.director.currentController.factory.miss(this.ufo);   
				}
			}
		}
			
	}

}