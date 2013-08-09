using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public enum ResultType {Success, CompileError, MacroError}
public enum MotionType {DryRunning, Line, Circular02, Circular03, MachineCooSys, AutoReturnRP, BackFromRP, Pause}
public enum ImmediateMotionType {ToolChanging = 'a', Pause, AutoReturnRP, BackFromRP, RadiusCompensationCancel, RadiusCompensationLeft, RadiusCompensationRight, 
	LengthCompensationCancel, LengthCompensationPositive, LengthCompensationNegative, G52, G53, G54, G54_1, G55, G56, G57, G58, G59, G92, M00, M01, M02, M03, M04, 
M05, M06, M07, M08, M09, M30, M98, M99}
public enum CheckInformation {MetricSystem, BritishSystem, XYPlane, YZPlane, ZXPlane, RadiusCancel, RadiusLeft, RadiusRight, LengthCancel, LengthPositive, 
LengthNegative, Scaling, ScalingCancel, FixedCycelCancel, AbsouteCoo, IncrementalCoo, G54, G54_1, G55, G56, G57, G58, G59}
public enum RadiusCompensationEnum{G40 = 0, G41, G42}
public enum LengthCompensationEnum{G43 = 0, G44, G49}
public enum RadiusType{CuttingStart = 0, No, Normal, Cancel, CancelInMiddle}
public enum ToolChange{T = 'a', M}


public interface IG_Code
{
	string ErrorMessage {get;}
	bool G_Check(string g_str, int row_index, ref DataStore step_compile_data, ref ModalCode_Fanuc_M modal_state);
}

public interface IM_Code
{
	string ErrorMessage {get;}
	bool M_Check(string m_str, int row_index, ref DataStore step_compile_data);
}

class G_FANUC_OI_M_T:IG_Code
{
	private string _errorMessage;
	public string ErrorMessage
	{
		get {return _errorMessage;}
	}
	private List<string> satisfactoryG_T = new List<string>() {"G0", "G00", "G1", "G01", "G2", "G02", "G3", "G03", "G4", "G04",  "G5.4", "G05.4", "G7.1", "G07.1", "G8", "G08",
		"G9", "G09", "G10", "G11", "G12.1", "G13.1", "G17", "G18", "G19", "G20", "G21", "G22", "G23", "G25", "G26", "G27", "G28", "G30", "G31", "G32", "G33", "G34", "G36", 
		"G37", "G39", "G40", "G41", "G42", "G50", "G50.3", "G50.2", "G51.2", "G50.4", "G50.5", "G50.6", "G51.4", "G51.5", "G51.6", "G52", "G53", "G54", "G55", "G56", "G57", 
		"G58", "G59", "G61", "G63", "G64", "G65", "G66", "G67", "G68", "G69", "G70", "G71", "G72", "G73", "G74", "G75", "G76", "G80", "G81", "G82", "G83", "G83.1", "G84", 
		"G84.2", "G85", "G87", "G88", "G89", "G90", "G92", "G94", "G91.1", "G96", "G97", "G96.1", "G96.2", "G96.3", "G96.4", "G98", "G99", };
	public G_FANUC_OI_M_T()
	{
		_errorMessage = "";
	}
	
	public bool G_Check(string g_str, int row_index, ref DataStore step_compile_data, ref ModalCode_Fanuc_M modal_state)
	{
		_errorMessage = "";
		if(satisfactoryG_T.IndexOf(g_str) == -1)
		{
			_errorMessage = "(Line:" + row_index + "): " + "系统中不存在该G指令: " + g_str;
			return false; 
		}
		else
			return true;
	}
}

class G_FANUC_OI_M_M:IG_Code
{
	private string _errorMessage;
	public string ErrorMessage
	{
		get {return _errorMessage;}
	}
	private List<string> satisfactoryG_M = new List<string>() {"G0", "G00", "G1", "G01", "G2", "G02", "G3", "G03", "G4", "G04", "G5.1", "G05.1",  "G5.4", "G05.4", "G7.1", "G07.1",
		"G9", "G09", "G10", "G11", "G15", "G16", "G17", "G18", "G19", "G20", "G21", "G22", "G23", "G27", "G28", "G29", "G30", "G31", "G33","G37", "G39", "G40", "G41", "G42",
		"G40.1", "G41.1", "G42.1", "G43", "G44", "G45", "G46", "G47", "G48", "G49", "G50", "G51", "G50.1", "G51.1", "G52", "G53", "G54", "G54.1", "G55", "G56", "G57", "G58", 
		"G59", "G60", "G61", "G62", "G63", "G64", "G65", "G66", "G67", "G68", "G69", "G73", "G74", "G75", "G76", "G77", "G78", "G79", "G80", "G80.4", "G81.4", "G81", "G82", 
		"G83", "G84", "G84.2", "G84.3", "G85", "G86", "G87", "G88", "G89", "G90", "G91", "G91.1", "G92", "G92.1", "G93", "G94", "G95", "G96", "G97", "G98", "G99", "G160", "161"};
	public G_FANUC_OI_M_M()
	{
		_errorMessage = "";
	}
	
	public bool G_Check(string g_str, int row_index, ref DataStore step_compile_data, ref ModalCode_Fanuc_M modal_state)
	{
		_errorMessage = "";
		if(satisfactoryG_M.IndexOf(g_str) == -1)
		{
			_errorMessage = "(Line:" + row_index + "): " + "系统中不存在该G指令: " + g_str;
			return false;
		}
		else
		{
			try
			{
				float g_value = (float)Convert.ToDouble(g_str.Trim('G'));
				if(g_value < 10f)
					g_str = "G0" + g_value.ToString();
			}
			catch
			{
				_errorMessage = "(Line:" + row_index + "): " + "系统中不存在该G指令: " + g_str;
				return false;
			}
			int modal_index = modal_state.ModalIndex(g_str);
			//立即执行G代码（非模态G代码）
			if(modal_index == -1)
			{
				switch(g_str)
				{
				case "G04":
					step_compile_data.ImmediateAdd((char)ImmediateMotionType.Pause);
					break;
				case "G28":
					step_compile_data.ImmediateAdd((char)ImmediateMotionType.AutoReturnRP);
					break;
				case "G29":
					step_compile_data.ImmediateAdd((char)ImmediateMotionType.BackFromRP);
					break;
				case "G52":
					step_compile_data.ImmediateAdd((char)ImmediateMotionType.G52);
					break;
				case "G53":
					step_compile_data.ImmediateAdd((char)ImmediateMotionType.G53);
					break;
				case "G92":
					step_compile_data.ImmediateAdd((char)ImmediateMotionType.G92);
					break;
				default:
					//Todo: 有很多未完成的功能
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持该G代码: " + g_str;
					return false;
				}
			}
			//模态代码
			else
			{//1 level
				switch(modal_index)
				{
				case 0:
					if(g_str == "G00")
						step_compile_data.motion_type = (int)MotionType.DryRunning;
					else if(g_str == "G01")
						step_compile_data.motion_type = (int)MotionType.Line;
					else if(g_str == "G02")
						step_compile_data.motion_type = (int)MotionType.Circular02;
					else
						step_compile_data.motion_type = (int)MotionType.Circular03;
					break;
				case 1:
					if(g_str != "G94")
					{
						_errorMessage = "(Line:" + row_index + "): " + "目前系统只支持G94(每分钟进给)，暂不支持" + g_str;
						return false;
					}
					break;
				case 2:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持09组G代码";
					return false;
				case 3:
					//G17、G18、G19
					break;
				case 4:
					if(g_str != "G21")
					{
						_errorMessage = "(Line:" + row_index + "): " + "目前系统只支持G21(公制输入)，暂不支持" + g_str;
						return false;
					}
					break;
				case 5:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持10组固定循环G代码";
					return false;
				case 6:
					//G90、G91 绝对、增量
					//Todo:
					break;
				case 7:
					//G40, G41, G42 刀具半径补偿
					//Todo: 坐标会发生一些变化
					if(g_str == "G40")
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.RadiusCompensationCancel);
					else if(g_str == "G41")
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.RadiusCompensationLeft);
					else
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.RadiusCompensationRight);
					break;
				case 8:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持11组比例缩放G代码";
					return false;
				case 9:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持04组存储形成检测功能G代码";
					return false;
				case 10:
					//G43, G44, G49 刀具长度补偿
					//Todo: 坐标会发生一些变化
					if(g_str == "G43")
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.LengthCompensationPositive);
					else if(g_str == "G44")
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.LengthCompensationNegative);
					else
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.LengthCompensationCancel);
					break;
				case 11:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持12组宏模态调用G代码";
					return false;
				case 12:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持13组周速恒定控制G代码";
					return false;
				case 13:
					//G54, G54.1, G55, G56, G57, G58, G59
					//Todo: 坐标会发生一些变化
					if(g_str == "G54.1")
					{
						_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持G54.1追加工件坐标系功能";
						return false;
					}
					else if(g_str == "G54")
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.G54);
					else if(g_str == "G55")
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.G55);
					else if(g_str == "G56")
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.G56);
					else if(g_str == "G57")
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.G57);
					else if(g_str == "G58")
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.G58);
					else
						step_compile_data.ImmediateAdd((char)ImmediateMotionType.G59);
					break;
				case 14:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持15组G代码";
					return false;
				case 15:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持16组坐标旋转方式G代码";
					return false;
				case 16:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持17组极坐标指令G代码";
					return false;
				case 17:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持18组法线方向控制G代码";
					return false;
				case 18:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持G25代码";
					return false;
				case 19:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持20组横向进磨控制（磨床用）G代码";
					return false;
				case 20:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持G13.1代码";
					return false;
				case 21:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持22组可编程镜像G代码";
					return false;
				case 22:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持G54.2代码";
					return false;
				case 23:
					_errorMessage = "(Line:" + row_index + "): " + "目前系统暂不支持G80.5代码";
					return false;
				default:
					break;
				}
				//模态代码改变
				if(modal_state.Modal_Code[modal_index] != g_str)
				{
					step_compile_data.modal_index.Add(modal_index);
					step_compile_data.modal_string.Add(g_str);
					modal_state.SetModalCode(g_str, modal_index);
				}	
			}//1 level
			step_compile_data.G_code.Add(g_str);
			return true;
		}
	}
}

