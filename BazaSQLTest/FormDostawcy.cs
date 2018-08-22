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
	public partial class FormDostawcy : Form
	{
		public FormDostawcy()
		{
			InitializeComponent();
		}
		string mojePolaczenie = "SERVER=127.0.0.1; DATABASE=magazyn;UID= root;PASSWORD=;";
		public string iddostawcy, iddu = "";
		private void FormDostawcy_Load(object sender, EventArgs e)
		{
			SQL();
		}
		void SQL()
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();

			MySqlCommand commandz = new MySqlCommand("SELECT Id_Uzytkownicy FROM uzytkownicy WHERE (Dostawcy_Id_Dostawcy = '" + iddostawcy + "');", polaczenie);
			iddu = commandz.ExecuteScalar().ToString();
			polaczenie.Close();
		}
		private void Wyloguj_btn_Click(object sender, EventArgs e)
		{
			Form1 f2 = new Form1();
			this.Hide();
			f2.Show();
		}

		private void button4_Click(object sender, EventArgs e) // stworz zamowienie 
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);

			polaczenie.Open();



			DateTime thisDay = DateTime.Today;
			MySqlCommand commandlp = new MySqlCommand("INSERT INTO `zamowienia` (`Id_Zamowienia`, `Data_Zamowienia`, `Czy_Przyjete`, `Czy_Zrealizowane`, `Czy_Zaplacone`, `Kwota`, `Uzytkownicy_Id_Uzytkownicy`,`Dost/zam`) VALUES(NULL, '" + thisDay.ToString("d") + "', '', '', '', '', '" + iddu + "','d')", polaczenie); //
			commandlp.ExecuteNonQuery();
			MessageBox.Show("Stworzono zamowienie", ":)");
			polaczenie.Close();
		}

		private void button5_Click(object sender, EventArgs e) // dodaj pozycje
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();
			MySqlCommand command = new MySqlCommand("SELECT Id_Zamowienia FROM zamowienia WHERE (Uzytkownicy_Id_Uzytkownicy='" + iddu + "');", polaczenie);
			string id_zam = textBox3.Text;

			MySqlCommand commandpoz = new MySqlCommand("INSERT INTO `pozycja` ( `Ilosc`, `Produkty_Id_Produkty`, `Zamowienia_id_Zamowienia`) VALUES( '" + textBox2.Text + "', '" + textBox1.Text + "', '" + id_zam + "')", polaczenie);
			commandpoz.ExecuteNonQuery();
			polaczenie.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();
			MySqlCommand commandlp = new MySqlCommand("SELECT * FROM Produkty", polaczenie);
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
					dataGridView3.DataSource = dt.DefaultView;
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

		private void button2_Click(object sender, EventArgs e)
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();
			MySqlCommand commandzam = new MySqlCommand("SELECT Id_zamowienia,Czy_Przyjete,Czy_Zaplacone FROM zamowienia WHERE (Uzytkownicy_Id_Uzytkownicy = '" + iddu + "');", polaczenie);

			try
			{
				//otwórz połączenie z bazą danych

				//wykonaj polecenie języka SQL na danych połączeniu
				using (commandzam)
				{
					DataTable dt = new DataTable();
					//Pobierz dane i zapisz w strukturze DataTable
					MySqlDataAdapter da = new MySqlDataAdapter(commandzam);
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

		private void button6_Click(object sender, EventArgs e)
		{
			using (MySqlConnection conn = new MySqlConnection(mojePolaczenie))
			{

				conn.Open();
				foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
				{
					if (oneCell.Selected)
					{
						string idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

						string removeVolCred = "DELETE FROM pozycja WHERE Numer_pozycji = " + idLocRemv;

						using (MySqlCommand command = new MySqlCommand(removeVolCred, conn))
						{
							command.ExecuteNonQuery();
						}
					}
				}
				conn.Close();
			}
		}

		private void button1_Click(object sender, EventArgs e) // pokaz pozycje zamowienia
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();
			
			MySqlCommand commandlp = new MySqlCommand("SELECT Numer_Pozycji,Ilosc,Produkty_ID_Produkty FROM Pozycja WHERE (Zamowienia_Id_Zamowienia = '" + textBox3.Text + "');", polaczenie);
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
	}
}
