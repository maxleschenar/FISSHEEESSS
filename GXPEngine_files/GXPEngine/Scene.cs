using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Scene: GameObject
    {
        int timer=1000;
        Sponge sponge;
        public List<Food> foodList;
        List<Fish> fishListPerScene;
        Shop shop;

        public Scene()
        {
            foodList = new List<Food>();
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
