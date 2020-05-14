using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Nodes;
using States.Game;

namespace DevTools
{
    public class GutterContents : MonoBehaviour
    {

        public LinkedList<NumberNode> nodes = new LinkedList<NumberNode>();
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
            nodes = NodeManager.GetNodes();
            nodeList = nodes.ToList<NumberNode>();
        }
    }
}

