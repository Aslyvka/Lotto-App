using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lab1_ASLyvka
{
	/// <summary>
	/// Name: Anastasiia Slyvka
	/// Project: Random Number Generator
	/// Done for: PROG1224 Lab 1
	/// Last Modified: May 24, 2022
	/// </summary>
	public sealed partial class MainPage : Page
    {
		//2 class level integer arrays that are holding the random numbers (7 numbers for player and 6 numbers for win)

		int[] playerNumbers = new int[7];
        int[] winningNumbers = new int[6];

        public MainPage()
        {
            this.InitializeComponent();
        }

		private void btnGeneratePlayerNumbers_Click(object sender, RoutedEventArgs e)
		{
            GenerateRandomNumbers(playerNumbers);

            lblArrayPlayerNumbers.Text = BuildDisplayString(playerNumbers);

            lblNumberOfMatches.Text = CompareTwoArrays(playerNumbers, winningNumbers).ToString();

        }

        private void btnGenerateWinningNumbers_Click(object sender, RoutedEventArgs e)
		{
            GenerateRandomNumbers(winningNumbers);

            lblArrayWinningNumbers.Text = BuildDisplayString(winningNumbers);

			lblNumberOfMatches.Text = CompareTwoArrays(playerNumbers, winningNumbers).ToString();

		}

        private void GenerateRandomNumbers(int[] numberArray)
        {
			//2 loops generating random numbers
			//unique number check using while loop, if numbers are the same --> generates the next random number until there are no matches

			Random random = new Random();

			for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = random.Next(1, 50);

				for (int j = 0; j < i; j++)
				{
					while (numberArray[i].Equals(numberArray[j]))
					{
						numberArray[i] = random.Next(1, 50);
					}
				}
			}
            
        }

		private string BuildDisplayString(int[] numberArray)
		{
			//This Method will be called in a button click event handler to output the actual array in a string format, so it can be displayed in a textblock
			//loop through the array and each element is added to the string builString in ascending order by sorting with Array.Sort() Method first

            Array.Sort(numberArray);

			string buildString = "";

			for (int k = 0; k < numberArray.Length; k++)
			{
				buildString += $"{numberArray[k]}   ";
			}
			return buildString;

		}

		private int CompareTwoArrays(int[] array1, int[] array2)
		{
			//2 loops to check the length of both of arrays
			//retrieving and comparing each element from both arrays
			//if the elements are equal, match returns the number of matches

			int match = 0;

			for (int i = 0; i < array1.Length; i++)
			{
				for (int j = 0; j < array2.Length; j++)
				{
					if (array1[i].Equals(array2[j]))
						match++;
				}
			}
			return match;

		}

	}
}
