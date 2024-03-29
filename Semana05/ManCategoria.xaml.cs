﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Entity;

namespace Semana05
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class ManCategoria : Window
    {
        public int ID { get; set; }
        public Categoria categoria = new Categoria();
        public ManCategoria(int Id)
        {
            InitializeComponent();

            ID = Id;
            if (ID > 0)
            {
                BCategoria bCategoria = new BCategoria();
                List<Categoria> categorias = new List<Categoria>();
                categorias = bCategoria.Listar(ID);
                if (categorias.Count > 0)
                {
                    lblId.Content = categorias[0].IdCategoria.ToString();
                    txtNombre.Text = categorias[0].NombreCategoria;
                    txtDescripcion.Text = categorias[0].Descripcion;
                }
            }
        }
        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria Bcategoria = null;
            bool result = true;
            try
            {
                //Listar todas las categorias
                Bcategoria = new BCategoria();
                if (ID > 0)
                    result = Bcategoria.Actualizar(new Categoria { IdCategoria = ID, NombreCategoria = txtNombre.Text,Descripcion=txtDescripcion.Text });
                else
                    result = Bcategoria.Insertar(new Categoria { NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                if (!result)
                    MessageBox.Show("Comunicarse con el administrador");

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el administrador");
            }
            finally
            {
                Bcategoria = null;
            }

        }
        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria bCategoria = new BCategoria();
            if (categoria != null)
            {
                bCategoria.Eliminar(categoria.IdCategoria);
            }
            Close();
        }
    }
}
