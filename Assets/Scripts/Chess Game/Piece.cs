using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IObjectTweener))]
[RequireComponent(typeof(MaterialSetter))]
public abstract class Piece : MonoBehaviour
{
    private MaterialSetter materialSetter;
    public Board board { protected get; set;}
    public Vector2Int occupiedSquare { get; set; }
    public TeamColor team { get; set; }
    public bool hasMoved { get; private set; }

    public List<Vector2Int> availableMoves;

    private IObjectTweener tweener;
    public abstract List<Vector2Int> SelectAvailableSquares();

    private void Awake()
    {
        availableMoves = new List<Vector2Int>();
        tweener = GetComponent<IObjectTweener>();
        materialSetter = GetComponent<MaterialSetter>();
        hasMoved = false;
    }

    //Takes a material and sets it for this piece
    public void SetMaterial(Material material)
    {
        if (materialSetter == null)
            materialSetter = GetComponent <MaterialSetter>();
        materialSetter.SetSingleMaterial(material);
    }

    public bool IsFromSameTeam(Piece piece)
    {
        return team == piece.team;

    }

    public bool CanMoveTo(Vector2Int coords)
    {
        return availableMoves.Contains(coords);
    }

    public virtual void MovePiece(Vector2Int coords)
    {

    }

    protected void TryToAddMove(Vector2Int coords)
    {
        availableMoves.Add(coords);
    }

    //Sets the information of a piece. It's coordinates, color, and the board it's on.
    public void SetData(Vector2Int coords, TeamColor team, Board board)
    {
        SetTeam(team);
        SetOccupiedSquare(coords);
        this.board = board;
        transform.position = board.CalculatePositionFromCoords(coords);
    }

    //team setter
    private void SetTeam(TeamColor team)
    {
        this.team = team;
    }

    //coords setter
    private void SetOccupiedSquare(Vector2Int coords)
    {
        this.occupiedSquare = coords;
    }

}
