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
    public partial class AddEventForm : Form
    {
        public Organizer organizer;

        public AddEventForm()
        {
            InitializeComponent();
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(EventType.METEENG.ToString()); 
            comboBox1.Items.Add(EventType.TASK.ToString());
        }
        public void setOrganize(ref Organizer organizer)
        {
            this.organizer = organizer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (DateTime.Now.Ticks > monthCalendar1.SelectionStart.Ticks)

            {
                MessageBox.Show("Дата уже прошла!!");
                return;
            }
            organizer.add(new Data(
               textBox1.Text, 
               monthCalendar1.SelectionStart, 
               dateTimePicker1.Value.TimeOfDay,
              (EventType)Enum.Parse(typeof(EventType), 
              comboBox1.Text, true)
                ));
            this.Close();
        }
    }
}
