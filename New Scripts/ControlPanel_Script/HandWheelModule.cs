using UnityEngine;
using System.Collections;
   
public class HandWheelModule : MonoBehaviour {
	
	//添加 BY:WH
	public float win_rect_width;
	public float win_rect_height; 
	public GUIStyle HandWheel_backgraound;
	private Rect win_rect;
	public float hand_x;
	public float hand_y;
	public float hand_width;
	public float hand_height;
	Rect handWheelPlaneRect;
	public float handWheelOrigin_x;
	public float handWheelOrigin_y;
	Vector2 handWheelOrigin;
	
	public float left_x=10;
	public float left_y=123;
	public float right_x=122;
	public float right_y=123;
	public float num_width=60;
	public float num_height;
	public Texture2D left_1;
	public Texture2D left_2;
	public Texture2D mid;
	public Texture2D right_1;
	public Texture2D right_2;
	public Texture2D left_num;
	public Texture2D right_num;
	
	public float mode_off_x=50f;
	public float mode_off_y=280f;
	public float mode_off_width=50f;
	public float mode_off_height=50f;
	
	public float mode_x_x=100f;
	public float mode_x_y=250f;
	public float mode_x_width=50f;
	public float mode_x_height=50f;
	
	public float mode_y_x=180f;
	public float mode_y_y=240f;
	public float mode_y_width=50f;
	public float mode_y_height=50f;
	
	public float mode_z_x=260f;
	public float mode_z_y=250f;
	public float mode_z_width=50f;
	public float mode_z_height=50f;
	
	public float mode_4_x=320f;
	public float mode_4_y=280f;
	public float mode_4_width=100f;
	public float mode_4_height=50f;
	
	public float mode_1_x=650f;
	public float mode_1_y=260f;
	public float mode_1_width=100f;
	public float mode_1_height=50f;
	
	public float mode_10_x=750f;
	public float mode_10_y=240f;
	public float mode_10_width=80f;
	public float mode_10_height=50f;
	
	public float mode_100_x=840f;
	public float mode_100_y=260f;
	public float mode_100_width=100f;
	public float mode_100_height=50f;
	// Vector2 handWheelOrigin=new Vector2(355,305);//手轮刻度盘圆心位置
	//Rect handWheelPlaneRect=new Rect(180,130,350,350);//手轮刻度盘贴图的位置
	//private Rect win_rect = new Rect(-550f, Screen.height - 550f, win_rect_width, win_rect_height);
	
	private float left = -550f; 
	private bool come_forth = false;
	public bool motion_start = false;
	private float time_value = 0;
	
	//Rect PanelHandWheel = new Rect(0, 0, 550, 500);
	public GUIStyle sty_Button;
	public float width = 550F,height = 500F;
	public float X_Offset_HandWheelSet=0;//手轮控制下在X轴方向上的位移
	public float Y_Offset_HandWheelSet=0;//手轮控制下在Y轴方向上的位移
	public float Z_Offset_HandWheelSet=0;//手轮控制下在Z轴方向上的位移
    	bool  HandWheel_OFF=true;//手轮是否处于off状态
    	bool  X_HandWheel=false;//手轮进给时X轴选中
	bool  Y_HandWheel=false;//手轮进给时Y轴选中
	bool  Z_HandWheel=false;//手轮进给时Z轴选中
//	bool  Axis4_HandWheel=false;//手轮进给时4轴选中
	float Scale_Offset_HandWheel=0.001f;//手轮进给的单位距离
	bool handWheelActive=false;//
	Vector3 lastMousePos=new Vector3(0,0,0);
	float currRotateAngle=0;//当前手轮旋转的角度；
	float rotatedAngle=0;
//	float sumAngle=0;
	bool initializeLastPos=false;
	
	
	// Rect handWheelRect=new Rect(320,310,125,125);//整个手轮贴图的位置		
    Rect handWheelAreaRect;//手轮激活贴图的位置
//	int size=100;//手轮受力范围
    Vector2 handWheelPoint=new Vector2(410,250);//手轮受力点
	float handWheelRadius=0;
//	float minDistance=0;
//	float maxDistance=0;
	//public float angle=0f;//累计旋转的角度
    float deltaAngle=3.6f;//+1格或-1格的临界角度
//	float rotateMinAngle=2f;//旋转手轮贴图的最小角度
	int handWheelDirection=0;//手轮旋转方向
	public Texture2D hand;//手轮贴图
	public Texture2D plane;//刻度盘贴图
	
