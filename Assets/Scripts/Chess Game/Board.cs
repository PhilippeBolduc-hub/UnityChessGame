using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //Transform of what is considered the bottom left square of the board
    [SerializeField] private Transform bottomLeftSquareTransform;
    //The size of one square on the board. In our case, I'm a genius and set it up to be 1
    [SerializeField] private float squareSize;

    //Our board layout doesn't deal with array values. So, for a piece based off of the board layout,
    // we use the bottom left square of the board as a reference to place the rest of the pieces at the right spot.
    //Therefore, this method takes coordinates of a piece from our board layout, and calculates the right placement on the board.
    public Vector3 CalculatePositionFromCoords(Vector2Int coords)
    {
        return bottomLeftSquareTransform.position + new Vector3(coords.x * squareSize, 0f, coords.y * squareSize);
    }
}
