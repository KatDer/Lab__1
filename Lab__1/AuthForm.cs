using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab__1
{
    public partial class AuthForm : Form
    {
        const String Login = "admin";
        const String password = "admin";

        public AuthForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tmpLogin = textBox1.Text.Trim(); 
            String tmpPassword = textBox2.Text.Trim();
            if (!tmpLogin.Equals(Login) || !tmpPassword.Equals(password))
            {
                MessageBox.Show("Данные аккаунта не верны!!");
                return;
            }
                
            
            {
                MessageBox.Show("Отлично!!");
                OrganizerForm organizerForm = new OrganizerForm(); 
                organizerForm.Show();
                this.Hide();
            }
                
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Boolean isShowPassword = checkBox1.Checked;
            textBox2.PasswordChar = !isShowPassword ? '*' : '\0';
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(":(", "Выход", MessageBoxButtons.OK) == DialogResult.OK)
            {
                Close();
            }
        }

    }
}
