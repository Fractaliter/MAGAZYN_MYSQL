using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
namespace BazaSQLTest
{
	public partial class FormPracownik : Form
	{
		string mojePolaczenie = "SERVER=127.0.0.1; DATABASE=magazyn;UID= root;PASSWORD=;";
		public string id_pracownik = "", idpu = "";
		private MySqlDataAdapter mySqlDataAdapter;
		public FormPracownik()
		{
			InitializeComponent();
		}

		private void FormPracownik_Load(object sender, EventArgs e)
		{
			SQL();

		}
		void SQL()
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();

			MySqlCommand commandz = new MySqlCommand("SELECT Id_Uzytkownicy FROM uzytkownicy WHERE (Klienci_Id_Klienci = '" + id_pracownik + "');", polaczenie);
			idpu = commandz.ExecuteScalar().ToString();
			polaczenie.Close();
		}
		private void button3_Click(object sender, EventArgs e)
		{
			//pokaz dostawy
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();
			MySqlCommand commandlp = new MySqlCommand("SELECT * FROM zamowienia", polaczenie);
			try
			{
				//otwórz połączenie z bazą danych
				
				//wykonaj polecenie języka SQL na danych połączeniu
				using (commandlp)
				{
					DataTable dt = new DataTable();
					//Pobierz dane i zapisz w strukturze DataTable
					MySqlDataAdapter da = new MySqlDataAdapter(commandlp);
					da.Fill(dt);
					//wpisz dane do kontrolki DATAGRID
					dataGridView1.DataSource = dt.DefaultView;
				}

			}
			//Jeżeli wystąpi wyjątek wyrzuć go i pokaż informacje
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show("Błąd logowania do bazy danych MySQL", "Błąd");
			}
			//Zamknij połączenie po wyświetleniu danych
			polaczenie.Close();

		}

		private void Wyloguj_Click(object sender, EventArgs e)
		{
			Form1 f2 = new Form1();
			this.Hide();
			f2.Show();
		}

		private void button2_Click(object sender, EventArgs e) // pokaz zamowienia
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();
			MySqlCommand commandlp = new MySqlCommand("SELECT * FROM zamowienia", polaczenie);
			try
			{
				
				mySqlDataAdapter = new MySqlDataAdapter(commandlp);
				DataSet DS = new DataSet();
				mySqlDataAdapter.Fill(DS);
				dataGridView1.DataSource = DS.Tables[0];

				
				

			}
			//Jeżeli wystąpi wyjątek wyrzuć go i pokaż informacje
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show("Błąd logowania do bazy danych MySQL", "Błąd");
			}
			//Zamknij połączenie po wyświetleniu danych
			polaczenie.Close();
		}

		private void button3_Click_1(object sender, EventArgs e) // dodaj produkt
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();

			MySqlCommand commandp = new MySqlCommand("INSERT INTO `produkty` ( `Nazwa_Produktu`, `Ilosc_Magazyn`, `Cena_aktualna`) VALUES ('"+textBox5.Text+ "', '" + textBox2.Text + "', '" + textBox1.Text + "')", polaczenie);
			commandp.ExecuteNonQuery();
			polaczenie.Close();
		}

		

		private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e) // update
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			DataTable changes = ((DataTable)dataGridView1.DataSource).GetChanges();
			MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from zamowienia", polaczenie);
			if (changes != null)
			{
				MySqlCommandBuilder mcb = new MySqlCommandBuilder(mySqlDataAdapter);
				mySqlDataAdapter.UpdateCommand = mcb.GetUpdateCommand();
				mySqlDataAdapter.Update(changes);
				((DataTable)dataGridView1.DataSource).AcceptChanges();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();
			DataTable changes = ((DataTable)dataGridView1.DataSource).GetChanges();
			foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
			{
				if (oneCell.Selected)
				{
					string idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
					MySqlCommand mr = new MySqlCommand("select * from pozycja WHERE Zamowienia_Id_Zamowienia =" +idLocRemv, polaczenie);
					
					
						
						using (mr)
						{
							DataTable dt = new DataTable();
							//Pobierz dane i zapisz w strukturze DataTable
							MySqlDataAdapter da = new MySqlDataAdapter(mr);
							da.Fill(dt);
							//wpisz dane do kontrolki DATAGRID
							dataGridView3.DataSource = dt.DefaultView;
						}

					
				}
			}
			polaczenie.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();
			MySqlCommand commandlp = new MySqlCommand("SELECT * FROM produkty", polaczenie);
			try
			{
				//otwórz połączenie z bazą danych

				//wykonaj polecenie języka SQL na danych połączeniu
				using (commandlp)
				{
					DataTable dt = new DataTable();
					//Pobierz dane i zapisz w strukturze DataTable
					MySqlDataAdapter da = new MySqlDataAdapter(commandlp);
					da.Fill(dt);
					//wpisz dane do kontrolki DATAGRID
					dataGridView2.DataSource = dt.DefaultView;
				}

			}
			//Jeżeli wystąpi wyjątek wyrzuć go i pokaż informacje
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show("Błąd logowania do bazy danych MySQL", "Błąd");
			}
			//Zamknij połączenie po wyświetleniu danych
			polaczenie.Close();
		}
	}
}