	public Texture2D activeArea;
    bool initializeAngleOffset=false;
    float angleOffset=0;
	MoveControl MoveControl_script;
	ControlPanel Main;
	public bool isShow;
	//public int Add_Interval_Num=0;
	//public int Sub_Interval_Num=0; 
	//GUI.Button(new Rect(750f/1000f*width, 850f/1000f*height, 50f/1000f*width, 50f/1000f*height), "DOWN"	
	// Use this for initialization
	
	void Awake()
	{
		LoadScriptOfAudio();	
		motion_start=false;
		isShow=false;
		Scale_Offset_HandWheel = 0.000001f;
		
		//添加 BY:WH
		Main=GameObject.Find("MainScript").GetComponent<ControlPanel>();
		HandWheel_backgraound.normal.background=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/0");
		left_1=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/2");
		left_2=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/3");
		mid=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/1");
		right_1=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/4");
		right_2=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/5");
		plane = (Texture2D)Resources.Load("DigitalControlPanel/HandWheel/6");
		left_num=left_2;
		right_num=left_1;
		win_rect_width=188f;
		win_rect_height=win_rect_width/314*785f;
		win_rect = new Rect(-550f, Screen.height - 550f, win_rect_width, win_rect_height);
		hand_x=24;
		hand_y=257;
		hand_width=140;
		hand_height=140;
		handWheelPlaneRect=new Rect(hand_x,hand_y,hand_width,hand_height);
		handWheelOrigin_x=94f;
		handWheelOrigin_y=326.5f;
		handWheelOrigin=new Vector2(handWheelOrigin_x,handWheelOrigin_y);
		
		mode_off_x=50f;
		mode_off_y=280f;
		mode_off_width=50f;
		mode_off_height=50f;
	
		mode_x_x=100f;
		mode_x_y=250f;
		mode_x_width=50f;
		mode_x_height=50f;
	
		mode_y_x=180f;
		mode_y_y=240f;
		mode_y_width=50f;
		mode_y_height=50f;
	
		mode_z_x=260f;
		mode_z_y=250f;
		mode_z_width=50f;
		mode_z_height=50f;
	
		mode_4_x=320f;
		mode_4_y=280f;
		mode_4_width=100f;
		mode_4_height=50f;
	
		mode_1_x=650f;
		mode_1_y=260f;
		mode_1_width=100f;
		mode_1_height=50f;
	
		mode_10_x=750f;
		mode_10_y=240f;
		mode_10_width=80f;
		mode_10_height=50f;
	
		mode_100_x=840f;
		mode_100_y=260f;
		mode_100_width=100f;
		mode_100_height=50f;
		
		left_x=10;
		left_y=123;
		right_x=122;
		right_y=123;
		num_width=60;
		num_height=num_width/416*502;
	}
	
	void LoadScriptOfAudio()
	{
		gameObject.AddComponent<AudioSource>();
		gameObject.audio.playOnAwake = false;
		gameObject.audio.clip = (AudioClip)Resources.Load("Audio/move");
		gameObject.audio.minDistance = 30f;
		
	}
	void Start (){
		// print(Mathf.Asin(0.5F));
	    handWheelAreaRect=new Rect(handWheelPlaneRect);
		//Debug.Log(handWheelPoint);
	   //Debug.Log(handWheelAreaRect);
		handWheelRadius=(handWheelPoint.x-handWheelOrigin.x)*(handWheelPoint.x-handWheelOrigin.x)+(handWheelPoint.y-handWheelOrigin.y)*(handWheelPoint.y-handWheelOrigin.y);
		handWheelRadius=Mathf.Pow (handWheelRadius,0.5f);
		//Debug.Log(handWheelRadius);
//		minDistance=Mathf.Pow( handWheelRadius,0.5f)-15;
//		maxDistance=Mathf.Pow( handWheelRadius,0.5f)+15;
		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
		
		//MoveControl_script = Main.MoveControl_script;
	}
	
