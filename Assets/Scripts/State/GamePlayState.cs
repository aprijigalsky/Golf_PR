using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class GamePlayState : GameState
    {
        public LevelContr levelContr;
        public PlayerContr playerContr;
        public GameState gameOverState;
        public TMP_Text scoreText;


        protected override void OnEnable()
        {
            base.OnEnable();

            levelContr.enabled = true;
            playerContr.enabled = true;

            GameEvents.onCollisionStones += OnGameOver;
            GameEvents.onStickHit += OnStickHit;
            OnStickHit();
        }

        private void OnStickHit()
        {
            scoreText.text = $" Score: {levelContr.score}";
        }

        private void OnGameOver()
        {
            Exit();
            gameOverState.Enter();
        }
        protected override void OnDisable()
        {
            base.OnDisable();

            GameEvents.onCollisionStones -= OnGameOver;

            levelContr.enabled = false;
            playerContr.enabled = false;
        }
    }
}
