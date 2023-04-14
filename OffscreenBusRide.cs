using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffscreenBusRide : MonoBehaviour
{
	private GameObject objectBus;

	private void Start()
	{
		if (GameObject.Find("ObjectBusSystem"))
		{
			objectBus = GameObject.Find("ObjectBusSystem");
		}
		else
		{
			throw new System.ArgumentException("no object bus system in scene");
		}
		
	}

	// Update is called once per frame
	void Update()
    {
		if (ObjectBusSystem.Instance.IsOffscreen(transform))
		{
			ObjectBusSystem.Instance.Attach(transform);
		}
	}
}
