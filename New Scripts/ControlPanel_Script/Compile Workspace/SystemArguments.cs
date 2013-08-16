using UnityEngine;
using System.Collections;

public enum WorkpieceCooSys {G00, G54, G55, G56, G57, G58, G59}

public enum Lights{
		MACHINE,
		MAG,
		AIRorLUB,
		X,
		Y,
		Z,
		FourTH
	};

public struct SystemArguments
{
	public const float PanelWindow_Width = 760f;
	public const float PanelWindow_Height = 800f;
	public const float SmallScreen_Width = 397.1f;
	public const float SmallScreen_Heght = 312.8f;
	public const float RapidMoveSpeed = 20000f;
	public const string CoordinatePath = "/Resources/Coordinate/";
	public const string ToolParameterPath = "/Resources/ToolParameter/";
	public Vector3 G92_temp;	
	public const string ToolsConfigFilePath = "/Resources/ConfigurationFiles/CuttingToolsConfig.ini";
	public const int CirclePrecision = 20;
	public const float EditLength1 = 345f;
	public const float AutoLength1 = 370f;
	public const float CursorLength = 340f;
	public const int EditLineNumber = 9;  //EDIT程序显示行数
	public const int AutoLongLineNumber = 9;  //AUTO程序全部显示行数
	public const int AutoPartLineNumber = 4;  //AUTO程序部分显示行数
}
