using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Fish: Sprite
    {
        Vec2 _position;
        public Vec2 velocity;
        Vec2 currentPoint = new Vec2(0, 0);
        float _radius;
        public Fish(): base("colors.png")
        {
            SetOrigin(width / 2, height / 2);
            _position = new Vec2(200, 300);
            _radius = width / 2;
        }

        void UpdateScreenPosition()
        {
            x = _position.x;
            y = _position.y;
        }
        void calcDistToPoint()
        {
            if (currentPoint.x != 0 && currentPoint.y != 0)
            {
                velocity.SetXY(0, 0);
                Vec2 deltaVector = currentPoint - _position;

                if (deltaVector.Magnitude() <= 0.5f)
                {
                    currentPoint.SetXY(0, 0);

                }
                else
                {

                    deltaVector.Normalize();
                    //deltaVector *= 0.2f;
                    velocity += deltaVector;
                }

            }
            else
            {
                currentPoint.SetXY(Utils.Random(50, game.width - 50), Utils.Random(50, game.height - 50));
            }
        }
        void move()
        {
            calcDistToPoint();
            _position += velocity;
            UpdateScreenPosition();
        }
        void Update()
        {
            Console.WriteLine(currentPoint);

            move();
        }
    }
}
