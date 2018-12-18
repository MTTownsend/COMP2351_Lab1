using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2351_Lab1
{
    class Input
    {
        public PongEntity ball1Ref;
        public PongEntity paddle1Ref;
        public PongEntity paddle2Ref;
        public Input(PongEntity ball1, PongEntity paddle1, PongEntity paddle2)
        {
            ball1Ref = ball1;
            paddle1Ref = paddle1;
            paddle2Ref = paddle2;
        }

        public static Vector2 GetKeyboardInputDirection(PlayerIndex _player)
        {
            Vector2 _rDirection;
            _rDirection.X = 0;
            _rDirection.Y = 0;

            KeyboardState keyboardState = Keyboard.GetState();
            if (_player == PlayerIndex.One)
            {
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    _rDirection.Y = -3;
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    _rDirection.Y = 3;
                }
                
            }
            if (_player == PlayerIndex.Two)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    _rDirection.Y = -3;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    _rDirection.Y = 3;
                }
                
            }
            return _rDirection;
        }
    }
}
