using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Pieces selectedPiece;
    public LayerMask pieceLayer;
    public LayerMask nodeLayer;

    

    // Update is called once per frame
    void Update()
    {
        if (selectedPiece != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Plane plane = new Plane(Vector3.up, new Vector3(0, 0.6f, 0));

            float rayLenght;
            if (plane.Raycast(ray, out rayLenght))
            {
                Vector3 mousePoint = ray.GetPoint(rayLenght);

                selectedPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, mousePoint.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(selectedPiece != null)
            {
                SelectPiece();
            }
            if(Input.GetKeyUp(KeyCode.Mouse0))
            {
                if(selectedPiece == null)
                {
                    MovePiece();
                }
            }
        }
    }

    void SelectPiece()
    {
        //if (GameManager.Instance.isOnPromotion) { return; }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, pieceLayer))
        {
            Pieces piece = hit.transform.GetComponent<Pieces>();
            if(piece.color == GameManager.Instance.turn)
            {
                selectedPiece = piece;
                selectedPiece.ShowMoveableNode();
            }
        }
    }

    void MovePiece()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, nodeLayer))
        {
            GameManager.Instance.ClearNode();

            Pieces piece = selectedPiece;
            selectedPiece = null;

            piece.MovePiece(hit.transform.GetComponent<Node>().pos);
        }
        else
        {
            selectedPiece.transform.position = new Vector3(GameManager.Instance.Map[(int)selectedPiece.currentPos.x, (int)selectedPiece.currentPos.y].transform.position.x, 14, GameManager.Instance.Map[(int)selectedPiece.currentPos.x, (int)selectedPiece.currentPos.y].transform.position.z);
            selectedPiece = null;
            GameManager.Instance.ClearNode();
        }
    }
}
