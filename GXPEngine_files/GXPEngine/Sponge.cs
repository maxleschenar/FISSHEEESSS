using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Sponge:Sprite
    {
        public Vec2 _position;
        float _radius;
        List<Dirt> dirtList;

        public Sponge() : base("sponge.png")
        {
            SetOrigin(width / 2, height / 2);

            width /= 20;
            height /= 20;
            _radius = width / 2;
            dirtList = new List<Dirt>();
        }

        public void addDirt(Dirt dirt)
        {
            dirtList.Add(dirt);
        }
        public void removeDirt(Dirt dirt)
        {
            dirtList.Remove(dirt);
        }
        void UpdateScreenPosition()
        {
            x = _position.x;
            y = _position.y;
        }
        void Update()
        {
            _position.SetXY(Input.mouseX, Input.mouseY);
            UpdateScreenPosition();
            BallBallCollisionDetection();
        }
        private void BallBallCollisionDetection()
        {
            for (int i = 0; i < dirtList.Count; i++)
            {
                Dirt mover = dirtList[i] as Dirt;
                Vec2 relativePosition = _position - mover._position;
                if (relativePosition.Magnitude() < _radius + mover._radius)
                {
                    removeDirt(mover);
                    mover.LateDestroy();
                   // return true;
                }
            }
           // return false;
        }
    }
}
