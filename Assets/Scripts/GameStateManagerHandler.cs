using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GameStateManagerHandler : MonoBehaviour
{

    void Start()
    {
        GameStateManager.Start();   
    }

    void Update()
    {
        GameStateManager.Update();
    }
}

