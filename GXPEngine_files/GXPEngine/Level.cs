using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GXPEngine;

public class Level : Sprite
{
    List<Button> buttons;
    List<Scene> scenes;
    public Level() : base("aquariums.png")
    {
        buttons = new List<Button>();
        scenes = new List<Scene>();
        AddButton(new Button(new Vec2(100, game.height / 2), "group1.png"));
        AddButton(new Button(new Vec2(game.width / 2 - 50, game.height / 2), "group1.png"));
        AddButton(new Button(new Vec2(game.width - 200, game.height / 2), "group1.png"));


        void MoveToAnotherTank()
        {
            if (MyGame.CheckMouseInRect(tanks[currentTank].rightArrow) && currentTank < tanks.Count - 1 && !journal.isOpen) //checks the right arrow and if its not on the last tank
            {
                tanks[currentTank].SetTankAlpha(0);
                currentTank++;
                tanks[currentTank].SetTankAlpha(1);

            }
            if (MyGame.CheckMouseInRect(tanks[currentTank].leftArrow) && currentTank > 0 && !journal.isOpen) //checks the left arrow and if its not on the first tank
            {
                tanks[currentTank].SetTankAlpha(0);
                currentTank--;
                tanks[currentTank].SetTankAlpha(1);
            }
            if (MyGame.CheckMouseInRect(journalButton) && !journal.isOpen) //checks for opening the journal
            {
                journal.SetActive(true);
            }
        }

        void DisplaySponge()
        {
            if (Input.GetMouseButton(button: 1))
            {
                if (spongeOnScreen == false)
                {
                    AddChild(sponge);
                    spongeOnScreen = true;
                }
            }
            else
            {
                if (spongeOnScreen == true)
                {
                    RemoveChild(sponge);
                    spongeOnScreen = false;
                }
            }

        }


        void Update()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (MyGame.CheckMouseInRect(buttons[i]))
                {
                    switch (i)
                    {
                        case 0:
                            AddScene(new Scene("fishtanksample.png"));
                            break;
                        case 1:
                            AddScene(new Scene("empty_tank2.jpg"));
                            break;
                        case 2:
                            AddScene(new Scene("fishtank3.jpg"));
                            break;

                    }
                }
            }
        }

        void AddScene(Scene scene)
        {
            AddChild(scene);
            scenes.Add(scene);
        }

        void AddButton(Button button)
        {
            AddChild(button);
            buttons.Add(button);
        }

    }
}

