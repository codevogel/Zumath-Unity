using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Nodes;
using States.Game;

namespace DevTools
{
    // Used to display the gameobjects that are in the gutter in the inspector view.
    public class GutterContents : MonoBehaviour
    {

        public LinkedList<NumberNode> linkedNodeList = new LinkedList<NumberNode>();
        public List<NumberNode> nodeList = new List<NumberNode>();

        void Start()
        {
            RefreshGutter();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameStateManager.GetGameState() != GameState.PAUSED && GameStateManager.GetGameState() != GameState.CHECKPOINT)
            {
                RefreshGutter();
            }
        }

        void RefreshGutter()
        {
            linkedNodeList = NodeManager.GetNodes();
            nodeList = linkedNodeList.ToList<NumberNode>();
        }
    }
}

