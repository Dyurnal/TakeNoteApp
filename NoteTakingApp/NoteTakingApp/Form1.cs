using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingApp
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public NoteTaker()
        {
            InitializeComponent();
        }

        private void Title_TextChanged(object sender, EventArgs e)
        {

        }

        private void Note_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Loadbutton_Click(object sender, EventArgs e)
        {
            Title.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            Note.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = Title.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = Note.Text;
            }
            else
            {
                notes.Rows.Add(Title.Text, Note.Text);
            }
            Title.Text = "";
            Note.Text = "";
            editing = false;
        }

        private void NewNotebutton_Click(object sender, EventArgs e)
        {
            Title.Text = "";
            Note.Text = "";
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            try 
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex) { Console.WriteLine("Not valid note"); }
        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previousNotes.DataSource = notes;
        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Title.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            Note.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}
