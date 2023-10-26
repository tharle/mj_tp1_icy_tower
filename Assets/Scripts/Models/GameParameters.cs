using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters
{
    public class AnimationPlayer 
    { 
        public const string IS_DEAD = "is_dead";
        public const string IS_GROUND = "is_ground";
        public const string VELOCITY_X = "velocity_x";
    }

    public class LayerNames 
    {
        public const string PLATAFORM = "Plataform";
        public const string DESTROYER = "Destroyer";
        
    }

    public class InputNames {
        public const string AXIS_HORIZONTAL = "Horizontal";
    }

    public class SceneNames {
        public const string MAIN_MENU = "MainMenu";
        public const string GAME = "Game";
    }
}
