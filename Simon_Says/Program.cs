using System;
using System.Threading;

//			  _________.__                          _________
//			 /   _____/|__| _____   ____   ____    /   _____/____  ___.__. ______
//			 \_____  \ |  |/     \ /  _ \ /    \   \_____  \\__  \<   |  |/  ___/
//			 /        \|  |  Y Y  (  <_> )   |  \  /        \/ __ \\___  |\___ \ 
//			/_______  /|__|__|_|  /\____/|___|  / /_______  (____  / ____/____  >
// 				    \/          \/            \/          \/     \/\/         \/ 
//	
//Simon Says game as console app by Tyler Thompson



namespace Simon_Says
{
	class Program
	{
		enum Arrows { Up, Down, Left, Right, None };
		

		static void Main(string[] args)
		{
			int numToMem;
			int sequenceIndex;
			Arrows[] randomSequence;
			ConsoleKeyInfo keyPressed;

			//Start
			WelcomeScreen();
			Console.Clear();		

			//User types in number to remember
			Console.Write("How many do you want to memorize? ");
			numToMem = Convert.ToInt32(Console.ReadLine());
			Console.Clear();
			Console.WriteLine("Simon says to memorize the followng {0} arrows", numToMem);
			Console.WriteLine("\nPress any key when you're ready...");
			Console.ReadKey();

			//Gets list of random arrows based on number given
			randomSequence = GetRandomArrows(numToMem);

			//Displays the random sequence of arrows to memorize
			foreach (var item in randomSequence)
			{
				FlashArrow(item);
			}

			Console.Clear();
			Console.WriteLine("Did you catch those? Simon wants to know." +
				"\nPress the arrows in that order.");

			

			//Do-While loop to read arrow key pressed and display it.
			/***********************needs work**********************/
			sequenceIndex = 0;
			do
			{ 
				keyPressed = Console.ReadKey();

				DisplayArrow(ProcessKeyToArrow(keyPressed.Key));
				
			} while (keyPressed.Key != ConsoleKey.Escape || 
					  sequenceIndex != randomSequence.Length);




			//End
			Console.Read();
		}

		//Method that takes the keyboard key pressed as param and 
		//returns a corresponding arrow enum. 
		private static Arrows ProcessKeyToArrow(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.LeftArrow:
					return Arrows.Left;
				case ConsoleKey.UpArrow:
					return Arrows.Up;
				case ConsoleKey.RightArrow:
					return Arrows.Right;
				case ConsoleKey.DownArrow:
					return Arrows.Down;
				default:
					break;
			}
			return Arrows.None;
		}

		//Splash screen
		private static void WelcomeScreen()
		{
			Console.WriteLine("<<<<<WELCOME TO SIMON SAYS>>>>>");
			DisplayArrow(Arrows.Up);
			DisplayArrow(Arrows.Down);
			DisplayArrow(Arrows.Left);
			DisplayArrow(Arrows.Right);
			Thread.Sleep(1500);
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		//Generates and returns a list of arrows the size of given param
		//Arrows generated with random numbers cast to Arrows
		private static Arrows[] GetRandomArrows(int num)
		{
			Arrows[] randomArrows = new Arrows[num];
			Random randomizer = new Random();

			for (int i = 0; i < num; i++)
			{
				randomArrows[i] = ((Arrows)randomizer.Next(4));
			}
			return randomArrows;
		}

		//Takes Arrows enum as parameter. Clears console, 
		//calls DisplayArrow on given arrow and waits 1 sec
		private static void FlashArrow(Arrows arrow)
		{
			Console.Clear();
			Thread.Sleep(1000);
			DisplayArrow(arrow);
			Thread.Sleep(1000);
		}

		//Method to take Arrows enum as parameter to display ascii string
		//of an arrow shape in a particular color. Then resets text color. 
		private static void DisplayArrow(Arrows arrow)
		{
			switch (arrow)
			{
				case Arrows.Up:

					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine(@"
					   *
					  ***
					 *****
					*******");

					break;

				case Arrows.Down:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(@"
					*******
					 *****
					  ***   
					   *");
					break;

				case Arrows.Left:
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine(@"
					     *
					  ****
					******
					  ****
					     *");
					break;

				case Arrows.Right:
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine(@"
					*
					****
					******
					****
					*");
					break;

				case Arrows.None:
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("NOT AN ARROW");
					Console.BackgroundColor = ConsoleColor.Black;
					break;

				default:
					Console.WriteLine("NULL");
					break;
			}
			Console.ForegroundColor = ConsoleColor.Gray;
		}
	}
}