class M_FANUC_OI_M:IM_Code
{
	private string _errorMessage;
	public string ErrorMessage
	{
		get {return _errorMessage;}
	}
	
	public M_FANUC_OI_M()
	{
		_errorMessage = "";
	}
	
	private List<string> satisfactoryM = new List<string>() {"M0", "M00", "M1", "M01", "M2", "M02", "M3", "M03", "M4", "M04", 
		"M5", "M05", "M6", "M06", "M7", "M07", "M8", "M08", "M9", "M09", "M19", "M30", "M98", "M98"};
	public bool M_Check(string m_str, int row_index, ref DataStore step_compile_data)
	{
		_errorMessage = "";
		if(satisfactoryM.IndexOf(m_str) == -1)
		{
			_errorMessage = "(Line:" + row_index + "): " + "系统中不存在该M指令: " + m_str;
			return false;
		}
		else
		{
			try
			{
				float m_value = (float)Convert.ToDouble(m_str.Trim('M'));
				if(m_value < 10f)
					m_str = "M0" + m_value.ToString();
			}
			catch
			{
				_errorMessage = "(Line:" + row_index + "): " + "系统中不存在该M指令: " + m_str;
				return false;
			}
			switch(m_str)
			{
			case "M00":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M00);
				break;
			case "M01":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M01);
				break;
			case "M02":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M02);
				break;
			case "M03":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M03);
				break;
			case "M04":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M04);
				break;
			case "M05":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M05);
				break;
			case "M06":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M06);
				step_compile_data.ToolChangeAdd((char)ToolChange.M);
				break;
			case "M08":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M08);
				break;
			case "M09":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M09);
				break;
			case "M30":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M30);
				break;
			case "M98":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M98);
				break;
			case "M99":
				step_compile_data.ImmediateAdd((char)ImmediateMotionType.M99);
				break;
			default:
				_errorMessage = "(Line:" + row_index + "): " + "系统暂不支持该M指令: " + m_str;
				return false;	
			}
			return true;
		}	
	}
}

/// <summary>
/// Lexical check class
/// </summary>
public abstract class LexicalCheck
{
	//接口，实现多态，以达成不同系统间的扩展；
	protected IG_Code g_code_check;
	protected IM_Code m_code_check;
	
	//Todo：模态信息保存的方式以后要更改，不能满足不同系统扩展的需求
	protected ModalCode_Fanuc_M ModalState;
	/*
	private enum FuncSelect {G_Check, M_Check, F_Check, I_Check, Slash_Check}
	private Dictionary<int, Func<string, int, bool>> CheckFunc;
	*/
	private string _errorMessage;
	protected string ErrorMessage
	{
		get {return _errorMessage;}
	}
	private List<string> _compileInfo;
	/// <summary>
	/// 错误信息汇集属性.
	/// </summary>
	/// <value>
	/// 错误信息List
	/// </value>
	public List<string> CompileInfo
	{
		get {return _compileInfo;}
	}
	public LexicalCheck()
	{
		_errorMessage = "";
		_compileInfo = new List<string>();
		ModalState = new ModalCode_Fanuc_M();
		/*
		CheckFunc = new Dictionary<int, Func<string, int, bool>>();
		CheckFunc.Add((int)FuncSelect.G_Check, G_Check);
		CheckFunc.Add((int)FuncSelect.M_Check, M_Check);
		CheckFunc.Add((int)FuncSelect.F_Check, F_Check);
		CheckFunc.Add((int)FuncSelect.I_Check, I_Check);
		CheckFunc.Add((int)FuncSelect.Slash_Check, Slash_Check);
		*/
	}
	/// <summary>
	/// 清空错误信息
	/// </summary>
	protected void ErrorClear()
	{
		_compileInfo.Clear();
	}
	
	/// <summary>
	/// 克隆当前系统中的模态信息
	/// </summary>
	/// <param name='current_modal'>
	/// 当前系统中的模态信息
	/// </param>
	public void ModalClone(ModalCode_Fanuc_M current_modal)
	{
		for(int i = 0; i < current_modal.Modal_Code.Length; i++)
		{
			ModalState.Modal_Code[i] = current_modal.Modal_Code[i];
		}
		ModalState.Slash = current_modal.Slash;
		ModalState.Feedrate = current_modal.Feedrate;
		ModalState.RotateSpeed = current_modal.Feedrate;
		ModalState.SetCooZero(current_modal.CooZero);
		ModalState.ReferencePoint = current_modal.ReferencePoint;
		ModalState.referenceFlag[0] = current_modal.referenceFlag[0];
		ModalState.referenceFlag[1] = current_modal.referenceFlag[1];
		ModalState.referenceFlag[2] = current_modal.referenceFlag[2];
	}
	
	private bool G_Check(string code_str, int row_index, ref DataStore step_compile_data, ref ModalCode_Fanuc_M modal_state)
	{
		_errorMessage = "";
		bool temp_flag = this.g_code_check.G_Check(code_str, row_index, ref step_compile_data, ref modal_state);
		_errorMessage = this.g_code_check.ErrorMessage;
		return temp_flag;
	}

	private bool M_Check(string code_str, int row_index, ref DataStore step_compile_data)
	{
		_errorMessage = "";
		bool temp_flag = this.m_code_check.M_Check(code_str, row_index, ref step_compile_data);
		_errorMessage = this.m_code_check.ErrorMessage;
		return temp_flag;
	}
	
	/// <summary>
	/// A, B, C, I, J, K, U, V, W, X, Y, Z, R;  F
	/// </summary>
	private bool F_Check(string code_str, int row_index, ref  DataStore step_compile_data, ref MotionInfo step_motion_data)
	{
		_errorMessage = "";
		string address_value = code_str[0].ToString().ToUpper();
		code_str = code_str.Remove(0, 1);
		float str_value = 0;
		try
		{
			str_value = (float)Convert.ToDouble(code_str);	
		}
		catch
		{
			_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值的格式错误";
			return false;
		}
		if(address_value == "F")
		{
			if(str_value < 0)
			{
				_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值不能为负数";
				return false;
			}
			step_compile_data.f_value = str_value;
			ModalState.Feedrate = str_value;
		}
		else
		{
			switch(address_value)
			{
			case "I":
				step_compile_data.i_value = str_value;
				step_compile_data.ijk_state[0] = true;
				step_motion_data.Address_Value.Add(str_value);
				break;
			case "J":
				step_compile_data.j_value = str_value;
				step_compile_data.ijk_state[1] = true;
				step_motion_data.Address_Value.Add(str_value);
				break;
			case "K":
				step_compile_data.k_value = str_value;
				step_compile_data.ijk_state[2] = true;
				step_motion_data.Address_Value.Add(str_value);
				break;
			case "X":
				step_compile_data.x_value = str_value;
				step_compile_data.xyz_state[0] = true;
				step_motion_data.Address_Value.Add(str_value);
				break;
			case "Y":
				step_compile_data.y_value = str_value;
				step_compile_data.xyz_state[1] = true;
				step_motion_data.Address_Value.Add(str_value);
				break;
			case "Z":
				step_compile_data.z_value = str_value;
				step_compile_data.xyz_state[2] = true;
				step_motion_data.Address_Value.Add(str_value);
				break;
			case "R":
				step_compile_data.r_value = str_value;
				step_compile_data.ijk_state[3] = true;
				step_motion_data.Address_Value.Add(str_value);
				break;
			default:
				_errorMessage = "(Line:" + row_index + "): " + "系统暂不支持该指令: " + code_str;
				return false;	
			}
		}
		return true;
	}
	
