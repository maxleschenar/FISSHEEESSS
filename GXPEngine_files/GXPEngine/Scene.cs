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

        public Scene()
        {
            foodList = new List<Food>();
            fishListPerScene = new List<Fish>();
            DisplayFishInScene fishes = new DisplayFishInScene(1, foodList, fishListPerScene);
            sponge = new Sponge();
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
                if (Input.GetKeyDown(Key.Q))
                {
                    fish.isUnlocked = true;
                }
            }
        }
        void makeFood()
        {
            if (Input.GetMouseButtonDown(button: 0))
            {
                Food food = new Food();
                AddChild(food);
                foodList.Add(food);
            }
        }
        void Update()
        {
            makeFood();
            makeDirt();
            displaySponge();
            addFish();
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
    }
}
