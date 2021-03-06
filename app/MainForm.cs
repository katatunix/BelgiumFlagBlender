﻿using System;
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

		public MainForm(Avatar avatar)
		{
			InitializeComponent();
			this.avatar = avatar;
		}

		private void buttonOpen_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				 load(openFileDialog.FileName);
			}
		}

		private void load(String path) {
			this.pictureBox.Image = avatar.blend(new Bitmap(path));
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				this.pictureBox.Image.Save(saveFileDialog.FileName);
			}
		}
	}
}
