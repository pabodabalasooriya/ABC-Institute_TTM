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
    public partial class ViewStudentGroup : Form
    {
        public ViewStudentGroup()
        {
            InitializeComponent();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private void ViewStudentGroup_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //set connection
        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source = timetable.db; Version=3;New=False;Compress=True;");
        }

        //set exeutequery code

        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }


        private void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select * from studentGroup";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            sql_con.Close();

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*private void SearchButton_Click(object sender, EventArgs e)
        {

            sql_con.Open();

            try
            {
                string txtQuery = "SELECT * FROM studentGroup ";
                string txtQuery += "WHERE AcedemicYear LIKE @keyword2";



            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " +ex.Message.ToString(),
                    "Error Message : Error finding.",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            finally
            {
                Close();
                KeywordTextBox1.Focus();
            }
        }*/
    }
}

    