using UnityEngine;
using System.Collections;

public class RightclickMenu : MonoBehaviour {
	ControlPanel Main;
	camera_sm Camera_Script;
	public bool rightclick_menu_on = false;
	Rect rightclick_rect;
	
	public const int CAMERA_LEFT = 1;
	public const int CAMERA_RIGHT = 2;
	public const int CAMERA_FACELOOK = 3;
	public const int CAMERA_OVERLOOK = 4;
	public const int PRESET_ONE = 5;
	public const int PRESET_TWO = 6;
	public const int CAMERA_CUSTOM = 7;
	public const int CUSTOM_SETTINGS = 8;
	int current_state = 0;
	// Use this for initialization
	void Start () {
		Main = GameObject.Find("MainScript").GetComponent<ControlPanel>();
		Camera_Script = GameObject.Find("Main Camera").GetComponent<camera_sm>();
		rightclick_rect = new Rect(0, 0, 150f, 213f);
		current_state = 0;
	}
	
	void OnGUI ()
	{
		Event mouse_e = Event.current;
		if(Main.panelWindowOnly)
		{
			if(!Main.PanelWindowRect.Contains(mouse_e.mousePosition) && mouse_e.isMouse && 
				mouse_e.type == EventType.MouseDown && mouse_e.button == 1 && !Input.GetMouseButton(2))
			{
				rightclick_menu_on = true;
				rightclick_rect.x = mouse_e.mousePosition.x;
				rightclick_rect.y = mouse_e.mousePosition.y;
			}
		}
		else
		{
			if(!Main.screenRect.Contains(mouse_e.mousePosition) && mouse_e.isMouse && 
				mouse_e.type == EventType.MouseDown && mouse_e.button == 1 && !Input.GetMouseButton(2))
			{
				rightclick_menu_on = true;
				rightclick_rect.x = mouse_e.mousePosition.x;
				rightclick_rect.y = mouse_e.mousePosition.y;
			}
		}
		
		if(mouse_e.isMouse && mouse_e.type == EventType.MouseDown && mouse_e.button != 1)
		{
			rightclick_menu_on = false;
		}
		
		if(rightclick_menu_on)
		{
			rightclick_rect = GUI.Window(4, rightclick_rect, RightClickMenu, "", Main.sty_Rightclick);
			GUI.BringWindowToFront(1);
		}
	}
	
	void RightClickMenu(int WindowID)
	{
		Event rightclick_e = Event.current;
//		GUI.contentColor = Color.black;
//		GUI.Box(new Rect(2, 2, 146, 25), "");
		if(new Rect(1, 2, 148, 25).Contains(rightclick_e.mousePosition))
			current_state = CAMERA_LEFT;
		else if(new Rect(1, 27, 148, 25).Contains(rightclick_e.mousePosition))
			current_state = CAMERA_RIGHT;
		else if(new Rect(1, 52, 148, 25).Contains(rightclick_e.mousePosition))
			current_state = CAMERA_FACELOOK;
		else if(new Rect(1, 77, 148, 25).Contains(rightclick_e.mousePosition))
			current_state = CAMERA_OVERLOOK;
		else if(new Rect(1, 109, 148, 25).Contains(rightclick_e.mousePosition))
			current_state = PRESET_ONE;
		else if(new Rect(1, 136, 148, 25).Contains(rightclick_e.mousePosition))
			current_state = PRESET_TWO;
		else if(new Rect(1, 161, 148, 25).Contains(rightclick_e.mousePosition))
			current_state = CAMERA_CUSTOM;
		else if(new Rect(1, 186, 148, 25).Contains(rightclick_e.mousePosition))
			current_state = CUSTOM_SETTINGS;
		else
			current_state = 0;
		
		switch(current_state)
		{
		case CAMERA_LEFT:
			GUI.Label(new Rect(1, 2, 148, 25), "", Main.sty_BlueCursor);
			break;
		case CAMERA_RIGHT:
			GUI.Label(new Rect(1, 27, 148, 25), "", Main.sty_BlueCursor);
			break;
		case CAMERA_FACELOOK:
			GUI.Label(new Rect(1, 52, 148, 25), "", Main.sty_BlueCursor);
			break;
		case CAMERA_OVERLOOK:
			GUI.Label(new Rect(1, 77, 148, 25), "", Main.sty_BlueCursor);
			break;
		case PRESET_ONE:
			GUI.Label(new Rect(1, 109, 148, 25), "", Main.sty_BlueCursor);
			break;
		case PRESET_TWO:
			GUI.Label(new Rect(1, 136, 148, 25), "", Main.sty_BlueCursor);
			break;
		case CAMERA_CUSTOM:
			GUI.Label(new Rect(1, 161, 148, 25), "", Main.sty_BlueCursor);
			break;
		case CUSTOM_SETTINGS:
			GUI.Label(new Rect(1, 186, 148, 25), "", Main.sty_BlueCursor);
			break;
		default:
			break;
		}
		
		GUI.Label(new Rect(4, 4, 146, 25), "左视图            Ctrl + ←", Main.sty_RightclickFont);
		
//		GUI.Box(new Rect(2, 27, 146, 25), "");
		GUI.Label(new Rect(4, 29, 146, 25), "右视图            Ctrl + →", Main.sty_RightclickFont);
		
//		GUI.Box(new Rect(2, 52, 146, 25), "");
		GUI.Label(new Rect(4, 54, 146, 25), "正视图            Ctrl +  ↑", Main.sty_RightclickFont);
		
//		GUI.Box(new Rect(2, 77, 146, 25), "");
		GUI.Label(new Rect(4, 79, 146, 25), "俯视图            Ctrl +  ↓", Main.sty_RightclickFont);

		GUI.Label(new Rect(4, 95, 146, 25), "——————————", Main.sty_RightclickFont);
		
//		GUI.Box(new Rect(2, 111, 146, 25), "");
		GUI.Label(new Rect(4, 113, 146, 25), "预设视角1       Ctrl + F1", Main.sty_RightclickFont);
		
//		GUI.Box(new Rect(2, 136, 146, 25), "");
		GUI.Label(new Rect(4, 138, 146, 25), "预设视角2       Ctrl + F2", Main.sty_RightclickFont);
		
//		GUI.Box(new Rect(2, 161, 146, 25), "");
		GUI.Label(new Rect(4, 163, 146, 25), "自定义视角      Ctrl + F3", Main.sty_RightclickFont);
		
//		GUI.Box(new Rect(2, 186, 146, 25), "");
		GUI.Label(new Rect(4, 188, 146, 25), "当前视角设定   Ctrl + F4", Main.sty_RightclickFont);
		
		if(rightclick_e.isMouse && rightclick_e.type == EventType.MouseDown && rightclick_e.button == 0 && current_state != 0)
		{
			Camera_Script.CameraMode(current_state);
			rightclick_menu_on = false;
		} 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
