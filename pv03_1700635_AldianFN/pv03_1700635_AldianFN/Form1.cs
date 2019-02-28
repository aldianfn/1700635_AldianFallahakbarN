using pv03_1700635_AldianFN.Model;
using pv03_1700635_AldianFN.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pv03_1700635_AldianFN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNim_Click(object sender, EventArgs e)
        {
            TodoRepository todo = new TodoRepository();
            
            string nim = txtNim.Text;

            if(todo.cekNim(nim) == 1)
            {
                txtNim.Enabled = false;
                btnTambah.Enabled = true;
                btnNim.Enabled = false;

                dataGridView1.DataSource = todo.getByNim(nim);

            }
            else
            {
                MessageBox.Show("NIM tidak terdaftar");
                txtNim.Text = "";
                txtNim.Focus();
            }
            
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.NimMhs = txtNim.Text;
            temp.Nama = txtNama.Text;
            temp.Kategori = txtKategori.Text;

            TodoRepository todo = new TodoRepository();

            todo.addTodo(temp);

            string nim = txtNim.Text;

            btnDelete.Enabled = true;
            btnTambah.Enabled = false;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.Id= Convert.ToInt16(txtId.Text);

            TodoRepository todo = new TodoRepository();

            todo.deleteTodo(temp);

            string nim = txtNim.Text;

            btnDelete.Enabled = false;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.Id = Convert.ToInt16(txtIdTodo.Text);
            temp.Nama = txtNamaTodo.Text;
            temp.Kategori = txtKategoriTodo.Text;

            TodoRepository todo = new TodoRepository();

            todo.updateTodo(temp);

            string nim = txtNim.Text;
            
            button1.Enabled = false;
            txtIdTodo.Enabled = false;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Enable(object sender, ScrollEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            txtIdTodo.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            txtNamaTodo.Text = dataGridView1.CurrentRow.Cells["Nama"].Value.ToString();
            txtKategoriTodo.Text = dataGridView1.CurrentRow.Cells["Kategori"].Value.ToString();
        }
    }
}
