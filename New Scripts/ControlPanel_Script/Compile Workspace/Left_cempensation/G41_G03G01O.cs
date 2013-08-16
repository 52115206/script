﻿using UnityEngine;
using System.Collections;

public class G41_G03G01O  {

	public void main (ref MotionInfo motion_data1,ref MotionInfo motion_data_circle,  ref MotionInfo motion_data2) {
		float k1;
		float k2;
		float Radius1;
		float Radius2;
		float Up_Down = 0;
		//获取半径
		if(motion_data1.D_Value == 0)
			Radius1 = 0;
		else
			Radius1 = LoadRadiusValue.D_Value(motion_data1.D_Value);
		
		if(motion_data2.D_Value == 0)
			Radius2 = 0;
		else
			Radius2 = LoadRadiusValue.D_Value(motion_data2.D_Value);
		
		Radius1 = Mathf.Abs (Radius1);//确保都是正值
		Radius2 = Mathf.Abs (Radius2);
		
		if(motion_data1.DisplayTarget.x == motion_data1.Center_Point.x)//第一段圆弧终点和圆心的直线k1不存在
		{
			if(motion_data1.DisplayTarget.y > motion_data1.Center_Point.y)
				Up_Down = 1;
			else
				Up_Down = -1;
			
//			motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x;
	    	motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y - Radius1*Up_Down;
			
    		if(motion_data2.DisplayTarget.y == motion_data1.DisplayTarget.y && motion_data2.DisplayTarget.x < motion_data1.DisplayStart.x) 
			{
//				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x;
	    		motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y -  Radius2;
			}
			else if(motion_data2.DisplayTarget.y == motion_data1.DisplayTarget.y && motion_data2.DisplayTarget.x > motion_data1.DisplayStart.x)
			{
				motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
				motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2;
				Debug.Log ("调试");
			}
			else
			{	
				if(motion_data2.DisplayTarget.x == motion_data2.DisplayStart.x)
				{
					motion_data_circle.DisplayTarget.x= motion_data2.DisplayStart.x -  Radius2*Up_Down;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
					//Debug.Log ("调试");
				}
				else
				{
					k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
					
		    		if(motion_data2.DisplayTarget.x > motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
		    			motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y +  Radius2/Mathf.Sqrt (1 + k2*k2);
		    			Debug.Log ("调试");	
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
		    			motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y -  Radius2/Mathf.Sqrt (1 + k2*k2);
		    			//Debug.Log ("调试");	
					}
				}
			}
		}
		else if(motion_data1.DisplayTarget.y == motion_data1.Center_Point.y)//第一段圆弧半径所在的直线的斜率为零
		{
			if(motion_data1.DisplayTarget.x < motion_data1.Center_Point.x)
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x +  Radius1;
//		    	motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y ;
	    		Debug.Log ("调试");	
				
				if(motion_data2.DisplayTarget.x == motion_data2.DisplayStart.x)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius2;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
					Debug.Log ("调试");
				}
				else
				{
					k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y -  Radius2/Mathf.Sqrt (1 + k2*k2);
					Debug.Log ("调试");
				}
			}
			else
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x -  Radius1;
//		    	motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y ;
	    			
				if(motion_data2.DisplayTarget.x == motion_data2.DisplayStart.x)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius2;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
					Debug.Log ("调试");
				}
				else
				{
					k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y +  Radius2/Mathf.Sqrt (1 + k2*k2);
					Debug.Log ("调试");
				}
			}
		}
		else//第一段圆弧终点处半径所在的直线斜率不为零且存在
		{
			k1 = (motion_data1.DisplayTarget.y - motion_data1.Center_Point.y)/(motion_data1.DisplayTarget.x - motion_data1.Center_Point.x);

//			if(k1 > 0)
//			{
				if(motion_data1.DisplayTarget.x > motion_data1.Center_Point.x)//偏向右象限
				{
					motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x -  Radius1/Mathf.Sqrt (1 + k1*k1);
					motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y -  Radius1*k1/Mathf.Sqrt (1 + k1*k1);
					//Debug.Log ("调试");
					if(motion_data2.DisplayStart.x == motion_data2.DisplayTarget.x)
					{
						if(motion_data2.DisplayTarget.y > motion_data2.DisplayStart.y)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius2;
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
							//Debug.Log ("调试");
						}
						else
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius2;
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
							Debug.Log ("调试");
						}	
					}
					else
					{
						k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
						if(motion_data2.DisplayStart.x < motion_data2.DisplayTarget.x)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y +  Radius2/Mathf.Sqrt (1 + k2*k2);
							//Debug.Log ("调试");
						}
						else
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y -  Radius2/Mathf.Sqrt (1 + k2*k2);
							//Debug.Log ("调试");
						}
					}

				}
				else //偏向左象限
				{
					motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x +  Radius1/Mathf.Sqrt (1 + k1*k1);
					motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y +  Radius1*k1/Mathf.Sqrt (1 + k1*k1);
					
					if(motion_data2.DisplayStart.x == motion_data2.DisplayTarget.x)
					{
						if(motion_data2.DisplayTarget.y > motion_data2.DisplayStart.y)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius2;
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
							//Debug.Log ("调试");
						}
						else
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius2;
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
							Debug.Log ("调试");
						}
					}
					else if(motion_data2.DisplayTarget.x > motion_data2.DisplayStart.x)
					{
						k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y +  Radius2/Mathf.Sqrt (1 + k2*k2);
						Debug.Log ("调试");
					}
					else
					{
						k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y -  Radius2/Mathf.Sqrt (1 + k2*k2);
						//"调试");
					}
				}
//			}
//			else
//			{
//				if(motion_data1.DisplayTarget.x > motion_data1.Center_Point.x)//偏向右侧象限
//				{
//					motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x -  Radius1/Mathf.Sqrt (1 + k1*k1);
//					motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y -  Radius1*k1/Mathf.Sqrt (1 + k1*k1);
//					//Debug.Log ("调试");
//					if(motion_data2.DisplayStart.x == motion_data2.DisplayTarget.x)
//					{
//						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius2;
//						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
//						//"调试");
//					}
//					else 
//					{
//						k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
//						if(motion_data2.DisplayStart.x < motion_data2.DisplayTarget.x)
//						{
//							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
//							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y +  Radius2/Mathf.Sqrt (1 + k2*k2);
//						}
//						else
//						{
//							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
//							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y -  Radius2/Mathf.Sqrt (1 + k2*k2);
//							//Debug.Log ("调试");
//						}
//					}
//				}
//				else//偏向左侧象限
//				{
//					motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x +  Radius1/Mathf.Sqrt (1 + k1*k1);
//					motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y +  Radius1*k1/Mathf.Sqrt (1 + k1*k1);
//					//Debug.Log ("调试");
//				
//					if(motion_data2.DisplayStart.x == motion_data2.DisplayTarget.x)
//					{
//						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius2;
//						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
//						Debug.Log ("调试");
//					}
//					else if(motion_data2.DisplayTarget.x > motion_data2.DisplayStart.x)
//					{
//						k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
//						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
//						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y +  Radius2/Mathf.Sqrt (1 + k2*k2);
//						Debug.Log ("调试");
//					}
//					else
//					{
//						k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
//						//Debug.Log ("调试");
//						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius2*k2/Mathf.Sqrt (1 + k2*k2);
//						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y -  Radius2/Mathf.Sqrt (1 + k2*k2);
//					}
//				}
//			}
		}
	}
}
