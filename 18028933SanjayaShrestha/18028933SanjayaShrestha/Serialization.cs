using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18028933SanjayaShrestha
{
    class Serialization
    {

        private string customerName;
        private string customerNumber;
        private string customerEmail;
        private string customerAddress;
        private string foodQuality;
        private string staffFriendliness;
        private string cleanliness;
        private string restaurantAmbiance;
        private string orderAccuracy;
        private string valueForMoney;

        public Serialization(string customerName, string customerNumber, string customerEmail, string customerAddress, string foodQuality, string staffFriendliness, string cleanliness, string restaurantAmbiance, string orderAccuracy, string valueForMoney)
        {
            this.customerName = customerName;
            this.customerNumber = customerNumber;
            this.customerEmail = customerEmail;
            this.customerAddress = customerAddress;
            this.foodQuality = foodQuality;
            this.staffFriendliness = staffFriendliness;
            this.cleanliness = cleanliness;
            this.restaurantAmbiance = restaurantAmbiance;
            this.orderAccuracy = orderAccuracy;
            this.valueForMoney = valueForMoney;

        }
        public string CustomerName
        {
            get { return customerName; }
        }
        public string CustomerNumber
        {
            get { return customerNumber; }
        }
        public string CustomerEmail
        {
            get { return customerEmail; }
        }
        public string CustomerAddress
        {
            get { return customerAddress; }
        }
        public string FoodQuality
        {
            get { return foodQuality; }
        }
        public string StaffFriendliness
        {
            get { return staffFriendliness; }
        }
        public string Cleanliness
        {
            get { return cleanliness; }
        }
        public string RestaurantAmbiance
        {
            get { return restaurantAmbiance; }
        }
        public string OrderAccuracy
        {
            get { return orderAccuracy; }
        }
        public string ValueForMoney
        {
            get { return valueForMoney; }
        }
    }

}