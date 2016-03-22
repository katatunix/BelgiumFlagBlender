using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belgium
{
	public partial class MainForm : Form
	{
		private Avatar avatar;

		public MainForm()
		{
			InitializeComponent();
			avatar = new Avatar(Properties.Resources.belgium);
		}

		private void buttonOpen_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				 load(openFileDialog1.FileName);
			}
		}

		private void load(String path) {
			this.pictureBox1.Image = avatar.blend(new Bitmap(path));
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
				this.pictureBox1.Image.Save(saveFileDialog1.FileName);
			}
		}
	}
}
