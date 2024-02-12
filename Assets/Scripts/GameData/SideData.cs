using System;
using System.Collections.Generic;

[Serializable]
public class SideAct
{
    public int targetType;
    public int sideType;
    public int value;
}

[Serializable]
public class SideData
{
    public static Dictionary<int, SideData> sideDatas = new Dictionary<int, SideData>();

    public int id;
    public string res;
    public List<SideAct> sideActs;
}

public class OriginalSideData
{
    public int id;
    public string res;
    public int targetType0;
    public int sideType0;
    public int value0;
    public int targetType1;
    public int sideType1;
    public int value1;
    public int targetType2;
    public int sideType2;
    public int value2;
}

