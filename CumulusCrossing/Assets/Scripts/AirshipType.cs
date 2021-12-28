using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT CREATES A GLOBAL ENUM, WHICH IN THIS CASE IS A LIST OF SHIP AND PORT TYPES I CAN ASSIGN TO GAME OBJECTS AND ACCESS IN OTHER SCRIPTS

public enum ShipOrPortType
{
    Green,
    Orange,
    Red,
    Purple,
}

public class AirshipType : MonoBehaviour
{
    public ShipOrPortType shipOrPortType;
}
