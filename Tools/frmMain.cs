﻿using LearnByPractice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuGenerira_Click(object sender, EventArgs e)
        {
            Generator generator = new Generator();
            generator.Show();
        }

        private void mnuHashingPassword_Click(object sender, EventArgs e)
        {
            frmHashing child = new frmHashing();
            child.Show();
        }

        private void mnuDrugKodZaHash_Click(object sender, EventArgs e)
        {
            frmPassHashing child = new frmPassHashing();
            child.Show();
        }
    }
}
