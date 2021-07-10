using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Board/Layout")]

public class BoardLayout : ScriptableObject
{
    [Serializable]

    //Class containing the information of a square on the chessboard (Position, the type of piece on it, and the team color
    private class BoardSquareSetup
    {
        public Vector2Int position;
        public PieceType pieceType;
        public TeamColor teamColor;

    }
    //Array with all the starting pieces and their information (Position, type and color)
    [SerializeField] private BoardSquareSetup[] boardSquares;

    //Gives the amount of pieces in the boardSquares array
    public int GetPiecesCount()
    {
        return boardSquares.Length;
    }

    //Takes the index of a BoardSquareSetup object in the boardSquares array and returns it's position. 
    //If the index is invalid, returns the (-1,-1) position with a log error
    public Vector2Int GetSquareCoordsAtIndex(int index)
    {
        bool invalidIndex = false;
        if(isIndexInvalid(index))
        {
            invalidIndex = true;
        }
        return invalidIndex == true ? new Vector2Int(-1, -1) : new Vector2Int(boardSquares[index].position.x - 1, boardSquares[index].position.y - 1);
    }

    //Takes the index of a BoardSquareSetup object in the boardSquares array and returns it's piece type. 
    //If the index is invalid, returns the "" empty string with a log error
    public string GetSquarePieceNameAtIndex(int index)
    {
        bool invalidIndex = false;
        if (isIndexInvalid(index))
        {
            invalidIndex = true;
        }
        return invalidIndex == true ? "" : boardSquares[index].pieceType.ToString();

    }

    //Takes the index of a BoardSquareSetup object in the boardSquares array and returns it's color. 
    //If the index is invalid, returns the Black color with a log error
    public TeamColor GetSquareTamColorAtIndex(int index)
    {
        bool invalidIndex = false;
        if (isIndexInvalid(index))
        {
            invalidIndex = true;
        }
        return invalidIndex == true ? TeamColor.Black : boardSquares[index].teamColor;

    }

    //Checks if a given index is invalid with the current boardSquares array. If it is, return true with a Log error
    private bool isIndexInvalid(int index)
    {
        if(boardSquares.Length <= index)
        {
            Debug.LogError("Index of piece is out of range");
        }
        return boardSquares.Length <= index ? true : false;
    }
}
