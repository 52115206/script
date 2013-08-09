using UnityEngine;
using System.Collections;

public class MachineFunctionModule : MonoBehaviour {
	ControlPanel Main;
	EntranceScript AutoRunning_Script;
	
	public float btn_width = 49f;
	public float btn_height = 45f;
	public float l_x=693;
	public float l_y=610;
	public float left_x=65;
	public float left_y=54;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		AutoRunning_Script = gameObject.GetComponent<EntranceScript>();
	}
	
	public void MachineFunction ()
	{
		if (GUI.Button(new Rect(l_x/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.MLK))             
		{
			if(Main.ScreenPower)
			{
				if(Main.MLK.normal.background == Main.MLK_u){
					Main.MLK.normal.background = Main.MLK_on_u;
					Main.MLK.active.background = Main.MLK_on_d;
					Main.sty_MLK.normal.background = Main.sty_MLK_d;
				}else{
					Main.MLK.normal.background = Main.MLK_u;
					Main.MLK.active.background = Main.MLK_d;
					Main.sty_MLK.normal.background = Main.sty_MLK_u;
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.DRN))            
		{
			if(Main.ScreenPower)
			{
				if(Main.DRN.normal.background == Main.DRN_u){
					Main.DRN.normal.background = Main.DRN_on_u;
					Main.DRN.active.background = Main.DRN_on_d;
					Main.sty_DRN.normal.background = Main.sty_DRN_d;
				}else{
					Main.DRN.normal.background = Main.DRN_u;
					Main.DRN.active.background = Main.DRN_d;
					Main.sty_DRN.normal.background = Main.sty_DRN_u;
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.BDT))            
		{
			if(Main.ScreenPower)
			{
				if(Main.BDT.normal.background == Main.BDT_u){
					Main.BDT.normal.background = Main.BDT_on_u;
					Main.BDT.active.background = Main.BDT_on_d;
					Main.sty_BDT.normal.background = Main.sty_BDT_d;
				}else{
					Main.BDT.normal.background = Main.BDT_u;
					Main.BDT.active.background = Main.BDT_d;
					Main.sty_BDT.normal.background = Main.sty_BDT_u;
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+3*left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.SBK))            
		{
			if(Main.ScreenPower)
			{
				if(Main.SBK.normal.background == Main.SBK_u){
					Main.SBK.normal.background = Main.SBK_on_u;
					Main.SBK.active.background = Main.SBK_on_d;
					Main.sty_SBK.normal.background = Main.sty_SBK_d;
					Main.SingleStep = true;
				}else{
					Main.SBK.normal.background = Main.SBK_u;
					Main.SBK.active.background = Main.SBK_d;
					Main.sty_SBK.normal.background = Main.sty_SBK_u;
					Main.SingleStep = false;
					AutoRunning_Script.SingleStepStop();
				}
			}
		}
		
		
		
		if (GUI.Button(new Rect((l_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.OSP))            
		{
			if(Main.ScreenPower)
			{
				if(Main.OSP.normal.background == Main.OSP_u){
					Main.OSP.normal.background = Main.OSP_on_u;
					Main.OSP.active.background = Main.OSP_on_d;
					Main.sty_OSP.normal.background = Main.sty_OSP_d;
				}else{
					Main.OSP.normal.background = Main.OSP_u;
					Main.OSP.active.background = Main.OSP_d;
					Main.sty_OSP.normal.background = Main.sty_OSP_u;
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.ZLOCK))            
		{
			if(Main.ScreenPower)
			{
				if(Main.ZLOCK.normal.background == Main.ZLOCK_u){
					Main.ZLOCK.normal.background = Main.ZLOCK_on_u;
					Main.ZLOCK.active.background = Main.ZLOCK_on_d;
					Main.sty_ZLOCK.normal.background = Main.sty_ZLOCK_d;
				}else{
					Main.ZLOCK.normal.background = Main.ZLOCK_u;
					Main.ZLOCK.active.background = Main.ZLOCK_d;
					Main.sty_ZLOCK.normal.background = Main.sty_ZLOCK_u;
				}
			}
		}
		
		if(GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.MachineEMPTY))
		{
			if(Main.ScreenPower)
			{
				if(Main.MachineEMPTY.normal.background == Main.MachineEMPTY_u){
					Main.MachineEMPTY.normal.background = Main.MachineEMPTY_on_u;
					Main.MachineEMPTY.active.background = Main.MachineEMPTY_on_d;
				}else{
					Main.MachineEMPTY.normal.background = Main.MachineEMPTY_u;
					Main.MachineEMPTY.active.background = Main.MachineEMPTY_d;
				}
			}
		}
		
		if(GUI.Button(new Rect((l_x+3*left_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.MachineEMPTY2))
		{
			if(Main.ScreenPower)
			{
				if(Main.MachineEMPTY2.normal.background == Main.MachineEMPTY_u){
					Main.MachineEMPTY2.normal.background = Main.MachineEMPTY_on_u;
					Main.MachineEMPTY2.active.background = Main.MachineEMPTY_on_d;
				}else{
					Main.MachineEMPTY2.normal.background = Main.MachineEMPTY_u;
					Main.MachineEMPTY2.active.background = Main.MachineEMPTY_d;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
