using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration.Install;

namespace CustomAction
{
    public partial class Form1 : Form
    {
        System.Configuration.Install.InstallContext formContext;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(System.Configuration.Install.InstallContext context)
        {
            formContext = context;
            InitializeComponent();
            this.CenterToScreen();
        }

    }
}
