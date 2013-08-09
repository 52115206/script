using UnityEngine;
using System.Collections;

public class Warnning : MonoBehaviour {
	
	Rect object_tips_rect = new Rect(-500f, Screen.height - 290f, 360f, 290f);
//	Rect win_rect = new Rect(-500f, Screen.height - 290f, 360f, 290f);
	private float left = -500f; 
	public bool come_forth = false;
	public bool motion_start = false;
	private float time_value = 0;
	
	public string object_description;
	public GUIText s;
	int height;
	public Vector2 scrollPosition = Vector2.zero;
	// Use this for initialization
	void Start () {
//		show=true;
		//object_description="天之道\n，损有余\n而补不足\n天之道\n，损有余\n而补不足天之道\n，损有余\n而补不足\n天之道\n，损有余\n而补不足\n天之道\n，损有余\n而补不足\n天之道\n，损有余\n而补不足\n天之道\n，损有余\n而补不足\n天之道\n，损有余\n而补不足\n天之道\n，损有余\n而补不足\n!@#";
//		object_description="天之道\n";
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnGUI()
	{
		object_tips_rect.x = left;
		GUI.Window(5, object_tips_rect, DoMyWindow5, "");
		
//		if(GUI.Button(new Rect(280, 50, 100, 30), "Increase String"))
//		{
//			i++;
//			object_description += "第" + i + "次增加;\n";
//		}
		
//		if(GUI.Button(new Rect(100f, Screen.height - 290f, 100f, 30f), "触发"))
//		{
//			motion_start = true;
//		}
		
//		if(GUI.Button(new Rect(390, 50, 100, 30), "Decrease String"))
//		{
//			object_description = object_description.Remove(object_description.Length - 10, 10);
//		}
		
	}
	
	void DoMyWindow5(int windowID) 
	{
		if(GUI.Button(new Rect(40, 250, 100, 30), "清除"))
		{
			object_description = "";
		}
		
		if(GUI.Button(new Rect(200, 250, 100, 30), "关闭"))
		{
			motion_start = true;
		}
		
		scrollPosition = GUI.BeginScrollView (new Rect (20, 20, 320, 200),scrollPosition , new Rect (0, 0, 300, 14*height+14));
		string	s1="";
		int len=object_description.Length;
		
		char[] myChars = object_description.ToCharArray();
		height=1;
		
		for(int i=0;i<len;i++)
		{
			s1+=myChars[i];
			s.text=s1;
			if(s.GetScreenRect().width>260)
			{
				height+=1;
				s1=""+myChars[i];
				s.text=s1;
			}
			if(myChars[i]=='\n')
			{
				height+=1;
				s1=""+myChars[i];
				s.text=s1;
			}
			
		}
		
		GUI.Label(new Rect(0, 0, 260,16*height+16), object_description);
		
		GUI.EndScrollView();	
	}
	
	void FixedUpdate ()
	{
		if(motion_start)
		{
			//出来
			if(come_forth)
			{
				time_value += Time.fixedDeltaTime;
				left = Mathf.Lerp(0, -500f, 2*time_value);
				if(2*time_value > 1f)
				{
					time_value = 0; 
					come_forth = !come_forth;
					motion_start = false;
				}
			}
			//进去
			else
			{
				time_value += Time.fixedDeltaTime;
				left = Mathf.Lerp(-500f, 0, 2*time_value);
				if(2*time_value > 1f)
				{
					time_value = 0; 
					come_forth = !come_forth;
					motion_start = false;
				}
			}
		}
		
	}
}
