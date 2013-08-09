using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//直线
public class LineInfo
{
	public List<int> index;
	public List<Vector3> start_point;
	public List<Vector3> end_point;
	public List<Color> line_color;
	
	public LineInfo()
	{
		index = new List<int>(); 
		start_point = new List<Vector3>();
		end_point = new List<Vector3>();
		line_color = new List<Color>();
	}
	
	public void Add(int IndexNum, Vector3 StartPoint, Vector3 EndPoint, Color LineColor)
	{
		index.Add(IndexNum);
		Vector3 temp_vec = StartPoint;
		temp_vec.z = -StartPoint.z;
		start_point.Add(temp_vec);
		temp_vec = EndPoint;
		temp_vec.z = -EndPoint.z;
		end_point.Add(temp_vec);
		line_color.Add(LineColor);
	}
	
	public int Count()
	{
		return start_point.Count;
	}
	
	public void Clear()
	{
		index.Clear();
		start_point.Clear();
		end_point.Clear();
		line_color.Clear();
	}
	
	public void RemoveAt(int indexNum)
	{
		index.RemoveAt(indexNum);
		start_point.RemoveAt(indexNum);
		end_point.RemoveAt(indexNum);
		line_color.RemoveAt(indexNum);
	}
	
	public string CurrentString(int k)
	{
		return index[k]+": "+start_point[k].x+","+start_point[k].y+","+start_point[k].z+"; "+end_point[k].x+","+end_point[k].y+","+end_point[k].z;
	}
}

//圆弧
public class ArcInfo
{
	public List<Vector3> start_point;
	public List<Vector3> end_point;
	public List<Vector3> centre_point;
	public List<float> angle;
	public List<float> radius;
	public List<Color> line_color;
	
	public ArcInfo()
	{
		start_point = new List<Vector3>();
		end_point = new List<Vector3>();
		centre_point = new List<Vector3>();
		angle = new List<float>();
		radius = new List<float>();
		line_color = new List<Color>();
	}
	
	public int Count()
	{
		return start_point.Count;
	}
	
	public void Clear()
	{
		start_point.Clear();
		end_point.Clear();
		centre_point.Clear();
		angle.Clear();
		radius.Clear();
		line_color.Clear();
	}
	
	public void RemoveAt(int index)
	{
		start_point.RemoveAt(index);
		end_point.RemoveAt(index);
		centre_point.RemoveAt(index);
		angle.RemoveAt(index);
		radius.RemoveAt(index);
		line_color.RemoveAt(index);
	}
	
}