using Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Semana05.ViewModel
{
    public class ListaCategoriaViewModel : ViewModelBase
    {
        ObservableCollection<Categoria> _Categorias;
        public ObservableCollection<Categoria> Categorias
        {
            get { return _Categorias; }
            set
            {
                if (_Categorias != value)
                {
                    _Categorias = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand NuevoCommand { get; set; }
        public ICommand ConsultarCommand { get; set; }

        public ListaCategoriaViewModel()
        {
            Categorias = new Model.CategoriaModel().Categorias;
            NuevoCommand = new RelayCommand<Window>(
                param => Abrir()

                );
            ConsultarCommand = new RelayCommand<Window>(
                o => { Categorias = (new Model.CategoriaModel()).Categorias; }
                );

            void Abrir()
            {
                View.ManCategoria window = new View.ManCategoria();
                window.ShowDialog();
                ConsultarCommand.Execute(window);
            }
            //void Cerrar()
            //{
            //    View.ManCategoria window = new View.ManCategoria();
            //    window.Close();
            //}
        }
    }
}