	// Update is called once per frame
	void Update () {
		//添加 BY:WH
//		win_rect_height=win_rect_width/314*785f;
//		//win_rect = new Rect(-550f, Screen.height - 550f, win_rect_width, win_rect_height);
		handWheelPlaneRect=new Rect(hand_x,hand_y,hand_width,hand_height);
		handWheelOrigin=new Vector2(handWheelOrigin_x,handWheelOrigin_y);
		num_height=num_width/416*502;
		
		//Debug.Log("ccc");
		Vector3 mousePos=Input.mousePosition;
		//Debug.Log(Screen.height-mousePos.y);
		//mousePos.y=Screen.height-mousePos.y;
		//Debug.Log(handWheelAreaRect);
		//Debug.Log(handWheelRect);
		//Debug.Log(mousePos);
		
		//Debug.Log(mousePos.x+"mpppp"+win_rect.x);
		//Debug.Log(win_rect.x+"we");
		mousePos.x-=win_rect.x;
		mousePos.y=Screen.height-mousePos.y;
		mousePos.y-=win_rect.y;
		//Debug.Log("Ok~~"+mousePos.x+" "+mousePos.y);
		//float distance=(mousePos.x-handWheelOrigin.x)*(mousePos.x-handWheelOrigin.x)+(mousePos.y-handWheelOrigin.y)*(mousePos.y-handWheelOrigin.y);
		if(handWheelAreaRect.Contains(mousePos))
		//distance=Mathf.Pow (distance,0.5f);
		//if(distance>minDistance&&distance<maxDistance)
		{   
			//Debug.Log("Ok~~"+mousePos.x+" "+mousePos.y);
	        if(Input.GetMouseButtonDown(0))
            {
				//Debug.Log(mousePos);
				if(!initializeAngleOffset)
		       {
		           angleOffset=180 - Mathf.Atan2(mousePos.x- handWheelOrigin.x, mousePos.y - handWheelOrigin.y) * Mathf.Rad2Deg;
				   currRotateAngle=angleOffset;
				   
					//currRotateAngle=angleOffset;
			       initializeAngleOffset=true;
		        }
		     	
		    //	mousePos.y=Screen.height-mousePos.y;
		    	//Debug.Log(mousePos);
			
				
			   if(!initializeLastPos)
			   {
				  lastMousePos=mousePos;
				  initializeLastPos=true;
				 // Debug.Log("shubiao click");
			 	}
			    
				handWheelActive=true;
			}
		 
	      	if(Input.GetMouseButtonUp(0))
	    	{
				if(handWheelActive)
				{
			    	rotatedAngle+=currRotateAngle-angleOffset;
		        	handWheelActive=false;
			    	initializeLastPos=false;
			    	initializeAngleOffset=false;
				}
				
			//	sumAngle=0;
	    	}
		}
		else
		{
			//if(Input.GetMouseButtonUp(0))
	    	if(handWheelActive)
			{
				rotatedAngle+=currRotateAngle-angleOffset;
			}
			 // rotatedAngle+=currRotateAngle-angleOffset;
			//rotatedAngle+=currRotateAngle-angleOffset;
		    handWheelActive=false;
			initializeLastPos=false;
			initializeAngleOffset=false;
			//rotatedAngle+=sumAngle;
		  ////  sumAngle=0;
			//Debug.Log(handWheelAreaRect);
		}
		
		
	}
	void ChangeHandWheelPoint()
	{
		   /* if(currentMousePos.x>handWheelOrigin.x&&currentMousePos.y>lastMousePos.y)
			{
				//handWheelDirection=2;//-1格；
			     
				
			}
			else if(currentMousePos.x>handWheelOrigin.x&&currentMousePos.y<lastMousePos.y)
			{
				handWheelDirection=1;//+1格
			}
			else if(currentMousePos.x<handWheelOrigin.x&&currentMousePos.y>lastMousePos.y)
			{
				handWheelDirection=1;
			}
			else if(currentMousePos.x<handWheelOrigin.x&&currentMousePos.y<lastMousePos.y)
			{
				handWheelDirection=2;
			}*/
	}
	void OnGUI()
	{ 
		
		
		//win_rect.x = win_rect.x;
		//win_rect = 
		
		//win_rect =GUI.Window(10, win_rect, Warnning, "手轮");
		
		//Debug.Log("aaa");
		//GUI.DrawTexture( handWheelAreaRect,activeArea);
		//if(motion_start)win_rect.x=left;	//Debug.Log(win_rect.x+" "+win_rect.y+"kk");
		//Debug.Log(win_rect.x+"ppp");
		
		if(motion_start)win_rect.x = left;
		
		Vector3 mousePos=Input.mousePosition;
		mousePos.x-=(win_rect.x);
		mousePos.y=Screen.height-mousePos.y;
		mousePos.y-=(win_rect.y);
		if(handWheelAreaRect.Contains(mousePos))
		{
			GUI.Window(11, win_rect, Warnning, "",HandWheel_backgraound);
		}
		else
			win_rect =GUI.Window(11, win_rect, Warnning, "",HandWheel_backgraound);
		
		//win_rect =GUI.Window(11, win_rect, Warnning, "手轮");
		
		
	
	} 
	
