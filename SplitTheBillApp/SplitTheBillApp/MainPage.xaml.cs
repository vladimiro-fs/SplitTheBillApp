namespace SplitTheBillApp
{
    public partial class MainPage : ContentPage
    {
        decimal bill;
        int tip;
        int numberPeople = 1;
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void txtBill_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(txtBill.Text);
            CalculateTotal();
        }

        private void CalculateTotal() 
        {
            // Total tip
            var totalTip = (bill * tip) / 100;

            var tipPerPerson = (totalTip / numberPeople);
            lblTipPerson.Text = $"{tipPerPerson:C}";

            // Subtotal
            var subtotal = (bill / numberPeople);
            lblSubtotal.Text = $"{subtotal:C}";

            // Total
            var totalPerPerson = (bill + totalTip) / numberPeople;
            lblTotal.Text = $"{totalPerPerson:C}";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                var btn = (Button)sender;
                var percentage = int.Parse(btn.Text.Replace("%", ""));
                sldTip.Value = percentage;
            }
        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sldTip.Value;
            lblTip.Text = $"Tip: {tip}%";
            CalculateTotal();
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if (numberPeople > 1)
            {
                numberPeople--;
            }
            lblNumberPeople.Text = numberPeople.ToString();
            CalculateTotal();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            numberPeople++;
            lblNumberPeople.Text = numberPeople.ToString();
            CalculateTotal();
        }

        private void btnStart_Clicked(object sender, EventArgs e)
        {
            bill = 0.00m;
            tip = 0;
            txtBill.Text = "";
            sldTip.Value = 0;
            lblNumberPeople.Text = "1";
            numberPeople = 1;
            CalculateTotal();
        }              
    }
}
