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
	public sealed partial class CurrencyConversion : Page
	{
		double[,] conversionRates = { { 1, 0.85189982, 0.72872436, 74.257327 }, { 1.1739732, 1, 0.8556672, 87.00755 }, { 1.371907, 1.1686692, 1, 101.68635 }, { 0.011492628, 0.013492774, 0.0098339397, 1 } };
		string[] currencyCodes = { "USD ", "EUR", "GBP", "INR" };
		string[] currencyNames = { "US Dollars", "Euros", "British Pounds", "Indian Rupees" };
		string[] currencySymbols = { "$", "€", "£", "₹" };

		public CurrencyConversion()
		{
			this.InitializeComponent();

			ApplicationView.PreferredLaunchViewSize = new Size(800, 600);
			ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
		}

		private void currencyConversionButton_Click(object sender, RoutedEventArgs e)
		{
			if (amountTextBox.Text != "" && fromComboBox.SelectedIndex != -1 && toComboBox.SelectedIndex != -1)
			{
				amountTextBlock.Text = amountTextBox.Text + " " + currencyNames[fromComboBox.SelectedIndex] + " =";
				double initialAmount = double.Parse(amountTextBox.Text);
				double convertedAmount = initialAmount * conversionRates[fromComboBox.SelectedIndex,toComboBox.SelectedIndex];
				currencyConvertedTextBlock.Text = currencySymbols[toComboBox.SelectedIndex] + convertedAmount.ToString() + " " + currencyNames[toComboBox.SelectedIndex];
				ratioTextBlock.Text = "1 " + currencyCodes[fromComboBox.SelectedIndex] + " = " + conversionRates[fromComboBox.SelectedIndex,toComboBox.SelectedIndex] + " " + currencyNames[toComboBox.SelectedIndex];
				reverseRatioTextBlock.Text = "1 " + currencyNames[toComboBox.SelectedIndex] + " = " + conversionRates[toComboBox.SelectedIndex, fromComboBox.SelectedIndex] + " " + currencyCodes[fromComboBox.SelectedIndex];
			}
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame rootFrame = Window.Current.Content as Frame;
			rootFrame.Navigate(typeof(MainMenu));
		}
	}
}
