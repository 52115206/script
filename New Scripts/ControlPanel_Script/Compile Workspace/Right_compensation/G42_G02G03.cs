﻿using UnityEngine;
using System.Collections;

public class G42_G02G03  {

	public void main (ref MotionInfo motion_data1, ref MotionInfo motion_data2) {
		
//		float k1;
		float k2;
		float CE;
		float AE;
		float x0;
		float y0;
		float dis;
		
		float Radius1;
		float Radius2;
		
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
		float R1 = Vector3.Magnitude (motion_data1.DisplayTarget - motion_data1.Center_Point);
		float R2 = Vector3.Magnitude (motion_data2.DisplayTarget - motion_data2.Center_Point);

		
		dis = Mathf.Sqrt (Mathf.Pow (motion_data1.Center_Point.y - motion_data2.Center_Point.y,2) + Mathf.Pow(motion_data1.Center_Point.x - motion_data2.Center_Point.x,2));
		
		if (motion_data1.DisplayTarget.x == motion_data1.Center_Point.x && motion_data1.DisplayTarget.y > motion_data1.Center_Point.y)//k1不存在且方向向上
		{	
			if (motion_data2.Center_Point.x == motion_data1.DisplayTarget.x)
			{
				if(motion_data2.Center_Point.y > motion_data2.DisplayStart.y)
				{
//					motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x;
					motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y - Radius1;
					//Debug.LogError ("调试");
				}
				else
				{
					AE = ((R1 - Radius1)*(R1 - Radius1) - (R2 + Radius2)*(R2 + Radius2) + dis*dis )/(2*dis);
					float CE_Quare = (R1 - Radius1)*(R1 - Radius1) - AE*AE;
					if(CE_Quare < 0)
						CE_Quare = 0;
					CE = Mathf.Sqrt (CE_Quare);
					motion_data1.DisplayTarget.x = motion_data1.Center_Point.x - CE;
					motion_data1.DisplayTarget.y = motion_data1.Center_Point.y + AE;
					//Debug.LogError ("调试");
				}
			}
			else
			{	
				k2 = (motion_data2.Center_Point.y - motion_data1.Center_Point.y)/(motion_data2.Center_Point.x - motion_data1.Center_Point.x);
				AE = ((R1 - Radius1)*(R1 - Radius1) - (R2 + Radius2)*(R2 + Radius2) + dis*dis )/(2*dis);
				float CE_Quare = (R1 - Radius1)*(R1 - Radius1) - AE*AE;
				if(CE_Quare < 0)
					CE_Quare = 0;
				CE = Mathf.Sqrt (CE_Quare);	
				if (k2 == 0)
				{
					motion_data1.DisplayTarget.x = motion_data1.Center_Point.x + AE;
					motion_data1.DisplayTarget.y = motion_data1.Center_Point.y + CE;
					//Debug.LogError ("调试");
				}
				else
				{
					x0 = motion_data1.Center_Point.x + (motion_data2.Center_Point.x - motion_data1.Center_Point.x)*AE/dis;
					y0 = motion_data1.Center_Point.y + (x0 - motion_data1.Center_Point.x)*k2;
					motion_data1.DisplayTarget.x = x0 + CE*k2/Mathf.Sqrt (1 + k2*k2);
					motion_data1.DisplayTarget.y = y0 - CE/Mathf.Sqrt (1 + k2*k2);
					//Debug.LogError ("调试");
				}
			}
		}
		else if (motion_data1.Center_Point.x == motion_data1.DisplayTarget.x && motion_data1.Center_Point.y > motion_data1.DisplayTarget.y)//k1不存在且方向向下
		{
			if (motion_data2.Center_Point.x == motion_data1.DisplayTarget.x)
			{
				if(motion_data2.Center_Point.y < motion_data2.DisplayStart.y)
				{
//					motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x;
					motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y + Radius1;
					//Debug.LogError ("调试");
				}
				else
				{
					AE = ((R1 - Radius1)*(R1 - Radius1) - (R2 + Radius2)*(R2 + Radius2) + dis*dis )/(2*dis);
					float CE_Quare = (R1 - Radius1)*(R1 - Radius1) - AE*AE;
					if(CE_Quare < 0)
						CE_Quare = 0;
					CE = Mathf.Sqrt (CE_Quare);
					motion_data1.DisplayTarget.x = motion_data1.Center_Point.x + CE;
					motion_data1.DisplayTarget.y = motion_data1.Center_Point.y - AE;
					//Debug.LogError ("调试");
				}	
			}
			else
			{
				k2 = (motion_data2.Center_Point.y - motion_data1.Center_Point.y)/(motion_data2.Center_Point.x - motion_data1.Center_Point.x);
				AE = ((R1 - Radius1)*(R1 - Radius1) - (R2 + Radius2)*(R2 + Radius2) + dis*dis )/(2*dis);
				float CE_Quare = (R1 - Radius1)*(R1 - Radius1) - AE*AE;
				if(CE_Quare < 0)
					CE_Quare = 0;
				CE = Mathf.Sqrt (CE_Quare);
				if (k2 == 0)
				{
					motion_data1.DisplayTarget.x = motion_data1.Center_Point.x - AE;
					motion_data1.DisplayTarget.y = motion_data1.Center_Point.y - CE;
					//Debug.LogError ("调试");
				}
				else
				{
					x0 = motion_data1.Center_Point.x + (motion_data2.Center_Point.x - motion_data1.Center_Point.x)*AE/dis;
					y0 = motion_data1.Center_Point.y + (x0 - motion_data1.Center_Point.x)*k2;
					//Debug.Log (x0 + "," + y0);
					motion_data1.DisplayTarget.x = x0 - CE*k2/Mathf.Sqrt (1 + k2*k2);
					motion_data1.DisplayTarget.y = y0 + CE/Mathf.Sqrt (1 + k2*k2);
					//Debug.LogError ("调试");
				}
			}
		}
		else//k1存在
		{
//			k1 = (motion_data1.DisplayTarget.y - motion_data1.Center_Point.y)/(motion_data1.DisplayTarget.x - motion_data1.Center_Point.x);
//			float y2 = k1*(motion_data2.Center_Point.x - motion_data1.DisplayTarget.x) + motion_data1.DisplayTarget.y;
			
//			if (k1 > 0)
//			{
				if(motion_data1.DisplayTarget.x > motion_data1.Center_Point.x)
				{
					AE = ((R1 - Radius1)*(R1 - Radius1) - (R2 + Radius2)*(R2 + Radius2) + dis*dis )/(2*dis);
					float CE_Quare = (R1 - Radius1)*(R1 - Radius1) - AE*AE;
					if(CE_Quare < 0)
						CE_Quare = 0;
					CE = Mathf.Sqrt (CE_Quare);
					float a = motion_data1.Center_Point.x - motion_data2.Center_Point.x;
					if(a > -0.0001f && a < 0.0001f)
					{
						motion_data1.DisplayTarget.x = motion_data1.Center_Point.x + CE;
						motion_data1.DisplayTarget.y = motion_data1.Center_Point.y - AE;
						//Debug.Log ("调试");
					}
					else 
					{
						k2 = (motion_data2.Center_Point.y - motion_data1.Center_Point.y)/(motion_data2.Center_Point.x - motion_data1.Center_Point.x);
						x0 = motion_data1.Center_Point.x + (motion_data2.Center_Point.x - motion_data1.Center_Point.x)*AE/dis;
						y0 = motion_data1.Center_Point.y + (x0 - motion_data1.Center_Point.x)*k2;
						if(motion_data2.Center_Point.x < motion_data1.Center_Point.x)
						{
							motion_data1.DisplayTarget.x = x0 + CE*k2/Mathf.Sqrt (1 + k2*k2);
							motion_data1.DisplayTarget.y = y0 - CE/Mathf.Sqrt (1 + k2*k2);
							Debug.Log ("调试");
						}
						else
						{
							motion_data1.DisplayTarget.x = x0 - CE*k2/Mathf.Sqrt (1 + k2*k2);
							motion_data1.DisplayTarget.y = y0 + CE/Mathf.Sqrt (1 + k2*k2);
							//"调试");
						}
					}
				}
				else
				{
					AE = ((R1 - Radius1)*(R1 - Radius1) - (R2 + Radius2)*(R2 + Radius2) + dis*dis )/(2*dis);
					float CE_Quare = (R1 - Radius1)*(R1 - Radius1) - AE*AE;
					if(CE_Quare < 0)
						CE_Quare = 0;
					CE = Mathf.Sqrt (CE_Quare);
					
					float a = motion_data1.Center_Point.x - motion_data2.Center_Point.x;
					if(a > -0.0001 && a < 0.0001)
					{
						motion_data1.DisplayTarget.x = motion_data1.Center_Point.x - CE;
						motion_data1.DisplayTarget.y = motion_data1.Center_Point.y + AE;
						//Debug.Log ("调试");
					}
					else 
					{
						k2 = (motion_data2.Center_Point.y - motion_data1.Center_Point.y)/(motion_data2.Center_Point.x - motion_data1.Center_Point.x);
						x0 = motion_data1.Center_Point.x + (motion_data2.Center_Point.x - motion_data1.Center_Point.x)*AE/dis;
						y0 = motion_data1.Center_Point.y + (x0 - motion_data1.Center_Point.x)*k2;
						if(motion_data2.Center_Point.x > motion_data1.Center_Point.x)
						{
							motion_data1.DisplayTarget.x = x0 - CE*k2/Mathf.Sqrt (1 + k2*k2);
							motion_data1.DisplayTarget.y = y0 + CE/Mathf.Sqrt (1 + k2*k2);
							Debug.Log ("调试");
						}
						else
						{
							motion_data1.DisplayTarget.x = x0 + CE*k2/Mathf.Sqrt (1 + k2*k2);
							motion_data1.DisplayTarget.y = y0 - CE/Mathf.Sqrt (1 + k2*k2);
							//Debug.Log ("调试");
						}
					}
				}
//			}
//			else//小于等于o
//			{
//				if(motion_data1.DisplayTarget.x > motion_data1.Center_Point.x)
//				{
//					AE = ((R1 - Radius1)*(R1 - Radius1) - (R2 + Radius2)*(R2 + Radius2) + dis*dis )/(2*dis);
//					CE = Mathf.Sqrt ((R1 - Radius1)*(R1 - Radius1) - AE*AE);
//					float a = motion_data1.Center_Point.x - motion_data2.Center_Point.x;
//					if(a > -0.0001 && a < 0.0001)
//					{
//						motion_data1.DisplayTarget.x = motion_data1.Center_Point.x + CE;
//						motion_data1.DisplayTarget.y = motion_data1.Center_Point.y - AE;
//						//Debug.Log ("调试");
//					}
//					else 
//					{
//						k2 = (motion_data2.Center_Point.y - motion_data1.Center_Point.y)/(motion_data2.Center_Point.x - motion_data1.Center_Point.x);
//						x0 = motion_data1.Center_Point.x + (motion_data2.Center_Point.x - motion_data1.Center_Point.x)*AE/dis;
//						y0 = motion_data1.Center_Point.y + (x0 - motion_data1.Center_Point.x)*k2;
//						if(motion_data2.Center_Point.x < motion_data1.Center_Point.x)
//						{
//							Debug.Log (x0 + "," + y0);
//							motion_data1.DisplayTarget.x = x0 + CE*k2/Mathf.Sqrt (1 + k2*k2);
//							motion_data1.DisplayTarget.y = y0 - CE/Mathf.Sqrt (1 + k2*k2);
//							Debug.Log ("调试");
//						}
//						else
//						{
//							motion_data1.DisplayTarget.x = x0 - CE*k2/Mathf.Sqrt (1 + k2*k2);
//							motion_data1.DisplayTarget.y = y0 + CE/Mathf.Sqrt (1 + k2*k2);
//							//Debug.Log ("调试");
//						}
//					}
//
//				}
//				else
//				{
//					AE = ((R1 - Radius1)*(R1 - Radius1) - (R2 + Radius2)*(R2 + Radius2) + dis*dis )/(2*dis);
//					CE = Mathf.Sqrt ((R1 - Radius1)*(R1 - Radius1) - AE*AE);
//					float a = motion_data1.Center_Point.x - motion_data2.Center_Point.x;
//					if(a > -0.0001 && a < 0.0001)
//					{
//						motion_data1.DisplayTarget.x = motion_data1.Center_Point.x - CE;
//						motion_data1.DisplayTarget.y = motion_data1.Center_Point.y + AE;
//						Debug.Log ("调试");
//					}
//					else 
//					{
//						k2 = (motion_data2.Center_Point.y - motion_data1.Center_Point.y)/(motion_data2.Center_Point.x - motion_data1.Center_Point.x);
//						x0 = motion_data1.Center_Point.x + (motion_data2.Center_Point.x - motion_data1.Center_Point.x)*AE/dis;
//						y0 = motion_data1.Center_Point.y + (x0 - motion_data1.Center_Point.x)*k2;
//
//						if(motion_data2.Center_Point.x > motion_data1.Center_Point.x)
//						{
//							motion_data1.DisplayTarget.x = x0 - CE*k2/Mathf.Sqrt (1 + k2*k2);
//							motion_data1.DisplayTarget.y = y0 + CE/Mathf.Sqrt (1 + k2*k2);
//							//"调试");
//						}
//						else
//						{
//							motion_data1.DisplayTarget.x = x0 + CE*k2/Mathf.Sqrt (1 + k2*k2);
//							motion_data1.DisplayTarget.y = y0 - CE/Mathf.Sqrt (1 + k2*k2);
//							Debug.Log ("调试");
//						}
//					}
//				}
//			}
		}
	}
}
