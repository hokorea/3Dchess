using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    public string pieceType;
    public state color;
    public Coord currentPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMoveableNode()
    {
        List<Node> movableNode = GetMovableNode();
        for(int i = 0; i < movableNode.Count; i++)
        {
            movableNode[i].gameObject.SetActive(true);
        }
    }

    public virtual List<Node> GetMovableNode()
    {
        return null;
    }

    public virtual void MovePiece(Coord pos)
    {
        currentPos = pos;
        transform.position = new Vector3(GameManager.Instance.Map[pos.x, pos.y].transform.position.x, 0.6f, GameManager.Instance.Map[pos.x, pos.y].transform.position.z);

        if (GameManager.Instance.Map[pos.x, pos.y].currentPiece != null)
        {
            //GameManager.Instance.Map[pos.x, pos.y].currentPiece.
        }
        GameManager.Instance.Map[pos.x, pos.y].currentPiece = this;
    }


}

[Serializable]
public class Coord
{
    public int x;
    public int y;

    public Coord(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public bool IsOverBoard()
    {
        if(x > 7 || x < 0 || y > 7 || y < 0)
        {
            return true;
        }
        return false;
    }
    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public static Coord operator +(Coord a, Coord b)
    {
        return new Coord(a.x + b.x, a.y + b.y);
    }
    public static bool operator ==(Coord a, Coord b) 
    {
        return a.x == b.x && a.y == b.y;
    }
    public static bool operator !=(Coord a, Coord b)
    {
        return a.x != b.x || a.y != b.y;
    }
    public static float Distance(Coord a, Coord b)
    {
        float num = a.x - b.x;
        float num2 = a.y - b.y;
        return (float)Math.Sqrt(num * num + num2 * num2);
    }
}