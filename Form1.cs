using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UnitConverterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            // Add conversion types
            comboBoxType.Items.AddRange(new string[] { "Length", "Weight" });
            comboBoxType.SelectedIndex = 0;

            // Populate units based on the selected conversion type
            PopulateUnits(comboBoxType.SelectedItem.ToString());

            // Handle the selected index change event for the conversion type ComboBox
            comboBoxType.SelectedIndexChanged += ComboBoxType_SelectedIndexChanged;
        }

        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear existing items
            comboBoxFrom.Items.Clear();
            comboBoxTo.Items.Clear();

            // Populate units based on the selected conversion type
            PopulateUnits(comboBoxType.SelectedItem.ToString());
        }

        private void PopulateUnits(string conversionType)
        {
            if (conversionType == "Length")
            {
                comboBoxFrom.Items.AddRange(new string[] { "Meters", "Kilometers", "Inches", "Feet" });
                comboBoxTo.Items.AddRange(new string[] { "Meters", "Kilometers", "Inches", "Feet" });
            }
            else if (conversionType == "Weight")
            {
                comboBoxFrom.Items.AddRange(new string[] { "Grams", "Kilograms", "Pounds", "Ounces" });
                comboBoxTo.Items.AddRange(new string[] { "Grams", "Kilograms", "Pounds", "Ounces" });
            }

            comboBoxFrom.SelectedIndex = 0;
            comboBoxTo.SelectedIndex = 1;
        }

        private void buttonConvert_Click(object sender, EventArgs e)
      
        {   

            double value;
            if (!double.TryParse(textBoxValue.Text, out value))
            {

                //
                labelConvertedValue.Text = "Invalid input!";
                //MessageBox.Show("PLEASE ENTER THE VALID POSITIVE INTEGER FOR GENERATION");
                return;
               
            }

            string fromUnit = comboBoxFrom.SelectedItem.ToString();
            string toUnit = comboBoxTo.SelectedItem.ToString();
            double result = ConvertUnits(value, fromUnit, toUnit);
            labelConvertedValue.Text = result.ToString();
        }



       
       

        private double ConvertUnits(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit)
            {
                return value;
            }

            // Conversion logic here
            double valueInBaseUnit = value;
            if (comboBoxType.SelectedItem.ToString() == "Length")
            {
                switch (fromUnit)
                {
                    case "Meters":
                        valueInBaseUnit = value;
                        break;
                    case "Kilometers":
                        valueInBaseUnit = value * 1000;
                        break;
                    case "Inches":
                        valueInBaseUnit = value * 0.0254;
                        break;
                    case "Feet":
                        valueInBaseUnit = value * 0.3048;
                        break;
                }

                switch (toUnit)
                {
                    case "Meters":
                        return valueInBaseUnit;
                    case "Kilometers":
                        return valueInBaseUnit / 1000;
                    case "Inches":
                        return valueInBaseUnit / 0.0254;
                    case "Feet":
                        return valueInBaseUnit / 0.3048;
                }
            }
            else if (comboBoxType.SelectedItem.ToString() == "Weight")
            {
                switch (fromUnit)
                {
                    case "Grams":
                        valueInBaseUnit = value;
                        break;
                    case "Kilograms":
                        valueInBaseUnit = value * 1000;
                        break;
                    case "Pounds":
                        valueInBaseUnit = value * 453.592;
                        break;
                    case "Ounces":
                        valueInBaseUnit = value * 28.3495;
                        break;
                }

                switch (toUnit)
                {
                    case "Grams":
                        return valueInBaseUnit;
                    case "Kilograms":
                        return valueInBaseUnit / 1000;
                    case "Pounds":
                        return valueInBaseUnit / 453.592;
                    case "Ounces":
                        return valueInBaseUnit / 28.3495;
                }
            }

            return 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonConvert_Click_1(object sender, EventArgs e)
        {
            double value;
            if (!double.TryParse(textBoxValue.Text, out value))
            {

                //
                labelConvertedValue.Text = "Invalid input!";
                //MessageBox.Show("PLEASE ENTER THE VALID POSITIVE INTEGER FOR GENERATION");
                return;

            }

            string fromUnit = comboBoxFrom.SelectedItem.ToString();
            string toUnit = comboBoxTo.SelectedItem.ToString();
            double result = ConvertUnits(value, fromUnit, toUnit);
            labelConvertedValue.Text = result.ToString();
        }

        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            textBoxValue.Clear();
            labelConvertedValue.Text = string.Empty;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // MessageBox.Show("PLEASE ENTER THE VALID POSITIVE INTEGER FOR GENERATION");
            return;
        }
    }
}
