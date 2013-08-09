using UnityEngine;
using System.Collections;

public class ButtonShowOff : MonoBehaviour {
	ControlPanel Main;
	MDIFunctionModule MDIFunction_Script;
	MDIInputModule MDIInput_Script;
	MDIEditModule MDIEdit_Script;
	AuxiliaryFunctionModule AuxiliaryFunction_Script;
	MachineFunctionModule MachineFunction_Script;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		MDIFunction_Script = gameObject.GetComponent<MDIFunctionModule>();
		MDIInput_Script = gameObject.GetComponent<MDIInputModule>();
		MDIEdit_Script = gameObject.GetComponent<MDIEditModule>();
		AuxiliaryFunction_Script = gameObject.GetComponent<AuxiliaryFunctionModule>();
		MachineFunction_Script = gameObject.GetComponent<MachineFunctionModule>();
	}
	
	public void ButtonEnlarge()
	{
		Event e = Event.current;
		
		//MDIInput Region
		if(MDIInput_Rect(0, 0).Contains(e.mousePosition))  //pO
			GUI.Label(MDIInput_Button(0, 0), "", Main.sty_pO);
		
		if(MDIInput_Rect(1, 0).Contains(e.mousePosition))  //qN
			GUI.Label(MDIInput_Button(1, 0), "", Main.sty_qN);
		
		if(MDIInput_Rect(2, 0).Contains(e.mousePosition))  //rG
			GUI.Label(MDIInput_Button(2, 0), "", Main.sty_rG);
		
		if(MDIInput_Rect(3, 0).Contains(e.mousePosition))  //a7
			GUI.Label(MDIInput_Button(3, 0), "", Main.sty_a7);
		
		if(MDIInput_Rect(4, 0).Contains(e.mousePosition))  //b8
			GUI.Label(MDIInput_Button(4, 0), "", Main.sty_b8);
		
		if(MDIInput_Rect(5, 0).Contains(e.mousePosition))  //c9
			GUI.Label(MDIInput_Button(5, 0), "", Main.sty_c9);
		
		if(MDIInput_Rect(0, 1).Contains(e.mousePosition))  //uX
			GUI.Label(MDIInput_Button(0, 1), "", Main.sty_uX);
		
		if(MDIInput_Rect(1, 1).Contains(e.mousePosition))  //vY
			GUI.Label(MDIInput_Button(1, 1), "", Main.sty_vY);
		
		if(MDIInput_Rect(2, 1).Contains(e.mousePosition))  //wZ
			GUI.Label(MDIInput_Button(2, 1), "", Main.sty_wZ);
		
		if(MDIInput_Rect(3, 1).Contains(e.mousePosition))  //four
			GUI.Label(MDIInput_Button(3, 1), "", Main.sty_four);
		
		if(MDIInput_Rect(4, 1).Contains(e.mousePosition))  //five
			GUI.Label(MDIInput_Button(4, 1), "", Main.sty_five);
		
		if(MDIInput_Rect(5, 1).Contains(e.mousePosition))  //six
			GUI.Label(MDIInput_Button(5, 1), "", Main.sty_six);
		
		if(MDIInput_Rect(0, 2).Contains(e.mousePosition))  //iM
			GUI.Label(MDIInput_Button(0, 2), "", Main.sty_iM);
		
		if(MDIInput_Rect(1, 2).Contains(e.mousePosition))  //jS
			GUI.Label(MDIInput_Button(1, 2), "", Main.sty_jS);
		
		if(MDIInput_Rect(2, 2).Contains(e.mousePosition))  //kT
			GUI.Label(MDIInput_Button(2, 2), "", Main.sty_kT);
		
		if(MDIInput_Rect(3, 2).Contains(e.mousePosition))  //one
			GUI.Label(MDIInput_Button(3, 2), "", Main.sty_one);
		
		if(MDIInput_Rect(4, 2).Contains(e.mousePosition))  //two
			GUI.Label(MDIInput_Button(4, 2), "", Main.sty_two);
		
		if(MDIInput_Rect(5, 2).Contains(e.mousePosition))  //three
			GUI.Label(MDIInput_Button(5, 2), "", Main.sty_three);
		
		if(MDIInput_Rect(0, 3).Contains(e.mousePosition))  //lF
			GUI.Label(MDIInput_Button(0, 3), "", Main.sty_lF);
		
		if(MDIInput_Rect(1, 3).Contains(e.mousePosition))  //dH
			GUI.Label(MDIInput_Button(1, 3), "", Main.sty_dH);
		
		if(MDIInput_Rect(2, 3).Contains(e.mousePosition))  //eEOB
			GUI.Label(MDIInput_Button(2, 3), "", Main.sty_eEOB);
		
		if(MDIInput_Rect(3, 3).Contains(e.mousePosition))  //ap
			GUI.Label(MDIInput_Button(3, 3), "", Main.sty_ap);
		
		if(MDIInput_Rect(4, 3).Contains(e.mousePosition))  //zero
			GUI.Label(MDIInput_Button(4, 3), "", Main.sty_zero);
		
		if(MDIInput_Rect(5, 3).Contains(e.mousePosition))  //po
			GUI.Label(MDIInput_Button(5, 3), "", Main.sty_po);
		
		if(MDIInput_Rect(3, 4).Contains(e.mousePosition))  //sh
			GUI.Label(MDIInput_Button(3, 4), "", Main.sty_sh);
		
		//MDIFunction Region
		if(MDIFunction_Rect(0, 4).Contains(e.mousePosition))  //POS
			GUI.Label(MDIFunction_Button(0, 4), "", Main.sty_Pos);
		
		if(MDIFunction_Rect(1, 4).Contains(e.mousePosition))  //PROG
			GUI.Label(MDIFunction_Button(1, 4), "", Main.sty_PROG);
		
		if(MDIFunction_Rect(2, 4).Contains(e.mousePosition))  //SET
			GUI.Label(MDIFunction_Button(2, 4), "", Main.sty_SET);
		
		if(MDIFunction_Rect(5, 4).Contains(e.mousePosition))  //INPUT
			GUI.Label(MDIFunction_Button(5, 4), "", Main.sty_INPUT);
		
		if(MDIFunction_Rect(0, 5).Contains(e.mousePosition))  //SYSTEM
			GUI.Label(MDIFunction_Button(0, 5), "", Main.sty_SYSTEM);
		
		if(MDIFunction_Rect(1, 5).Contains(e.mousePosition))  //MESSAGE
			GUI.Label(MDIFunction_Button(1, 5), "", Main.sty_MESSAGE);

		if(MDIFunction_Rect(2, 5).Contains(e.mousePosition))  //GRPH
			GUI.Label(MDIFunction_Button(2, 5), "", Main.sty_GRPH);
		
		if(MDIFunction_Rect(5, 6).Contains(e.mousePosition))  //HELP
			GUI.Label(MDIFunction_Button(5, 6), "", Main.sty_HELP);
		
		if(MDIFunction_Rect(5, 7).Contains(e.mousePosition))  //RESET
			GUI.Label(MDIFunction_Button(5, 7), "", Main.sty_RESET);
		
		//MDIEdit Region
		if(MDIEdit_Rect(4, 4).Contains(e.mousePosition))  //CAN
			GUI.Label(MDIEdit_Button(4, 4), "", Main.sty_CAN);
		
		if(MDIEdit_Rect(3, 5).Contains(e.mousePosition))  //ALTER
			GUI.Label(MDIEdit_Button(3, 5), "", Main.sty_ALTER);
		
		if(MDIEdit_Rect(4, 5).Contains(e.mousePosition))  //INSERT
			GUI.Label(MDIEdit_Button(4, 5), "", Main.sty_INSERT);
		
		if(MDIEdit_Rect(5, 5).Contains(e.mousePosition))  //DELETE
			GUI.Label(MDIEdit_Button(5, 5), "", Main.sty_DELETE);
		
		if(MDIEdit_Rect(0, 6).Contains(e.mousePosition))  //PAGEu
			GUI.Label(MDIEdit_Button(0, 6), "", Main.sty_PAGEu);
		
		if(MDIEdit_Rect(0, 7).Contains(e.mousePosition))  //PAGEd
			GUI.Label(MDIEdit_Button(0, 7), "", Main.sty_PAGEd);
		
		//AuxiliaryFunction Region
		if(AuxiliaryFunction_Rect(0, 0).Contains(e.mousePosition))  //COOL
			GUI.Label(AuxiliaryFunction_Button(0, 0), "", Main.sty_COOL);
		
		if(AuxiliaryFunction_Rect(2, 0).Contains(e.mousePosition))  //MHS
			GUI.Label(AuxiliaryFunction_Button(2, 0), "", Main.sty_MHS);
		
		if(AuxiliaryFunction_Rect(0, 1).Contains(e.mousePosition))  //ATCW
			GUI.Label(AuxiliaryFunction_Button(0, 1), "", Main.sty_ATCW);
		
		if(AuxiliaryFunction_Rect(1, 1).Contains(e.mousePosition))  //ATCCW
			GUI.Label(AuxiliaryFunction_Button(1, 1), "", Main.sty_ATCCW);
		
		if(AuxiliaryFunction_Rect(2, 1).Contains(e.mousePosition))  //MHRN
			GUI.Label(AuxiliaryFunction_Button(2, 1), "", Main.sty_MHRN);
		
		if(AuxiliaryFunction_Rect(0, 2).Contains(e.mousePosition))  //FOR
			GUI.Label(AuxiliaryFunction_Button(0, 2), "", Main.sty_FOR);
		
		if(AuxiliaryFunction_Rect(1, 2).Contains(e.mousePosition))  //BACK
			GUI.Label(AuxiliaryFunction_Button(1, 2), "", Main.sty_BACK);
		
		//MachineFunction Region
		if(MachineFunction_Rect(0, 0).Contains(e.mousePosition))  //MLK
			GUI.Label(MachineFunction_Button(0, 0), "", Main.sty_MLK);
		
		if(MachineFunction_Rect(1, 0).Contains(e.mousePosition))  //DRN
			GUI.Label(MachineFunction_Button(1, 0), "", Main.sty_DRN);
		
		if(MachineFunction_Rect(2, 0).Contains(e.mousePosition))  //BDT
			GUI.Label(MachineFunction_Button(2, 0), "", Main.sty_BDT);
		
		if(MachineFunction_Rect(3, 0).Contains(e.mousePosition))  //SBK
			GUI.Label(MachineFunction_Button(3, 0), "", Main.sty_SBK);
		
		if(MachineFunction_Rect(0, 1).Contains(e.mousePosition))  //OSP
			GUI.Label(MachineFunction_Button(0, 1), "", Main.sty_OSP);
		
		if(MachineFunction_Rect(1, 1).Contains(e.mousePosition))  //ZLOCK
			GUI.Label(MachineFunction_Button(1, 1), "", Main.sty_ZLOCK);
		
		//Manual Region
		if(Manual_Rect(0, 0).Contains(e.mousePosition))  //S4P
			GUI.Label(Manual_Button(0, 0), "", Main.sty_S4P);
		
		if(Manual_Rect(1, 0).Contains(e.mousePosition))  //SYN
			GUI.Label(Manual_Button(1, 0), "", Main.sty_SYN);
		
		if(Manual_Rect(2, 0).Contains(e.mousePosition))  //SZP
			GUI.Label(Manual_Button(2, 0), "", Main.sty_SZP);
		
		if(Manual_Rect(0, 1).Contains(e.mousePosition))  //SXP
			GUI.Label(Manual_Button(0, 1), "", Main.sty_SXP);
		
		if(Manual_Rect(1, 1).Contains(e.mousePosition))  //SRAPID
			GUI.Label(Manual_Button(1, 1), "", Main.sty_SRAPID);
		
		if(Manual_Rect(2, 1).Contains(e.mousePosition))  //SXN
			GUI.Label(Manual_Button(2, 1), "", Main.sty_SXN);
		
		if(Manual_Rect(0, 2).Contains(e.mousePosition))  //S4N
			GUI.Label(Manual_Button(0, 2), "", Main.sty_S4N);
		
		if(Manual_Rect(1, 2).Contains(e.mousePosition))  //SYP
			GUI.Label(Manual_Button(1, 2), "", Main.sty_SYP);
		
		if(Manual_Rect(2, 2).Contains(e.mousePosition))  //SZN
			GUI.Label(Manual_Button(2, 2), "", Main.sty_SZN);
		
		//Spindle Region
		if(Spindle_Rect(0, 0).Contains(e.mousePosition))  //SF0
			GUI.Label(Spindle_Button(0, 0), "", Main.sty_SF0);
		
		if(Spindle_Rect(1, 0).Contains(e.mousePosition))  //SF25
			GUI.Label(Spindle_Button(1, 0), "", Main.sty_SF25);
		
		if(Spindle_Rect(2, 0).Contains(e.mousePosition))  //SF50
			GUI.Label(Spindle_Button(2, 0), "", Main.sty_SF50);
		
		if(Spindle_Rect(3, 0).Contains(e.mousePosition))  //SF100
			GUI.Label(Spindle_Button(3, 0), "", Main.sty_SF100);
		
		if(Spindle_Rect(1, 1).Contains(e.mousePosition))  //SDOWN
			GUI.Label(Spindle_Button(1, 1), "", Main.sty_SDOWN);
		
		if(Spindle_Rect(2, 1).Contains(e.mousePosition))  //SHUNDRED
			GUI.Label(Spindle_Button(2, 1), "", Main.sty_SHUNDRED);
		
		if(Spindle_Rect(3, 1).Contains(e.mousePosition))  //SUP
			GUI.Label(Spindle_Button(3, 1), "", Main.sty_SUP);
		
		if(Spindle_Rect(0, 2).Contains(e.mousePosition))  //SORIENT
			GUI.Label(Spindle_Button(0, 2), "", Main.sty_SORIENT);
		
		if(Spindle_Rect(1, 2).Contains(e.mousePosition))  //SCW
			GUI.Label(Spindle_Button(1, 2), "", Main.sty_SCW);
		
		if(Spindle_Rect(2, 2).Contains(e.mousePosition))  //SSTOP
			GUI.Label(Spindle_Button(2, 2), "", Main.sty_SSTOP);
		
		if(Spindle_Rect(3, 2).Contains(e.mousePosition))  //SCCW
			GUI.Label(Spindle_Button(3, 2), "", Main.sty_SCCW);
	}
	
	//MDIFunction位置区域
	Rect MDIFunction_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIFunction_Script.l_x + column*MDIFunction_Script.left_x + MDIFunction_Script.btn_width/4)/1000f*Main.width;
		rect_return.y = (MDIFunction_Script.l_y+row*MDIFunction_Script.left_y + MDIFunction_Script.btn_height/4)/1000f*Main.height;
		rect_return.width = (MDIFunction_Script.btn_width/2)/1000f*Main.width;
		rect_return.height = (MDIFunction_Script.btn_height/2)/1000f*Main.height;
		return rect_return;
	}
	
	//MDIFunction显示区域
	Rect MDIFunction_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIFunction_Script.l_x + (column - 1)*MDIFunction_Script.left_x + MDIFunction_Script.btn_width/2)/1000f*Main.width;
		rect_return.y = (MDIFunction_Script.l_y+(row - 1)*MDIFunction_Script.left_y + MDIFunction_Script.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*MDIFunction_Script.left_x/1000f*Main.width;
		rect_return.height = 2*MDIFunction_Script.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//MDIInput位置区域
	Rect MDIInput_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIInput_Script.l_x + column*MDIInput_Script.left_x + MDIInput_Script.btn_width/4)/1000f*Main.width;
		rect_return.y = (MDIInput_Script.l_y+row*MDIInput_Script.left_y + MDIInput_Script.btn_height/4)/1000f*Main.height;
		rect_return.width = (MDIInput_Script.btn_width/2)/1000f*Main.width;
		rect_return.height = (MDIInput_Script.btn_height/2)/1000f*Main.height;
		return rect_return;
	}
	
	//MDIInput显示区域
	Rect MDIInput_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIInput_Script.l_x + (column - 1)*MDIInput_Script.left_x + MDIInput_Script.btn_width/2)/1000f*Main.width;
		rect_return.y = (MDIInput_Script.l_y+(row - 1)*MDIInput_Script.left_y + MDIInput_Script.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*MDIInput_Script.left_x/1000f*Main.width;
		rect_return.height = 2*MDIInput_Script.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//MDIEdit位置区域
	Rect MDIEdit_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIEdit_Script.l_x + column*MDIEdit_Script.left_x + MDIEdit_Script.btn_width/4)/1000f*Main.width;
		rect_return.y = (MDIEdit_Script.l_y+row*MDIEdit_Script.left_y + MDIEdit_Script.btn_height/4)/1000f*Main.height;
		rect_return.width = (MDIEdit_Script.btn_width/2)/1000f*Main.width;
		rect_return.height = (MDIEdit_Script.btn_height/2)/1000f*Main.height;
		return rect_return;
	}
	
	//MDIEdit显示区域
	Rect MDIEdit_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIEdit_Script.l_x + (column - 1)*MDIEdit_Script.left_x + MDIEdit_Script.btn_width/2)/1000f*Main.width;
		rect_return.y = (MDIEdit_Script.l_y+(row - 1)*MDIEdit_Script.left_y + MDIEdit_Script.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*MDIEdit_Script.left_x/1000f*Main.width;
		rect_return.height = 2*MDIEdit_Script.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//AuxiliaryFunction位置区域
	Rect AuxiliaryFunction_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (AuxiliaryFunction_Script.l_x + column*AuxiliaryFunction_Script.left_x + AuxiliaryFunction_Script.btn_width/4)/1000f*Main.width;
		rect_return.y = (AuxiliaryFunction_Script.l_y+row*AuxiliaryFunction_Script.left_y + AuxiliaryFunction_Script.btn_height/4)/1000f*Main.height;
		rect_return.width = (AuxiliaryFunction_Script.btn_width/2)/1000f*Main.width;
		rect_return.height = (AuxiliaryFunction_Script.btn_height/2)/1000f*Main.height;
		return rect_return;
	}
	
	//AuxiliaryFunction显示区域
	Rect AuxiliaryFunction_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (AuxiliaryFunction_Script.l_x + (column - 1)*AuxiliaryFunction_Script.left_x + AuxiliaryFunction_Script.btn_width/2)/1000f*Main.width;
		rect_return.y = (AuxiliaryFunction_Script.l_y+(row - 1)*AuxiliaryFunction_Script.left_y + AuxiliaryFunction_Script.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*AuxiliaryFunction_Script.left_x/1000f*Main.width;
		rect_return.height = 2*AuxiliaryFunction_Script.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//MachineFunction位置区域
	Rect MachineFunction_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MachineFunction_Script.l_x + column*MachineFunction_Script.left_x + MachineFunction_Script.btn_width/4)/1000f*Main.width;
		rect_return.y = (MachineFunction_Script.l_y+row*MachineFunction_Script.left_y + MachineFunction_Script.btn_height/4)/1000f*Main.height;
		rect_return.width = (MachineFunction_Script.btn_width/2)/1000f*Main.width;
		rect_return.height = (MachineFunction_Script.btn_height/2)/1000f*Main.height;
		return rect_return;
	}
	
	//MachineFunction显示区域
	Rect MachineFunction_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MachineFunction_Script.l_x + (column - 1)*MachineFunction_Script.left_x + MachineFunction_Script.btn_width/2)/1000f*Main.width;
		rect_return.y = (MachineFunction_Script.l_y+(row - 1)*MachineFunction_Script.left_y + MachineFunction_Script.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*MachineFunction_Script.left_x/1000f*Main.width;
		rect_return.height = 2*MachineFunction_Script.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//Manual位置区域
	Rect Manual_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (Main.Axis_x + column*Main.left_x + Main.btn_width/4)/1000f*Main.width;
		rect_return.y = (Main.Axis_y+row*Main.left_y + Main.btn_height/4)/1000f*Main.height;
		rect_return.width = (Main.btn_width/2)/1000f*Main.width;
		rect_return.height = (Main.btn_height/2)/1000f*Main.height;
		return rect_return;
	}
	
	//Manual显示区域
	Rect Manual_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (Main.Axis_x + (column - 1)*Main.left_x + Main.btn_width/2)/1000f*Main.width;
		rect_return.y = (Main.Axis_y+(row - 1)*Main.left_y + Main.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*Main.left_x/1000f*Main.width;
		rect_return.height = 2*Main.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//Spindle位置区域
	Rect Spindle_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (Main.Rapid_x + column*Main.left_x + Main.btn_width/4)/1000f*Main.width;
		rect_return.y = (Main.Rapid_y+row*Main.left_y + Main.btn_height/4)/1000f*Main.height;
		rect_return.width = (Main.btn_width/2)/1000f*Main.width;
		rect_return.height = (Main.btn_height/2)/1000f*Main.height;
		return rect_return;
	}
	
	//Spindle显示区域
	Rect Spindle_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (Main.Rapid_x + (column - 1)*Main.left_x + Main.btn_width/2)/1000f*Main.width;
		rect_return.y = (Main.Rapid_y+(row - 1)*Main.left_y + Main.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*Main.left_x/1000f*Main.width;
		rect_return.height = 2*Main.left_y/1000f*Main.height;
		return rect_return;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
