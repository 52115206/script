using UnityEngine;
using System.Collections;

public class FeedrateModule : MonoBehaviour {
	ControlPanel Main;
	MoveControl MoveControl_script;
	AutoMoveModule AutoMove_Script;
	EntranceScript AutoRunning_Script;
	bool feedrate0_pause = false;
	
	public float Feedrate_x=440f;
	public float Feedrate_y=600f;
	public float Feedrate_width=220f;
	public float Feedrate_height;
	
	public float mode1_x=450f;
	public float mode1_y=700f;
	public float mode1_width=40f;
	public float mode1_height=20f;
	
	public float mode2_x=440f;
	public float mode2_y=682f;
	public float mode2_width=40f;
	public float mode2_height=16f;
	
	public float mode3_x=440f;
	public float mode3_y=665f;
	public float mode3_width=40f;
	public float mode3_height=18f;
	
	public float mode4_x=440f;
	public float mode4_y=650f;
	public float mode4_width=40f;
	public float mode4_height=16f;
	
	public float mode5_x=446f;
	public float mode5_y=635f;
	public float mode5_width=40f;
	public float mode5_height=16f;
	
	public float mode6_x=455f;
	public float mode6_y=620f;
	public float mode6_width=40f;
	public float mode6_height=16f;
	
	public float mode7_x=500f;
	public float mode7_y=600f;
	public float mode7_width=16f;
	public float mode7_height=40f;
	
	public float mode8_x=516f;
	public float mode8_y=600f;
	public float mode8_width=16f;
	public float mode8_height=40f;
	
	public float mode9_x=532f;
	public float mode9_y=600f;
	public float mode9_width=16f;
	public float mode9_height=40f;
	
	public float mode10_x=552f;
	public float mode10_y=600f;
	public float mode10_width=16f;
	public float mode10_height=40f;
	
	public float mode11_x=565f;
	public float mode11_y=620f;
	public float mode11_width=40f;
	public float mode11_height=16f;
	
	public float mode12_x=580f;
	public float mode12_y=635f;
	public float mode12_width=40f;
	public float mode12_height=16f;
	
	public float mode13_x=582f;
	public float mode13_y=650f;
	public float mode13_width=40f;
	public float mode13_height=16f;
	
	public float mode14_x=582f;
	public float mode14_y=665f;
	public float mode14_width=40f;
	public float mode14_height=18f;
	
	public float mode15_x=586f;
	public float mode15_y=680f;
	public float mode15_width=40f;
	public float mode15_height=18f;
	
	public float mode16_x=580f;
	public float mode16_y=699f;
	public float mode16_width=40f;
	public float mode16_height=20f;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
		AutoMove_Script = GameObject.Find("AutoMove").GetComponent<AutoMoveModule>();
		AutoRunning_Script = gameObject.GetComponent<EntranceScript>();
		
