﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;//内容--增加文件IO功能，姓名--刘旋，时间--2013-3-20
using System.Text.RegularExpressions;

public class MDIEditModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	SoftkeyModule Softkey_Script;
	NCCodeFormat NCCodeFormat_Script;
	MDIInputModule MDIInput_Script;
	
	public float btn_width = 48;
	public float btn_height = 48;
	public float l_x=603;
	public float l_y=34;
	public float left_x=57;
	public float left_y=53;
	// Use this for initialization
	void Awake()
	{
		Main = gameObject.GetComponent<ControlPanel>();
	}
	
	void Start () {
		
		CooSystem_script = gameObject.GetComponent<CooSystem>();
		Softkey_Script = gameObject.GetComponent<SoftkeyModule>();
		NCCodeFormat_Script=gameObject.GetComponent<NCCodeFormat>();
		MDIInput_Script = gameObject.GetComponent<MDIInputModule>();
	}
	
	public void Edit ()
	{
//		GUI.color = Color.cyan;
		if (GUI.Button(new Rect((l_x+4*left_x)/1000f*Main.width, (l_y+4*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.CAN))            
		{
			if(Main.ScreenPower)
			{
				if(Main.InputText != "")
				{
					char[] TempCharArray = Main.InputText.ToCharArray();
					string TempStr = "";
					for(int i = 0; i < TempCharArray.Length - 1; i++)
					{
						TempStr += TempCharArray[i];
					}
					Main.InputText = TempStr;
					Main.CursorText.text = Main.InputText;
					Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
					if(Main.InputText == "")
					{
						MDIInput_Script.isXSelected = false;
						MDIInput_Script.isYSelected = false;
						MDIInput_Script.isZSelected = false;
					}
				}
			}
		}

		if (GUI.Button(new Rect((l_x+3*left_x)/1000f*Main.width, (l_y+5*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.ALTER))           
		{
			if(Main.ScreenPower)
			{
				if(Main.ProgMenu)
				{
					if(Main.ProgProtect)
					{
						Main.ProgProtectWarn = true;
						Main.WarnningMessageCreate("WRITE PROTECT");
					}
					else
					{
						Main.ProgProtectWarn = false;
						Main.WarnningClear();
						if(Main.ProgEDIT|| Main.ProgMDI)
						{
							if(Main.InputText != "")
							{
								AlterCode();	
								Main.beModifed = true;
							}	
						}
					}
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+4*left_x)/1000f*Main.width, (l_y+5*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.INSERT))             
		{
			if(Main.ScreenPower)
			{
				if(Main.ProgMenu)
				{
					if(Main.ProgProtect)
					{
						Main.ProgProtectWarn = true;
						Main.WarnningMessageCreate("WRITE PROTECT");
					}
					else
					{
						Main.ProgProtectWarn = false;
						Main.WarnningClear();
						if(Main.ProgEDIT|| Main.ProgMDI)
						{
							if(Main.InputText != "")
							{
								InsertCode();	
								Main.beModifed = true;
							}	
						}
					}
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+5*left_x)/1000f*Main.width, (l_y+5*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.DELETE))           
		{
			if(Main.ScreenPower)
			{
				if(Main.ProgMenu)
				{
					if(Main.ProgProtect)
					{
						Main.ProgProtectWarn = true;
						Main.WarnningMessageCreate("WRITE PROTECT");
					}
					else
					{
						Main.ProgProtectWarn = false;
						Main.WarnningClear();
						if(Main.ProgEDIT|| Main.ProgMDI)	
						{
							if(Main.ProgMDI)
							{
								if(Main.SelectStart == 0 || Main.SelectStart == 1)
									return;
							}
							DeleteCode();	
							Main.beModifed = true;
						}
					}
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x)/1000f*Main.width, (l_y+6*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.PAGEu))             
		{
			if(Main.ScreenPower)
				PageUp();
		}
		
		if (GUI.Button(new Rect((l_x)/1000f*Main.width, (l_y+7*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.PAGEd))           
		{
			if(Main.ScreenPower)
				PageDown();
		}
//		GUI.color = Color.white;
		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, (l_y+6.5f*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.LEFT))             
		{
			if(Main.ScreenPower)
			{
				if(Main.ProgMenu)
				{
					if(Main.ProgEDIT||Main.ProgMDI)
					{
						//编辑程序时
						if(Main.ProgEDITProg)
						{
							EditProgLeft();
						}
					}
				}
//				if(Main.ProgAUTO)
//				{
//					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, false);
//				}
				if(Main.SettingMenu)
				{
					//刀偏界面左移
					if(Main.OffSetTool)
					{
						CooSystem_script.tool_left();
					}
					//坐标系界面光标左移
					if(Main.OffSetCoo)
					{
						CooSystem_script.Left();
					}
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, (l_y+6*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.UP))             
		{
			if(Main.ScreenPower)
			{
				UpButton();
				if(Main.ProgMDI)
				{
					if(Main.SelectStart == 0)
					{
						EditProgRight();
					}
				}
			}
		}
		
		if (GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, (l_y+7*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.DOWN))           
		{
			if(Main.ScreenPower)
				DownButton();
		}
		
		if (GUI.Button(new Rect((l_x+3*left_x)/1000f*Main.width, (l_y+6.5f*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.RIGHT))             
		{
			if(Main.ScreenPower)
			{
				if(Main.ProgMenu)
				{
					if(Main.ProgEDIT||Main.ProgMDI)
					{
						//编辑程序时
						if(Main.ProgEDITProg)
						{
							EditProgRight();
						}
					}
//					if(Main.ProgAUTO)
//					{
//						Main.AutoDisplayFindRows(Main.autoSelecedProgRow,true);
//					}
				}
				
				if(Main.SettingMenu)
				{
					//刀偏界面右移
					if(Main.OffSetTool)
					{
						CooSystem_script.tool_right();
					}
					//坐标系界面光标右移
					if(Main.OffSetCoo)
					{
						CooSystem_script.Right();
					}
				}
			}
		}
	}
	
	
	/// <summary>
	/// 重新编写的AlterCode()，实现代码的替换 董帅 2013-4-2
	/// </summary>
	void AlterCode() 
	{
	   if(Main.SelectStart==0)
			Main.isSelecFirst=true;
	   else
			Main.isSelecFirst=false;
	   DeleteCode();
	   InsertCode();
	}
	
	/// <summary>
	/// 手动添加新的程序.
	/// </summary>
	void InsertNewProgram(string prog_name)
	{
		string temp_name = "";
		//Regular Expression: 判断输入的是否为数字字符，且大小在(0,10000)之间
		Regex name_Reg = new Regex(@"^\d{1,4}$");
		if(name_Reg.IsMatch(prog_name))
		{//3 level
			int name_num = 0;
			try
			{
				name_num = Convert.ToInt32(prog_name);
			}
			catch
			{
				Main.WarnningMessageCreate("程序名格式错误！");
				return;
			}
//			Debug.Log(name_num);
			if(name_num <= 0 || name_num >= 9000)
			{
				Main.WarnningMessageCreate("程序命名超出范围！");
				return;
			}
			if(name_num > 0 && name_num < 10)
				temp_name = "O000" + name_num.ToString();
			else if(name_num >= 10 && name_num < 100 )
				temp_name = "O00" + name_num.ToString();
			else if(name_num >= 100 && name_num < 1000)
				temp_name = "O0" + name_num.ToString();
			else
				temp_name = "O" + name_num.ToString();
			//插入新的程序
			if(Main.FileNameList.IndexOf(temp_name) == -1)
			{
				Main.CodeForAll.Clear();
				Main.CodeForAll.Add(temp_name);
				Main.CodeForAll.Add(";");
				Main.ProgramNum = name_num;
				Main.Progname_Backup = Main.ProgramNum;
				Main.ProgEDITCusorV=0;
				Main.ProgEDITCusorH=0;
				Main.StartRow=0;
				Main.EndRow=SystemArguments.EditLineNumber;
				Main.SelectStart=0;
				Main.SelectEnd=0;
			}
			Main.InputText = "";
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
			Main.WarnningClear();
		}
		else
		{
			Main.WarnningMessageCreate("程序名格式错误！");
		}
	}
	
	/// <summary>
	/// 重新编写的InsertCode ()，实现代码的添加 陈晓威 2013-3-31
	/// </summary>
	void InsertCode ()
	{
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.CodeForAll.Count == 0)
					{
						if(Main.InputText.StartsWith("O"))
						{
							InsertNewProgram(Main.InputText.Trim('O'));
							return;
						}
						else
						{
							Main.InputText = "";
							Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
							Main.WarnningMessageCreate("程序未登记，请先登记！");
						}
						return;
					}
					else
					{
						if(Main.InputText.StartsWith("O"))
						{
							InsertNewProgram(Main.InputText.Trim('O'));
							return;
						}
					}
				}
			}
		}
		
		//待插入的字符串
		int row_begin = 0;
		int row_end;
		int row_length;
		int append_pos = 0;  //插入处的代码序号
		int semicolon_flag = 0;  //程度的代码字符最后是否带有";"，0代表有，1代表没有
		//Debug.Log("V:"+Main.ProgEDITCusorV);
		//当程序只为"_"时，删除这个("_"为下划线为了显示光标)
		if(Main.CodeForAll.Count == 1 && Main.CodeForAll[0] == ";")
		{
		    Main.CodeForAll.RemoveAt(0);
		    Main.TotalCodeNum--;
		}
		int before_codenum = Main.CodeForAll.Count;  //记录未插入前的代码长度
		List<string> appendlist = NCCodeFormat_Script.CodeFormat(Main.InputText);
		//如果是插入;因为会被格式方法CodeFormat去除，这里直接补上;
		if(Main.InputText.Trim() == ";") 
			appendlist.Add(";");
//		Debug.Log("V" + Main.ProgEDITCusorV);
		if(Main.CodeForAll.Count == 0 || Main.isSelecFirst)  //代码为空时或者从最开始被选中添加则pos=0,否则为selectstart+1
			append_pos = 0;
		else if(Main.ProgEDITCusorV >= 0 && Main.CodeForAll.Count != 0)
			append_pos = Main.SelectStart + 1;
		string editstr = Main.InputText;
		//如果插入的代码最后没有;，则删除
		if(editstr.Substring(editstr.Length - 1) != ";")
		{
		    appendlist.RemoveAt(appendlist.Count - 1);  //因为格式方法CodeFormat会在代码段最后自动加上";"
		    semicolon_flag = 1;
		}
		//插入代码
		foreach(string subappendstr in appendlist)
		{
		    if(append_pos > Main.CodeForAll.Count - 1)
		        Main.CodeForAll.Add(subappendstr);
		    else
		        Main.CodeForAll.Insert(append_pos, subappendstr);
		    append_pos++;
		}
		Main.TotalCodeNum = Main.CodeForAll.Count;
		//在只有;时候插入处理为在;前插入
		if(before_codenum==0)
		{
			Main.CodeForAll.Add(";");
			Main.TotalCodeNum=Main.CodeForAll.Count;
		}
		if(Main.CodeForAll[Main.CodeForAll.Count - 1] != ";")
		{
			Main.CodeForAll.Add(";");
			Main.TotalCodeNum=Main.CodeForAll.Count;
		}
		Softkey_Script.calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
		//EditProgRight();
		//有分号
		if(semicolon_flag == 0)
		{
			while(Main.CodeForAll[Main.SelectStart] != ";")
				EditProgRight();
		}
		EditProgRight(); //光标往右前进一格
		Main.InputText = "";
		//插入完毕后光标移到最左边
		Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
	}
	
	/// <summary>
	/// 重新编写的DeleteCode ()，实现代码的删除 陈晓威 2013-4-1
	/// </summary>
	public void DeleteCode()
	{
		int SelStart = Main.SelectStart > Main.SelectEnd? Main.SelectEnd:Main.SelectStart;
		int SelEnd = Main.SelectStart > Main.SelectEnd? Main.SelectStart:Main.SelectEnd;
		Main.CodeForAll.RemoveRange(SelStart, SelEnd - SelStart + 1);
		Main.TotalCodeNum = Main.CodeForAll.Count;
		if(Main.SelectStart == Main.SelectEnd)  //只删除一个代码字符
		{
			if(Main.ProgEDITCusorH > 0)
			{
				--Main.ProgEDITCusorH;
			}
			else if(Main.ProgEDITCusorV > 0)
			{
				int row_begin = 0;
                int row_end = 0;
                int row_length = 0;
                row_begin = Main.SeparatePosStart[Main.ProgEDITCusorV - 1];	                 
                row_end = Main.SeparatePosEnd[Main.ProgEDITCusorV - 1];		                 
                row_length = row_end - row_begin;       
				--Main.ProgEDITCusorV;
				Main.ProgEDITCusorH = row_length - 1;
			}
			else
			{
			    Main.ProgEDITCusorV = 0;
				Main.ProgEDITCusorH = 0;
			}
		}
		else  //删除一串选择的代码字符
		{
			if(Main.ProgEDITCusorH > 0)
				--Main.ProgEDITCusorH;
			else if(Main.ProgEDITCusorV > 0)
			{
				int row_begin = 0;
				int row_end = 0;
				int row_length = 0;
				row_begin = Main.SeparatePosStart[Main.ProgEDITCusorV - 1];	                 
                row_end = Main.SeparatePosEnd[Main.ProgEDITCusorV - 1];						
				row_length = row_end - row_begin;
				--Main.ProgEDITCusorV;
				Main.ProgEDITCusorH = row_length - 1;
			}
			else						
			{
			    Main.ProgEDITCusorV = 0;
				Main.ProgEDITCusorH = 0;
			}
		}	
		
		if(Main.TotalCodeNum==0)
		{
			Main.CodeForAll.Add(";");
			Main.TotalCodeNum = Main.CodeForAll.Count;
			Main.ProgEDITCusorV=0;
			Main.ProgEDITCusorH=0;
			Main.SelectStart=0;
			Main.SelectEnd=0;
			Main.StartRow=0;
			Main.EndRow=SystemArguments.EditLineNumber;
		}
		else
		{
			if(SelStart > 0)
				Main.SelectStart = SelStart - 1;
			else
				Main.SelectStart = 0;
			Softkey_Script.calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
			if(Main.StartRow > Main.ProgEDITCusorV)
			{
				Main.StartRow = Main.ProgEDITCusorV;
				Main.EndRow = Main.StartRow+SystemArguments.EditLineNumber;
			}
		   	Main.SelectEnd = Main.SelectStart;
		}
	   	Main.ProgEDITFlip = 2;
	   	Main.IsSelect = false;
	}
	
	
	
	/// <summary>
	/// 向上翻页，程序翻页部分待修改
	/// </summary>
	void PageUp () 
	{	
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT || Main.ProgMDI)
			{
				//程序翻页
				if(Main.ProgEDITProg)
				{
					if(Main.StartRow > 0)	 
				   	{	   	
						if (Main.ProgEDITFlip==5)
				   		{
					      	//取消全选择 
							Main.IsSelect = false;
							Main.ProgEDITFlip = 2;
						}
						if(Main.StartRow >= SystemArguments.EditLineNumber)
						{
						    Main.StartRow -= SystemArguments.EditLineNumber;
							Main.EndRow = Main.StartRow + SystemArguments.EditLineNumber;
							Main.ProgEDITCusorV = Main.StartRow;
							Main.ProgEDITCusorH = 0;	
						    if(Main.StartRow > 0) 
							    Main.SelectStart = Main.SeparatePosStart[Main.StartRow];
						    else
								Main.SelectStart = 0;
						    Main.SelectEnd = Main.SelectStart;
						}
						else
						{
							Main.StartRow = 0;
							Main.EndRow = SystemArguments.EditLineNumber;
							Main.ProgEDITCusorV = 0;
							Main.ProgEDITCusorH = 0;
							Main.SelectStart = 0;
						    Main.SelectEnd = Main.SelectStart;
						}
	                }
	                else
					{
//		                 Debug.Log("This is the first page!!!"); 
					}

				}
				//列表翻页
				if(Main.ProgEDITList)
				{
					if(Main.CodeName[0] != "")
					{
						if(Main.ProgEDITFlip == 0)
							Main.ProgEDITFlip = 1;
						int name_index = Main.FileNameList.IndexOf(Main.CodeName[0]);
						if(name_index >= 0)
						{//1 level
							int current_page = name_index / 8;
							//下面还有页数则翻页，无则不翻页
							if(current_page > 0)
							{
								current_page--;
								name_index = current_page * 8 +1;
								string[] TempNameArray = new string[8];
								int[] TempSizeArray = new int[8]; 
								string[] TempDateArray = new string[8];
								for(int i = 0; i < 8; i++)
								{
									TempNameArray[i] = "";
									TempSizeArray[i] = 0;
									TempDateArray[i] = "";
								}
								int final_index = name_index + 7;
								if(final_index > Main.TotalListNum)
									final_index = Main.TotalListNum;
								int temp_index = -1;
								for(int i = name_index - 1; i < final_index; i++)
								{
									temp_index++;
									TempNameArray[temp_index] = Main.FileNameList[i];
									TempSizeArray[temp_index] = Main.FileSizeList[i];
									TempDateArray[temp_index] = Main.FileDateList[i];
								}
								for(int i = 0; i < 8; i++)
								{
									Main.CodeName[i] = TempNameArray[i];
									Main.CodeSize[i] = TempSizeArray[i];
									Main.UpdateDate[i] = TempDateArray[i];
								}
								Softkey_Script.Locate_At_Position(Main.RealListNum);
							}
						}//1 level
					}
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			//刀偏向上翻页
			if(Main.OffSetTool)
			{
				if(Main.ToolOffSetPage_num>0)
					CooSystem_script.Tool_pageup();
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffCooFirstPage == false)
				{
					Main.OffCooFirstPage = true;
					CooSystem_script.PageUp();
				}
			}
		}
	}
	
	/// <summary>
	/// 向上翻页，程序翻页部分待修改
	/// </summary>
	void PageDown () {
		
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT|| Main.ProgMDI)
			{
				//程序界面向下翻页
				if(Main.ProgEDITProg)
				{
					if (Main.ProgEDITFlip==5)
				   	{
					    //取消全选择 
						Main.IsSelect = false;
						Main.ProgEDITFlip = 2;
					}
					if(Main.EndRow < Main.total_row)
					{
					    Main.StartRow = Main.EndRow;
						Main.EndRow += SystemArguments.EditLineNumber;
						Main.ProgEDITCusorV = Main.StartRow;
						Main.ProgEDITCusorH = 0;
						Main.SelectStart = Main.SeparatePosStart[Main.StartRow];
						Main.SelectEnd = Main.SelectStart;
					}
				}
				//列表界面向下翻页
				if(Main.ProgEDITList)
				{
					if(Main.CodeName[0] != "")
					{
						if(Main.ProgEDITFlip == 0)
							Main.ProgEDITFlip = 1;
						int name_index = Main.FileNameList.IndexOf(Main.CodeName[0]);
						if(name_index >= 0)
						{//2 level
							int total_page = (Main.TotalListNum - 1) / 8;
							int current_page = name_index / 8;
							//下面还有页数则翻页，无则不翻页
							if(total_page > current_page)
							{
								current_page++;
								name_index = current_page * 8 +1;
								string[] TempNameArray = new string[8];
								int[] TempSizeArray = new int[8]; 
								string[] TempDateArray = new string[8];
								for(int i = 0; i < 8; i++)
								{
									TempNameArray[i] = "";
									TempSizeArray[i] = 0;
									TempDateArray[i] = "";
								}
								int final_index = name_index + 7;
								if(final_index > Main.TotalListNum)
									final_index = Main.TotalListNum;
								int temp_index = -1;
								for(int i = name_index - 1; i < final_index; i++)
								{
									temp_index++;
									TempNameArray[temp_index] = Main.FileNameList[i];
									TempSizeArray[temp_index] = Main.FileSizeList[i];
									TempDateArray[temp_index] = Main.FileDateList[i];
								}
								for(int i = 0; i < 8; i++)
								{
									Main.CodeName[i] = TempNameArray[i];
									Main.CodeSize[i] = TempSizeArray[i];
									Main.UpdateDate[i] = TempDateArray[i];
								}
								Softkey_Script.Locate_At_Position(Main.RealListNum);
							}
						}//2 level
					}
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				//刀偏向下翻页
				if(Main.ToolOffSetPage_num < 49)
					CooSystem_script.Tool_pagedown();
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffCooFirstPage)
				{
					Main.OffCooFirstPage = false;
					CooSystem_script.PageDown();
				}
			}
		}
	}
	

	
	/// <summary>
	/// 光标上移按钮
	/// </summary>
	void UpButton () {
		
		if(Main.ProgMenu)
		{
//			if(Main.ProgAUTO||Main.ProgDNC||(Main.ProgMDI&&(Main.ProgMDIFlip==1))||Main.ProgHAN||Main.ProgJOG||Main.ProgREF)
//			{
//				if(Main.autoSelecedProgRow > 0)
//					Main.autoSelecedProgRow--;
//				Main.AutoDisplayFindRows(Main.autoSelecedProgRow,Main.autoDisplayNormal);
//			}
			
			
			if(Main.ProgEDIT|| Main.ProgMDI)
			{
				//编辑程序时
				if(Main.ProgEDITProg)
				{
					bool NumInNine = false;
					EditProgUp();
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			//刀偏界面上移
			if(Main.OffSetTool)
			{
				CooSystem_script.tool_up();
			}
			//设定界面上移
			if(Main.OffSetSetting)
			{
				CooSystem_script.argu_up();
			}
			if(Main.OffSetCoo)
			{
				CooSystem_script.Up();
			}
		}
	}
	
	/// <summary>
	/// 光标下移按钮
	/// </summary>
	void DownButton () {
		
		if(Main.ProgMenu)
		{
//			if(Main.ProgAUTO||Main.ProgDNC||(Main.ProgMDI&&(Main.ProgMDIFlip==1))||Main.ProgHAN||Main.ProgJOG||Main.ProgREF)
//			{
//				if(Main.AutoStopRow < Main.auto_total_row - 1)
//					Main.autoSelecedProgRow++;
//				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, Main.autoDisplayNormal);
//			}
			if(Main.ProgEDIT|| Main.ProgMDI)
			{
				//编辑程序时
				//分两种情况：如果输入以“O”开始，则执行“O检索”功能；否则执行光标下移功能.
				if(Main.ProgEDITProg)
				{
					if(Main.InputText.StartsWith("O"))
					{
						Softkey_Script.O_Search();
						Softkey_Script.Locate_At_Position(Main.RealListNum);
					}
					else
					{
						bool NumInNine = false;
						//Debug.Log("hello");
						EditProgDown();
					}
				}
				//O检索时
				//分为两种情况：光标选择模式开或者关
				//当光标模式关时，如果有输入，且以"O"开始，则进行相应的O检索操作；
				//Todo: 当光标模式开时，上下移动光标；
				if(Main.ProgEDITList)
				{
					if(Main.InputText.StartsWith("O"))
					{
						Softkey_Script.O_Search();
						Softkey_Script.Locate_At_Position(Main.RealListNum);
					}	
				}
			}
			
		}
		
		if(Main.SettingMenu)
		{
			//刀偏界面下移
			if(Main.OffSetTool)
			{
				CooSystem_script.tool_down();
			}
			//设定界面下移
			if(Main.OffSetSetting)
			{
				CooSystem_script.argu_down();
			}

			if(Main.OffSetCoo)
			{
				CooSystem_script.Down();
			}	
		}
	}

	//光标右移
	public void EditProgRight () 
	{
		int row_begin = 0;  //这一行开始字符序号
		int row_end = 0;  //下一行开始字符序号
		int row_length = 0;  //这一行字符数
		row_begin = Main.SeparatePosStart[Main.ProgEDITCusorV];
		row_end = Main.SeparatePosEnd[Main.ProgEDITCusorV];
		row_length = row_end - row_begin;
		if (Main.ProgEDITFlip==5)
		{
			//取消全选择 
			Main.IsSelect = false;
			Main.ProgEDITFlip = 2;
		}
		if(Main.ProgEDITCusorH < row_length - 1)  //光标在这一行末尾之前
		{
		    ++Main.ProgEDITCusorH;
			if(Main.IsSelect)
			    ++Main.SelectEnd;
			else
			{
				Main.SelectStart = Main.SelectEnd;   
				++Main.SelectStart;
				++Main.SelectEnd;
			}
		}
		else  //光标在这一行末尾
		{
			if(Main.SelectEnd < Main.TotalCodeNum - 1) //此行以下依然有代码字符
			{
			    ++Main.ProgEDITCusorV;
				if(Main.ProgEDITCusorV == Main.EndRow)  //TobeModified  此为页面向上跳一行
				{
				    ++Main.EndRow;
				    ++Main.StartRow;
				}
				Main.ProgEDITCusorH = 0;
				if(Main.IsSelect)
			       ++Main.SelectEnd;
				else
				{
					Main.SelectStart = Main.SelectEnd;  
				   ++Main.SelectStart;
				   ++Main.SelectEnd;
				}
			}
			else  //此为最后一行
			{
//			    Debug.Log("This is the end!!!");
			}
		}	
	}
	
	//光标左移
	void EditProgLeft () 
	{
		if(Main.ProgMDI)
		{
			if(Main.SelectStart == 1)
				return;
		}
		
		if (Main.ProgEDITFlip==5)
		{
			//取消全选择 
			Main.IsSelect = false;
			Main.ProgEDITFlip = 2;
		}
	    int row_begin = 0;
		int row_end = 0;
		int row_length = 0;
		if(Main.ProgEDITCusorV > 0)
			row_begin = Main.SeparatePosStart[Main.ProgEDITCusorV - 1];
		else
			row_begin = 0;
		if(Main.ProgEDITCusorV > 0)
		    row_end = Main.SeparatePosEnd[Main.ProgEDITCusorV - 1];
		else
			row_end = Main.SeparatePosEnd[0];
		
		row_length = row_end - row_begin;
        //ProgEDITCusorH，ProgEDITCusorV均从0开始记
		if(Main.ProgEDITCusorH > 0)  //光标在第一个代码字符之前
		{
		    --Main.ProgEDITCusorH;
			if(Main.IsSelect)
			       --Main.SelectEnd;
			else
			{
		        Main.SelectStart = Main.SelectEnd;   
				--Main.SelectStart;
				--Main.SelectEnd;
			}
		}
		else  //光标在第一个代码字符处
		{
			if(Main.ProgEDITCusorV > 0)  //光标不在第一行
			{
			    --Main.ProgEDITCusorV;
				if(Main.StartRow > 0 && Main.ProgEDITCusorV < Main.StartRow)   //TobeModified  此为页面向下跳一行
				{
				    --Main.StartRow;
				    --Main.EndRow;
				}
				Main.ProgEDITCusorH = row_length - 1;
				if(Main.IsSelect)
			       --Main.SelectEnd;
				else
				{
				   Main.SelectStart = Main.SelectEnd;
				   --Main.SelectStart;
				   --Main.SelectEnd;
				}
			}
			else  //光标位于第一行
			{
//			    Debug.Log("This is the start!!!");
			}
		}	
	}
	
	//光标下移
	void EditProgDown () 
	{
		if (Main.ProgEDITFlip==5)
		{
			//取消全选择 
			Main.IsSelect = false;
			Main.ProgEDITFlip = 2;
		}
		int row_begin = 0;
		int row_end = 0;
		int row_length = 0;
		if(Main.SeparatePosEnd[Main.ProgEDITCusorV] - 1 < Main.CodeForAll.Count - 1)  //此行不是最后一行
		{
		   	row_begin = Main.SeparatePosStart[Main.ProgEDITCusorV + 1];
		   	row_end = Main.SeparatePosEnd[Main.ProgEDITCusorV+1];
		   	//计算出下一行的单词个数
		   	row_length = row_end - row_begin;
		  	if(Main.ProgEDITCusorV == (Main.EndRow - 1))   //TobeModified  此为页面向上跳一行
			{
		        ++Main.StartRow;
				++Main.EndRow;	
			}
		   	if(Main.ProgEDITCusorH < row_length)
			{
		    	++Main.ProgEDITCusorV;
			}
		   	else
		   	{
				++Main.ProgEDITCusorV;
				Main.ProgEDITCusorH = row_length - 1;
		   	}
		   	if(Main.IsSelect)
				Main.SelectEnd = Main.SeparatePosEnd[Main.ProgEDITCusorV - 1] + Main.ProgEDITCusorH;
		   	else
		   	{
				Main.SelectStart = Main.SeparatePosEnd[Main.ProgEDITCusorV - 1] + Main.ProgEDITCusorH;
		        Main.SelectEnd = Main.SeparatePosEnd[Main.ProgEDITCusorV - 1] + Main.ProgEDITCusorH;
		   	}
		}
		else //此行不是最后一行此行为最后一行
		{
//		   Debug.Log("This is the last line!!!"); 	
		}	
	}
	
	//光标上移
	void EditProgUp () 
	{
		if (Main.ProgEDITFlip==5)
		{
			//取消全选择 
			Main.IsSelect = false;
			Main.ProgEDITFlip = 2;
		}
		int row_begin;
		int row_end;
		int row_length;
		bool IsReverse = false;
		if(Main.ProgEDITCusorV > 0)
		    row_begin = Main.SeparatePosStart[Main.ProgEDITCusorV - 1];
		else
		    row_begin = 0;
		if(Main.ProgEDITCusorV > 0)
		    row_end = Main.SeparatePosEnd[Main.ProgEDITCusorV - 1];
		else
		    row_end = Main.SeparatePosEnd[0];
		row_length = row_end - row_begin;
		
		if(Main.ProgEDITCusorV > 0)  //不是第一行
		{
		    if(Main.ProgEDITCusorV == Main.StartRow)   //TobeModified  此为页面向下跳一行
		    {
		        if(Main.StartRow > 0)
		        {
		            --Main.StartRow;
		            --Main.EndRow;
		        }
		    }
		    if(Main.ProgEDITCusorH < row_length)
		        --Main.ProgEDITCusorV;
		    else
		    {
		        --Main.ProgEDITCusorV;
		        Main.ProgEDITCusorH = row_length - 1;
		    }
			
		    if(Main.ProgEDITCusorV > 0)
		    {
		        if(Main.IsSelect)
				{
					Main.SelectEnd = Main.SeparatePosEnd[Main.ProgEDITCusorV -  1] + Main.ProgEDITCusorH;
				}
		        else
		        {
		            Main.SelectStart = Main.SeparatePosEnd[Main.ProgEDITCusorV - 1] + Main.ProgEDITCusorH;
		            Main.SelectEnd = Main.SeparatePosEnd[Main.ProgEDITCusorV - 1] + Main.ProgEDITCusorH;
		        }
		    }
		    else
		    {
		        if(Main.IsSelect)
		            Main.SelectEnd = Main.ProgEDITCusorH;
		        else
		        {
		            Main.SelectStart = Main.ProgEDITCusorH;
		            Main.SelectEnd = Main.ProgEDITCusorH;
		        }
		    }
		}  //位于第一行
		else
		{
//		    Debug.Log("This is the first line!!!");	
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}