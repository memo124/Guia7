using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guia_7.models;

namespace Guia_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Refrescar()
        {
            using (BDD_UFGEntities db = new BDD_UFGEntities())
            {
                var lista  = from datos in db.Persona select datos;
                dgvDatos.DataSource = lista.ToList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmTabla frmTabla = new FrmTabla();
            frmTabla.ShowDialog();
            Refrescar();
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[0].Value.ToString());
            }catch { return null; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                FrmTabla frmTabla = new FrmTabla(id);
                frmTabla.ShowDialog();
            }
            Refrescar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                using (BDD_UFGEntities db = new BDD_UFGEntities())
                {
                    Persona persona = db.Persona.Find(id);
                    db.Persona.Remove(persona);
                    db.SaveChanges();
                }
            }
            Refrescar();
        }
    }
}
