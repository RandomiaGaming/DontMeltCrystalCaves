using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapConverter : MonoBehaviour
{
    public TileBase Air = null;
    public TileBase Lava = null;
    public TileBase Ground = null;
    public TileBase NoJump = null;
    [Space]
    public Tilemap TargetTilemap = null;
    [Space]
    public Transform CheckPointParent = null;
    public Transform GoalGate = null;

    // Start is called before the first frame update
    void Start()
    {
        string output = "";

        for (int x = TargetTilemap.cellBounds.xMin; x < TargetTilemap.cellBounds.xMax; x++)
        {
            for (int y = TargetTilemap.cellBounds.yMin; y < TargetTilemap.cellBounds.yMax; y++)
            {
                TileBase tileBase = TargetTilemap.GetTile(new Vector3Int(x, y, 0));
                if (tileBase.name.ToLower() == Air.name.ToLower())
                {
                    output += $"{x};{y};Air;\n";
                }
                else if (tileBase.name.ToLower() == Ground.name.ToLower())
                {
                    output += $"{x};{y};Ground;\n";
                }
                else if (tileBase.name.ToLower() == Lava.name.ToLower())
                {
                    output += $"{x};{y};Lava;\n";
                }
                else if (tileBase.name.ToLower() == NoJump.name.ToLower())
                {
                    output += $"{x};{y};NoJump;\n";
                }
            }
        }

        for (int i = 0; i < CheckPointParent.childCount; i++)
        {
            Transform checkPoint = CheckPointParent.GetChild(i);

            Vector2 checkPointPosition = checkPoint.position;
            checkPointPosition -= new Vector2(0, 0.5f);
            Vector3Int posint = TargetTilemap.WorldToCell(checkPointPosition);
            output += $"{posint.x};{posint.y};CheckPoint;\n";
        }

        Vector2 goalGatePosition = GoalGate.position;
        goalGatePosition -= new Vector2(0, 0.5f);
        Vector3Int posint2 = TargetTilemap.WorldToCell(goalGatePosition);
        output += $"{posint2.x};{posint2.y};GoalGate;\n";

        System.IO.File.WriteAllText("D:\\Output.txt", output);
    }
}
