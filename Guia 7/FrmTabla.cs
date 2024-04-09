using Guia_7.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia_7
{
    public partial class FrmTabla : Form
    {
        public int? id;
        Persona persona = null;
        public FrmTabla(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null) cargarDatos();
        }
        private void cargarDatos()
        {
            using (BDD_UFGEntities db = new BDD_UFGEntities())
            {
                persona = db.Persona.Find(id);
                txtname.Text = persona.nombre;
                txtemail.Text = persona.correo;
                txtid.Text = persona?.id.ToString();
                txtdate.Value = (DateTime)persona.fecha_nacimiento;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (BDD_UFGEntities db = new BDD_UFGEntities())
            {
            
                if (this.id == null)
                {
                    Persona persona = new Persona();
                    persona.id = int.Parse(txtid.Text);
                    persona.nombre = txtname.Text;
                    persona.correo = txtemail.Text;
                    persona.fecha_nacimiento = txtdate.Value;
                    db.Persona.Add(persona);
                }
                else
                {
                    persona.id = int.Parse(txtid.Text);
                    persona.nombre = txtname.Text;
                    persona.correo = txtemail.Text;
                    persona.fecha_nacimiento = txtdate.Value;
                    db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