	/// <summary>
	/// D, H;  L, P;  N, Q;   O;  S;  T;  
	/// </summary>
	private bool I_Check(string code_str, int row_index, ref DataStore step_compile_data)
	{
		_errorMessage = "";
		string address_value = code_str[0].ToString().ToUpper();
		code_str = code_str.Remove(0, 1);
		int index_number = 0;
		try
		{
			index_number = Convert.ToInt32(code_str);
		}
		catch
		{
			_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值的格式错误";
			return false;
		}
		switch(address_value)
		{
		case "D":
			if(index_number < 0 || index_number > 400)
			{
				_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值为" + index_number + ", 超出规定范围(0~400)";
				return false;
			}
//			step_compile_data.d_value = index_number;
			ModalState.D_Value = index_number;
			if(index_number == 0)
				ModalState.Modal_Code[7] = "G40";
			break;
		case "H":
			if(index_number < 0 || index_number > 400)
			{
				_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值为" + index_number + ", 超出规定范围(0~400)";
				return false;
			}
//			step_compile_data.h_value = index_number;
			ModalState.H_Value = index_number;
			if(index_number == 0)
				ModalState.Modal_Code[10] = "G49";
			break;
		case "L":
		case "P":
			if(index_number <= 0 || index_number > 99999999)
			{
				_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值为" + index_number + ", 超出规定范围(1~99999999)";
				return false;
			}
			//Todo: 程序循环相关
			step_compile_data.p_value = index_number;
			break;
		case "N":
		case "Q":
			if(index_number <= 0 || index_number > 99999)
			{
				_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值为" + index_number + ", 超出规定范围(1~99999)";
				return false;
			}
			//Todo: 程序跳转相关
			break;
		case "O":
			if(index_number <= 0 || index_number > 9999)
			{
				_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值为" + index_number + ", 超出规定范围(1~9999)";
				return false;
			}
			break;
		case "S":
			if(index_number < 0 || index_number > 99999)
			{
				_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值为" + index_number + ", 超出规定范围(0~99999)";
				return false;
			}
			step_compile_data.s_value = (float)index_number;
			ModalState.RotateSpeed = step_compile_data.s_value;
			break;
		case "T":
			if(index_number < 0 || index_number > 99999999)
			{
				_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值为" + index_number + ", 超出规定范围(0~99999999)";
				return false;
			}
			if(index_number > 20)
			{
				_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值为" + code_str + ", 超出刀库最大刀具数量，暂不支持换刀时直接设定偏置量";
				return false;
			}
			step_compile_data.ImmediateAdd((char)ImmediateMotionType.ToolChanging);
			step_compile_data.ToolChangeAdd((char)ToolChange.T);
			step_compile_data.tool_number = index_number;
			break;
		default:
			break;
		}
		return true;
	}
	
	/// <summary>
	/// check
	/// </summary>
	private bool Slash_Check(string code_str, int row_index, ref  DataStore step_compile_data)
	{
		_errorMessage = "";
		string address_value = code_str[0].ToString().ToUpper();
		code_str = code_str.Remove(0, 1);
		int num = 1;
		try
		{
			if(code_str == "")
				num = 1;
			else
				num = Convert.ToInt32(code_str);
		}
		catch
		{
			_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值的格式错误";
			return false;
		}
		if(num <= 0 || num > 9)
		{
			_errorMessage = "(Line:" + row_index + "): " + address_value + "地址后值为" + num + ", 超出规定范围(1~9)";
			return false;
		}
		step_compile_data.slash_value = num;
		return true;
	}
	
	/// <summary>
	/// Calculates the degree.
	/// </summary>
	/// <returns>
	/// The wanted degree.
	/// </returns>
	/// <param name='centre_point'>
	/// Centre_point of the circle.
	/// </param>
	/// <param name='start_position'>
	/// Start  position of the arc.
	/// </param>
	/// <param name='end_position'>
	/// End position of the arc.
	/// </param>
	/// <param name='cw'>
	///  Decide whether the arc is clockwise or counterclockwise.
	/// </param>
	/// <param name='modal_state'>
	///  Acquire current modal state.
	/// </param>
	private float CalculateDegree(Vector3 centre_point, Vector3 start_position, Vector3 end_position, bool cw, ModalCode_Fanuc_M modal_state)
	{
		Vector3 start_direction = start_position - centre_point;
		Vector3 end_direction = end_position - centre_point;
		float degree_value = 0;
		Vector3 standard_vec = new Vector3(0,0,0);
		//起止向量差乘
		Vector3 cross_vec = Vector3.Cross(start_direction, end_direction);
		if(modal_state.PlaneCheck() == (int)CheckInformation.XYPlane)
		{
			standard_vec.x = 0;
			standard_vec.y = 0;
			standard_vec.z = 1f;
		}
		else if(modal_state.PlaneCheck() == (int)CheckInformation.ZXPlane)
		{
			standard_vec.x = 0;
			standard_vec.y = 1f;
			standard_vec.z = 0;
		}
		else
		{
			standard_vec.x = 1f;
			standard_vec.y = 0;
			standard_vec.z = 0;
		}
		if(Vector3.Dot(cross_vec, standard_vec) > 0)
		{
			//大于180°CW---小于180°:CCW 	
			degree_value = Mathf.Acos(Vector3.Dot(start_direction, end_direction) / (start_direction.magnitude*end_direction.magnitude)) * 180 / Mathf.PI;
			if(cw)
				return 360f - degree_value;
			else
				return degree_value;
		}
		else if(Vector3.Dot(cross_vec, standard_vec) < 0)
		{
			//小于180°:CW ---大于180°:CCW
			degree_value = Mathf.Acos(Vector3.Dot(start_direction, end_direction) / (start_direction.magnitude*end_direction.magnitude)) * 180 / Mathf.PI;
			if(cw)
				return degree_value;
			else
				return 360f - degree_value;
		}
		else
			//等于180°
			return 180f;
	}
	
