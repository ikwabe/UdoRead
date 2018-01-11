﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Bunifu.Framework.UI;

namespace OnlineMongo
{
    public partial class login : Form
    {
        public static BunifuMaterialTextbox txt = new BunifuMaterialTextbox();
        public static string user_id;
        public login()
        {
            InitializeComponent();
        }

        public static string dbConnection = "server = localhost; user = root; password = ikwabe04; database = udoread;";
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Are you sure you want to close?","Close",MessageBoxButtons.YesNo) == DialogResult.Yes){
                Application.Exit();
            }
        }
       
        

        private void animate_Tick(object sender, EventArgs e)
        {
            animate.Stop();
                annimator.ShowSync(logopic);
        }

        private void login_Load(object sender, EventArgs e)
        {
            logopic.Visible = false;
            animate.Start();

            txt.Size = new Size(295, 33);
            txt.Location = new Point(124, 282);
            txt.Visible = true;
            txt.Margin = new Padding(4, 4, 4, 4);
            txt.ForeColor = Color.FromArgb(64,64,64);
            txt.BackColor = Color.FromArgb(30, 0, 40);
            txt.HintForeColor = Color.FromArgb(64,64,64);
           
            Controls.Add(txt);

        }


        private void signUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            signUp sgp = new signUp();
            sgp.Show();
            this.Hide();
        }

        private void forgetPwdLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            verifyEmail ve = new verifyEmail();
            ve.Show();
            this.Hide();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = dbConnection;
            string signIn = "select username,password from users where username = '" + txt.Text + "' and password = '" + pwd.Text + "'";
            string chekSecWord = "select secword from users where username = '" + txt.Text + "' and password = '" + pwd.Text + "'";
            string usertake = "select * from users where username = '" + txt.Text + "' and password = '" + pwd.Text + "'";
            MySqlCommand com = new MySqlCommand(signIn, con);
            MySqlCommand com1 = new MySqlCommand(chekSecWord, con);
            MySqlCommand com2 = new MySqlCommand(usertake, con);
            MySqlDataAdapter da;
            DataTable usertable = new DataTable();
            try
            {
                con.Open();

                MySqlDataReader reader;
                DataTable table = new DataTable();
                if (txt.Text == "")
                {
                    label3.Text = "Username field can not be empty.";
                }
                else if (pwd.Text == "")
                {
                    label3.Text = "Password field can not be empty.";

                }
                else
                {
                reader = com.ExecuteReader();
                table.Load(reader);
                reader.Close();

                //execute ones to check if the database is empty or not
                object nullValue = com1.ExecuteScalar();

                if (table.Rows.Count > 0)
                {
                    pwd.Enabled = false;
                    if (nullValue == null || nullValue == DBNull.Value)
                    {
                        MessageBox.Show("Please remember to set your SECRET WORD for password recovery and security purposes.");
                            //capturing user id for public purposes
                            da = new MySqlDataAdapter(com2);
                            da.Fill(usertable);
                            user_id = usertable.Rows[0][0].ToString();
                            da.Dispose();
                            dashBoard dsb = new dashBoard();
                        dsb.Show();
                        this.Hide();
                    }
                    else
                    {
                            //capturing user id for public purposes
                            da = new MySqlDataAdapter(com2);
                            da.Fill(usertable);
                            user_id = usertable.Rows[0][0].ToString();
                            da.Dispose();
                            dashBoard dsb = new dashBoard();
                        dsb.Show();
                        this.Hide();

                    }


                }
                else
                {
                    label3.Text = "You have enterd a wrong Password or Username";
                }
            }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
       
        private void pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = dbConnection;
                string signIn = "select username,password from users where username = '" + txt.Text + "' and password = '" + pwd.Text + "'";
                string chekSecWord = "select secword from users where username = '" + txt.Text + "' and password = '" + pwd.Text + "'";
                string usertake = "select * from users where username = '" + txt.Text + "' and password = '" + pwd.Text + "'";
                MySqlCommand com = new MySqlCommand(signIn, con);
                MySqlCommand com1 = new MySqlCommand(chekSecWord, con);
                MySqlCommand com2 = new MySqlCommand(usertake, con);
                MySqlDataAdapter da;
                DataTable usertable = new DataTable();
                try
                {
                    con.Open();
                    MySqlDataReader reader;
                    DataTable table = new DataTable();
                    if (txt.Text == "")
                    {
                        label3.Text = "Username field can not be empty.";
                    }
                    else if (pwd.Text == "")
                    {
                        label3.Text = "Password field can not be empty.";

                    }
                    else
                    {
                        reader = com.ExecuteReader();
                        table.Load(reader);
                        reader.Close();

                        //execute ones to check if the database is empty or not
                        object nullValue = com1.ExecuteScalar();

                        if (table.Rows.Count > 0)
                        {
                            pwd.Enabled = false;
                            if (nullValue == null || nullValue == DBNull.Value)
                            {
                                MessageBox.Show("Please remember to set your SECRET WORD for password recovery and security purposes.");
                                //capturing user id for public purposes
                                da = new MySqlDataAdapter(com2);
                                da.Fill(usertable);
                                user_id = usertable.Rows[0][0].ToString();
                                da.Dispose();
                                dashBoard dsb = new dashBoard();
                                dsb.Show();
                                this.Hide();
                            }
                            else
                            {
                                //capturing user id for public purposes
                                da = new MySqlDataAdapter(com2);
                                da.Fill(usertable);
                                user_id = usertable.Rows[0][0].ToString();
                                da.Dispose();
                                dashBoard dsb = new dashBoard();
                                dsb.Show();
                                this.Hide();

                            }


                        }
                        else
                        {
                            label3.Text = "You have enterd a wrong Password or Username";
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            else
            {

            }
        }
    }
}
