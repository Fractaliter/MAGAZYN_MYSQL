using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace BazaSQLTest
{
	
	public partial class Form1 : Form
	{
		
		public Form1()
		{
			InitializeComponent();
		}
		string mojePolaczenie = "SERVER=127.0.0.1; DATABASE=magazyn;UID= root;PASSWORD=;";
		public string  id_klienci = "", id_dostawcy = "", id_pracownicy = "";
		private void Form1_Load(object sender, EventArgs e)
		{

		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			pobierzDane();
		}
		public void pobierzDane()
		{
			//pobierz dane logowania z formularza i przypisz
			//string mojePolaczenie =
			//"SERVER=" + textBox1.Text + ";" +
			//"DATABASE=" + textBox2.Text + ";" +
			//"UID=" + textBox3.Text + ";" +
			//"PASSWORD=" + textBox4.Text + ";";

			//zapisz polecenie języka SQL
			string reje = "SELECT id_Pracownika FROM  Pracownicy WHERE (Nazwisko='" + textBox11.Text + "')";


			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			//blok try-catch przechwytuje błędy
			try
			{
				//otwórz połączenie z bazą danych
				polaczenie.Open();
				//wykonaj polecenie języka SQL na danych połączeniu
				using (MySqlCommand cmdSel = new MySqlCommand(reje, polaczenie))
				{
					DataTable dt = new DataTable();
					//Pobierz dane i zapisz w strukturze DataTable
					MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
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

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void Rejestracja_btn_Click(object sender, EventArgs e)
		{
			wpiszdane();
		}
		public void wpiszdane()
		{
			string prac = "SELECT id_Pracownika FROM  Pracownicy WHERE (Nazwisko='" + textBox6.Text + "' And Imie='" + textBox5.Text + "')";
			string klieci = "SELECT * FROM " + textBox11.Text + ";";
			string dost = "SELECT id_Dostawcy FROM  Dostawcy WHERE (Nazwisko='" + textBox6.Text + "' And Imie='" + textBox5.Text + "')";
			string id_prac="",id_dost="", id_klienci="";
			//wykonaj polecenie języka SQL
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			MySqlCommand command = polaczenie.CreateCommand();
			if (radioButton1.Checked)
			{
				command.CommandText = "INSERT INTO pracownicy (Imie, Nazwisko) VALUES('" + textBox5.Text + "', '" + textBox6.Text + "');";
				//otwórz połączenie z bazą danych
				polaczenie.Open();
				//blok try-catch przechwytuje błędy
				try
				{
					command.ExecuteNonQuery();

				}
				catch (MySql.Data.MySqlClient.MySqlException ex)
				{
					MessageBox.Show("Nie wstawilo pracownika", "Błąd");
				}

				try
				{
					MySqlCommand commandp = polaczenie.CreateCommand();
					commandp.CommandText = "SELECT id_Pracownika FROM  Pracownicy WHERE (Nazwisko='" + textBox6.Text + "' And Imie='" + textBox5.Text + "')";
						id_prac = commandp.ExecuteScalar().ToString();

				}
				catch (MySql.Data.MySqlClient.MySqlException ex)
				{
					MessageBox.Show("Nie wybrano id pracownika", "Błąd");
				}
				command.CommandText = "INSERT INTO uzytkownicy (login, haslo, Pracownicy_Id_Pracownicy) VALUES('" + textBox7.Text + "', '" + textBox8.Text + "' , '"+ id_prac +"');";
				try
				{
					command.ExecuteNonQuery();
				}

				//Jeżeli wystąpi wyjątek wyrzuć go i pokaż informacje
				catch (MySql.Data.MySqlClient.MySqlException ex)
				{
					MessageBox.Show("nie wstawiono uzytkownika", "Błąd");
				}
			}

			if (radioButton2.Checked)
			{
				command.CommandText = "INSERT INTO klienci (Imie, Nazwisko, Nazwa_firmy) VALUES('" + textBox5.Text + "', '" + textBox6.Text + "', '" + nazwa_firmy_txt.Text + "');";
				try
				{
					polaczenie.Open();
					command.ExecuteNonQuery();
					MySqlCommand commandk = polaczenie.CreateCommand();
					commandk.CommandText = "SELECT id_Klienci FROM  klienci WHERE (Nazwisko='" + textBox6.Text + "' And Imie='" + textBox5.Text + "')";

					id_klienci = commandk.ExecuteScalar().ToString();
					
					
					commandk.CommandText = "INSERT INTO uzytkownicy (login, haslo, Klienci_Id_Klienci) VALUES('" + textBox7.Text + "', '" + textBox8.Text + "' , '" + id_klienci + "');";
					commandk.ExecuteNonQuery();
					
				}
				catch (MySql.Data.MySqlClient.MySqlException ex)
				{
					MessageBox.Show("Błąd dodania klienta", "Błąd");
				}
			}
				if (radioButton3.Checked)
			{
				command.CommandText = "INSERT INTO dostawcy (Imie, Nazwisko, Nazwa_firmy) VALUES('" + textBox5.Text + "', '" + textBox6.Text + "', '" + nazwa_firmy_txt.Text + "');";
					try
					{
						polaczenie.Open();
						command.ExecuteNonQuery();
					MySqlCommand commandd = polaczenie.CreateCommand();
					commandd.CommandText = "SELECT id_Dostawcy FROM  dostawcy WHERE (Nazwisko='" + textBox6.Text + "' And Imie='" + textBox5.Text + "')";

					id_dost = commandd.ExecuteScalar().ToString();
					
					commandd.CommandText = "INSERT INTO uzytkownicy (login, haslo, Dostawcy_Id_Dostawcy) VALUES('" + textBox7.Text + "', '" + textBox8.Text + "' , '" + id_dost + "');";
					commandd.ExecuteNonQuery();
				}
					catch (MySql.Data.MySqlClient.MySqlException ex)
					{
						MessageBox.Show("Błąd logowania do bazy danych MySQL", "Błąd");
					}
				}

			
			//Zamknij połączenie
			polaczenie.Close();



		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{

		}

		private void Logowanie_baza_btn_Click(object sender, EventArgs e)
		{
			MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
			polaczenie.Open();
			MySqlCommand command = new MySqlCommand(  "SELECT login, haslo, Pracownicy_Id_Pracownicy, Klienci_Id_Klienci, Dostawcy_Id_dostawcy FROM uzytkownicy;", polaczenie);
			MySqlCommand commandlp = new MySqlCommand("SELECT Id_Pracownika FROM pracownicy;", polaczenie);
			MySqlCommand commandlk = new MySqlCommand("SELECT Id_Klienci FROM klienci;", polaczenie);
			MySqlCommand commandld = new MySqlCommand("SELECT Id_Dostawcy FROM dostawcy;", polaczenie);
			MySqlDataReader reader = command.ExecuteReader();
			DataTable schemaTable = reader.GetSchemaTable();
			string login, haslo;
			login= textBox9.Text;
			haslo =textBox10.Text;
			while (reader.Read())
			{

				foreach (DataRow row in schemaTable.Rows)
				{

					if (login == reader.GetString(0) && haslo == reader.GetString(1))
					{
						login = reader.GetString(0);
						haslo = reader.GetString(1);
						MessageBox.Show("Pomyślne Logowanie", "ZALOGOWANO");
						this.Hide();          // ( lub this.Visible = false;)
						if (reader.GetSafeString(2) != "")
						{ 
						FormPracownik f = new FormPracownik();
							id_pracownicy = reader.GetSafeString(4);

							f.id_pracownik = this.id_pracownicy.ToString();
							f.Show();
						}
						else if (reader.GetSafeString(4) != "")
						{
							FormDostawcy f2 = new FormDostawcy();
							id_dostawcy = reader.GetSafeString(4);

							f2.iddostawcy = this.id_dostawcy.ToString();
							f2.Show();
						}
						 else if (reader.GetSafeString(3) != "")
						{
							FormKlienta f3 = new FormKlienta();
							id_klienci = reader.GetSafeString(3);

							f3.idklienta = this.id_klienci.ToString();
							f3.Show();
							


						}
								break;
					}
					
				}
			}
			reader.Close();

			
	
			
			
			polaczenie.Close();
		}

	
	}
}