	private int CalculateCentrePoint(ModalCode_Fanuc_M modal_state, float r_value, Vector3 start_position, Vector3 end_position, ref Vector3 temp_centre1, ref Vector3 temp_centre2)
	{
		Vector2 start_vec2 = new Vector2(0, 0);
		Vector2 end_vec2 = new Vector2(0, 0);
		Vector2 centre_vec1 = new Vector2(0, 0);
		Vector2 centre_vec2 = new Vector2(0, 0);
		//分三种平面条件讨论，转化为统一的二维平面，从而简化后续计算
		if(modal_state.PlaneCheck() == (int)CheckInformation.XYPlane)
		{
			start_vec2.x = start_position.x;
			start_vec2.y = start_position.y;
			end_vec2.x = end_position.x;
			end_vec2.y = end_position.y;
		}
		else if(modal_state.PlaneCheck() == (int)CheckInformation.ZXPlane)
		{
			start_vec2.x = start_position.x;
			start_vec2.y = start_position.z;
			end_vec2.x = end_position.x;
			end_vec2.y = end_position.z;
		}
		else
		{
			start_vec2.x = start_position.z;
			start_vec2.y = start_position.y;
			end_vec2.x = end_position.z;
			end_vec2.y = end_position.y;
		}
		//用平面的方法解二元一次方程求平面圆心坐标
		if(end_vec2.x - start_vec2.x == 0)
		{
			centre_vec1.y = (start_vec2.y + end_vec2.y)/2.0f;
			centre_vec2.y = (start_vec2.y + end_vec2.y)/2.0f;
			float ac4 = 2*Mathf.Sqrt(Mathf.Pow(r_value, 2) - Mathf.Pow((end_vec2.y - start_vec2.y)/2.0f, 2));
			centre_vec1.x = (2*start_vec2.x + ac4)/2.0f;
			centre_vec2.x = (2*start_vec2.x - ac4)/2.0f;
		}
		else if(end_vec2.y - start_vec2.y == 0)
		{
			centre_vec1.x = (start_vec2.x + end_vec2.x)/2.0f;
			centre_vec2.x = (start_vec2.x + end_vec2.x)/2.0f;
			float ac4 = 2*Mathf.Sqrt(Mathf.Pow(r_value, 2) - Mathf.Pow((end_vec2.x - start_vec2.x)/2.0f, 2));
			centre_vec1.y = (2*start_vec2.y + ac4)/2.0f;
			centre_vec2.y = (2*start_vec2.y - ac4)/2.0f;
		}
		else
		{
//			float k = (end_vec2.y - start_vec2.y) / (end_vec2.x - start_vec2.x);
			float k = -(end_vec2.x - start_vec2.x) / (end_vec2.y - start_vec2.y);
//			float h = (start_vec2.y * end_vec2.x - end_vec2.y * start_vec2.x) / (end_vec2.x - start_vec2.x);
//			float h = (end_vec2.y * end_vec2.x - start_vec2.y * start_vec2.x) / (end_vec2.x - start_vec2.x);
			float h = (end_vec2.y * end_vec2.y - start_vec2.y * start_vec2.y + end_vec2.x * end_vec2.x - start_vec2.x * start_vec2.x) / (2 * end_vec2.y - 2 * start_vec2.y);
			float a = 1f + k*k;
			float b = 2*k*h - 2*start_vec2.x - 2*start_vec2.y*k;
			float c = h*h - 2*start_vec2.y*h + start_vec2.x * start_vec2.x + start_vec2.y * start_vec2.y - r_value*r_value;
			centre_vec1.x = (-b + Mathf.Sqrt(b*b - 4*a*c))/(2*a);
			centre_vec2.x = (-b - Mathf.Sqrt(b*b - 4*a*c))/(2*a);
			centre_vec1.y = k*centre_vec1.x + h;
			centre_vec2.y = k*centre_vec2.x + h;
		}
		//将平面圆心坐标按条件转回三维坐标
		if(modal_state.PlaneCheck() == (int)CheckInformation.XYPlane)
		{
			temp_centre1.x = centre_vec1.x;
			temp_centre1.y = centre_vec1.y;
			temp_centre1.z = start_position.z;
			temp_centre2.x = centre_vec2.x;
			temp_centre2.y = centre_vec2.y;
			temp_centre2.z = start_position.z;
		}
		else if(modal_state.PlaneCheck() == (int)CheckInformation.ZXPlane)
		{
			temp_centre1.x = centre_vec1.x;
			temp_centre1.y = start_position.y;
			temp_centre1.z = centre_vec1.y;
			temp_centre2.x = centre_vec2.x;
			temp_centre2.y = start_position.y;
			temp_centre2.z = centre_vec2.y;
		}
		else
		{
			temp_centre1.x = start_position.x;
			temp_centre1.y = centre_vec1.y;
			temp_centre1.z = centre_vec1.x;
			temp_centre2.x = start_position.x;
			temp_centre2.y = centre_vec2.y;
			temp_centre2.z = centre_vec2.x;
		}
		if(Vector3.Equals(temp_centre1, temp_centre2))
			return 1;
		else
			return 2;
	}
	
