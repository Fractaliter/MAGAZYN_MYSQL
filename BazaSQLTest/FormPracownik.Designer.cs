﻿namespace BazaSQLTest
{
	partial class FormPracownik
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Wyloguj = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.dataGridView3 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 129);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(272, 284);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
			// 
			// Wyloguj
			// 
			this.Wyloguj.Location = new System.Drawing.Point(634, 332);
			this.Wyloguj.Name = "Wyloguj";
			this.Wyloguj.Size = new System.Drawing.Size(208, 81);
			this.Wyloguj.TabIndex = 1;
			this.Wyloguj.Text = "Wyloguj";
			this.Wyloguj.UseVisualStyleBackColor = true;
			this.Wyloguj.Click += new System.EventHandler(this.Wyloguj_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(53, 42);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(164, 81);
			this.button2.TabIndex = 2;
			this.button2.Text = "Pokaz Zamowienia i Dostawy";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(460, 42);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(168, 81);
			this.button1.TabIndex = 3;
			this.button1.Text = "Pokaz Produkty";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new System.Drawing.Point(460, 129);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.Size = new System.Drawing.Size(168, 284);
			this.dataGridView2.TabIndex = 4;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(634, 105);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(208, 45);
			this.button3.TabIndex = 5;
			this.button3.Text = "Dodaj Produkt";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click_1);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(634, 26);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(127, 20);
			this.textBox5.TabIndex = 13;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(634, 52);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(127, 20);
			this.textBox1.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(767, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Nazwa Produktu";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(767, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "Cena Aktualna";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(634, 79);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(127, 20);
			this.textBox2.TabIndex = 18;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(767, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "Ilosc";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(290, 42);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(164, 81);
			this.button4.TabIndex = 20;
			this.button4.Text = "Pozycje zaznaczonego zamowienia";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// dataGridView3
			// 
			this.dataGridView3.AllowUserToAddRows = false;
			this.dataGridView3.AllowUserToDeleteRows = false;
			this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView3.Location = new System.Drawing.Point(290, 129);
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.Size = new System.Drawing.Size(164, 284);
			this.dataGridView3.TabIndex = 21;
			// 
			// FormPracownik
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(854, 508);
			this.Controls.Add(this.dataGridView3);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.Wyloguj);
			this.Controls.Add(this.dataGridView1);
			this.Name = "FormPracownik";
			this.Text = "FormPracownik";
			this.Load += new System.EventHandler(this.FormPracownik_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button Wyloguj;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGridView dataGridView3;
	}
}