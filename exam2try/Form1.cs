using Npgsql;
using System.Windows.Forms;

namespace exam2try
{
    public partial class Form1 : Form
    {
        NpgsqlCommand request;
        string connString = "Host=localhost;Port=4444;Username=admin;Password=admin1;Database=postgres;";
        List<string[]> data = new List<string[]>();
        public Form1()
        {
            InitializeComponent();
            currencyDG.Columns[0].Width = this.ClientSize.Width / 3;
            currencyDG.Columns[1].Width = this.ClientSize.Width / 3;
            currencyDG.Columns[2].Width = this.ClientSize.Width / 3 - 2;
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            request = new NpgsqlCommand("SELECT name FROM currency_data;", conn);
            using (NpgsqlDataReader reader = request.ExecuteReader())
            {
                while (reader.Read())
                {

                    currencyCB.Items.Add(reader.GetString(0));
                    currencyResultCB.Items.Add(reader.GetString(0));
                }
            }
            request = new NpgsqlCommand("SELECT name, reduction, convert_value FROM currency_data;", conn);
            using (NpgsqlDataReader reader = request.ExecuteReader())
            {

                while (reader.Read())
                {
                    data.Add(new string[3]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                }

                conn.Close();

                foreach (string[] s in data)
                {
                    currencyDG.Rows.Add(s);
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            mainPanel.Width = this.ClientSize.Width;
            convertBT.Width = this.ClientSize.Width / 100 * 30;
            currencyCB.Width = this.ClientSize.Width / 100 * 30;
            currencyDG.Width = this.ClientSize.Width;
            currencyDG.Columns[0].Width = this.ClientSize.Width / 3;
            currencyDG.Columns[1].Width = this.ClientSize.Width / 3;
            currencyDG.Columns[2].Width = this.ClientSize.Width / 3;
            currencyResultCB.Width = this.ClientSize.Width / 100 * 30;
            currencyResultLB.Width = this.ClientSize.Width / 100 * 30;
            currencyTB.Width = this.ClientSize.Width / 100 * 30;
        }

        private void convertBT_Click(object sender, EventArgs e)
        {
            double currencyFirstResult = 0, currencySecondResult = 0;
            if (currencyTB.Text != "" && currencyResultCB.Text != "" && currencyCB.Text != "")
            {
                NpgsqlConnection conn = new NpgsqlConnection(connString);
                conn.Open();
                request = new NpgsqlCommand($"SELECT convert_value FROM currency_data WHERE name = '{currencyCB.Text}';", conn);
                using (NpgsqlDataReader reader = request.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        currencyFirstResult = reader.GetDouble(0);
                    }
                }
                request = new NpgsqlCommand($"SELECT convert_value FROM currency_data WHERE name = '{currencyResultCB.Text}';", conn);
                using (NpgsqlDataReader reader = request.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        currencySecondResult = reader.GetDouble(0);
                    }
                }
                double.TryParse(currencyTB.Text, out double currencyAmmount);
                double finalCurrency = (currencyFirstResult * currencyAmmount) / currencySecondResult;
                currencyResultLB.Text = finalCurrency.ToString();
            }
        }
    }
}