	/// <summary>
	/// Code Check Entrance
	/// </summary>
	protected bool Code_Check(List<string> code_segment, int row_index, ref bool macro_flag, ref DataStore step_compile_data, ref Vector3 display_position, ref MotionInfo step_motion_data, ref Vector3 virtual_position, ref ToolChangeInfo step_tool_data)
	{
		bool temp_flag = true;
		bool return_flag = true;
		string Address = "";
		Vector3 program_position = new Vector3(0, 0, 0);
		macro_flag = false;
		Regex macro_Reg = new Regex(@"((#+)|(\[+)|(\]+)|(=+))", RegexOptions.IgnoreCase);
		MatchCollection macro_Col;
		//获得当前程序段的总体信息，以便后续进行编译
		for(int i = 0; i < code_segment.Count; i++)
		{
			// 检查是否有宏代码，如果有宏代码
			macro_Col = macro_Reg.Matches(code_segment[i]);
			//如果程序中含有宏代码，中断编译过程，返回宏代码错误，宏代码的编译暂不处理
			if(macro_Col.Count > 0)
			{
				temp_flag = false;
				macro_flag = true;
				break;
			}
			if(code_segment[i] != ";")
			{
				_errorMessage = "";
				Address = code_segment[i][0].ToString().ToUpper();
				switch(Address)
				{
				case "G":
					return_flag = G_Check(code_segment[i], row_index, ref step_compile_data, ref ModalState);
					break;
				case "M":
					return_flag = M_Check(code_segment[i], row_index, ref step_compile_data);
					break;
				/// A, B, C, I, J, K, U, V, W, X, Y, Z, R;  F
				case "I":
				case "J":
				case "K":
				case "U":
				case "V":
				case "W":
				case "X":
				case "Y":
				case "Z":
				case "R":
					step_motion_data.G_Address.Add(Address);
					return_flag = F_Check(code_segment[i], row_index, ref step_compile_data, ref step_motion_data);
					break;
				case "A":
				case "B":
				case "C":
				case "F":
					return_flag = F_Check(code_segment[i], row_index, ref step_compile_data, ref step_motion_data);
					break;
				case "/":
					return_flag = Slash_Check(code_segment[i], row_index, ref step_compile_data);
					break;
				/// D, H;  L, P;  N, Q;   O;  S;  T;  
				case "D":
				case "H":
				case "L":
				case "P":
				case "N":
				case "Q":
				case "O":
				case "S":
				case "T":
					return_flag = I_Check(code_segment[i], row_index, ref step_compile_data);
					break;
				default:
					_errorMessage = "(Line:" + row_index + "): " + Address + "地址不存在";
					return_flag = false;
					break;
				}
				
				if(return_flag == false)
				{
					if(temp_flag)
					{
						temp_flag = false;
					}
					_compileInfo.Add(ErrorMessage);
				}
			}
		}
		//编译程序段，生成运动信息
		if(temp_flag)
		{//compile level
			//Todo: 分析此段代码，生成相关运动信息；
			//是否为空
			if(step_compile_data.IsEmpty())
				return true;
			else
			{//1 level
				//立即执行代码处理
				bool radiusDealFlag = false;
				if(step_compile_data.immediate_execution != "")
				{//2 level
					step_motion_data.Immediate_Motion = step_compile_data.immediate_execution;
					for(int i = 0; i < step_compile_data.immediate_execution.Length; i++)
					{
						switch((char)step_compile_data.immediate_execution[i])
						{
//						//Todo: 考虑下当前行只有T代码或者只有M06的情况
//						case (char)ImmediateMotionType.ToolChanging:
//							step_motion_data.Tool_Number = step_compile_data.tool_number;
//							break;
						case (char)ImmediateMotionType.M00:
							step_motion_data.M_Code = 0;
							break;
						case (char)ImmediateMotionType.M01:
							step_motion_data.M_Code = 1;
							break;
						case (char)ImmediateMotionType.M02:
							step_motion_data.M_Code = 2;
							break;
						case (char)ImmediateMotionType.M03:
							if(ModalState.RotateSpeed == 0)
							{
								_errorMessage = "(Line:" + row_index + "): " + "当前程序段中未指定主轴转速";
								_compileInfo.Add(ErrorMessage);
								return false;
							}
							step_motion_data.M_Code = 3;
							step_motion_data.SpindleSpeed = (int)ModalState.RotateSpeed;
							break;
						case (char)ImmediateMotionType.M04:
							if(ModalState.RotateSpeed == 0)
							{
								_errorMessage = "(Line:" + row_index + "): " + "当前程序段中未指定主轴转速";
								_compileInfo.Add(ErrorMessage);
								return false;
							}
							step_motion_data.M_Code = 4;
							step_motion_data.SpindleSpeed = (int)ModalState.RotateSpeed;
							break;
						case (char)ImmediateMotionType.M05:
							step_motion_data.M_Code = 5;
							break;
						case (char)ImmediateMotionType.M06:
							step_motion_data.M_Code = 6;
							break;
						case (char)ImmediateMotionType.M08:
							step_motion_data.M_Code = 8;
							break;
						case (char)ImmediateMotionType.M09:
							step_motion_data.M_Code = 9;
							break;
						//G52局部坐标系编译
						case (char)ImmediateMotionType.G52:
							//若x值为0，则X轴的原点回到原始坐标系原点，当前X的显示值变化
							if(step_compile_data.x_value == 0)
								display_position.x = virtual_position.x + ModalState.CooZero.x;
							//若x值不为0，则原点偏置该值大小，X的显示值发生变化
							else
								display_position.x = virtual_position.x + ModalState.CooZero.x - step_compile_data.x_value;
							//同X轴
							if(step_compile_data.y_value == 0)
								display_position.y = virtual_position.y + ModalState.CooZero.y;
							else
								display_position.y = virtual_position.y + ModalState.CooZero.y - step_compile_data.y_value;
							//同X轴
							if(step_compile_data.z_value == 0)
								display_position.z = virtual_position.z + ModalState.CooZero.z;
							else
								display_position.z = virtual_position.z + ModalState.CooZero.z - step_compile_data.z_value;
							step_motion_data.CooTransformation = new Vector3(step_compile_data.x_value, step_compile_data.y_value, step_compile_data.z_value);
							if(ModalState.RadiusCheck() != (int)RadiusCompensationEnum.G40)
							{
								step_motion_data.RadiusState = (int)RadiusType.CancelInMiddle;
								radiusDealFlag = true;
							}
							break;
						case (char)ImmediateMotionType.G53:
							if(step_compile_data.G_code.Contains("G50") || step_compile_data.G_code.Contains("G51") || step_compile_data.G_code.Contains("G50.1") || 
								step_compile_data.G_code.Contains("G51.1") || step_compile_data.G_code.Contains("G68") || step_compile_data.G_code.Contains("G69"))
							{
								_errorMessage = "(Line:" + row_index + "): " + "不可在与G53指令相同的程序段中指令G50/G51（比例缩放）、G50.1/G51.1（可编程镜像）以及G68/G69（坐标旋转）";
								_compileInfo.Add(ErrorMessage);
								return false;
							}
							if(step_compile_data.G_code.Contains("G01") || step_compile_data.G_code.Contains("G02") || step_compile_data.G_code.Contains("G03"))
							{
								_errorMessage = "(Line:" + row_index + "): " + "不可在与G53指令相同的程序段中指令G01、G02和G03";
								_compileInfo.Add(ErrorMessage);
								return false;
							}
							if(ModalState.RadiusCheck() != (int)RadiusCompensationEnum.G40)
							{
								step_motion_data.RadiusState = (int)RadiusType.CancelInMiddle;
								radiusDealFlag = true;
							}
							break;
						case (char)ImmediateMotionType.G54:
						case (char)ImmediateMotionType.G55:
						case (char)ImmediateMotionType.G56:
						case (char)ImmediateMotionType.G57:
						case (char)ImmediateMotionType.G58:
						case (char)ImmediateMotionType.G59:
							ModalState.SetCooZero(- ModalState.LocalCoordinate() - ModalState.EXTCoo());
							display_position = virtual_position + ModalState.CooZero;
							break;
						case (char)ImmediateMotionType.G92:
							if(step_compile_data.xyz_state[0])
							{
								step_motion_data.CooState[0] = true;
								step_motion_data.CooTransformation.x = step_compile_data.x_value;
								ModalState.CooZero.x = step_compile_data.x_value - virtual_position.x;
								display_position.x = step_compile_data.x_value;
							}
							if(step_compile_data.xyz_state[1])
							{
								step_motion_data.CooState[1] = true;
								step_motion_data.CooTransformation.y = step_compile_data.y_value;
								ModalState.CooZero.y = step_compile_data.y_value - virtual_position.y;
								display_position.y = step_compile_data.y_value;
							}
							if(step_compile_data.xyz_state[2])
							{
								step_motion_data.CooState[2] = true;
								step_motion_data.CooTransformation.z = step_compile_data.z_value;
								ModalState.CooZero.z = step_compile_data.z_value - virtual_position.z;
								display_position.z = step_compile_data.z_value;
							}
							if(ModalState.RadiusCheck() != (int)RadiusCompensationEnum.G40)
							{
								step_motion_data.RadiusState = (int)RadiusType.CancelInMiddle;
								radiusDealFlag = true;
							}
							break;
						//Todo: 关于补偿可能还需要修改，还有中间点的问题
						case (char)ImmediateMotionType.AutoReturnRP:
							//绝对坐标
							if(ModalState.AbsoluteCooCheck() == (int)CheckInformation.AbsouteCoo)
							{
								if(step_compile_data.xyz_state[0])
								{
									ModalState.referenceFlag[0] = true;
									ModalState.ReferencePoint.x = step_compile_data.x_value;
								}
								if(step_compile_data.xyz_state[1])
								{
									ModalState.referenceFlag[1] = true;
									ModalState.ReferencePoint.y = step_compile_data.y_value;
								}
								if(step_compile_data.xyz_state[2])
								{
									ModalState.referenceFlag[2] = true;
									ModalState.ReferencePoint.z = step_compile_data.z_value;
								}
							}
							//增量坐标
							else
							{
								if(step_compile_data.xyz_state[0])
								{
									ModalState.referenceFlag[0] = true;
									ModalState.ReferencePoint.x = step_compile_data.x_value + display_position.x;
								}
								if(step_compile_data.xyz_state[1])
								{
									ModalState.referenceFlag[1] = true;
									ModalState.ReferencePoint.y = step_compile_data.y_value + display_position.y;
								}
								if(step_compile_data.xyz_state[2])
								{
									ModalState.referenceFlag[2] = true;
									ModalState.ReferencePoint.z = step_compile_data.z_value + display_position.z;
								}
							}
							if(ModalState.RadiusCheck() != (int)RadiusCompensationEnum.G40)
							{
								step_motion_data.RadiusState = (int)RadiusType.CancelInMiddle;
								radiusDealFlag = true;
							}
							break;
						case (char)ImmediateMotionType.BackFromRP:
							//在计算运动信息中处理
							if(ModalState.RadiusCheck() != (int)RadiusCompensationEnum.G40)
							{
								step_motion_data.RadiusState = (int)RadiusType.CancelInMiddle;
								radiusDealFlag = true;
							}
							break;
						case (char)ImmediateMotionType.Pause:
//							在计算运动信息中处理
							if(ModalState.RadiusCheck() != (int)RadiusCompensationEnum.G40)
							{
								step_motion_data.RadiusState = (int)RadiusType.CancelInMiddle;
								radiusDealFlag = true;
							}
							break;
						case (char)ImmediateMotionType.RadiusCompensationCancel:
							//半径补偿取消
							step_motion_data.RadiusState = (int)RadiusType.Cancel;
							radiusDealFlag = true;
							break;
						case (char)ImmediateMotionType.RadiusCompensationLeft:
							//左补偿
							step_motion_data.RadiusState = (int)RadiusType.CuttingStart;
							radiusDealFlag = true;
							break;
						case (char)ImmediateMotionType.RadiusCompensationRight:
							//右补偿
							step_motion_data.RadiusState = (int)RadiusType.CuttingStart;
							radiusDealFlag = true;
							break;
						default:
							break;
						}
					}
				}//2 level
				
				//半径补偿信息添加
				step_motion_data.RadiusCompensationInfo = ModalState.RadiusCheck();
				step_motion_data.LengthCompensationInfo = ModalState.LengthCheck();
				step_motion_data.D_Value = ModalState.D_Value;
				//长度补偿信息添加
				step_motion_data.H_Value = ModalState.H_Value;
				//刀具信息添加
//				step_motion_data.Tool_Number = 
				if(!radiusDealFlag)
				{
					switch(ModalState.RadiusCheck())
					{
					case (int)RadiusCompensationEnum.G40:
						step_motion_data.RadiusState = (int)RadiusType.No;
						break;
					case (int)RadiusCompensationEnum.G41:
						step_motion_data.RadiusState = (int)RadiusType.Normal;
						break;
					case (int)RadiusCompensationEnum.G42:
						step_motion_data.RadiusState = (int)RadiusType.Normal;
						break;
					default:
						break;
					}
				}
				
				//平面信息添加
				step_motion_data.Current_Plane = ModalState.PlaneCheck();
				
				//计算运动信息
				if(step_compile_data.HasMotion() && step_compile_data.G_code.IndexOf("G52") == -1 && step_compile_data.G_code.IndexOf("G92") == -1)
				{//3 level
					step_motion_data.Motion_Type = step_compile_data.MotionTypeIndex(ModalState.Modal_Code[0]);
					if(step_motion_data.Motion_Type == -1)
					{
						_errorMessage = "(Line:" + row_index + "): " + "未知运动方式错误！";
						_compileInfo.Add(ErrorMessage);
						return false;
					}
					switch(step_motion_data.Motion_Type)
					{
					//G00 空运行
					case (int)MotionType.DryRunning:
						step_motion_data.SetStartPosition(display_position, virtual_position);
						//公制单位
						if(ModalState.UnitCheck() == (int)CheckInformation.MetricSystem)
						{
							//绝对坐标
							if(ModalState.AbsoluteCooCheck() == (int)CheckInformation.AbsouteCoo)
								program_position = step_compile_data.AbsolutePosition(display_position);
							//增量坐标
							else
								program_position = step_compile_data.IncrementalPosition(display_position);
							step_motion_data.Direction = program_position - display_position;
							step_motion_data.SetRemainingMovement();
							step_motion_data.Velocity = SystemArguments.RapidMoveSpeed;
							step_motion_data.Time_Value = step_motion_data.Direction.magnitude / SystemArguments.RapidMoveSpeed * 60;
							virtual_position += step_motion_data.Direction;
							display_position = program_position;
							step_motion_data.SetTargetPosition(display_position, virtual_position);
						}
						//英制单位
						else
						{
							
						}
						break;
					//G01 直线插补
					case (int)MotionType.Line:
						if(ModalState.Feedrate == 0)
						{
							_errorMessage = "(Line:" + row_index + "): " + "未指定进给速率！";
							_compileInfo.Add(ErrorMessage);
							return false;
						}
						step_motion_data.SetStartPosition(display_position, virtual_position);
						//公制单位
						if(ModalState.UnitCheck() == (int)CheckInformation.MetricSystem)
						{
							//绝对坐标
							if(ModalState.AbsoluteCooCheck() == (int)CheckInformation.AbsouteCoo)
								program_position = step_compile_data.AbsolutePosition(display_position);
							//增量坐标
							else
								program_position = step_compile_data.IncrementalPosition(display_position);
							step_motion_data.Direction = program_position - display_position;
							step_motion_data.SetRemainingMovement();
							step_motion_data.Velocity = ModalState.Feedrate;
							step_motion_data.Time_Value = step_motion_data.Direction.magnitude / step_motion_data.Velocity * 60;
							virtual_position += step_motion_data.Direction;
							display_position = program_position;
							step_motion_data.SetTargetPosition(display_position, virtual_position);
						}
						//英制单位
						else
						{
							
						}
						break;
					//G02 圆弧顺时针插补
					//G03圆弧逆时针插补
					case (int)MotionType.Circular02:
					case (int)MotionType.Circular03:
						if(step_motion_data.RadiusState == (int)RadiusType.CuttingStart)
						{
							_errorMessage = "(Line:" + row_index + "): " + "进行偏置起刀时，不能使用圆弧指令（G02和G03）";
							_compileInfo.Add(ErrorMessage);
							return false;
						}
						if(step_motion_data.RadiusState == (int)RadiusType.Cancel)
						{
							_errorMessage = "(Line:" + row_index + "): " + "进行偏置取消时，不能使用圆弧指令（G02和G03）";
							_compileInfo.Add(ErrorMessage);
							return false;
						}
						if(ModalState.Feedrate == 0)
						{
							_errorMessage = "(Line:" + row_index + "): " + "未指定进给速率！";
							_compileInfo.Add(ErrorMessage);
							return false;
						}
						step_motion_data.SetStartPosition(display_position, virtual_position);
						//公制单位
						Vector3 ijk_coo = new Vector3(0, 0, 0);
						float rValue = 0;
						if(ModalState.UnitCheck() == (int)CheckInformation.MetricSystem)
						{
							//绝对坐标
							if(ModalState.AbsoluteCooCheck() == (int)CheckInformation.AbsouteCoo)
								program_position = step_compile_data.AbsolutePosition(display_position);
							//增量坐标
							else
								program_position = step_compile_data.IncrementalPosition(display_position);
							step_motion_data.Direction = program_position - display_position;
							step_motion_data.SetRemainingMovement();
							step_motion_data.Velocity = ModalState.Feedrate;
							virtual_position += step_motion_data.Direction;
							switch(step_compile_data.CircleArguJudge(ref _errorMessage, ModalState, ref ijk_coo, ref rValue))
							{
							//报错
							case -1:
								_errorMessage = "(Line:" + row_index + "): " + _errorMessage;
								_compileInfo.Add(ErrorMessage);
								return false;
							//原地不动	
							case 0:
								step_motion_data.Motion_Type = -1;
								return true;
							//转360°
							case 1:
								step_motion_data.Center_Point = display_position + ijk_coo;
								step_motion_data.Rotate_Degree = 360f;
								rValue = ijk_coo.magnitude;
								break;
							//IJK输入参数
							case 2:
								step_motion_data.Center_Point = display_position + ijk_coo;
								//求角度
								if(step_motion_data.Motion_Type == (int)MotionType.Circular02)
								{
									step_motion_data.Rotate_Degree = CalculateDegree(step_motion_data.Center_Point, 
										step_motion_data.DisplayStart, program_position, true, ModalState);
								}
								else
								{
									step_motion_data.Rotate_Degree = CalculateDegree(step_motion_data.Center_Point, 
										step_motion_data.DisplayStart, program_position, false, ModalState);
								}
								rValue = ijk_coo.magnitude;
								break;
							//R输入参数
							case 3:
								Vector3 temp_centre1 = new Vector3(0, 0, 0);
								Vector3 temp_centre2 = new Vector3(0, 0, 0);
								//只有一个圆心
								if(CalculateCentrePoint(ModalState, rValue, step_motion_data.DisplayStart, program_position, ref temp_centre1, ref temp_centre2) == 1)
								{
									//应该直接返回180°
									step_motion_data.Center_Point = temp_centre1;
									step_motion_data.Rotate_Degree = 180f;
								}
								else
								{
									//剔除一个点
									if(step_motion_data.Motion_Type == (int)MotionType.Circular02)
										step_motion_data.Rotate_Degree = CalculateDegree(temp_centre1, step_motion_data.DisplayStart, program_position, true, ModalState);
									else
										step_motion_data.Rotate_Degree = CalculateDegree(temp_centre1, step_motion_data.DisplayStart, program_position, false, ModalState);
									if(rValue > 0)
									{
										if(step_motion_data.Rotate_Degree > 180f)
										{
											step_motion_data.Rotate_Degree = 360f - step_motion_data.Rotate_Degree;
											step_motion_data.Center_Point = temp_centre2;
										}
										else
											step_motion_data.Center_Point = temp_centre1;
									}
									else
									{
										if(step_motion_data.Rotate_Degree < 180f)
										{
											step_motion_data.Rotate_Degree = 360f - step_motion_data.Rotate_Degree;
											step_motion_data.Center_Point = temp_centre2;
										}
										else
											step_motion_data.Center_Point = temp_centre1;
									}
								}
								rValue = Mathf.Abs(rValue);
								break;
							}
							step_motion_data.Rotate_Speed = (step_motion_data.Velocity / (60f * rValue)) * (180 / Mathf.PI);
							step_motion_data.Time_Value = step_motion_data.Rotate_Degree / step_motion_data.Rotate_Speed;
							display_position = program_position;
							step_motion_data.SetTargetPosition(display_position, virtual_position);
							//step_motion_data.Center_Point = step_motion_data.Center_Point + virtual_position - display_position;
						}
						//英制单位
						else
						{
							
						}
						break;
					//G53高速移动
					case (int)MotionType.MachineCooSys:
						step_motion_data.SetStartPosition(display_position, virtual_position);
						//公制单位
						if(ModalState.UnitCheck() == (int)CheckInformation.MetricSystem)
						{
							//绝对坐标
							if(ModalState.AbsoluteCooCheck() == (int)CheckInformation.AbsouteCoo)
								program_position = step_compile_data.AbsolutePosition(virtual_position);
							//增量坐标
							else
							{
								step_motion_data.Motion_Type = -1;
								return true;
							}
							step_motion_data.Direction = program_position - virtual_position;
							step_motion_data.SetRemainingMovement();
							step_motion_data.Velocity = SystemArguments.RapidMoveSpeed;
							step_motion_data.Time_Value = step_motion_data.Direction.magnitude / SystemArguments.RapidMoveSpeed * 60;
							display_position += step_motion_data.Direction;
							virtual_position = program_position;
							step_motion_data.SetTargetPosition(display_position, virtual_position);
						}
						//英制单位
						else
						{
							
						}
						break;
					//自动返回参考点
					case (int)MotionType.AutoReturnRP:
						step_motion_data.SetStartPosition(display_position, virtual_position);
						//公制单位
						if(ModalState.UnitCheck() == (int)CheckInformation.MetricSystem)
						{
							program_position = display_position;
							if(ModalState.referenceFlag[0])
								program_position.x = ModalState.ReferencePoint.x;
							if(ModalState.referenceFlag[1])
								program_position.y = ModalState.ReferencePoint.y;
							if(ModalState.referenceFlag[2])
								program_position.z = ModalState.ReferencePoint.z;
							step_motion_data.Direction = program_position - display_position;
							step_motion_data.SetRemainingMovement();
							step_motion_data.Velocity = SystemArguments.RapidMoveSpeed;
							step_motion_data.Time_Value = step_motion_data.Direction.magnitude / SystemArguments.RapidMoveSpeed * 60;
							virtual_position += step_motion_data.Direction;
							display_position = program_position;
							step_motion_data.SetTargetPosition(display_position, virtual_position);
							step_motion_data.VirtualTarget2 = new Vector3(0, 0, 0);
							virtual_position = step_motion_data.VirtualTarget2;
							step_motion_data.Direction2 = step_motion_data.VirtualTarget2 - step_motion_data.VirtualTarget;
							display_position += step_motion_data.Direction2;
							step_motion_data.Time_Value2 = step_motion_data.Direction2.magnitude / SystemArguments.RapidMoveSpeed * 60;
						}
						//英制单位
						else
						{
							
						}
						break;
					//从参考点返回
					case (int)MotionType.BackFromRP:
						step_motion_data.SetStartPosition(display_position, virtual_position);
						//公制单位
						if(ModalState.UnitCheck() == (int)CheckInformation.MetricSystem)
						{
							program_position = display_position;
							if(ModalState.referenceFlag[0] || ModalState.referenceFlag[1] || ModalState.referenceFlag[2])
							{
								if(ModalState.referenceFlag[0])
									program_position.x = ModalState.ReferencePoint.x;
								if(ModalState.referenceFlag[1])
									program_position.y = ModalState.ReferencePoint.y;
								if(ModalState.referenceFlag[2])
									program_position.z = ModalState.ReferencePoint.z;
							}
							else
								program_position = Vector3.zero;	
							step_motion_data.Direction = program_position - display_position;
							step_motion_data.SetRemainingMovement();
							step_motion_data.Velocity = SystemArguments.RapidMoveSpeed;
							step_motion_data.Time_Value = step_motion_data.Direction.magnitude / SystemArguments.RapidMoveSpeed * 60;
							virtual_position += step_motion_data.Direction;
							display_position = program_position;
							step_motion_data.SetTargetPosition(display_position, virtual_position);
							//绝对坐标
							if(ModalState.AbsoluteCooCheck() == (int)CheckInformation.AbsouteCoo)
							{
								if(step_compile_data.xyz_state[0])
									program_position.x = step_compile_data.x_value;
								if(step_compile_data.xyz_state[1])
									program_position.y = step_compile_data.y_value;
								if(step_compile_data.xyz_state[2])
									program_position.z = step_compile_data.z_value;
							}
							//增量坐标
							else
							{
								if(step_compile_data.xyz_state[0])
									program_position.x = step_compile_data.x_value + ModalState.ReferencePoint.x;
								if(step_compile_data.xyz_state[1])
									program_position.y = step_compile_data.y_value + ModalState.ReferencePoint.y;
								if(step_compile_data.xyz_state[2])
									program_position.z = step_compile_data.z_value + ModalState.ReferencePoint.z;
							}
							step_motion_data.Direction2 = program_position - display_position;
							step_motion_data.Time_Value2 = step_motion_data.Direction2.magnitude / SystemArguments.RapidMoveSpeed * 60;
							step_motion_data.VirtualTarget2 = step_motion_data.VirtualTarget + step_motion_data.Direction2;
						}
						//英制单位
						else
						{
							
						}
						break;
					case (int)MotionType.Pause:
						if(!step_compile_data.xyz_state[0] && step_compile_data.p_value == 0)
						{
							_errorMessage = "(Line:" + row_index + "): " + "G04暂停指令格式错误 ";
							_compileInfo.Add(ErrorMessage);
							return false;
						}
						else
						{
							if(step_compile_data.xyz_state[0])
								step_motion_data.Time_Value = step_compile_data.x_value;
							else
								step_motion_data.Time_Value = step_compile_data.p_value / 1000.0f;
						}
						break;
					default:
						_errorMessage = "(Line:" + row_index + "): " + "当前系统暂不支持Motion Type: " + step_compile_data.motion_type;
						_compileInfo.Add(ErrorMessage);
						return false;
					}
				}//3 level	
				step_motion_data.ToolChange_Motion = step_compile_data.toolChange;
				for(int i = 0; i < step_compile_data.toolChange.Length; i++)
				{
					switch((char)step_compile_data.toolChange[i])
					{
					case (char)ToolChange.T:
						step_motion_data.Tool_Number = step_compile_data.tool_number;
						break;
					case (char)ToolChange.M:
						//判断当前Z轴是否在最高点
						if(virtual_position.z != 0)
						{
							step_tool_data.VirtualStart = virtual_position;
							step_tool_data.Direction = new Vector3(0, 0, 0 - virtual_position.z);
							step_tool_data.VirtualTarget = new Vector3(virtual_position.x, virtual_position.y, 0);
							step_tool_data.TimeValue = step_tool_data.Direction.magnitude / SystemArguments.RapidMoveSpeed * 60;
							virtual_position.z = 0;
							display_position += step_tool_data.Direction;
						}
						break;
					}
				}
				
				
				
			}//1 level
			//复制一些辅助画面的显示信息
			step_motion_data.List_Copy(step_compile_data.G_code, step_compile_data.modal_index, step_compile_data.modal_string);
			if(!step_motion_data.ReasonableCoo())
			{
				_errorMessage = "(Line:" + row_index + "): " + "该行坐标轴超程！";
				_compileInfo.Add(ErrorMessage);
				return false;
			}
			
			//代码跳过
			if(step_compile_data.slash_value > 0)
				step_motion_data.Slash = step_compile_data.slash_value;

			return true;
		}//compile level
		else
			return false;
	}
	
	
}