	void Warnning(int WindowID)
	{
		GUI.DrawTexture(new Rect(left_x,left_y,num_width,num_height),left_num);
		GUI.DrawTexture(new Rect(right_x,right_y,num_width,num_height),right_num);
		
			if (GUI.Button(new Rect(mode_off_x/1000f*win_rect.width,mode_off_y/1000f*win_rect.height, mode_off_width/1000f*win_rect.width, mode_off_height/1000f*win_rect.height), "",Main.sty_ButtonEmpty))            
			{
				//Debug.Log("sldjflkdsjflkds");
				
				HandWheel_OFF=true;
				X_HandWheel=false;
		        Y_HandWheel=false;
		        Z_HandWheel=false;
//		        Axis4_HandWheel=false;
				//Debug.Log("????");
				
				//添加 BY:WH
				left_num=left_2;
			}
		 	if (GUI.Button(new Rect(mode_x_x/1000f*win_rect.width,mode_x_y/1000f*win_rect.height, mode_x_width/1000f*win_rect.width, mode_x_height/1000f*win_rect.height), "",Main.sty_ButtonEmpty))            
			{
				//Debug.Log("sldjflkdsjflkds");
				HandWheel_OFF=false;
				X_HandWheel=true;
		        Y_HandWheel=false;
		        Z_HandWheel=false;
//		        Axis4_HandWheel=false;
				MoveControl_script.x_n=true;
				//添加 BY:WH
				left_num=left_1;
			}
			if (GUI.RepeatButton(new Rect(mode_y_x/1000f*win_rect.width,mode_y_y/1000f*win_rect.height, mode_y_width/1000f*win_rect.width, mode_y_height/1000f*win_rect.height), "",Main.sty_ButtonEmpty))            
			{
				//Debug.Log("sldjflkdsjflkds");
				HandWheel_OFF=false;
				X_HandWheel=false;
		        Y_HandWheel=true;
		        Z_HandWheel=false;
//		        Axis4_HandWheel=false;
				//添加 BY:WH
				left_num=mid;
			
				//Main.MoveControl_script.speed_to_move = 0.16667F;//内容--JOG模式下，慢常速为10m/min=(10/60)m/s,因此spee-to-move=10/60,姓名--刘旋，时间--2013-4-8				
				//Main.MoveControl_script.move_rate = 1f;
				//Main.MoveControl_script.y_n=true;
				//MoveControl_script.audio.Play();
				
				//MoveControl_script.audio.Stop();
		
			}
			if (GUI.Button(new Rect(mode_z_x/1000f*win_rect.width,mode_z_y/1000f*win_rect.height, mode_z_width/1000f*win_rect.width, mode_z_height/1000f*win_rect.height), "",Main.sty_ButtonEmpty))            
			{
				//Debug.Log("sldjflkdsjflkds");
				HandWheel_OFF=false;
				X_HandWheel=false;
		        Y_HandWheel=false;
		        Z_HandWheel=true;
//		        Axis4_HandWheel=false;
				//添加 BY:WH
				left_num=right_1;
			}
			if (GUI.Button(new Rect(mode_4_x/1000f*win_rect.width,mode_4_y/1000f*win_rect.height, mode_4_width/1000f*win_rect.width, mode_4_height/1000f*win_rect.height), "",Main.sty_ButtonEmpty))            
			{
				//Debug.Log("sldjflkdsjflkds");
				HandWheel_OFF=false;
				X_HandWheel=false;
		        Y_HandWheel=false;
		        Z_HandWheel=false;
//		        Axis4_HandWheel=true;
				//添加 BY:WH
				left_num=right_2;
			}
			
			if (GUI.Button(new Rect(mode_1_x/1000f*win_rect.width,mode_1_y/1000f*win_rect.height, mode_1_width/1000f*win_rect.width, mode_1_height/1000f*win_rect.height), "",Main.sty_ButtonEmpty))            
			{
				//Debug.Log("sldjflkdsjflkds");
				Scale_Offset_HandWheel=0.000001f;
				//添加 BY:WH
				right_num=left_1;
			}
			if (GUI.Button(new Rect(mode_10_x/1000f*win_rect.width,mode_10_y/1000f*win_rect.height, mode_10_width/1000f*win_rect.width, mode_10_height/1000f*win_rect.height), "",Main.sty_ButtonEmpty))            
			{
				//Debug.Log("sldjflkdsjflkds");
				Scale_Offset_HandWheel=0.00001f;
				//添加 BY:WH
				right_num=mid;
			}
			if (GUI.Button(new Rect(mode_100_x/1000f*win_rect.width,mode_100_y/1000f*win_rect.height, mode_100_width/1000f*win_rect.width, mode_100_height/1000f*win_rect.height), "",Main.sty_ButtonEmpty))            
			{
				//Debug.Log("sldjflkdsjflkds");
				Scale_Offset_HandWheel=0.0001f;
				//添加 BY:WH
				right_num=right_1;
			}
//			if (GUI.Button(new Rect(350f/1000f*win_rect.width,20f/1000f*win_rect.height, 120f/1000f*win_rect.width, 70f/1000f*win_rect.height), "+1格")) 
//				//手轮往右移动一格
//			{
//				//Debug.Log("sldjflkdsjflkds");
//				handWheelDirection=1;
//				axlePostionChange();
//			}
//			if (GUI.Button(new Rect(350f/1000f*win_rect.width,220f/1000f*win_rect.height, 120f/1000f*win_rect.width, 70f/1000f*win_rect.height), "-1格"))            
//			{
//				//Debug.Log("sldjflkdsjflkds");
//				handWheelDirection=2;
//				axlePostionChange();
//			}
			


	
		
		if(!handWheelActive)
		{

			GUIUtility.RotateAroundPivot(rotatedAngle,handWheelOrigin);
		    GUI.DrawTexture( handWheelPlaneRect,plane);
		}
	    			
		if(handWheelActive)
		{
			
			
			//Debug.Log("active");
			//获取当前鼠标坐标
			Vector3 currentMousePos=Input.mousePosition;
			//handWheelAreaRect=new Rect(currentMousePos.x-size,Screen.height-currentMousePos.y-size,2*size,2*size);
			//计算在手轮圆心的哪一侧
			currentMousePos.y=Screen.height-currentMousePos.y;
			//根据相对手轮圆心的位置和鼠标y值的变化趋势确定是+1格还是-1格
			currentMousePos.x-=win_rect.x;
			currentMousePos.y-=win_rect.y;
			//Debug.Log("????"+currentMousePos.x+"???"+currentMousePos.y);
			//Debug.Log("ooo"+lastMousePos.x+"ooo"+lastMousePos.y);
			//Debug.Log("cuu"+currentMousePos.y+" last:"+lastMousePos.y);
			
			if(currentMousePos.x>handWheelOrigin.x&&currentMousePos.y<lastMousePos.y)
			{
				handWheelDirection=2;//-1格；
				
			}
			else if(currentMousePos.x>handWheelOrigin.x&&currentMousePos.y>lastMousePos.y)
			{
				handWheelDirection=1;//+1格
			}
			else if(currentMousePos.x<handWheelOrigin.x&&currentMousePos.y<lastMousePos.y)
			{
				handWheelDirection=1;
			}
			else if(currentMousePos.x<handWheelOrigin.x&&currentMousePos.y>lastMousePos.y)
			{
				handWheelDirection=2;
			}
			//根据tan值求angle
			
		    float rotateAngle=180 - Mathf.Atan2(currentMousePos.x- handWheelOrigin.x, currentMousePos.y -handWheelOrigin.y) * Mathf.Rad2Deg;
			//Debug.Log("ra:"+rotateAngle);
			//handWheelAreaRect=new Rect((handWheelRadius)*(Mathf.Sin(rotateAngle/Mathf.Rad2Deg))+handWheelOrigin.x-size,(-Mathf.Cos(rotateAngle/Mathf.Rad2Deg))*handWheelRadius+handWheelOrigin.y-size,2*size,2*size);
			//旋转贴图
			
			//若angle>=阈值，响应的X_offset_handWheel或Y_offset_handWheel或z_offset_handWheel改变
			//Debug.Log(handWheelAreaRect);
			float r=Mathf.Abs((Mathf.Abs(rotateAngle)-Mathf.Abs(currRotateAngle)));
			//Debug.Log(Mathf.Abs(rotateAngle)+"  "+Mathf.Abs(currRotateAngle));
			//Debug.Log(rotateAngle+"PPPP"+currRotateAngle);
			//Debug.Log(handWheelDirection+"QQQ");
			 //Debug.Log(r);
			if(r>=deltaAngle)
			{
				//Debug.Log("rotateangle");
		    	//Debug.Log(rotateAngle);
		    	//Debug.Log("currRotateAngle");
		    	//Debug.Log(currRotateAngle);
				//根据handwheeldirection旋转rotateangle度
				float thedeltAngle=rotateAngle-angleOffset;
				//Debug.Log(thedeltAngle+rotatedAngle+"QQ");
				if((thedeltAngle+rotatedAngle)!=0)audio.Play();
			    if(thedeltAngle>=0)
				{
				   GUIUtility.RotateAroundPivot(thedeltAngle+rotatedAngle,handWheelOrigin);	
				   //sumAngle+=thedeltAngle;
					
				}
				
			    else 
			    {
				  GUIUtility.RotateAroundPivot(360+thedeltAngle+rotatedAngle,handWheelOrigin);
				 // sumAngle+=(360+thedeltAngle);
					
			    }	
				//Debug.Log("dfds");
		        GUI.DrawTexture( handWheelPlaneRect,plane);
				//handWheelAreaRect=new Rect(currentMousePos.x -size,currentMousePos.y-size,2*size,2*size);
				lastMousePos=currentMousePos;
				//if(Mathf.Abs((Mathf.Abs(rotateAngle)-Mathf.Abs(currRotateAngle)))>=deltaAngle)
				//{
				/*
				if(handWheelDirection==1)
				{
					
					//handWheelPoint.x=
					//ChangeHandWheelPoint();
					
					if(X_HandWheel)
					{
						X_Offset_HandWheelSet+=Scale_Offset_HandWheel;
						Debug.Log("x+1");
					}
					else if(Y_HandWheel)
						Y_Offset_HandWheelSet+=Scale_Offset_HandWheel;
					else if(Z_HandWheel)
						Z_Offset_HandWheelSet+=Scale_Offset_HandWheel;
				}
				else if(handWheelDirection==2)
				{
					if(X_HandWheel)
					{
						X_Offset_HandWheelSet-=Scale_Offset_HandWheel;
						Debug.Log("x-1");
					}
					else if(Y_HandWheel)
						Y_Offset_HandWheelSet-=Scale_Offset_HandWheel;
					else if(Z_HandWheel)
						Z_Offset_HandWheelSet-=Scale_Offset_HandWheel;
				}
				*/
				//}
			    currRotateAngle=rotateAngle;
				axlePostionChange();
				
				
			}
			else 
			{
				float thedeltAngle=currRotateAngle-angleOffset;
			    if(thedeltAngle>=0)
				{	
				   GUIUtility.RotateAroundPivot(thedeltAngle+rotatedAngle,handWheelOrigin);	
					
				}
			    else 
			    {
			     	GUIUtility.RotateAroundPivot(360+thedeltAngle+rotatedAngle,handWheelOrigin);	
			    }
		       GUI.DrawTexture( handWheelPlaneRect,plane);
			}
			
			
		}
		//添加 BY:WH
		//GUI.Button(new Rect(handWheelOrigin_x-70,handWheelOrigin_y-70,140,140),"圆心");
		/*
		Vector3 mousePos=Input.mousePosition;
		mousePos.x-=(win_rect.x);
		mousePos.y=Screen.height-mousePos.y;
		mousePos.y-=(win_rect.y);
		if(!handWheelAreaRect.Contains(mousePos))
		{
			GUI.DragWindow();
			
		}
		*/
		
		GUI.DragWindow();
		
		//Debug.Log("bbb");

		
		
		
	}

