using System;
using System.Windows.Forms;

namespace Multi_Stage_Event_Chaining_with_Custom_EventArgs
{
    public partial class Form1 : Form
    {
        // Define Events
        public event EventHandler<ShipEventArgs> OrderCreated;
        public event EventHandler OrderRejected;
        public event EventHandler OrderConfirmed;
        public event EventHandler<ShipEventArgs> OrderShipped;

        private bool isOrderValid = false;

        public Form1()
        {
            InitializeComponent();

            // Subscribe static handlers
            this.OrderCreated += ValidateOrder;
            this.OrderCreated += DisplayOrderInfo;
            this.OrderRejected += ShowRejection;
            this.OrderConfirmed += ShowConfirmation;
            this.OrderShipped += ShowDispatch;
        }

        // button

        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
            string product = cmbProduct.SelectedItem?.ToString() ?? "Unknown";
            bool express = chkExpress.Checked;

            // raise ordercreated
            OrderCreated?.Invoke(this, new ShipEventArgs(product, express));
        }

        private void btnShipOrder_Click(object sender, EventArgs e)
        {
            if (!isOrderValid)
            {
                MessageBox.Show("Cannot ship: No valid order confirmed.");
                return;
            }

            string product = cmbProduct.SelectedItem?.ToString();
            bool express = chkExpress.Checked;

            // dynamic subscription
            this.OrderShipped -= NotifyCourier; // Remove first to prevent duplicates

            if (express)
            {
                this.OrderShipped += NotifyCourier; // Add only if checked
            }

            // raise ordershipped
            OrderShipped?.Invoke(this, new ShipEventArgs(product, express));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
   
        }

        // subscriber methods

        private void ValidateOrder(object sender, ShipEventArgs e)
        {
            if (numQuantity.Value > 0 && !string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                lblStatus.Text = "Validated";
                isOrderValid = true;
                OrderConfirmed?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                isOrderValid = false;
                OrderRejected?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DisplayOrderInfo(object sender, ShipEventArgs e)
        {
            MessageBox.Show($"Order Received for {e.Product}. Express: {e.Express}", "Order Summary");
        }

        private void ShowRejection(object sender, EventArgs e)
        {
            lblStatus.Text = "Order Invalid - Please retry";
        }

        private void ShowConfirmation(object sender, EventArgs e)
        {
            lblStatus.Text = $"Order Processed Successfully for {txtCustomerName.Text}";
        }

        private void ShowDispatch(object sender, ShipEventArgs e)
        {
            lblStatus.Text = $"Product dispatched: {e.Product}";
        }

        private void NotifyCourier(object sender, ShipEventArgs e)
        {
            MessageBox.Show("Express delivery initiated!", "Courier Notification");
        }
    }

    public class ShipEventArgs : EventArgs
    {
        public string Product { get; }
        public bool Express { get; }

        public ShipEventArgs(string p, bool ex)
        {
            Product = p;
            Express = ex;
        }
    }
}