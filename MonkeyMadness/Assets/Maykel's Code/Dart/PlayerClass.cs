using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public class PlayerInfo
    {
        public int points;
        public int placement;
        public bool dead;
        
        public PlayerInfo(int _points, int _placement, bool _dead)
        {
            points = _points;
            placement = _placement;
            dead = _dead;
        }
    }

}
