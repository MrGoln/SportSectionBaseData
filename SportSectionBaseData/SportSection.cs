using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SportSectionBaseData
{
    public partial class SportSection : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter_SportsMan = null;

        private SqlDataAdapter sqlDataAdapter_Trainer = null;

        private SqlDataAdapter sqlDataAdapter_SportsTimeGroup = null;

        private SqlDataAdapter sqlDataAdapter_Sports = null;

        private DataSet dataSet_SportsMan = null;

        private DataSet dataSet_Trainer = null;

        private DataSet dataSet_SportsTimeGroup = null;

        private DataSet dataSet_Sports = null;

        private bool newRowAdding_SportsMan = false;

        private bool newRowAdding_Trainer = false;

        private bool newRowAdding_SportsTimeGroup = false;

        private bool newRowAdding_Sports = false;

        //Разные переменные с дописанием названий табличек sqlDataAdapter, dataSet, newRowAdding используються для корректной работы кода/

        public SportSection()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sancu\source\repos\SportSectionBaseData\SportSectionBaseData\SportSectionDataBase.mdf;Integrated Security=True");

            sqlConnection.Open();

            Load_Data_SportsMan();

            Load_Data_Trainer();

            Load_Data_SportsTimeGroup();

            Load_Data_Sports();

        }//Первоначальная загрузка базы данных и первоначальных функций

        //Начало кода для спортсменов

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            Reload_Data_SportsMan();
        }//Перезагрузка таблички

        private void Load_Data_SportsMan()
        {
            try
            {
                sqlDataAdapter_SportsMan = new SqlDataAdapter("SELECT *, 'Delete' AS [Action] FROM SportsMan", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter_SportsMan);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet_SportsMan = new DataSet();

                sqlDataAdapter_SportsMan.Fill(dataSet_SportsMan, "SportsMan");

                dataGridView1.DataSource = dataSet_SportsMan.Tables["SportsMan"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[7, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //Первоначальная загрузка тренеров

        private void Reload_Data_SportsMan()
        {
            try
            {
                dataSet_SportsMan.Tables["SportsMan"].Clear();

                sqlDataAdapter_SportsMan.Fill(dataSet_SportsMan, "SportsMan");

                dataGridView1.DataSource = dataSet_SportsMan.Tables["SportsMan"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[7, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Перезагрузка странички спортсменов

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            dataGridView1.Rows.RemoveAt(rowIndex);

                            dataSet_SportsMan.Tables["SportsMan"].Rows[rowIndex].Delete();

                            sqlDataAdapter_SportsMan.Update(dataSet_SportsMan, "SportsMan");
                        }

                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;

                        DataRow row = dataSet_SportsMan.Tables["SportsMan"].NewRow();

                        row["FullName"] = dataGridView1.Rows[rowIndex].Cells["FullName"].Value;
                        row["Trainer"] = dataGridView1.Rows[rowIndex].Cells["Trainer"].Value;
                        row["SportsRank"] = dataGridView1.Rows[rowIndex].Cells["SportsRank"].Value;
                        row["NumberPhone"] = dataGridView1.Rows[rowIndex].Cells["NumberPhone"].Value;
                        row["DateOfBirth"] = dataGridView1.Rows[rowIndex].Cells["DateOfBirth"].Value;
                        row["SportName"] = dataGridView1.Rows[rowIndex].Cells["SportName"].Value;

                        dataSet_SportsMan.Tables["SportsMan"].Rows.Add(row);

                        dataSet_SportsMan.Tables["SportsMan"].Rows.RemoveAt(dataSet_SportsMan.Tables["SportsMan"].Rows.Count - 2);

                        sqlDataAdapter_SportsMan.Update(dataSet_SportsMan, "SportsMan");

                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);

                        newRowAdding_SportsMan = false;
                    }

                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet_SportsMan.Tables["SportsMan"].Rows[r]["FullName"] = dataGridView1.Rows[r].Cells["FullName"].Value;
                        dataSet_SportsMan.Tables["SportsMan"].Rows[r]["Trainer"] = dataGridView1.Rows[r].Cells["Trainer"].Value;
                        dataSet_SportsMan.Tables["SportsMan"].Rows[r]["SportsRank"] = dataGridView1.Rows[r].Cells["SportsRank"].Value;
                        dataSet_SportsMan.Tables["SportsMan"].Rows[r]["NumberPhone"] = dataGridView1.Rows[r].Cells["NumberPhone"].Value;
                        dataSet_SportsMan.Tables["SportsMan"].Rows[r]["DateOfBirth"] = dataGridView1.Rows[r].Cells["DateOfBirth"].Value;
                        dataSet_SportsMan.Tables["SportsMan"].Rows[r]["SportName"] = dataGridView1.Rows[r].Cells["SportName"].Value;

                        sqlDataAdapter_SportsMan.Update(dataSet_SportsMan, "SportsMan");

                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = "Delete";
                    }

                    Reload_Data_SportsMan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }//Код для удаления, изменения и добавления 

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding_SportsMan == false)
                {
                    newRowAdding_SportsMan = true;

                    int lastRow = dataGridView1.Rows.Count - 2;

                    DataGridViewRow row = dataGridView1.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[7, lastRow] = linkCell;

                    row.Cells["Action"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//гипертекст добавить

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding_SportsMan == false)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[7, rowIndex] = linkCell;

                    editingRow.Cells["Action"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//гипертекст изменить

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"FullName LIKE '%{textBox1.Text}%'";
        }//Поиск по именам

        //Конец кода для спортсменов
        //#############################
        //Начало кода для тренеров
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            Reload_Data_Trainer();

        }//Перезагрузка таблички

        private void Load_Data_Trainer()
        {
            try
            {
                sqlDataAdapter_Trainer = new SqlDataAdapter("SELECT *, 'Delete' AS [Action] FROM Trainer", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter_Trainer);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet_Trainer = new DataSet();

                sqlDataAdapter_Trainer.Fill(dataSet_Trainer, "Trainer");

                dataGridView2.DataSource = dataSet_Trainer.Tables["Trainer"];

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView2[6, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //Первоначальная загрузка тренеров

        private void Reload_Data_Trainer()
        {
            try
            {
                dataSet_Trainer.Tables["Trainer"].Clear();

                sqlDataAdapter_Trainer.Fill(dataSet_Trainer, "Trainer");

                dataGridView2.DataSource = dataSet_Trainer.Tables["Trainer"];

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView2[6, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //Перезагрузка странички тренеров

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    string task = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            dataGridView2.Rows.RemoveAt(rowIndex);

                            dataSet_Trainer.Tables["Trainer"].Rows[rowIndex].Delete();

                            sqlDataAdapter_Trainer.Update(dataSet_Trainer, "Trainer");
                        }

                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView2.Rows.Count - 2;

                        DataRow row = dataSet_Trainer.Tables["Trainer"].NewRow();

                        row["FullName"] = dataGridView2.Rows[rowIndex].Cells["FullName"].Value;
                        row["SportsRank"] = dataGridView2.Rows[rowIndex].Cells["SportsRank"].Value;
                        row["NumberPhone"] = dataGridView2.Rows[rowIndex].Cells["NumberPhone"].Value;
                        row["DateOfBirth"] = dataGridView2.Rows[rowIndex].Cells["DateOfBirth"].Value;
                        row["SportName"] = dataGridView2.Rows[rowIndex].Cells["SportName"].Value;

                        dataSet_Trainer.Tables["Trainer"].Rows.Add(row);

                        dataSet_Trainer.Tables["Trainer"].Rows.RemoveAt(dataSet_Trainer.Tables["Trainer"].Rows.Count - 2);

                        sqlDataAdapter_Trainer.Update(dataSet_Trainer, "Trainer");

                        dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);

                        newRowAdding_Trainer = false;
                    }

                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet_Trainer.Tables["Trainer"].Rows[r]["FullName"] = dataGridView2.Rows[r].Cells["FullName"].Value;
                        dataSet_Trainer.Tables["Trainer"].Rows[r]["SportsRank"] = dataGridView2.Rows[r].Cells["SportsRank"].Value;
                        dataSet_Trainer.Tables["Trainer"].Rows[r]["NumberPhone"] = dataGridView2.Rows[r].Cells["NumberPhone"].Value;
                        dataSet_Trainer.Tables["Trainer"].Rows[r]["DateOfBirth"] = dataGridView2.Rows[r].Cells["DateOfBirth"].Value;
                        dataSet_Trainer.Tables["Trainer"].Rows[r]["SportName"] = dataGridView2.Rows[r].Cells["SportName"].Value;

                        sqlDataAdapter_Trainer.Update(dataSet_Trainer, "Trainer");

                        dataGridView2.Rows[e.RowIndex].Cells[6].Value = "Delete";
                    }

                    Reload_Data_Trainer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }//Код для удаления, изменения и добавления 

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding_Trainer == false)
                {
                    newRowAdding_Trainer = true;

                    int lastRow = dataGridView2.Rows.Count - 2;

                    DataGridViewRow row = dataGridView2.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView2[6, lastRow] = linkCell;

                    row.Cells["Action"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//гипертекст добавить

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding_Trainer == false)
                {
                    int rowIndex = dataGridView2.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView2.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView2[6, rowIndex] = linkCell;

                    editingRow.Cells["Action"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//гипертекст изменить

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = $"FullName LIKE '%{textBox2.Text}%'";
        }//Поиск по именам

        //Конец кода для тренеров
        //#############################
        //Начало кода для расписания

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            Reload_Data_SportsTimeGroup();
        }//Перезагрузка таблички

        private void Load_Data_SportsTimeGroup()
        {
            try
            {
                sqlDataAdapter_SportsTimeGroup = new SqlDataAdapter("SELECT *, 'Delete' AS [Action] FROM SportsTimeGroup", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter_SportsTimeGroup);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet_SportsTimeGroup = new DataSet();

                sqlDataAdapter_SportsTimeGroup.Fill(dataSet_SportsTimeGroup, "SportsTimeGroup");

                dataGridView3.DataSource = dataSet_SportsTimeGroup.Tables["SportsTimeGroup"];

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView3[9, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Первоначальная загрузка тренеров

        private void Reload_Data_SportsTimeGroup()
        {
            try
            {
                dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Clear();

                sqlDataAdapter_SportsTimeGroup.Fill(dataSet_SportsTimeGroup, "SportsTimeGroup");

                dataGridView3.DataSource = dataSet_SportsTimeGroup.Tables["SportsTimeGroup"];

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView3[9, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Перезагрузка странички тренеров

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9)
                {
                    string task = dataGridView3.Rows[e.RowIndex].Cells[9].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            dataGridView3.Rows.RemoveAt(rowIndex);

                            dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows[rowIndex].Delete();

                            sqlDataAdapter_SportsTimeGroup.Update(dataSet_SportsTimeGroup, "SportsTimeGroup");
                        }

                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView3.Rows.Count - 2;

                        DataRow row = dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].NewRow();

                        row["SportName"] = dataGridView3.Rows[rowIndex].Cells["SportName"].Value;
                        row["Monday"] = dataGridView3.Rows[rowIndex].Cells["Monday"].Value;
                        row["Tuesday"] = dataGridView3.Rows[rowIndex].Cells["Tuesday"].Value;
                        row["Wednesday"] = dataGridView3.Rows[rowIndex].Cells["Wednesday"].Value;
                        row["Thusday"] = dataGridView3.Rows[rowIndex].Cells["Thusday"].Value;
                        row["Friday"] = dataGridView3.Rows[rowIndex].Cells["Friday"].Value;
                        row["Saturday"] = dataGridView3.Rows[rowIndex].Cells["Saturday"].Value;
                        row["Sunday"] = dataGridView3.Rows[rowIndex].Cells["Sunday"].Value;

                        dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows.Add(row);

                        dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows.RemoveAt(dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows.Count - 1);//2

                        dataGridView3.Rows.RemoveAt(dataGridView3.Rows.Count - 2);//Под кодом sqlDataAdapter_SportsTimeGroup.Update(dataSet_SportsTimeGroup, "SportsTimeGroup");/

                        sqlDataAdapter_SportsTimeGroup.Update(dataSet_SportsTimeGroup, "SportsTimeGroup");

                        newRowAdding_SportsTimeGroup = false;
                    }

                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows[r]["SportName"] = dataGridView3.Rows[r].Cells["SportName"].Value;
                        dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows[r]["Monday"] = dataGridView3.Rows[r].Cells["Monday"].Value;
                        dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows[r]["Tuesday"] = dataGridView3.Rows[r].Cells["Tuesday"].Value;
                        dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows[r]["Wednesday"] = dataGridView3.Rows[r].Cells["Wednesday"].Value;
                        dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows[r]["Thusday"] = dataGridView3.Rows[r].Cells["Thusday"].Value;
                        dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows[r]["Friday"] = dataGridView3.Rows[r].Cells["Friday"].Value;
                        dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows[r]["Saturday"] = dataGridView3.Rows[r].Cells["Saturday"].Value;
                        dataSet_SportsTimeGroup.Tables["SportsTimeGroup"].Rows[r]["Sunday"] = dataGridView3.Rows[r].Cells["Sunday"].Value;

                        sqlDataAdapter_SportsTimeGroup.Update(dataSet_SportsTimeGroup, "SportsTimeGroup");

                        dataGridView3.Rows[e.RowIndex].Cells[9].Value = "Delete";
                    }

                    Reload_Data_SportsTimeGroup();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Код для удаления, изменения и добавления 

        private void dataGridView3_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding_SportsTimeGroup == false)
                {
                    newRowAdding_SportsTimeGroup = true;

                    int lastRow = dataGridView3.Rows.Count - 2;

                    DataGridViewRow row = dataGridView3.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView3[9, lastRow] = linkCell;

                    row.Cells["Action"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//гипертекст добавить

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding_SportsTimeGroup == false)
                {
                    int rowIndex = dataGridView3.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView3.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView3[9, rowIndex] = linkCell;

                    editingRow.Cells["Action"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//гипертекст изменить

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = $"SportName LIKE '%{textBox3.Text}%'";
        }//Поиск по именам

        //Конец кода для расписания
        //#############################
        //Начало кода для дисциплин

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            Reload_Data_Sports();
        }//Перезагрузка таблички

        private void Load_Data_Sports()
        {
            try
            {
                sqlDataAdapter_Sports = new SqlDataAdapter("SELECT *, 'Delete' AS [Action] FROM Sports", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter_Sports);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet_Sports = new DataSet();

                sqlDataAdapter_Sports.Fill(dataSet_Sports, "Sports");

                dataGridView4.DataSource = dataSet_Sports.Tables["Sports"];

                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView4[2, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Первоначальная загрузка тренеров

        private void Reload_Data_Sports()
        {
            try
            {
                dataSet_Sports.Tables["Sports"].Clear();

                sqlDataAdapter_Sports.Fill(dataSet_Sports, "Sports");

                dataGridView4.DataSource = dataSet_Sports.Tables["Sports"];

                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView4[2, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Перезагрузка странички тренеров

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    string task = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            dataGridView4.Rows.RemoveAt(rowIndex);

                            dataSet_Sports.Tables["Sports"].Rows[rowIndex].Delete();

                            sqlDataAdapter_Sports.Update(dataSet_Sports, "Sports");
                        }

                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView4.Rows.Count - 2;

                        DataRow row = dataSet_Sports.Tables["Sports"].NewRow();

                        row["SportName"] = dataGridView4.Rows[rowIndex].Cells["SportName"].Value;
                        row["SportsRules"] = dataGridView4.Rows[rowIndex].Cells["SportsRules"].Value;

                        dataSet_Sports.Tables["Sports"].Rows.Add(row);

                        dataSet_Sports.Tables["Sports"].Rows.RemoveAt(dataSet_Sports.Tables["Sports"].Rows.Count - 2);

                        sqlDataAdapter_Sports.Update(dataSet_Sports, "Sports");

                        dataGridView4.Rows.RemoveAt(dataGridView4.Rows.Count - 2);

                        newRowAdding_Sports = false;
                    }

                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet_Sports.Tables["Sports"].Rows[r]["SportName"] = dataGridView4.Rows[r].Cells["SportName"].Value;
                        dataSet_Sports.Tables["Sports"].Rows[r]["SportsRules"] = dataGridView4.Rows[r].Cells["SportsRules"].Value;

                        sqlDataAdapter_Sports.Update(dataSet_Sports, "Sports");

                        dataGridView4.Rows[e.RowIndex].Cells[2].Value = "Delete";
                    }

                    Reload_Data_Sports();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Код для удаления, изменения и добавления 

        private void dataGridView4_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding_Sports == false)
                {
                    newRowAdding_Sports = true;

                    int lastRow = dataGridView4.Rows.Count - 2;

                    DataGridViewRow row = dataGridView4.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView4[2, lastRow] = linkCell;

                    row.Cells["Action"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//гипертекст добавить

        private void dataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding_Sports == false)
                {
                    int rowIndex = dataGridView4.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView4.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView4[2, rowIndex] = linkCell;

                    editingRow.Cells["Action"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//гипертекст изменить

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = $"SportName LIKE '%{textBox4.Text}%'";
        }//Поиск по именам

        //Конец кода для дисциплин
        //#############################
        //###### Конец всего кода #####
        //#############################
    }
}