	void FixedUpdate ()
	{
		//Debug.Log(motion_start+"etststst"+come_forth);
		
		if(motion_start)
		{
			//进去
			if(come_forth)
			{
				time_value += Time.fixedDeltaTime;
				left = Mathf.Lerp(win_rect.x, -550f, 2*time_value);
				if(2*time_value > 1f)
				{
					time_value = 0; 
					come_forth = !come_forth;
					motion_start = false;
				}
				//Debug.Log("out~~");
			}
			//出来
			else
			{
				time_value += Time.fixedDeltaTime;
				left = Mathf.Lerp(-550f, 100f, 2*time_value);
				if(2*time_value > 1f)
				{
					time_value = 0; 
					come_forth = !come_forth;
					motion_start = false;
				}
			}
			
			
		}
		
	
		
	}
	/// <summary>
	/// 移动手轮及按键让轴XYZ移动-陈晓威 03-5-16
	/// </summary>
	void axlePostionChange()
	{
		if(!HandWheel_OFF)
		{	audio.Play();	
			//Debug.Log(handWheelDirection+"juuu");
			float distance=0;
			if(handWheelDirection==1)
				distance=Scale_Offset_HandWheel;
			else if(handWheelDirection==2)
				distance=-Scale_Offset_HandWheel;
			
			if(X_HandWheel==true)
			{
				//Debug.Log(MoveControl_script.X_part.localPosition.z+"zz");
				if(MoveControl_script.X_part.localPosition.z+distance<-0.4093075f)
					distance=-0.4093075f;
				else if(MoveControl_script.X_part.localPosition.z+distance>0.3906925f)
					distance=0.3906925f;
			    else
					distance+=MoveControl_script.X_part.localPosition.z;
				
				MoveControl_script.X_part.localPosition=new Vector3(MoveControl_script.X_part.localPosition.x,MoveControl_script.X_part.localPosition.y,distance);
			
			}else if(Y_HandWheel==true)
			{
				if(MoveControl_script.Y_part.localPosition.x+distance<-0.3187108f)
					distance=-0.3187108f;
				else if(MoveControl_script.Y_part.localPosition.x+distance>0.1812892f)
					distance=0.1812892f;
			    else
					distance+=MoveControl_script.Y_part.localPosition.x;
				
				MoveControl_script.Y_part.localPosition=new Vector3(distance,MoveControl_script.Y_part.localPosition.y,MoveControl_script.Y_part.localPosition.z);
			
			}else if(Z_HandWheel==true)
			{
				if(MoveControl_script.Z_part.localPosition.y+distance<1.609089f)
					distance=1.609089f;
				else if(MoveControl_script.Z_part.localPosition.y+distance>2.119089f)
					distance=2.119089f;
			    else
					distance+=MoveControl_script.Z_part.localPosition.y;
				
				MoveControl_script.Z_part.localPosition=new Vector3(MoveControl_script.Z_part.localPosition.x,distance,MoveControl_script.Z_part.localPosition.z);
			
			}
			
		}
	}
	
	public void showWheel()
	{
		if(isShow==false)
		{
			motion_start=true;
			isShow=true;
		}
	}
	public void closeWheel()
	{
		if(isShow==true)
		{
			motion_start=true;
			isShow=false;
		}
	}
	

}
