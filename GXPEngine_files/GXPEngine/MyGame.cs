using System;									// System contains a lot of default C# libraries 
using GXPEngine;								// GXPEngine contains the engine
using System.Drawing;

public class MyGame : Game
{
	Button test;
	public MyGame() : base(800, 600, false)		// Create a window that's 800x600 and NOT fullscreen
	{
		//test = new Button(new Vec2(width / 2, height / 2), "playbutton.png");
		//AddChild(test);
		Fish testFish = new Fish();
		AddChild(testFish);
    }

    void Update()
	{
		//if (CheckMouseInRect(test))
		//{
		//	Console.WriteLine("lol tities");
		//}

	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}

	//bool CheckMouseInRect(Button button)
	//{
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		if (Input.mouseX > button.x && Input.mouseX < button.x + button.Width &&
	//			Input.mouseY > button.y && Input.mouseY < button.y + button.Height)
	//		{
	//			return true;
	//		}
	//		return false;
	//	}
	//	else return false;
	//}

}