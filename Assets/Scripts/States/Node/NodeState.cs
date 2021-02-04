using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States.Node
{
    // Represents the states a node can have
    public enum NodeState
    {
        // This node is shot out of the cannon and on it's way as a projectile
        PROJECTILE,
        // This node is part of the nodes in the gutter
        GUTTER,
        // This node is shown in the middle of the cannon as a preview of the projectile node
        PREVIEW
    }
}

