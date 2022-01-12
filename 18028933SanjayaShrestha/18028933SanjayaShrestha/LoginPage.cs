using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18028933SanjayaShrestha
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            passwordTextField.PasswordChar = '*'; //makes the password in the form of "*" in the textfield of password

        }


        private void adminLoginButton_Click(object sender, EventArgs e)
        {
            String username, password;
            username = usernameTextField.Text;
            password = passwordTextField.Text;
            if (username == "admin" && password == "admin")//setting the username and pasword for the admin login
            {
                
                AdminPage adminPage = new AdminPage();
                adminPage.Show();
                usernameTextField.Text = "";
                passwordTextField.Text = "";
                //MessageBox.Show("Admin is successfully logged in");
                MessageBox.Show("Admin is logged in successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                //MessageBox.Show("Incorrect uername and password. Please try again!!!");
                MessageBox.Show("Incorrect username and password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTextField.Text = "";
                passwordTextField.Text = "";
            }
        }

        private void customerLoginButton_Click(object sender, EventArgs e)
        {
            CustomerPage customerPage = new CustomerPage();
            customerPage.Show();
            //MessageBox.Show("Some text", "Some title",MessageBoxButtons.OK, MessageBoxIcon.Error);
            //MessageBox.Show("Customer is logged in successfully");
            MessageBox.Show("Customer is logged in successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
