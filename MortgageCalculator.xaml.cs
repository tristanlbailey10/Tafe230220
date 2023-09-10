using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
			this.InitializeComponent();
			ApplicationView.PreferredLaunchViewSize = new Size(800, 1500);
			ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
		}

		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			// Parse user input from TextBoxes
			if (double.TryParse(PrincipalTextBox.Text.Replace("$", "").Replace(",", ""), out double principal) &&
				double.TryParse(YearlyInterestRateTextBox.Text.Replace("%", ""), out double yearlyInterestRate) &&
				int.TryParse(YearsTextBox.Text, out int years) &&
				int.TryParse(MonthsTextBox.Text, out int months))
			{
				// Calculate monthly interest rate
				double monthlyInterestRate = (yearlyInterestRate / 100) / 12;

				// Calculate total number of months 
				int totalMonths = years * 12 + months;

				// Calculate the monthly repayment 
				double numerator = principal * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths));
				double denominator = Math.Pow(1 + monthlyInterestRate, totalMonths) - 1;
				double monthlyRepayment = numerator / denominator;

				// Display the results
				MonthlyRepaymentTextBox.Text = string.Format("${0:0,0.00}", monthlyRepayment);
				MonthlyInterestRateTextBox.Text = string.Format("{0:0.0000}%", monthlyInterestRate);
			}
			else
			{
				ShowErrorMessageBox("Invalid input. Please check your values.");
			}
		}

		private async void ShowErrorMessageBox(string errorMessage)
		{
			var messageDialog = new Windows.UI.Popups.MessageDialog(errorMessage, "Error");
			messageDialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok"));
			await messageDialog.ShowAsync();
		}


		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame rootFrame = Window.Current.Content as Frame;
			rootFrame.Navigate(typeof(MainMenu));
		}

		
	}
}
