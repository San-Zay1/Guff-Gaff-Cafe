using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace _18028933SanjayaShrestha
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");//shows the current date
            ratingPanel.Visible = false;
            //txtTime.Text = DateTime.Now.ToString("hh:mm tt");
            timer1.Start();
        }
        private List<Serialization> myInput = new List<Serialization>();//list

        private void timer1_Tick(object sender, EventArgs e)//method that is used to set a timer in the system
        {
            txtTime.Text = DateTime.Now.ToString("hh:mm:ss tt");//shows the current time
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            loadData();

        }

        private void btnSorting_Click(object sender, EventArgs e)
        {
            //dataGridViewRating.Sort(dataGridViewRating.Columns[4], ListSortDirection.Ascending);
            //MessageBox.Show("Data is sorted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            sortData();
        }
        private void sortData()//sorting data
        {
            
            for (int i = 0; i < myInput.Count - 1; i++)
                for (int j = 0; j < myInput.Count - 1; j++)
                {
                    switch (comboBoxSort.SelectedIndex)
                    {

                        case 0:
                            if (myInput[j].FoodQuality.CompareTo(myInput[j + 1].FoodQuality) > 0)
                            {
                                SwapData(j, j + 1);
                            }
                            break;
                        case 1:
                            if (myInput[j].StaffFriendliness.CompareTo(myInput[j + 1].StaffFriendliness) > 0)
                            {
                                SwapData(j, j + 1);
                            }
                            break;
                        case 2:
                            if (myInput[j].Cleanliness.CompareTo(myInput[j + 1].Cleanliness) > 0)
                            {
                                SwapData(j, j + 1);
                            }
                            break;
                    }
                     
                }
            if (comboBoxSort.SelectedIndex == 0)
            {
                dataGridViewRating.Sort(dataGridViewRating.Columns[4], ListSortDirection.Ascending);
                MessageBox.Show("Data is sorted successfully on the basis of Food Quality","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);//displays message with the icon
            }
            else if (comboBoxSort.SelectedIndex == 1)
            {
                dataGridViewRating.Sort(dataGridViewRating.Columns[9], ListSortDirection.Ascending);
                MessageBox.Show("Data is sorted successfully on the basis of Value for money", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private void SwapData(int i, int j)//swaps data
        {
            Serialization temp;
            temp = myInput[i];
            myInput[i] = myInput[j];
            myInput[j] = temp;

        }



        private void loadData() { //method to read the CSV file
            dataGridViewRating.ReadOnly = true; //enables editing
            using (StreamReader reader = new StreamReader(@"CustomerRating.csv")) {
                string rowLine;
                string[] columnLine = null;

                while ((rowLine = reader.ReadLine()) != null) {
                    columnLine = rowLine.Split(',');
                    myInput.Add(new Serialization(columnLine[0], columnLine[1], columnLine[2], columnLine[3], columnLine[4], columnLine[5], columnLine[6], columnLine[7], columnLine[8], columnLine[9]));
                }
                
            }
            storeExcelDetails();
        }

        private void storeExcelDetails() {//store the data
            string[] abc = new string[10];
            foreach (Serialization i in myInput) {
                int rowCount = dataGridViewRating.Rows.Add();
                DataGridViewRow row = dataGridViewRating.Rows[rowCount];
                row.Cells[0].Value = i.CustomerName;
                row.Cells[1].Value = i.CustomerNumber;
                row.Cells[2].Value = i.CustomerEmail;
                row.Cells[3].Value = i.CustomerAddress;
                row.Cells[4].Value = i.FoodQuality;
                row.Cells[5].Value = i.StaffFriendliness;
                row.Cells[6].Value = i.Cleanliness;
                row.Cells[7].Value = i.RestaurantAmbiance;
                row.Cells[8].Value = i.OrderAccuracy;
                row.Cells[9].Value = i.ValueForMoney;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            ratingPanel.Visible = false;
            myInput.Clear();
            dataGridViewRating.ReadOnly = true; //enables editing
            using (StreamReader reader = new StreamReader(@"Rating.csv"))
            {
                string rowLine;
                string[] columnLine = null;

                while ((rowLine = reader.ReadLine()) != null)
                {
                    columnLine = rowLine.Split(',');
                    myInput.Add(new Serialization(columnLine[0], columnLine[1], columnLine[2], columnLine[3], columnLine[4], columnLine[5], columnLine[6], columnLine[7], columnLine[8], columnLine[9]));
                }
                MessageBox.Show("CSV data is loaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            storeExcelDetails();
        }
        public int getAverageRatingpoint(int total, int num) {
            return total / num;
        }
        private void btnChartRating_Click(object sender, EventArgs e)
        {
            ratingPanel.Visible = true;
            int totalCount = 0;
            int foodQuality = 0;
            int staffFriendliness = 0;
            int cleanliness = 0;
            int restaurantAmbiance = 0;
            int orderAccuracy = 0;
            int valueForMoney = 0;

            foreach (Serialization i in myInput) {
                totalCount += 1;
                foodQuality += Convert.ToInt32(i.FoodQuality);
                staffFriendliness += Convert.ToInt32(i.StaffFriendliness);
                cleanliness += Convert.ToInt32(i.Cleanliness);
                restaurantAmbiance += Convert.ToInt32(i.RestaurantAmbiance);
                orderAccuracy += Convert.ToInt32(i.OrderAccuracy);
                valueForMoney += Convert.ToInt32(i.ValueForMoney);


            }
            txtTotal.Text = totalCount.ToString();
            barGraph.Series[0].Points.AddXY("Food Quality", getAverageRatingpoint(foodQuality,totalCount));
            barGraph.Series[0].Points.AddXY("Staff Friendliness", getAverageRatingpoint(staffFriendliness, totalCount));
            barGraph.Series[0].Points.AddXY("Cleanliness", getAverageRatingpoint(cleanliness, totalCount));
            barGraph.Series[0].Points.AddXY("Restaurant Ambiance", getAverageRatingpoint(restaurantAmbiance, totalCount));
            barGraph.Series[0].Points.AddXY("Order Accuracy", getAverageRatingpoint(orderAccuracy, totalCount));
            barGraph.Series[0].Points.AddXY("Value For Money", getAverageRatingpoint(valueForMoney, totalCount));

            barGraph.Series[0].ChartType = SeriesChartType.Pie;
            barGraph.Series[0].IsValueShownAsLabel = true;
            barGraph.Series[0].IsVisibleInLegend = true;
        }
    }
}
