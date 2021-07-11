using System;
using UnityEngine;

[RequireComponent(typeof(PieceCreator))]

//This class will be placed on the game manager object, and will be used to generate the board with the right presets at the beginning of the game
public class ChessGameController : MonoBehaviour
{
    //This is that board starting layout that we want to generate. This object is scriptable inside of unity
    [SerializeField] private BoardLayout startingBoardLayout;
    //This is the Board game object in unity, which contains a transform, a box collider and a board script
    [SerializeField] private Board board;

    //This piece creator script will be our main tool for creating the right pieces at the right places with the right colors based off of our layout
    private PieceCreator pieceCreator;

    private void Awake()
    {
        SetDependencies();
    }

    //We create a reference to our pieceCreator, automatically attached to our GameController becaused it's a required component
    private void SetDependencies()
    {
        pieceCreator = GetComponent<PieceCreator>();
    }

    void Start()
    {
        StartNewGame();
    }

    private void StartNewGame()
    {
        CreatePiecesFromLayout(startingBoardLayout);
    }

    //Create the chessboard based off our selected layout
    private void CreatePiecesFromLayout(BoardLayout layout)
    {
        //The layout object contains an array off all the pieces and their info. Here, we go through this array,
        //and for each item, we create the piece at the right place with the right settings.
        for(int i=0;i < layout.GetPiecesCount(); i++)
        {
            Vector2Int squareCoords = layout.GetSquareCoordsAtIndex(i);
            TeamColor team = layout.GetSquareTeamColorAtIndex(i);
            string typeName = layout.GetSquarePieceNameAtIndex(i);

            Type type = Type.GetType(typeName);
            CreatePieceAndInitialize(squareCoords, team, type);
        }
    }

    //This method creates a singular piece and initializes it in our board.
    private void CreatePieceAndInitialize(Vector2Int squareCoords, TeamColor team, Type type)
    {
        Piece newPiece = pieceCreator.CreatePiece(type).GetComponent<Piece>();
        newPiece.SetData(squareCoords, team, board);

        Material teamMaterial = pieceCreator.GetTeamMaterial(team);
        newPiece.SetMaterial(teamMaterial);
    }
}
