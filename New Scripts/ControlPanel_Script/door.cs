using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	// Use this for initialization
	bool enter;
	bool move;
	float speed;

	void Start () {
		speed=0.08F;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(enter==true)
			{
				move=true;
			}
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			move=false;
		}

		if(move)
		{
			float h =  Input.GetAxis("Mouse X"); 
			transform.Translate(new Vector3(0,0,1f)*h*speed,Space.Self);
		}
		
		if(this.name == "door_left")
		{
			if(transform.position.z >= 0.01470597f)
				transform.position = new Vector3(transform.position.x , transform.position.y, 0.01470597f);
			
			if(transform.position.z <= -0.5059499f)
				transform.position = new Vector3(transform.position.x , transform.position.y, -0.5059499f);
		}
		
		if(this.name == "door_right")
		{
			if(transform.position.z >= -1.091452f)
				transform.position = new Vector3(transform.position.x , transform.position.y, -1.091452f);
			
			if(transform.position.z <= -1.58747f)
				transform.position = new Vector3(transform.position.x , transform.position.y, -1.58747f);
		}
		
		//To be modified
		if(this.name == "main protecting crust_11")
		{
			if(transform.localPosition.z <= -0.2983818f)
				transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y, -0.2983818f);
			
			if(transform.localPosition.z >= 0.187275f)
				transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y, 0.187275f);
		}
		
		//To be modified
		if(this.name == "main protecting crust_12")
		{
			if(transform.localPosition.z <= -1.423464f)
				transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y, -1.423464f);
			
			if(transform.localPosition.z >= -0.887454f)
				transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y, -0.887454f);
		}
	}
	
	void OnGUI()
	{
		//GUI.Label(new Rect(100,100,100,100),hideFlags.ToString());
	}
	
	void OnMouseEnter() 
	{
        	enter=true;
    	}
	
	void OnMouseExit() 
	{
        	enter=false;
    	}
}
