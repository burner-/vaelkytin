using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSGSI.Nodes;

namespace vaelkytin
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerComboBox1.Items.Clear();
            playerComboBox2.Items.Clear();
            playerComboBox3.Items.Clear();
            playerComboBox4.Items.Clear();
            playerComboBox5.Items.Clear();
            playerComboBox6.Items.Clear();
            playerComboBox7.Items.Clear();
            playerComboBox8.Items.Clear();
            playerComboBox9.Items.Clear();
            playerComboBox10.Items.Clear();
            foreach (PlayerNode n in Program.nodeList)
            {
                PlayerIdNode p = new PlayerIdNode(n);
                if (!playerComboBox1.Items.Contains(p))
                {
                    playerComboBox1.Items.Add(p);
                    playerComboBox2.Items.Add(p);
                    playerComboBox3.Items.Add(p);
                    playerComboBox4.Items.Add(p);
                    playerComboBox5.Items.Add(p);
                    playerComboBox6.Items.Add(p);
                    playerComboBox7.Items.Add(p);
                    playerComboBox8.Items.Add(p);
                    playerComboBox9.Items.Add(p);
                    playerComboBox10.Items.Add(p);
                }
            }
            
        }

        private void playerComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox1.SelectedItem) != null)
                textBox1.Text = ((PlayerIdNode)playerComboBox1.SelectedItem).SteamID;
        }

        private void playerComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox2.SelectedItem) != null)
                textBox2.Text = ((PlayerIdNode)playerComboBox2.SelectedItem).SteamID;
        }

        private void playerComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox3.SelectedItem) != null)
                textBox4.Text = ((PlayerIdNode)playerComboBox3.SelectedItem).SteamID;
        }

        private void playerComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox4.SelectedItem) != null)
                textBox3.Text = ((PlayerIdNode)playerComboBox4.SelectedItem).SteamID;
        }

        private void playerComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox5.SelectedItem) != null)
                textBox5.Text = ((PlayerIdNode)playerComboBox5.SelectedItem).SteamID;
        }

        private void playerComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox6.SelectedItem) != null)
                textBox10.Text = ((PlayerIdNode)playerComboBox6.SelectedItem).SteamID;
        }

        private void playerComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox7.SelectedItem) != null)
                textBox9.Text = ((PlayerIdNode)playerComboBox7.SelectedItem).SteamID;
        }

        private void playerComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox8.SelectedItem) != null)
                textBox8.Text = ((PlayerIdNode)playerComboBox8.SelectedItem).SteamID;
        }

        private void playerComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox9.SelectedItem) != null)
                textBox7.Text = ((PlayerIdNode)playerComboBox9.SelectedItem).SteamID;
        }

        private void playerComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox10.SelectedItem) != null)
                textBox6.Text = ((PlayerIdNode)playerComboBox10.SelectedItem).SteamID;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Program.healthBars.SetHealthBarId(0, textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Program.healthBars.SetHealthBarId(1, textBox2.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Program.healthBars.SetHealthBarId(2, textBox4.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Program.healthBars.SetHealthBarId(3, textBox3.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Program.healthBars.SetHealthBarId(4, textBox5.Text);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            Program.healthBars.SetHealthBarId(5, textBox10.Text);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            Program.healthBars.SetHealthBarId(6, textBox9.Text);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Program.healthBars.SetHealthBarId(7, textBox8.Text);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Program.healthBars.SetHealthBarId(8, textBox7.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Program.healthBars.SetHealthBarId(9, textBox6.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            playerComboBox1.SelectedIndex = -1;
            playerComboBox2.SelectedIndex = -1;
            playerComboBox3.SelectedIndex = -1;
            playerComboBox4.SelectedIndex = -1;
            playerComboBox5.SelectedIndex = -1;
            playerComboBox6.SelectedIndex = -1;
            playerComboBox7.SelectedIndex = -1;
            playerComboBox8.SelectedIndex = -1;
            playerComboBox9.SelectedIndex = -1;
            playerComboBox10.SelectedIndex = -1;
            Program.healthBars.Reset();
        }

        private void ConfigurationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.gsl.Stop();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.config.DefaultScreen++;
            if (Program.config.DefaultScreen > Screen.AllScreens.Length) Program.config.DefaultScreen = 0;
            Program.SetBarsToScreen(Program.config.DefaultScreen);
        }
    }
}
