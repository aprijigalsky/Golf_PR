using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameOverState : GameState
    {
        public GameState mainMenuState;
        public LevelContr levelContr;

        public void Restart()
        {
            levelContr.ClearStone();

            Exit();
            mainMenuState.Enter();
        }
    }
}