public abstract class CompileBase:LexicalCheck
{
	private bool _executeFlag;
	//编译后是否可以MEM执行判断属性；
	public bool ExecuteFlag
	{
		get {return _executeFlag;}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="CompileBase"/> class.
	/// </summary>
	public CompileBase()
	{
		_executeFlag = false;
		
	}
	
	/// <summary>
	/// The main method of NC code compile
	/// </summary>
	/// <returns>
	/// compile result type
	/// </returns>
	/// <param name='source_code'>
	/// formative NC code
	/// </param>
	/// <param name='prog_name'>
	/// the name of current NC program
	/// </param>
	public int CompileEntrance(List<List<string>> source_code, Vector3 current_position, List<MotionInfo> motion_data, Vector3 virtual_position, List<MotionInfo> original_motion_data, List<ToolChangeInfo> tool_motion_info)
	{
		//初始信息
		bool temp_execute = true;
		bool macro_flag = false;
		ResultType type_var = ResultType.Success;
		_executeFlag = false;
		ErrorClear();
		motion_data.Clear();
		original_motion_data.Clear();
		tool_motion_info.Clear();
		DataStore step_compile_data = new DataStore();
		MotionInfo step_motion_data = new MotionInfo();
		ToolChangeInfo step_tool_data = new ToolChangeInfo();
		
		for(int i = 0; i < source_code.Count; i++)
		{
			step_compile_data = new DataStore();
			step_motion_data = new MotionInfo();
			step_tool_data = new ToolChangeInfo();
			if(Code_Check(source_code[i], i + 1, ref macro_flag, ref step_compile_data, ref current_position, ref step_motion_data, ref virtual_position, ref step_tool_data) == false)
			{
				if(macro_flag)
				{
					temp_execute = false;
					type_var = ResultType.MacroError;
					break;
				}
				if(temp_execute)
				{
					temp_execute = false;
					type_var = ResultType.CompileError;
				}
			}
			if(temp_execute)
			{
				step_motion_data.index = i;
				motion_data.Add(step_motion_data);
				string m06_check = "" + (char)ImmediateMotionType.M06;
				if(step_motion_data.Immediate_Motion.Contains(m06_check))
					tool_motion_info.Add(step_tool_data);
				if(i > 0)
				{
					motion_data[i - 1].G_Display2 = step_motion_data.G_Display;
					motion_data[i - 1].G_Address2 = step_motion_data.G_Address;
					motion_data[i - 1].Address_Value2 = step_motion_data.Address_Value;
				}
			}
		}
		//除补偿外顺利编译完成
		if(temp_execute)
		{
			//半径补偿处理
			//原始编译数据保存保存
			for(int i = 0; i < motion_data.Count; i++)
			{
				original_motion_data.Add(motion_data[i]);
			}
			/**
			  *半径补偿分成五种大的情况讨论
			  *(1)起刀，即从G40变成G41或者G42；
			  *(2)普通的中间过程，即开始补偿以后，保持补偿的状态，中间一直需要计算补偿；
			  *(3)中间过程中改变补偿值，即改变D值，改变了补偿号，有一个类似起刀的变化；
			  *(4)补偿取消，即从G41或者G42变成了G40；
			  *(5)中间某一步取消补偿；
			  *(6)点重合；
			  *(7)钝角用圆弧拿来补偿，相当于中间插入一段圆弧，需要重新调整数据结构；
			  **/
			/*
			//实例化该计算补偿的工具类
			CompensationCalculate CalFunction = new CompensationCalculate();
			
			//编译出来的信息暂时都存在motion_data的数据结构里，遍历一遍，补充半径补偿信息
			MotionInfo motion_data1 = new MotionInfo();
			MotionInfo motion_data2 = new MotionInfo();
			int index1 = 0; //第一个数据结构的序号
			int index2 = 0; //第二个数据结构的序号
			for(int i = 0; i < motion_data.Count; i++)
			{
				//每次运行前都将创建圆弧的标志位置反
				CalFunction.Has_circle = false;
				//判断当前数据是否需要补偿
				if(motion_data[i].RadiusState != (int)RadiusType.No && motion_data[i].Motion_Type != -1 && motion_data[i].Motion_Type != (int)MotionType.Pause)
				{
					index1 = i;
					motion_data1 = motion_data[index1];  
					//如果不是最后一个数据结构，则第二个参数传入下一个数据结构以判断补偿的类型
					if(i != motion_data.Count - 1)
					{
						for(int j = i + 1; j < motion_data.Count; j++)
						{
							if(motion_data[j].Motion_Type == -1 || motion_data[j].Motion_Type == (int)MotionType.Pause)
							{
								continue; //当前数据结构不产生移动，无法判断补偿类型，继续下移循环
							}
							else
							{
								index2 = j;
								break; //找到合适的数据结构，退出该循环
							}
						}
						motion_data2 = motion_data[index2];
						CalFunction.Calculate(ref motion_data1, ref motion_data2);  //输入补偿数据，进行补偿
						//判断是否要增加圆弧，需要则进入该分支
						if(CalFunction.Has_circle)
						{
							MotionInfo motion_data_circle = new MotionInfo();
							motion_data_circle.index = index2;
							motion_data.Insert(index2, motion_data_circle);
							motion_data_circle = motion_data[index2];
							CalFunction.CalculateForCircle(ref motion_data1, ref motion_data_circle, ref motion_data2);
							motion_data[index2] = motion_data_circle;  //把修改好的数据传回给原始的数据结构
							motion_data[index2 + 1] = motion_data2;  //把修改好的数据传回给原始的数据结构
							i = index2;  //跳过新增的圆弧数据结构
						}
						else
							motion_data[index2] = motion_data2; //把修改好的数据传回给原始的数据结构
					}
					//最后一个数据结构，一般为刀具补偿取消，传入同样的两个参数，只需要修改其中一个即可
					else
					{
						motion_data2 = motion_data[i];
						CalFunction.Calculate(ref motion_data1, ref motion_data2);
					}
					motion_data[index1] = motion_data1;  //把修改好的数据传回给原始的数据结构
				}
				
			}
			*/
			_executeFlag = true;
		}
		else
		{
			_executeFlag = false;
			motion_data.Clear();
			original_motion_data.Clear();
			tool_motion_info.Clear();
		}
		int return_type = (int)type_var;
		return return_type;
	}
}

public class FANUC_OI_M:CompileBase
{
	public FANUC_OI_M()
	{
		this.g_code_check = new G_FANUC_OI_M_M();
		this.m_code_check = new M_FANUC_OI_M();
	}
}

//计算补偿专用的类,将你的所有计算过程都集中到这个类里
public class CompensationCalculate
{
	public bool Has_circle = false;
	private float Radius1 = 0;
	private float Radius2 = 0;
	//计算半径补偿的主函数，public类型，对外开放的入口函数, 传入的参数为两个类，是引用类型，所以
	public void Calculate(ref MotionInfo motion_data1, ref MotionInfo motion_data2)
	{
		//读取补偿半径值
		if(motion_data1.D_Value == 0)
			Radius1 = 0;
		else
			Radius1 = LoadRadiusValue.D_Value(motion_data1.D_Value);
		if(motion_data2.D_Value == 0)
			Radius2 = 0;
		else
			Radius2 = LoadRadiusValue.D_Value(motion_data2.D_Value);
		
		//传入第一个数据结构的RadiusState变量, 判断补偿方式
		switch(motion_data1.RadiusState)
		{
		//起刀，需要两个数据结构
		case (int)RadiusType.CuttingStart:
			//起刀的函数
			CuttingStart(ref motion_data1, ref motion_data2);
			break;
		//正常补偿阶段，需要两个数据结构
		case (int)RadiusType.Normal:
			Normals(ref motion_data1, ref motion_data2);
			break;
		//补偿取消，需要第一个数据结构或者两个数据结构（当前只有G04，下一段再移动，补偿下一段）
		case (int)RadiusType.Cancel:
			Cancel(ref motion_data1, ref motion_data2);
			break;
		//在中间暂时取消补偿，只需要第一个数据结构
		case (int)RadiusType.CancelInMiddle:
			CancelInMiddle(ref motion_data1, ref motion_data2);
			break;
		default:
			break;
		}
	}
	
