namespace WPF.VistaModelo.VistaModelo
{
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using WPF.Modelos.Modelos;
    using WPF.Servicios.Interfaces;
    using WPF.Servicios.Servicios;
    using WPF.VistaModelo.Base;
    public class VistaAutor : VistaModelBase
    {
        private readonly IAutorService _service;
        private readonly ICombosService _serviceCombo;
        private readonly VistaLibros _vistaLibros;

        public VistaAutor()
        {
            _service = new AutorService();
            _serviceCombo = new CombosService();
            _vistaLibros = new VistaLibros();
            CrearAutorComando = new RelayCommand(async () => await CrearAutor());
            ActualizarAutorComando = new RelayCommand(async () => await ActualizarAutor());
            EliminarAutorCommand = new RelayCommand(async () => await EliminarAutor());
            GetAll().ConfigureAwait(true);
            GetPaises().ConfigureAwait(true);
            GetGeneros().ConfigureAwait(true);

        }

        public async Task GetAll()
        {
            string Json;
            IsBusy = true;
            try
            {

                Json = await _service.consultarAutores();
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

        private async Task CrearAutor()
        {
            IsBusy = true;
            DTAutor = new DTAutor
            {
                Nombre = NombreAutor,
                Apellido = ApellidoAutor,
                Edad = Edad,
                Sexo = IdSexo,
                Ciudad = IdCiudad,
                Departamento = IdDepartamento,
                Pais = IdCountry
            };
            try
            {
                if (DTAutor != null)
                {
                    string Json;
                    if (ValidateFields())
                    {
                        Json = await _service.CrearAutor(DTAutor);
                        if (Json != null)
                        {

                            Msj = "Datos registrados con éxito";
                            await GetAll();
                            await _vistaLibros.GetAllAutores().ConfigureAwait(true);
                            ClearFields();
                        }
                        else
                        {
                            IsSaved = false;
                            Msj = "Error al guardar los datos, por favor verifique que esté todo diligenciado";
                        }

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

        private async Task ActualizarAutor()
        {
            IsBusy = true;
            DTAutor = new DTAutor
            {
                IdAutor = Id,
                Nombre = NombreAutor,
                Apellido = ApellidoAutor,
                Edad = Edad,
                Sexo = IdSexo,
                Ciudad = IdCiudad,
                Departamento = IdDepartamento,
                Pais = IdCountry
            };
            try
            {
                if (DTAutor != null)
                {
                    string Json;
                    if (ValidateFields())
                    {
                        Json = await _service.ActualizarAutor(DTAutor);
                        if (Json != null)
                        {
                            Msj = "Datos actualizados con éxito";
                            await GetAll();
                            await _vistaLibros.GetAllAutores().ConfigureAwait(true);
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
        private async Task GetAutorById()
        {

            IsBusy = true;
            DTAutor = new DTAutor
            {
                IdAutor = Id
            };
            try
            {
                string response = await _service.getAutorByiD(DTAutor);
                if (response != null)
                {
                    DTRespuesta<DTAutor> result = JsonConvert.DeserializeObject<DTRespuesta<DTAutor>>(response);
                    Id = result.Data.IdAutor;
                    NombreAutor = result.Data.Nombre;
                    ApellidoAutor = result.Data.Nombre;
                    Edad = result.Data.Edad;


                }
                else
                {

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

        private async Task EliminarAutor()
        {

            IsBusy = true;
            DTAutor = new DTAutor
            {
                IdAutor = Id
            };
            try
            {
                string response = await _service.eliminarAutorById(DTAutor);
                if (response != null)
                {
                    DTRespuesta<DTAutor> result = JsonConvert.DeserializeObject<DTRespuesta<DTAutor>>(response);
                    if (result.Data.IdAutor != 0)
                    {
                        Msj = "Datos eliminados con éxito";
                        await GetAll();
                        await _vistaLibros.GetAllAutores().ConfigureAwait(true);
                        ClearFields();
                    }
                    else
                    {
                        Msj = "Autor con libros asociados no se puede eliminar";
                        ClearFields();
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

        private async Task GetPaises()
        {
            string Json;
            try
            {

                Json = await _serviceCombo.ConsultarPaises();
                if (Json != null)
                {
                    DTRespuesta<IList<DTPais>> result = JsonConvert.DeserializeObject<DTRespuesta<IList<DTPais>>>(Json);
                    Paises = new ObservableCollection<DTPais>(result.Data);
                }
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
            }
        }
        private async Task GetDepartamentos()
        {
            string Json;
            DTPais pais = new DTPais();
            pais.IdPais = IdCountry;
            try
            {
                Json = await _serviceCombo.ConsultarDepartamentos(pais);
                if (Json != null)
                {
                    DTRespuesta<IList<DTDepartamento>> result = JsonConvert.DeserializeObject<DTRespuesta<IList<DTDepartamento>>>(Json);
                    Departamentos = new ObservableCollection<DTDepartamento>(result.Data);

                }

            }
            catch (Exception ex)
            {
                Msj = ex.Message;

            }
        }
        private async Task GetCiudades()
        {
            string Json;
            DTDepartamento departamento = new DTDepartamento();
            departamento.IdDepartamento = IdDepartamento;
            try
            {
                Json = await _serviceCombo.ConsultarCiudades(departamento);
                if (Json != null)
                {
                    DTRespuesta<IList<DTCiudad>> result = JsonConvert.DeserializeObject<DTRespuesta<IList<DTCiudad>>>(Json);
                    Ciudades = new ObservableCollection<DTCiudad>(result.Data);
                }

            }
            catch (Exception ex)
            {
                Msj = ex.Message;

            }
        }
        private async Task GetGeneros()
        {
            string Json;
            try
            {
                Json = await _serviceCombo.GetGeneros();
                if (Json != null)
                {
                    DTRespuesta<IList<DTSexo>> result = JsonConvert.DeserializeObject<DTRespuesta<IList<DTSexo>>>(Json);
                    Sexo = new ObservableCollection<DTSexo>(result.Data);
                }

            }
            catch (Exception ex)
            {
                Msj = ex.Message;

            }
        }

        private object autorSeleccionado;

        public object AutorSeleccionado
        {
            get => autorSeleccionado;
            set
            {
                SetProperty(ref autorSeleccionado, value);
                if (autorSeleccionado != null)
                {
                    Id = Convert.ToInt32(autorSeleccionado.GetType().GetProperty("IdAutor").GetValue(autorSeleccionado, null));
                    GetAutorById().ConfigureAwait(true);
                }
            }

        }


        private bool ValidateFields()
        {
            bool validate = true;

            if (string.IsNullOrEmpty(NombreAutor))
            {
                Msj = "Nombre requerido *";
                validate = false;
            }
            else if (string.IsNullOrEmpty(ApellidoAutor))
            {
                Msj = "Nombre requerido *";
                validate = false;
            }
            else if (Edad == default)
            {
                Msj = "Edad requerida *";
                validate = false;
            }
            else if (IdSexo == default)
            {
                Msj = "Género requerido *";
                validate = false;
            }
            else if (idCiudad == default)
            {
                Msj = "Ciudad requerido *";
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
            NombreAutor = string.Empty;
            ApellidoAutor = string.Empty;
            Edad = default;
            if (Paises != null)
            {
                Paises.Clear();
            }
            if (Departamentos != null)
            {
                Departamentos.Clear();
            }
            if (Ciudades != null)
            {
                Ciudades.Clear();
            }
            Sexo.Clear();
            await GetGeneros().ConfigureAwait(true);
            await GetPaises().ConfigureAwait(true);
            await Task.Delay(3500);
            Msj = string.Empty;
        }


        private int id;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        private DTAutor dTAutor;

        public DTAutor DTAutor
        {
            get => dTAutor;
            set => SetProperty(ref dTAutor, value);
        }

        private string nombreAutor;

        public string NombreAutor
        {
            get => nombreAutor;
            set => SetProperty(ref nombreAutor, value);

        }
        private string apellidoAutor;

        public string ApellidoAutor
        {
            get => apellidoAutor;
            set => SetProperty(ref apellidoAutor, value);
        }
        private int edad;

        public int Edad
        {
            get => edad;
            set => SetProperty(ref edad, value);
        }

        private int idgenero;

        public int Idgenero
        {
            get => idgenero;
            set => SetProperty(ref idgenero, value);
        }
        private int idCountry;

        public int IdCountry
        {
            get => idCountry;
            set
            {
                SetProperty(ref idCountry, value);

                if (Departamentos != null)
                {
                    Departamentos.DefaultIfEmpty();
                }
                if (Ciudades != null)
                {
                    Ciudades.Clear();
                }
                GetDepartamentos().ConfigureAwait(true);
            }

        }

        public static ObservableCollection<DTAutorList> authors = null;
        public ObservableCollection<DTAutorList> Authors
        {
            get
            {
                if (authors == null)
                    authors = new ObservableCollection<DTAutorList>();
                return authors;
            }
        }


        private ObservableCollection<DTAutor> autor;
        public ObservableCollection<DTAutor> Autor
        {
            get => autor;
            set => SetProperty(ref autor, value);
        }

        private ObservableCollection<DTPais> paises;

        public ObservableCollection<DTPais> Paises
        {
            get => paises;
            set => SetProperty(ref paises, value);
        }

        private ObservableCollection<DTDepartamento> departamentos;

        public ObservableCollection<DTDepartamento> Departamentos
        {
            get => departamentos;
            set => SetProperty(ref departamentos, value);
        }

        private ObservableCollection<DTCiudad> ciudad;

        public ObservableCollection<DTCiudad> Ciudades
        {
            get => ciudad;
            set => SetProperty(ref ciudad, value);
        }

        private ObservableCollection<DTSexo> sexo;
        public ObservableCollection<DTSexo> Sexo
        {
            get => sexo;
            set => SetProperty(ref sexo, value);
        }

        private int idDepartamento;

        public int IdDepartamento
        {
            get => idDepartamento;
            set
            {
                SetProperty(ref idDepartamento, value);
                GetCiudades().ConfigureAwait(true);
            }

        }
        private int idCiudad;

        public int IdCiudad
        {
            get => idCiudad;
            set => SetProperty(ref idCiudad, value);
        }
        private int idSexo;

        public int IdSexo
        {
            get => idSexo;
            set => SetProperty(ref idSexo, value);
        }

        private bool isSaved;

        public bool IsSaved
        {
            get => isSaved;
            set => SetProperty(ref isSaved, value);
        }

        private int idAutor;
        public int IdAutor
        {
            get => idAutor;
            set => SetProperty(ref idAutor, value);

        }



        public ICommand CrearAutorComando { get; }
        public ICommand ActualizarAutorComando { get; }
        public ICommand EliminarAutorCommand { get; }
    }
}
