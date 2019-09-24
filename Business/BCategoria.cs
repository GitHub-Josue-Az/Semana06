using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;



namespace Business
{
    public class BCategoria
    {
        private DCategoria DCategoria = null;

        public List<Categoria> Listar(int IdCategoria)
        {
            List<Categoria> categorias = null;
            try
            {
                DCategoria = new DCategoria();
                categorias = DCategoria.Listar(new Categoria { IdCategoria = IdCategoria });
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return categorias;
        }
        public bool Insertar(Categoria categoria)
        {
            bool result = true;
            List<Categoria> categorias = null;
            int IdNextCategoria = 0;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Insertar(categoria);

                IdNextCategoria = categorias.Max(x => x.IdCategoria) + 1;
                categoria.IdCategoria = IdNextCategoria;
            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;
        }
        public bool Actualizar(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Actualizar(categoria);
            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;
        }
        public bool Eliminar(int IdCategoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Eliminar(IdCategoria);
            }
            catch(Exception ex)
            {
                // Escribir en el log
                result = false;
            }
            return result;
        }
    }
}