	//关于起刀的所有的操作在这里进行
	private void CuttingStart(ref MotionInfo motion_data1, ref MotionInfo motion_data2)
	{
		//当前肯定为直线，如果是圆弧起刀，我会在之前就报错
		//后一种运动方式判断并处理
		if(motion_data2.Motion_Type == (int)MotionType.Circular02) //直线 + G02圆弧
		{
			//当前起点: motion_data1.DisplayStart, 对应机床屏幕上显示的绝对坐标值
			//当前终点: motion_data1.DisplayTarget = motion_data2.DisplayStart
			//如果过程很杂，再在此处嵌入其他函数
			
		}
		else if(motion_data2.Motion_Type == (int)MotionType.Circular03) //直线 + G03圆弧
		{
			
		}
		else //直线 + 直线
		{
			
		}
		motion_data1.DisplayTarget = new Vector3(100, 100, 100);
		motion_data2.DisplayStart = new Vector3(-100, -100, -100);
	}
	
	private void Normals(ref MotionInfo motion_data1, ref MotionInfo motion_data2)
	{
		//if(遇到要增加圆弧的情况)
		//{
			//Has_Circle = true;
			//return;
		//}
		
		motion_data1.DisplayTarget = new Vector3(-100, -100, -100);
		motion_data2.DisplayStart = new Vector3(-100, -100, -100);
	}
	
	private void Cancel(ref MotionInfo motion_data1, ref MotionInfo motion_data2)
	{
		motion_data1.DisplayTarget = new Vector3(100, 100, 100);
		motion_data2.DisplayStart = new Vector3(-100, -100, -100);
	}
	
	private void CancelInMiddle(ref MotionInfo motion_data1, ref MotionInfo motion_data2)
	{
		motion_data1.DisplayTarget = new Vector3(100, 100, 100);
		motion_data2.DisplayStart = new Vector3(-100, -100, -100);
	}
	
	//新增圆弧情况处理
	public void CalculateForCircle(ref MotionInfo motion_data1, ref MotionInfo motion_data_circle, ref MotionInfo motion_data2)
	{
		//在这里处理加了圆弧的情况
	}
}

