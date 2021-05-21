﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace ABC_Institute_Menu
{
    public partial class addLecturer : Form
    {
        public addLecturer()
        {
            InitializeComponent();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();


        private void label8_Click(object sender, EventArgs e)
        {
          
        }

        //set Connection
        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=timetable.db;version=3;New=False;Compress=True");
        }

        //set execute query
        private void ExecuteQuery(String txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        //set LoadDb
        private void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select * from tbLecturers";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            sql_con.Close();
        }



        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addLecturer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        //add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string txtQuery = " insert into tbLecturers ( EmployeeID,EmployeeName,Faculty,Department,Center,Building,Level,Rank ) values ( '" + textBox3.Text + "','" + textBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "')";


            //Check text fileds are not empty
            if (textBox2.Text == "" || textBox3.Text == "" || textBox6.Text == "" || textBox1.Text == ""  )
            {
                MessageBox.Show("Fill all records !! ");
            }

            else if (comboBox1.Text == null || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Level is empty !! ");
            }

            else if (comboBox2.Text == null || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Faculty is empty !! ");
            }

            else if (comboBox3.Text == null || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Department is empty !! ");
            }

            else if(comboBox4.Text == null || comboBox1.Text == string.Empty )
            {
                MessageBox.Show("Center is emptyl !! ");
            }

            
            //Check Length only 6 digit in Employee number
            else if (textBox3.Text.Length < 6 || textBox3.Text.Length > 6)
            {
                MessageBox.Show("Invalied Employee ID.Enter 6 Digit !! ");
            }


            else
            {
                ExecuteQuery(txtQuery);
                LoadData();


                MessageBox.Show("One Record Added Successfully !! ");
                return;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string txtQuery = "update tbLecturers set EmployeeName = '" + textBox1.Text + "',EmployeeID = '" + textBox3.Text + "',Faculty = '" + comboBox2.Text + "',Department ='" + comboBox3.Text + "',Center ='" + comboBox4.Text + "',Building = '" + textBox6.Text + "',Level = '" + comboBox1.Text + "',Rank = '" + textBox2.Text + "' where EmployeeID = '" + textBox3.Text + "' ";

            //Check text fileds are not empty
            if (textBox2.Text == "" || textBox3.Text == "" || textBox6.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Fill all records !! ");
            }

            else if (comboBox1.Text == null || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Level is empty !! ");
            }

            else if (comboBox2.Text == null || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Faculty is empty !! ");
            }

            else if (comboBox3.Text == null || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Department is empty !! ");
            }

            else if (comboBox4.Text == null || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Center is emptyl !! ");
            }


            //Check Length only 6 digit in Employee number
            else if (textBox3.Text.Length < 6 || textBox3.Text.Length > 6)
            {
                MessageBox.Show("Invalied Employee ID.Enter 6 Digit !! ");
            }



            else
            {

                ExecuteQuery(txtQuery);
                LoadData();
                MessageBox.Show("Updated Successfully !! ");
                return;
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string txtQuery = "delete from tbLecturers where EmployeeID = '" + textBox3.Text + "' " ;
            ExecuteQuery(txtQuery);
            LoadData();
            MessageBox.Show("Record Deleted !! ");
            return;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string EmpID = textBox3.Text;
            string EmpLevel = comboBox1.Text;
            string Rank = EmpLevel + " . " + EmpID;
            textBox2.Text = Rank;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if( String.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                ErrorProvider.ReferenceEquals(textBox1, "Enter Employee Name");

            }
            else
            {
                e.Cancel = false;
                ErrorProvider.ReferenceEquals(textBox1, " ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            //textBox4.Text = " ";
           // textBox5.Text = " ";
            textBox6.Text = " ";
           // textBox7.Text = " ";

            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox4.Text = string.Empty;






        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