		Feedrate_height=Feedrate_width*511/893;
	}
	
	
	public void FeedrateSelect()
	{
		GUI.DrawTexture(new Rect(Feedrate_x/1000f*Main.width,Feedrate_y/1000f*Main.height,Feedrate_width/1000f*Main.width,Feedrate_height/1000f*Main.height), Main.t2d_feedrate, ScaleMode.ScaleAndCrop, true, 893/511f);
		if (GUI.Button(new Rect(mode1_x/1000f*Main.width, mode1_y/1000f*Main.height, mode1_width/1000f*Main.width, mode1_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_0;
			PlayerPrefs.SetInt("FeedrateSelect", 1);
			Main.move_rate = 0f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag && !AutoMove_Script.PauseState())
			{
				AutoMove_Script.SetPause();
				Main.RunningSpeed = 0;
				feedrate0_pause = true;
			}
		}
		if (GUI.Button(new Rect(mode2_x/1000f*Main.width, mode2_y/1000f*Main.height, mode2_width/1000f*Main.width, mode2_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_10;
			PlayerPrefs.SetInt("FeedrateSelect", 2);
			Main.move_rate = 0.1f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
		if (GUI.Button(new Rect(mode3_x/1000f*Main.width, mode3_y/1000f*Main.height, mode3_width/1000f*Main.width, mode3_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_20;
			PlayerPrefs.SetInt("FeedrateSelect", 3);
			Main.move_rate = 0.2f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
		if (GUI.Button(new Rect(mode4_x/1000f*Main.width, mode4_y/1000f*Main.height, mode4_width/1000f*Main.width, mode4_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_30;
			PlayerPrefs.SetInt("FeedrateSelect", 4);
			Main.move_rate = 0.3f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
		if (GUI.Button(new Rect(mode5_x/1000f*Main.width, mode5_y/1000f*Main.height, mode5_width/1000f*Main.width, mode5_height/1000f*Main.height), "", Main.sty_ButtonEmpty))           
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_40;
			PlayerPrefs.SetInt("FeedrateSelect", 5);
			Main.move_rate = 0.4f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
//		if (GUI.Button(new Rect(463f/1000f*Main.width, 647/1000f*Main.height, 40f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_40;
//			PlayerPrefs.SetInt("FeedrateSelect", 5);
//			Main.move_rate = 0.4f;
//			MoveControl_script.move_rate = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode6_x/1000f*Main.width, mode6_y/1000f*Main.height, mode6_width/1000f*Main.width, mode6_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_50;
			PlayerPrefs.SetInt("FeedrateSelect", 6);
			Main.move_rate = 0.5f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
//		if (GUI.Button(new Rect(490f/1000f*Main.width, 627/1000f*Main.height, 30f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_50;
//			PlayerPrefs.SetInt("FeedrateSelect", 6);
//			Main.move_rate = 0.5f;
//			MoveControl_script.move_rate = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode7_x/1000f*Main.width, mode7_y/1000f*Main.height, mode7_width/1000f*Main.width, mode7_height/1000f*Main.height), "", Main.sty_ButtonEmpty))              
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_60;
			PlayerPrefs.SetInt("FeedrateSelect", 7);
			Main.move_rate = 0.6f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
//		if (GUI.Button(new Rect(528f/1000f*Main.width, 647/1000f*Main.height, 17f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_60;
//			PlayerPrefs.SetInt("FeedrateSelect", 7);
//			Main.move_rate = 0.6f;
//			MoveControl_script.move_rate = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode8_x/1000f*Main.width, mode8_y/1000f*Main.height, mode8_width/1000f*Main.width, mode8_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_70;
			PlayerPrefs.SetInt("FeedrateSelect", 8);
			Main.move_rate = 0.7f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
//		if (GUI.Button(new Rect(540f/1000f*Main.width, 627/1000f*Main.height, 20f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_70;
//			PlayerPrefs.SetInt("FeedrateSelect", 8);
//			Main.move_rate = 0.7f;
//			MoveControl_script.move_rate = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode9_x/1000f*Main.width, mode9_y/1000f*Main.height, mode9_width/1000f*Main.width, mode9_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_80;
			PlayerPrefs.SetInt("FeedrateSelect", 9);
			Main.move_rate = 0.8f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
//		if (GUI.Button(new Rect(560f/1000f*Main.width, 647/1000f*Main.height, 15f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_80;
//			PlayerPrefs.SetInt("FeedrateSelect", 9);
//			Main.move_rate = 0.8f;
//			MoveControl_script.move_rate = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode10_x/1000f*Main.width, mode10_y/1000f*Main.height, mode10_width/1000f*Main.width, mode10_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_90;
			PlayerPrefs.SetInt("FeedrateSelect", 10);
			Main.move_rate = 0.9f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
//		if (GUI.Button(new Rect(575f/1000f*Main.width, 647/1000f*Main.height, 15f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_90;
//			PlayerPrefs.SetInt("FeedrateSelect", 10);
//			Main.move_rate = 0.9f;
//			MoveControl_script.move_rate = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode11_x/1000f*Main.width, mode11_y/1000f*Main.height, mode11_width/1000f*Main.width, mode11_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_100;
			PlayerPrefs.SetInt("FeedrateSelect", 11);
			Main.move_rate = 1.0f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
//		if (GUI.Button(new Rect(600f/1000f*Main.width, 627/1000f*Main.height, 20f/1000f*Main.width, 30f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_100;
//			PlayerPrefs.SetInt("FeedrateSelect", 11);
//			Main.move_rate = 1.0f;
//			MoveControl_script.move_rate = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode12_x/1000f*Main.width, mode12_y/1000f*Main.height, mode12_width/1000f*Main.width, mode12_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_110;
			PlayerPrefs.SetInt("FeedrateSelect", 12);
			Main.move_rate = 1.1f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
//		if (GUI.Button(new Rect(614f/1000f*Main.width, 657/1000f*Main.height, 25f/1000f*Main.width, 18f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_110;
//			PlayerPrefs.SetInt("FeedrateSelect", 12);
//			Main.move_rate = 1.1f;
//			MoveControl_script.move_rate = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode13_x/1000f*Main.width, mode13_y/1000f*Main.height, mode13_width/1000f*Main.width, mode13_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_120;
			PlayerPrefs.SetInt("FeedrateSelect", 13);
			Main.move_rate = 1.2f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
		if (GUI.Button(new Rect(mode14_x/1000f*Main.width, mode14_y/1000f*Main.height, mode14_width/1000f*Main.width, mode14_height/1000f*Main.height), "", Main.sty_ButtonEmpty))           
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_130;
			PlayerPrefs.SetInt("FeedrateSelect", 14);
			Main.move_rate = 1.3f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
		if (GUI.Button(new Rect(mode15_x/1000f*Main.width, mode15_y/1000f*Main.height, mode15_width/1000f*Main.width, mode15_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_140;
			PlayerPrefs.SetInt("FeedrateSelect", 15);
			Main.move_rate = 1.4f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
		if (GUI.Button(new Rect(mode16_x/1000f*Main.width, mode16_y/1000f*Main.height, mode16_width/1000f*Main.width, mode16_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_150;
			PlayerPrefs.SetInt("FeedrateSelect", 16);
			Main.move_rate = 1.5f;
			MoveControl_script.move_rate = Main.move_rate;
			if(Main.AutoRunning_flag)
			{
				if(feedrate0_pause && !Main.AutoPause_flag)
				{
					AutoMove_Script.ReleasePause();
					feedrate0_pause = false;
				}
				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
			}
		}
		//GUIUtility
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
