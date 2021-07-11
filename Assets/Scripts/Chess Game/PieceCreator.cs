using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PieceCreator : MonoBehaviour
{
    //Array containing all the prefabs that we use for pieces. If we wanted to add a new piece to the game,
    //we would have to add it's prefab in this array
    [SerializeField] private GameObject[] piecesPrefabs;
    //Material of black color for the black team
    [SerializeField] private Material blackMaterial;
    //Material of black color for the white team
    [SerializeField] private Material whiteMaterial;

    //Dictionary containing a string and a prefab. For example, the string "Rook" will be matched with the prefab "Rook"
    //ATTENTION : Prefabs in the prefab folder must have a corresponding name in the enum TeamColor, otherwise this script will not work
    private Dictionary<string, GameObject> nameToPieceDict = new Dictionary<string, GameObject>();

    private void Awake()
    {
        //For each prefab in our array, we create the corresponding value in the dictionary
        //For example, for a prefab called Rook, we add to the dictionary nameToPieceDict <"Rook",Rook>
        foreach (var piece in piecesPrefabs)
        {
            nameToPieceDict.Add(piece.GetComponent<Piece>().GetType().ToString(), piece);
        }
    }

    //From the type of a piece, we find it's corresponding prefab in the dictionary, create a copy of 
    //that prefab, instantiate it (To note that the prefabs all have their corresponding piece script)
    //and return it in this method.
    public GameObject CreatePiece(Type type)
    {
        GameObject prefab = nameToPieceDict[type.ToString()];
        bool foundPrefab = false;
        if (prefab)
        {
            Instantiate(prefab);
            foundPrefab = true;
        }

        return foundPrefab ? prefab: null;
    }

    //Returns the proper material of a piece from it's TeamColor enum value
    public Material GetTeamMaterial(TeamColor team)
    {
        return team == TeamColor.White ? whiteMaterial : blackMaterial;
    }
}
