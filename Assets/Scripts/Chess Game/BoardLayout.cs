using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Board/Layout")]

public class BoardLayout : ScriptableObject
{
    [Serializable]
    private class BoardSquareSetup
    {
        public Vector2Int position;
        public PieceType pieceType;
        public TeamColor teamColor;

    }

    [SerializeField] private BoardSquareSetup[] boardSquares;

    public int GetPiecesCount()
    {
        return boardSquares.Length;
    }

    public Vector2Int GetSquareCoordsAtIndex(int index)
    {
        bool invalidIndex = false;
        if(isIndexInvalid(index))
        {
            Debug.LogError("Index of piece is out of range");
            invalidIndex = true;
        }
        return invalidIndex == true ? new Vector2Int(-1, -1) : new Vector2Int(boardSquares[index].position.x - 1, boardSquares[index].position.y - 1);
    }

    public string GetSquarePieceNameAtIndex(int index)
    {
        bool invalidIndex = false;
        if (isIndexInvalid(index))
        {
            Debug.LogError("Index of piece is out of range");
            invalidIndex = true;
        }
        return invalidIndex == true ? "" : boardSquares[index].pieceType.ToString();

    }

    public TeamColor GetSquareTamColorAtIndex(int index)
    {
        bool invalidIndex = false;
        if (isIndexInvalid(index))
        {
            Debug.LogError("Index of piece is out of range");
            invalidIndex = true;
        }
        return invalidIndex == true ? TeamColor.Black : boardSquares[index].teamColor;

    }

    public bool isIndexInvalid(int index)
    {

        return boardSquares.Length <= index ? true : false;
    }
}
