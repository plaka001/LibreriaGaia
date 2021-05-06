namespace WPF.VistaModelo.VistaModelo
{
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using WPF.Modelos.Modelos;
    using WPF.Servicios.Interfaces;
    using WPF.Servicios.Servicios;
    using WPF.VistaModelo.Base;


    public class VistaLibros : VistaModelBase
    {
        private readonly ILibroService _service;
        private readonly IAutorService _serviceAutor;
        public VistaLibros()
        {
            _service = new LibroService();
            _serviceAutor = new AutorService();
            createLibroCommand = new RelayCommand(async () => await CrearLibro());
            ActualizarLibroComando = new RelayCommand(async () => await ActualizarLibro());
            EliminarLibroCommand = new RelayCommand(async () => await EliminarLibro());
            GetAllAutores().ConfigureAwait(true);
            GetAllLibros().ConfigureAwait(true);
            FechaD = DateTime.Today;

        }


        public async Task GetAllAutores()
        {
            string Json;
            IsBusy = true;
            try
            {
                Json = await _serviceAutor.consultarAutores();
                if (Json != null)
                {

                    DTRespuesta<IList<DTAutorList>> result = JsonConvert.DeserializeObject<DTRespuesta<IList<DTAutorList>>>(Json);
                    var lista = new ObservableCollection<DTAutorList>(result.Data);
                    Authors.Clear();
                    foreach (var item in lista)
                        Authors.Add(item);
                   
                }
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GetLibroById()
        {

            IsBusy = true;
            DTLibro = new DTLibro
            {
                IdLibro = Id
            };
            try
            {
                string response = await _service.getLibroByiD(DTLibro);
                if (response != null)
                {
                    DTRespuesta<DTLibro> result = JsonConvert.DeserializeObject<DTRespuesta<DTLibro>>(response);
                    Id = result.Data.IdLibro;
                    NombreLibro = result.Data.Nombre;
                    FechaD = result.Data.FechaEscritura;
                    Costo = result.Data.Costo;
                    IdAutor = result.Data.IdAutor;

                    IsEnabled = false;
                    // IsEnabledUpdate = true;

                }
                else
                {
                    IsEnabled = true;
                    // IsEnabledUpdate = false;
                }
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GetAllLibros()
        {
            string Json;
            IsBusy = true;
            try
            {
                Json = await _service.ConsultarLibros();
                if (Json != null)
                {
                    DTRespuesta<IList<DTListLibros>> result = JsonConvert.DeserializeObject<DTRespuesta<IList<DTListLibros>>>(Json);
                    Libros = new ObservableCollection<DTListLibros>(result.Data);

                }
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task CrearLibro()
        {
            IsBusy = true;
            DTLibro = new DTLibro
            {
                Nombre = NombreLibro,
                IdAutor = IdAutor,
                FechaEscritura = FechaD,
                Costo = Costo

            };
            try
            {
                if (DTLibro != null)
                {
                    string Json;
                    if (ValidateFields())
                    {
                        Json = await _service.CrearLibro(DTLibro);
                        if (Json != null)
                        {
                            Msj = "Datos registrados con éxito";
                            await GetAllLibros();
                            //ClearFields();
                        }
                        else
                            Msj = "Error al guardar los datos";

                    }

                }
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task ActualizarLibro()
        {
            IsBusy = true;
            DTLibro = new DTLibro
            {
                IdLibro = Id,
                Nombre = NombreLibro,
                FechaEscritura = FechaD,
                Costo = Costo,
                IdAutor = IdAutor
            };
            try
            {
                if (DTLibro != null)
                {
                    string Json;
                    if (ValidateFields())
                    {
                        Json = await _service.ActualizarLibro(DTLibro);
                        if (Json != null)
                        {
                            Msj = "Datos actualizados con éxito";
                            await GetAllLibros();
                            ClearFields();
                        }
                        else
                            Msj = "Error al actualizar los datos";

                    }

                }
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task EliminarLibro()
        {

            IsBusy = true;
            DTLibro = new DTLibro
            {
                IdLibro = Id
            };
            try
            {
                string response = await _service.eliminarAutorById(DTLibro);
                if (response != null)
                {
                    Msj = "Datos eliminados con éxito";
                    //IsEnabledUpdate = false;
                    IsEnabled = true;
                    await GetAllLibros();
                    // ClearFields();
                }
                else
                {
                    Msj = "Autor con libros asociados no se puede eliminar";
                    IsEnabled = true;
                    // IsEnabledUpdate = false;
                    //   ClearFields();
                }



            }
            catch (Exception ex)
            {
                Msj = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private object libroSeleccionado;

        public object LibroSeleccionado
        {
            get => libroSeleccionado;
            set
            {
                SetProperty(ref libroSeleccionado, value);
                if (libroSeleccionado != null)
                {
                    Id = Convert.ToInt32(libroSeleccionado.GetType().GetProperty("IdLibro").GetValue(libroSeleccionado, null));
                    GetLibroById().ConfigureAwait(true);
                }
            }

        }

        private bool ValidateFields()
        {
            bool validate = true;

            if (string.IsNullOrEmpty(NombreLibro))
            {
                Msj = "Nombre requerido *";
                validate = false;
            }
            else if (FechaD == default)
            {
                Msj = "Fecha de escritura requierida *";
                validate = false;
            }
            else if (Costo == decimal.Zero)
            {
                Msj = "Precio requerido *";
                validate = false;
            }
            else if (IdAutor == default)
            {
                Msj = "Autor requerido *";
                validate = false;
            }
            else
            {
                validate = true;
            }
            return validate;
        }
        private async void ClearFields()
        {
            NombreLibro = string.Empty;
            FechaD = DateTime.Today;
            Costo = decimal.Zero;
            await Task.Delay(3500);
            //if (Authors != null)
            //{
            //    Authors.Clear();
            //}
            Msj = string.Empty;

        }
        private ObservableCollection<DTAutorList> authors = null;
        public ObservableCollection<DTAutorList> Authors
        {
            get
            {
                if (authors == null)
                    authors = new ObservableCollection<DTAutorList>();
                return authors;
            }
        }

        private ObservableCollection<DTListLibros> libros;
        public ObservableCollection<DTListLibros> Libros
        {
            get => libros;
            set => SetProperty(ref libros, value);
        }

        private int id;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        private DTLibro dTLibro;

        public DTLibro DTLibro
        {
            get => dTLibro;
            set => SetProperty(ref dTLibro, value);
        }
        private string nombreLibro;

        public string NombreLibro
        {
            get => nombreLibro;
            set => SetProperty(ref nombreLibro, value);

        }

        private DateTime fechad;

        public DateTime FechaD
        {
            get => fechad;
            set => SetProperty(ref fechad, value);

        }
        private decimal costo;
        public decimal Costo
        {
            get => costo;
            set => SetProperty(ref costo, value);

        }
        private int idAutor;
        public int IdAutor
        {
            get => idAutor;
            set => SetProperty(ref idAutor, value);

        }

        public ICommand createLibroCommand { get; }
        public ICommand ActualizarLibroComando { get; }
        public ICommand EliminarLibroCommand { get; }
    }
}
