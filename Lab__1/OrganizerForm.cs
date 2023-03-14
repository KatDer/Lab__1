using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Lab__1
{
    public partial class OrganizerForm : Form
    {
        

        

        public Organizer organizer = new Organizer();

        public OrganizerForm()
        {
            InitializeComponent();
        }

        private void OrganizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEventForm eventForm = new AddEventForm();
            eventForm.Show();
            eventForm.setOrganize(ref organizer);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

            refreshDataGridView();


        }

        public void refreshDataGridView()
        {
            dataGridView1.Rows.Clear();

            organizer.list.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Date.Year}-{item.Date.Month}-{item.Date.Day}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Time.Hours}:{item.Time.Minutes}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });

                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = item.EventType.ToString(),
                    Style = new DataGridViewCellStyle
                    {
                        BackColor = item.EventType == EventType.TASK ? Color.IndianRed : Color.GreenYellow
                    }
                });


                dataGridView1.Rows.Add(row);
            });
        }

        private void OrganizerForm_Activated(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = !groupBox3.Visible; 
            button2.Text = groupBox3.Visible ? "Скрыть поиск" : "Найти";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

            List<Data> tmp = organizer.findByTime(dateTimePicker1.Text);
            dataGridView1.Rows.Clear();
            tmp.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Date.Year}-{item.Date.Month}-{item.Date.Day}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Time.Hours}:{item.Time.Minutes}:{item.Time.Seconds}"
                });

                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });
                dataGridView1.Rows.Add(row);
            });

        }

        private void button4_Click(object sender, EventArgs e)
        {
            organizer.sortByEvent(0);
            refreshDataGridView();
        }

        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(EventType.METEENG.ToString());
            comboBox1.Items.Add(EventType.TASK.ToString());
            comboBox1.Select(0, 1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            List<Data> tmp = organizer.findByCategory((EventType)Enum.Parse(typeof(EventType),
                comboBox1.Text,true));
            dataGridView1.Rows.Clear();
            tmp.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Date.Year}-{item.Date.Month}-{item.Date.Day}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Time.Hours}:{item.Time.Minutes}"
                });

                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });

                dataGridView1.Rows.Add(row);
            });
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            organizer.sortByEvent(1);
            refreshDataGridView();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(dateTimePicker1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }

            }
        }
    }
}
