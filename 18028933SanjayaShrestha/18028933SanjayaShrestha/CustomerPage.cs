using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;

namespace _18028933SanjayaShrestha
{
    public partial class CustomerPage : Form
    {
        


        //int foodQuality, staffFriendliness, cleanliness, restaurantAmbiance, orderAccuracy, valueForMoney;
        string customerName, customerNumber, customerEmail, customerAddress, foodQuality, staffFriendliness, cleanliness, restaurantAmbiance, orderAccuracy, valueForMoney;

 

        public CustomerPage()
        {
            InitializeComponent();
            //txtTime.Text = DateTime.Now.ToString("hh:mm tt");
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            timer1.Start();
            staffFriendlinessComboBox.SelectedIndex = 0;
            foodQualityComboBox.SelectedIndex = 0;
            cleanlinessComboBox.SelectedIndex = 0;
            restaurantAmbianceComboBox.SelectedIndex = 0;
            orderAccuracyComboBox.SelectedIndex = 0;
            valueForMoneyComboBox.SelectedIndex = 0;


        }
        private List<Serialization> myInput = new List<Serialization>();

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //string customerName, customerNumber, customerEmail, customerAddress, foodQuality, staffFriendliness, cleanliness, restaurantAmbiance, orderAccuracy, valueForMoney;
            customerName = nameTextField.Text;
            customerNumber = numberTextField.Text;
            customerEmail = emailTextField.Text;
            customerAddress = addressTextField.Text;
            foodQuality = foodQualityComboBox.SelectedItem.ToString();
            staffFriendliness = staffFriendlinessComboBox.SelectedItem.ToString();
            cleanliness = cleanlinessComboBox.SelectedItem.ToString();
            restaurantAmbiance = restaurantAmbianceComboBox.SelectedItem.ToString();
            orderAccuracy = orderAccuracyComboBox.SelectedItem.ToString();
            valueForMoney = valueForMoneyComboBox.SelectedItem.ToString();



            Regex number = new Regex(@"^98[0-9]{8}$");//pattern for number
            Regex gmail = new Regex(@"[A-Za-z0-9].*@gmail\.com");//pattern for gmail
            Regex name = new Regex(@"([A-Za-z]\w)+");

            if (string.IsNullOrEmpty(customerName))
            {
                //MessageBox.Show("Name textfield cannot be empty");
                MessageBox.Show("Customer Name Textfield cannot be null or empty", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(customerNumber))
            {
                //MessageBox.Show("Number textfield cannot be empty");
                MessageBox.Show("Customer Number Textfield cannot be null or empty", "Alert ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(customerEmail))
            {
                //MessageBox.Show("Email textfield cannot be empty");
                MessageBox.Show("Email Textfield cannot be empty or null", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(customerAddress)) {//checking the null or empty field
               // MessageBox.Show("Address textfield cannot be empty");
                MessageBox.Show("Address Textfield cannot be empty or null", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else if (name.IsMatch(customerName)){

                if (number.IsMatch(customerNumber)){
                    if (gmail.IsMatch(customerEmail))
                    {
                        try
                        {
                            string loadDetails=customerName + "," + customerNumber + "," + customerEmail + "," + customerAddress + "," + foodQuality + "," + staffFriendliness + "," + cleanliness + "," + restaurantAmbiance + "," + orderAccuracy + "," + valueForMoney + "";
                            readCSV(loadDetails);
                            MessageBox.Show("Thank you for your Feedback","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            myInput.Add(new Serialization(customerName, customerNumber, customerEmail, customerAddress, foodQuality, staffFriendliness, cleanliness, restaurantAmbiance, orderAccuracy, valueForMoney));
                            this.Close();

                        }
                        catch (Exception)
                        {
                            //MessageBox.Show("Invalid error!!!!");
                            MessageBox.Show("Invalid error!!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error); 

                        }
                    }
                    else {
                        //MessageBox.Show("Invalid gmail");
                        MessageBox.Show("Please enter correct gmail", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                }
                else
                {
                    //MessageBox.Show("Invalid phone number");
                    MessageBox.Show("Invalid phone number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //MessageBox.Show("Invalid Customer Name");
                MessageBox.Show("Invalid Customer Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readCSV(string loadDetails) {//reads the CSV file
            string csvLocation = @"CustomerRating.csv";
            if (!File.Exists(csvLocation)) {
                File.Create(csvLocation);
            }
            using (StreamWriter cast = new StreamWriter(csvLocation, true)) {
                cast.WriteLine(loadDetails);
            }
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

    }
}
