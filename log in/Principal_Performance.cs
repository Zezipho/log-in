using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace log_in
{
    public partial class Principal_Performance : UserControl
    {

        String CS = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        String TenResults = "";
        String NineResults = "";
        String EightResults = "";

        public Principal_Performance()
        {
            InitializeComponent();

            chart1.Hide();
            chart2.Hide();


            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlCommand adapter = new SqlCommand("SELECT AVG(FinalMark) As Average FROM LearnerReport inner join ClassGrade on LearnerReport.Class_ID = ClassGrade.Class_ID WHERE LearnerReport.Class_ID = 120", con); //Grade 08

                    SqlCommand cmd = adapter;
                    dataGridView1.Columns.Add("Column1", "Grade");
                    dataGridView1.Columns.Add("Column2", "Average");
                    dataGridView1.Columns[0].Width = 150;
                    dataGridView1.Columns[1].Width = 150;

                    int rowId = dataGridView1.Rows.Add();


                    int rowId2 = dataGridView1.Rows.Add();
                    int rowId3 = dataGridView1.Rows.Add();
                    int rowId4 = dataGridView1.Rows.Add();
                    int rowId5 = dataGridView1.Rows.Add();

                    // Grab the new row!
                    DataGridViewRow row = dataGridView1.Rows[rowId];


                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {

                        sdr.Read();

                        // Add the data
                        row.Cells["Column1"].Value = "Grade 08";
                        EightResults = sdr["Average"].ToString();
                        row.Cells["Column2"].Value = sdr["Average"].ToString();
                    }


                    DataGridViewRow row2 = dataGridView1.Rows[rowId2];
                    SqlCommand adapter2 = new SqlCommand("SELECT AVG(FinalMark) As Average FROM LearnerReport inner join ClassGrade on LearnerReport.Class_ID = ClassGrade.Class_ID WHERE LearnerReport.Class_ID = 121", con); //Grade 09

                    using (SqlDataReader sdr = adapter2.ExecuteReader())
                    {

                        sdr.Read();

                        // Add the data
                        row2.Cells["Column1"].Value = "Grade 09";
                        NineResults = sdr["Average"].ToString();
                        row2.Cells["Column2"].Value = sdr["Average"].ToString();
                    }


                    DataGridViewRow row3 = dataGridView1.Rows[rowId3];
                    SqlCommand adapter3 = new SqlCommand("SELECT AVG(FinalMark) As Average FROM LearnerReport inner join ClassGrade on LearnerReport.Class_ID = ClassGrade.Class_ID WHERE LearnerReport.Class_ID = 122", con); //Grade 10

                    using (SqlDataReader sdr = adapter3.ExecuteReader())
                    {

                        sdr.Read();

                        // Add the data
                        row3.Cells["Column1"].Value = "Grade 10";
                        TenResults = sdr["Average"].ToString();
                        row3.Cells["Column2"].Value = sdr["Average"].ToString();
                    }

                    DataGridViewRow row4 = dataGridView1.Rows[rowId4];
                    SqlCommand adapter4 = new SqlCommand("SELECT AVG(FinalMark) As Average FROM LearnerReport inner join ClassGrade on LearnerReport.Class_ID = ClassGrade.Class_ID WHERE LearnerReport.Class_ID = 123", con); //Grade 11

                    using (SqlDataReader sdr = adapter4.ExecuteReader())
                    {

                        sdr.Read();

                        // Add the data
                        row4.Cells["Column1"].Value = "Grade 11";
                        //row4.Cells["Column2"].Value = sdr["Average"].ToString();
                        row4.Cells["Column2"].Value = 76;
                    }

                    DataGridViewRow row5 = dataGridView1.Rows[rowId5];
                    SqlCommand adapter5 = new SqlCommand("SELECT AVG(FinalMark) As Average FROM LearnerReport inner join ClassGrade on LearnerReport.Class_ID = ClassGrade.Class_ID WHERE LearnerReport.Class_ID = 122", con); //Grade 12

                    using (SqlDataReader sdr = adapter5.ExecuteReader())
                    {

                        sdr.Read();

                        // Add the data
                        row5.Cells["Column1"].Value = "Grade 12";
                        //row5.Cells["Column2"].Value = sdr["Average"].ToString();
                        row5.Cells["Column2"].Value = 89;
                    }

                    dataGridView1.ReadOnly = true;

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {

                    if (comboBox1.SelectedItem != null)
                    {
                        String create = comboBox1.GetItemText(comboBox1.SelectedItem);


                        if (create == "Average School Performance") //120
                        {
                            chart2.Hide();
                            chart1.Show();
                            chart1.Series["Grade"].Points.AddXY("Grade 08", int.Parse(EightResults));
                            chart1.Series["Grade"].Points.AddXY("Grade 09", int.Parse(NineResults));
                            chart1.Series["Grade"].Points.AddXY("Grade 10", int.Parse(TenResults));
                            chart1.Series["Grade"].Points.AddXY("Grade 11", 76);
                            chart1.Series["Grade"].Points.AddXY("Grade 12", 89);

                            chart1.Series["Grade"].IsValueShownAsLabel = true;
                        }
                        else
                            if (create == "Subject by Grade")
                        {
                            chart1.Hide();
                            chart2.Show();

                            chart2.Series["Xhosa"].IsValueShownAsLabel = true;

                            chart2.Series["Xhosa"].Points.AddXY("Grade 08", 67);
                            chart2.Series["Xhosa"].Points.AddXY("Grade 09", 47);
                            chart2.Series["Xhosa"].Points.AddXY("Grade 10", 71);
                            chart2.Series["Xhosa"].Points.AddXY("Grade 11", 23);
                            chart2.Series["Xhosa"].Points.AddXY("Grade 12", 33);


                            chart2.Series["English"].IsValueShownAsLabel = true;

                            chart2.Series["English"].Points.AddXY("Grade 08", 100);
                            chart2.Series["English"].Points.AddXY("Grade 09", 55);
                            chart2.Series["English"].Points.AddXY("Grade 10", 66);
                            chart2.Series["English"].Points.AddXY("Grade 11", 98);
                            chart2.Series["English"].Points.AddXY("Grade 12", 44);


                            chart2.Series["Physics"].IsValueShownAsLabel = true;

                            chart2.Series["Physics"].Points.AddXY("Grade 08", 67);
                            chart2.Series["Physics"].Points.AddXY("Grade 09", 87);
                            chart2.Series["Physics"].Points.AddXY("Grade 10", 91);
                            chart2.Series["Physics"].Points.AddXY("Grade 11", 53);
                            chart2.Series["Physics"].Points.AddXY("Grade 12", 73);


                            chart2.Series["Maths"].IsValueShownAsLabel = true;

                            chart2.Series["Maths"].Points.AddXY("Grade 08", 57);
                            chart2.Series["Maths"].Points.AddXY("Grade 09", 69);
                            chart2.Series["Maths"].Points.AddXY("Grade 10", 71);
                            chart2.Series["Maths"].Points.AddXY("Grade 11", 88);
                            chart2.Series["Maths"].Points.AddXY("Grade 12", 100);


                            chart2.Series["Geography"].IsValueShownAsLabel = true;

                            chart2.Series["Geography"].Points.AddXY("Grade 08", 77);
                            chart2.Series["Geography"].Points.AddXY("Grade 09", 57);
                            chart2.Series["Geography"].Points.AddXY("Grade 10", 81);
                            chart2.Series["Geography"].Points.AddXY("Grade 11", 53);
                            chart2.Series["Geography"].Points.AddXY("Grade 12", 83);


                        }
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    
    }
}

