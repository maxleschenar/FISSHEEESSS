using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Scene: GameObject
    {

        Sprite tank, downArrow;

        int timer=1000;
        bool isActive;
        Sponge sponge;
        public List<Food> foodList;
        List<Fish> fishListPerScene;
        Shop shop;

        public Scene(string path) : base()
        {
            isActive = true;
            tank = new Sprite(path);
            downArrow = new Sprite("downarrow.png");
            foodList = new List<Food>();

            AddChild(tank);
            AddChild(downArrow);


            fishListPerScene = new List<Fish>();
            DisplayFishInScene fishes = new DisplayFishInScene(1, foodList, fishListPerScene);
            sponge = new Sponge();
            shop = new Shop(fishListPerScene);
        }
        void addFish()
        {
            foreach(Fish fish in fishListPerScene)
            {
                if (fish.isUnlocked == true)
                {
                    if (fish.isAdded == false)
                    {
                        AddChild(fish);
                        fish.isAdded = true;
                    }
                }
            }
        }
        void makeFood()
        {
            if (Input.GetMouseButtonDown(button: 0))
            {
                Food food = new Food();
                AddChildAt(food,1);
                foodList.Add(food);
            }
        }
        void Update()
        {

            if (isActive)
            {
                makeFood();
                makeDirt();
                displaySponge();
                addFish();
                goBack();
            }

            if (isShopDisplayed == false)
            {
                makeFood();

            }
            makeDirt();
            displaySponge();
            addFish();
            displayShop();

        }
        void makeDirt()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Dirt dirt = new Dirt();
                sponge.addDirt(dirt);
                AddChild(dirt);
                timer = 1000;
            }
        }

        void goBack()
        {
            if (MyGame.CheckMouseInRect(downArrow))
            {
                isActive = false;
                tank.alpha = 0f;
                //fish1.alpha = 0f;
                //fish2.alpha = 0f;
                downArrow.alpha = 0f;
            }
        }

        bool spongeOnScreen = false;
        void displaySponge()
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
        bool isShopDisplayed = false;
        void displayShop()
        {
            if (Input.GetKeyDown(Key.SPACE))
            {
                if (isShopDisplayed == false)
                {
                    AddChild(shop);
                    isShopDisplayed = true;
                }
                else
                {
                    RemoveChild(shop);
                    isShopDisplayed = false;
                }
            }
        }
    }
}
