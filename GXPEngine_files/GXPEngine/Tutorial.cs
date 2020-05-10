using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Tutorial:AnimationSprite
    {
        Sprite next;
        Sprite skip;
        public int maxFrameToChange=1;
        bool changeMaxFrame = true;
        public Tutorial() : base("tutorial.png", 10, 1)
        {
            next = new Sprite("checkers.png");
            skip = new Sprite("checkers.png");
            next.height /= 2;
            next.width /= 2;
            skip.height /= 2;
            skip.width /= 2;
            next.x = width - next.width;
            next.y = height - next.height;
            skip.y = height - next.height;
            AddChild(next);
            AddChild(skip);
        }
        void Update()
        {
            if (MyGame.CheckMouseInRectClick(skip))
            {
                LateDestroy();
            }
            if (currentFrame <= maxFrameToChange)
            {
                BecomeVisible();
                if (MyGame.CheckMouseInRectClick(next))
                {
                    
                    ChangeFrame();
                }
            }
            else BecomeInvisible();
            Console.WriteLine(currentFrame+"   "+maxFrameToChange+"    "+visible);

        }
        public void ChangeFrame()
        {
            currentFrame++;
        }

        public void BecomeInvisible()
        {
            visible = false;
        }
        public void BecomeVisible()
        {
            visible = true;
        }
        public void ChangePosition()
        {

        }
    }
}
