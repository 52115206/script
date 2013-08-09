using UnityEngine;
using System.Collections;

public class ShowOuterSkin : MonoBehaviour {
	
	Transform outer_skin;
	string display = "隐藏机床外壳";
	// Use this for initialization
	void Start () {
		outer_skin = GameObject.Find("OuterSkin1").transform;
	}
	
	void OnGUI () {
//		if(GUI.Button(new Rect(10, 10, 120, 30), display ))
//		{
//			if(display == "隐藏机床外壳")
//			{
//				display = "显示机床外壳";
//				foreach(Transform child in outer_skin)
//				{
//					child.renderer.enabled = false;
//					foreach(Transform grandson in child)
//						grandson.renderer.enabled = false;
//				}
//			}
//			else
//			{
//				display = "隐藏机床外壳";
//				foreach(Transform child in outer_skin)
//				{
//					child.renderer.enabled = true;
//					foreach(Transform grandson in child)
//						grandson.renderer.enabled = true;
//				}
//			}
//		}
	}
	
	public void Hide()
	{
		display = "显示机床外壳";
		foreach(Transform child in outer_skin)
		{
			child.renderer.enabled = false;
			foreach(Transform grandson in child)
				grandson.renderer.enabled = false;
		}
	}
	
	public void Display()
	{
		display = "隐藏机床外壳";
		foreach(Transform child in outer_skin)
		{
			child.renderer.enabled = true;
			foreach(Transform grandson in child)
				grandson.renderer.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
