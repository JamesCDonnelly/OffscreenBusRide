using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectBusSystem : MonoBehaviour
{
	public static ObjectBusSystem Instance { get; private set; }

	readonly List<Transform> busList = new();

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

    // Update is called once per frame
    void Update()
    {
		
		foreach (Transform riderTransform in busList)
		{
			if (!IsOffscreen(riderTransform))
			{
				Debug.Log(riderTransform.name + " says: Let me off the bus");
				riderTransform.gameObject.SetActive(true);
				riderTransform.parent = null;
				busList.Remove(riderTransform);
				break;
			}
		}
    }

	public void Attach(Transform riderTransform)
	{
		busList.Add(riderTransform);
		riderTransform.parent = transform;
		riderTransform.gameObject.SetActive(false);
		Debug.Log(riderTransform.name + " is on the bus at seat " + riderTransform.position );
	}

	public bool IsOffscreen(Transform riderTransform)
	{
		float buffer = 200f;
		Vector3 goscreen = Camera.main.WorldToScreenPoint(riderTransform.position);

		float distX = Vector2.Distance(new Vector2(Screen.width / 2, 0f), new Vector2(goscreen.x, 0f));
		float distY = Vector2.Distance(new Vector2(0f, Screen.height / 2), new Vector2(0f, goscreen.y));

		return (distX > Screen.width / 2 + buffer || distY > Screen.height / 2 + buffer);
	}
}
