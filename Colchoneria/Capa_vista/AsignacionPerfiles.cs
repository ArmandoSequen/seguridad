﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_controlador;

namespace Capa_vista
{
    public partial class AsignacionPerfiles : Form
    {
        string table = "tbl_asignacionesperfilsusuario";

        Controlador cn = new Controlador();

        public AsignacionPerfiles()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            txtCadenas.Text = "";
            txtIdUsuario.Text = "";
            txtIdPerfil.Text = "";
        }

        public void ocultar()
        {
            txtIdPerfil.Visible = false;
        }

        public void getIds()
        {
            try
            {
                string dato;
                dato = listPerfilesDB.CurrentCell.Value.ToString();
                if (txtCadenas.Text == "")
                {
                    txtCadenas.Text = dato;
                }
                else
                {
                    string valor = txtCadenas.Text;
                    txtCadenas.Text = valor + "," + dato;
                }

            }
            catch (Exception ex)
            {

            }
        }

        public void actualizardatagriew()
        {
            string cadena = txtIdUsuario.Text;
            DataTable dt = cn.SelectList(table, cadena);
            listPerfilUsuario.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {

            char[] delimiterChars = { ',' };
            string text = txtCadenas.Text;
            string[] words = text.Split(delimiterChars);

            foreach (var word in words)
            {
                txtIdPerfil.Text = word;
                TextBox[] textbox = { txtIdPerfil, txtIdUsuario };
                cn.ingresar(textbox, table);
            }
            string message = "Registro Guardado";
            limpiar();
            MessageBox.Show(message);
            //actualizardatagriew();
            listPerfilesDB.Visible = false;
            //663; 369
            Size = new Size(663, 369);
        }

        private void AsignacionPerfiles_Load(object sender, EventArgs e)
        {
            cn.llenarListPerfiles(listPerfilesDB.Tag.ToString(), listPerfilesDB);
            Size = new Size(663, 369);
            ocultar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void listAplicacionesDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getIds();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1040; 369
            if (listPerfilesDB.Visible == false)
            {
                listPerfilesDB.Visible = true;
                Size = new Size(1040, 369);
            }
            else
            {
                listPerfilesDB.Visible = false;
                Size = new Size(663, 369);
            }
        }
    }
}
