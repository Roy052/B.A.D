using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class UnitData
{
    public static Dictionary<int, UnitData> unitDatas = new Dictionary<int, UnitData>();

    public int id;
    public int nameId;
    public string res;
    public int atk;
    public int def;
    public int health;
    public int diceId;
}
