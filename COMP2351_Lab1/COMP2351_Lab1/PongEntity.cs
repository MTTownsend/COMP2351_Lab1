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
    abstract class PongEntity:Entity
    {
        protected Vector2 _location;
        protected float _mSpeed;
        protected Vector2 _velocity;
        protected Texture2D _texture;


        public PongEntity()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.AntiqueWhite);
        }

        public virtual void Update(Vector2 velocity)
        {

        }

        public int GetLocX()
        {
            return (int)_location.X;
        }

        public int GetLocY()
        {
            return (int)_location.Y;
        }

        public void SetLocation(float xPos, float yPos)
        {
            _location.X = xPos;
            _location.Y = yPos;
        }

        public void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }

        public Texture2D GetTexture()
        {
            return _texture;
        }

        public Rectangle Hitbox
        {
            get
            {
                Rectangle _hitBox = new Rectangle(GetLocX(), GetLocY(), _texture.Width, _texture.Height);
                return _hitBox;
            }  
        }

        public static bool CheckPaddleBallCollision(PongEntity pPaddle, PongEntity pBall)
        {
            bool _collision;

            if (pPaddle.Hitbox.Intersects(pBall.Hitbox))
            {
                _collision = true;
            }
            else
            {
                _collision = false;
            }
            return _collision;
        }

        public void InvertVelocityX()
        {
            _velocity.X *= -1;
        }

        public void InvertVelocityY()
        {
            _velocity.Y *= -1;
        }
    }
}
