using Newtonsoft.Json;
using Npgsql;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml;

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
            bool check = true;
            for (int i = 0; i < currencyDG.RowCount; i++)
            {
                if (Convert.ToDouble(currencyDG[2, i].Value) < 0)
                {
                    check = false;
                    MessageBox.Show($"Ошибка в ячейке {i + 1}");
                }
            }

            if (check == true)
            {
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
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

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
                double finalCurrencyRounded = Math.Round(finalCurrency, 4);
                currencyResultLB.Text = finalCurrencyRounded.ToString();
            }
        }

        private void currencySave()
        {
            List<Currency> currencyList = new List<Currency>();
            DateTime today = DateTime.Today;
            bool check = true;
            for (int i = 0; i < currencyDG.RowCount; i++)
            {
                if (Convert.ToDouble(currencyDG[2, i].Value) < 0)
                {
                    check = false;
                    MessageBox.Show($"Ошибка в ячейке {i + 1}");
                }
            }

            if (check == true)
            {
                foreach (DataGridViewRow row in currencyDG.Rows)
                {
                    Currency currency = new Currency
                    {

                        CurrencyName = row.Cells["name"].Value.ToString(),
                        CurrencyReduction = row.Cells["reduction"].Value.ToString(),
                        СurrencyVal = Convert.ToDouble(row.Cells["convert"].Value)
                    };
                    currencyList.Add(currency);
                }

                    var datasave = new Save()
                    {
                        Date = today,
                        Data = currencyList.ToArray()
                    };

                    var json = JsonConvert.SerializeObject(datasave, Newtonsoft.Json.Formatting.Indented);
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "exam");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    try
                    {
                        using (StreamWriter sr = new StreamWriter(Path.Combine(path, "save.json")))
                        {
                            sr.WriteLine(json);
                            MessageBox.Show($"Запись в файл по пути {path} прошла успешна");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не получилось записать данные в файл код ошибки {ex}");
                    }
            }
            
        }

        private void saveBT_Click(object sender, EventArgs e)
        {
            currencySave();
        }
    }
}