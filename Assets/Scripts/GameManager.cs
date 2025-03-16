using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject positionBoard;

    [SerializeField] Transform board;

    public Node[,] Map = new Node[8, 8];

    private static GameManager instance;

    public state turn; 


    public GameObject pawnPrefab_B;
    public GameObject pawnPrefab_W;
    public GameObject knightPrefab_B;
    public GameObject knightPrefab_W;
    public GameObject bishopPrefab_B;
    public GameObject bishopPrefab_W;
    public GameObject rookPrefab_B;
    public GameObject rookPrefab_W;
    public GameObject queenPrefab_B;
    public GameObject queenPrefab_W;
    public GameObject kingPrefab_B;
    public GameObject kingPrefab_W;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateMap();
        SetGame();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void CreateMap()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject obj = Instantiate(positionBoard, board);
                obj.transform.position = new Vector3(-5.25f + 1.5f * i, board.position.y, -5.25f + 1.5f * j);
                obj.name = $"{Convert.ToChar(65 + i)}{j + 1}";
                Map[i, j] = obj.GetComponent<Node>();
                obj.GetComponent<Node>().pos = new Coord(i, j);
                
            }
        }
    }

    void SetGame()
    {
        //king
        GameObject king_B = Instantiate(kingPrefab_B, Map[3, 7].transform.position, Quaternion.Euler(Vector3.right * -90));
        Map[3, 7].currentPiece = king_B.GetComponent<Pieces>();
        GameObject king_W = Instantiate(kingPrefab_W, Map[3, 0].transform.position, Quaternion.Euler(Vector3.right * -90));
        Map[3, 0].currentPiece = king_W.GetComponent<Pieces>();
        //queen
        GameObject queen_B = Instantiate(queenPrefab_B, Map[4, 7].transform.position, Quaternion.Euler(Vector3.right * -90));
        Map[4, 7].currentPiece = queen_B.GetComponent<Pieces>();
        GameObject queen_W = Instantiate(queenPrefab_W, Map[4, 0].transform.position, Quaternion.Euler(Vector3.right * -90));
        Map[4, 0].currentPiece = queen_B.GetComponent<Pieces>();
        //rook
        for (int i = 0; i < 8; i += 7)
        {
            GameObject rook = Instantiate(rookPrefab_B, Map[i, 7].transform.position, Quaternion.Euler(Vector3.right * -90));
            Map[i, 7].currentPiece = rook.GetComponent<Pieces>();
        }
        for (int i = 0; i < 8; i += 7)
        {
            GameObject rook = Instantiate(rookPrefab_W, Map[i, 0].transform.position, Quaternion.Euler(Vector3.right * -90));
            Map[i, 0].currentPiece = rook.GetComponent<Pieces>();
        }
        //bishop
        for (int i = 2; i < 6; i += 3)
        {
            GameObject bishop = Instantiate(bishopPrefab_B, Map[i, 7].transform.position, Quaternion.Euler(Vector3.right * -90));
            Map[i, 7].currentPiece = bishop.GetComponent<Pieces>();
        }
        for (int i = 2; i < 6; i += 3)
        {
            GameObject bishop = Instantiate(bishopPrefab_W, Map[i, 0].transform.position, Quaternion.Euler(Vector3.right * -90));
            Map[i, 0].currentPiece = bishop.GetComponent<Pieces>();
        }
        //knight
        for (int i = 1; i < 8; i += 5)
        {
            GameObject knight = Instantiate(knightPrefab_B, Map[i, 7].transform.position, Quaternion.Euler(Vector3.right * -90));
            Map[i, 7].currentPiece = knight.GetComponent<Pieces>();
        }
        for (int i = 1; i < 8; i += 5)
        {
            GameObject knight = Instantiate(knightPrefab_W, Map[i, 0].transform.position, Quaternion.Euler(Vector3.right * -90));
            Map[i, 0].currentPiece = knight.GetComponent<Pieces>();
        }
        //pawn
        for (int i = 0; i < 8; i++)
        {
            GameObject pawn = Instantiate(pawnPrefab_B, Map[i, 6].transform.position, Quaternion.Euler(Vector3.right * -90));
            Map[i, 6].currentPiece = pawn.GetComponent<Pieces>();
        }
        for (int i = 0; i < 8; i++)
        {
            GameObject pawn = Instantiate(pawnPrefab_W, Map[i, 1].transform.position, Quaternion.Euler(Vector3.right * -90));
            Map[i, 1].currentPiece = pawn.GetComponent<Pieces>();
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    public void ClearNode()
    {
        for (int i = 0;i < 8; i++)
        {
            for(int j = 0;j < 8; j++)
            {
                Map[i,j].gameObject.SetActive(false);
            }
        }
    }
}

public enum state
{
    black, white
}

