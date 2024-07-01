using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rsm.Dialogs {
    public partial class dialogRename : Form {
        public string Result { get; private set; }

        public dialogRename(string currentName) {
            InitializeComponent();
            txtRename.Text = currentName;
        }

        private void Submit(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Result = txtRename.Text;
            Close();
        }
    }
}
