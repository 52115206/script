using UnityEngine;
using System.Collections;

public class AuxiliaryFunctionModule : MonoBehaviour {
	ControlPanel Main;
	
	public float btn_width = 49;
	public float btn_height = 45;
	public float l_x=264;
	public float l_y=778;
	public float left_x=64;
	public float left_y=52;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
	}
	
	public void AuxiliaryFunction ()
	{
		if (GUI.Button(new Rect(l_x/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.COOL))           
		{
			if(Main.ScreenPower)
			{
				if(Main.COOL.normal.background == Main.COOL_off_u){
					Main.COOL.normal.background = Main.COOL_on_u;
					Main.COOL.active.background = Main.COOL_on_d;
					Main.sty_COOL.normal.background = Main.sty_COOL_d;
				}else{
					Main.COOL.normal.background = Main.COOL_off_u;
					Main.COOL.active.background = Main.COOL_off_d;
					Main.sty_COOL.normal.background = Main.sty_COOL_u;
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, (l_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Empty1))            
		{
			if(Main.ScreenPower)
			{
				if(Main.Empty1.normal.background == Main.Empty1_off_u){
					Main.Empty1.normal.background = Main.Empty1_on_u;
					Main.Empty1.active.background = Main.Empty1_on_d;
				}else{
					Main.Empty1.normal.background = Main.Empty1_off_u;
					Main.Empty1.active.background = Main.Empty1_off_d;
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, (l_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.MHS))            
		{
			if(Main.ScreenPower)
			{
				if(Main.MHS.normal.background == Main.MHS_off_u){
					Main.MHS.normal.background = Main.MHS_on_u;
					Main.MHS.active.background = Main.MHS_on_d;
					Main.sty_MHS.normal.background = Main.sty_MHS_d;
				}else{
					Main.MHS.normal.background = Main.MHS_off_u;
					Main.MHS.active.background = Main.MHS_off_d;
					Main.sty_MHS.normal.background = Main.sty_MHS_u;
				}
			}
		}

		if (GUI.Button(new Rect((l_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.ATCW))            
		{
			if(Main.ScreenPower)
			{
				if(Main.ATCW.normal.background == Main.ATCW_off_u){
					Main.ATCW.normal.background = Main.ATCW_on_u;
					Main.ATCW.active.background = Main.ATCW_on_d;
					Main.sty_ATCW.normal.background = Main.sty_ATCW_d;
				}else{
					Main.ATCW.normal.background = Main.ATCW_off_u;
					Main.ATCW.active.background = Main.ATCW_off_d;
					Main.sty_ATCW.normal.background = Main.sty_ATCW_u;
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.ATCCW))            
		{
			if(Main.ScreenPower)
			{
				if(Main.ATCCW.normal.background == Main.ATCCW_off_u){
					Main.ATCCW.normal.background = Main.ATCCW_on_u;
					Main.ATCCW.active.background = Main.ATCCW_on_d;
					Main.sty_ATCCW.normal.background = Main.sty_ATCCW_d;
				}else{
					Main.ATCCW.normal.background = Main.ATCCW_off_u;
					Main.ATCCW.active.background = Main.ATCCW_off_d;
					Main.sty_ATCCW.normal.background = Main.sty_ATCCW_u;
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.MHRN))            
		{
			if(Main.ScreenPower)
			{
				if(Main.MHRN.normal.background == Main.MHRN_off_u){
					Main.MHRN.normal.background = Main.MHRN_on_u;
					Main.MHRN.active.background = Main.MHRN_on_d;
					Main.sty_MHRN.normal.background = Main.sty_MHRN_d;
				}else{
					Main.MHRN.normal.background = Main.MHRN_off_u;
					Main.MHRN.active.background = Main.MHRN_off_d;
					Main.sty_MHRN.normal.background = Main.sty_MHRN_d;
				}
			}
		}

		if (GUI.Button(new Rect((l_x)/1000f*Main.width, (l_y+2*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.FOR))            
		{
			if(Main.ScreenPower)
			{
				if(Main.FOR.normal.background == Main.FOR_off_u){
					Main.FOR.normal.background = Main.FOR_on_u;
					Main.FOR.active.background = Main.FOR_on_d;
					Main.sty_FOR.normal.background = Main.sty_FOR_d;
				}else{
					Main.FOR.normal.background = Main.FOR_off_u;
					Main.FOR.active.background = Main.FOR_off_d;
					Main.sty_FOR.normal.background = Main.sty_FOR_u;
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, (l_y+2*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.BACK))            
		{
			if(Main.ScreenPower)
			{
				if(Main.BACK.normal.background == Main.BACK_off_u){
					Main.BACK.normal.background = Main.BACK_on_u;
					Main.BACK.active.background = Main.BACK_on_d;
					Main.sty_BACK.normal.background = Main.sty_BACK_d;
				}else{
					Main.BACK.normal.background = Main.BACK_off_u;
					Main.BACK.active.background = Main.BACK_off_d;
					Main.sty_BACK.normal.background = Main.sty_BACK_u;
				}
			}
		}
		
		if(GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, (l_y+2*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Empty2))
		{
			if(Main.ScreenPower)
			{
				if(Main.Empty2.normal.background == Main.Empty2_off_u){
					Main.Empty2.normal.background = Main.Empty2_on_u;
					Main.Empty2.active.background = Main.Empty2_on_d;
				}else{
					Main.Empty2.normal.background = Main.Empty2_off_u;
					Main.Empty2.active.background = Main.Empty2_off_d;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
