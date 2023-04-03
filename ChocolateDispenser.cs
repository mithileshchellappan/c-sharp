using System;


namespace _24_3_Proj
{
	public class ChocolateDispenser
	{

		public static Stack<string> DispenserStack;

		public ChocolateDispenser()
		{
			DispenserStack = new Stack<string>();
		}

		public static void AddChocolates(string color, int count)
		{
			for (int i = 0; i < count; i++)
			{
				DispenserStack.Push(color);
			}

		}

		public static void RemoveChocolates(int count)
		{
			for (int i = 0; i < count; i++)
			{
				DispenserStack.Pop();
			}
		}

		public static List<string> DispenseChocolates(int count)
		{
			//removing chocolates from stack in order
			var temporaryListOfChocolates = new List<string>();
			while (DispenserStack.Count > 0)
			{
				temporaryListOfChocolates.Add(DispenserStack.Pop());

			}

			//getting the first <count> range of choclates from list
			var list = new List<string>(temporaryListOfChocolates.GetRange(0, count));

			//only add those chocolates which were not dispensed
			for (int i = temporaryListOfChocolates.Count - 1; i >= count; i--)
			{
				DispenserStack.Push(temporaryListOfChocolates[i]);
			}

			return list;

		}

		public static List<string> DispenseChocolatesOfColor(string color, int count)
		{
			//removing chocolates from stack in order
			var temporaryListOfChocolates = new List<string>();
			while (DispenserStack.Count > 0)
			{
				temporaryListOfChocolates.Add(DispenserStack.Pop());

			}

			//hashset to keep track of all indexes of choclates removed
			HashSet<int> removedIndexes = new HashSet<int>();
			var list = new List<string>();

			//looping through the list and finding matching chocolates
			for (int i = 0; count > 0 && i < temporaryListOfChocolates.Count; i++)
			{
				if (temporaryListOfChocolates[i] == color)
				{
					list.Add(temporaryListOfChocolates[i]);
					removedIndexes.Add(i);
					count--;
				}

			}

			//only add those chocolates which were not dispensed
			for (int i = temporaryListOfChocolates.Count - 1; i >= 0; i--)
			{
				if (!removedIndexes.Contains(i))
					DispenserStack.Push(temporaryListOfChocolates[i]);
			}

			return list;

		}

		public static int GetIndex(string color)
		{
			if (color == "green") return 0;
			if (color == "silver") return 1;
			if (color == "blue") return 2;
			if (color == "crimson") return 3;
			if (color == "purple") return 4;
			if (color == "red") return 5;
			if (color == "pink") return 6;
			return -1;

		}

		public static int[] NumberOfChocolates()
		{
			int[] returnArray = new int[7] { 0, 0, 0, 0, 0, 0, 0 };

			foreach (string choco in DispenserStack)
			{
				returnArray[GetIndex(choco)]++;
			}

			return returnArray;
		}

		public static void ChangeChocolateColor(int count, string color, string finalColor)
		{
			//removing chocolates from stack in order
			var temporaryListOfChocolates = new List<string>();
			while (DispenserStack.Count > 0)
			{
				temporaryListOfChocolates.Add(DispenserStack.Pop());

			}

			int countOfFinalColorChocolates = 0;

			for (int i = 0; count > 0 && i < temporaryListOfChocolates.Count; i++)
			{
				if (count > 0 && temporaryListOfChocolates[i].Equals(color))
				{
					temporaryListOfChocolates[i] = finalColor;
					countOfFinalColorChocolates++;
					count--;
				}
			}

			for (int i = temporaryListOfChocolates.Count - 1; i >= 0; i--)
			{
				DispenserStack.Push(temporaryListOfChocolates[i]);
			}

		}

		public static int[] ChangeChocolateColorOfAllXCount(string color, string finalColor)
		{
			var temporaryListOfChocolates = new List<string>();
			while (DispenserStack.Count > 0)
			{
				temporaryListOfChocolates.Add(DispenserStack.Pop());

			}

			int countOfFinalColorChocolates = 0;

			for (int i = 0; i < temporaryListOfChocolates.Count; i++)
			{
				if (temporaryListOfChocolates[i].Equals(color))
				{
					temporaryListOfChocolates[i] = finalColor;
					countOfFinalColorChocolates++;
				}
			}

			for (int i = temporaryListOfChocolates.Count - 1; i >= 0; i--)
			{
				DispenserStack.Push(temporaryListOfChocolates[i]);
			}

			return new int[] { countOfFinalColorChocolates, DispenserStack.Count };


		}

		public static string RemoveChocolateOfColor(string color)
		{
			var temporaryListOfChocolates = new List<string>();
			while (DispenserStack.Count > 0)
			{
				temporaryListOfChocolates.Add(DispenserStack.Pop());
}
			int removedIndex = -1;

			for (int i = 0; i < temporaryListOfChocolates.Count; i++)
			{
				if (temporaryListOfChocolates[i] == color)
				{
					removedIndex = i;
					break;
				}

			}

			for (int i = temporaryListOfChocolates.Count - 1; i >= 0; i--)
			{
				if (i != removedIndex)
					DispenserStack.Push(temporaryListOfChocolates[i]);
			}

			return color;



		}

		public static int NumberOfRainbowChocolates()
		{
			int noOfRainbowChocolates=0;

			//TODO: implement logic

			return noOfRainbowChocolates;


		}


	}
}