using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity.Validation;

namespace DataAccess
{
    public class UnitOfWork
    {
        private readonly MinsurRepoEntities _context = null;

        //Entidad LISTA_VALOR
        private GenericRepository<MS_LISTA_VALOR> _lista_valorRepository;

        //Entidad LISTA
        private GenericRepository<MS_LISTA> _listaRepository;

        //Entidad ESTADO
        private GenericRepository<MS_ESTADO> _estadoRepository;

        //Entidad GUARDIA
        private GenericRepository<MS_GUARDIA> _guardiaRepository;

        //Entidad PARADA
        private GenericRepository<MS_PARADA> _paradaRepository;

        //Entidad TIPO_PARADA
        private GenericRepository<MS_TIPO_PARADA> _tipo_paradaRepository;

        //Entidad PROCESO
        private GenericRepository<MS_PROCESO> _procesoRepository;

        //Entidad DESORCION
        private GenericRepository<MS_DESORCION> _desorcionRepository;

        //Entidad ADSORCION
        private GenericRepository<MS_ADSORCION> _adsorcionRepository;

        //Entidad PARAMETRO
        private GenericRepository<MS_PARAMETRO> _parametroRepository;

        //Entidad PRODUCCION
        private GenericRepository<MS_PRODUCCION> _produccionRepository;

        //Entidad MANT_PRODUCCION_X_HORA
        private GenericRepository<MS_MANT_PRODUCCION_X_HORA> _mant_produccion_x_horaRepository;

        //Entidad MANT_EQUIPOS
        private GenericRepository<MS_MANT_EQUIPOS> _mant_equiposRepository;

        //Entidad CHANCADORA
        private GenericRepository<MS_CHANCADORA> _chancadoraRepository;

        //Entidad CONSUMO_COMBUSTIBLE
        private GenericRepository<MS_CONSUMO_COMBUSTIBLE> _consumo_combustibleRepository;

        //Entidad INGRESONIVELESPOZA
        private GenericRepository<MS_INGRESONIVELESPOZA> _ingresonivelespozaRepository;

        //Entidad INGRESOPORGOTEO
        private GenericRepository<MS_INGRESOPORGOTEO> _ingresoporgoteoRepository;

        //Entidad APILAMIENTO
        private GenericRepository<MS_APILAMIENTO> _apilamientoRepository;

        //Entidad AGUAS_OPERACIONES
        private GenericRepository<MS_AGUAS_OPERACIONES> _aguas_operacionesRepository;

        //Entidad TURNO_LIX
        private GenericRepository<MS_TURNO_LIX> _turno_lixRepository;

        //Entidad CONTROL_DIG_LIXIVIACION
        private GenericRepository<MS_CONTROL_DIG_LIXIVIACION> _control_dig_lixiviacionRepository;

        //Entidad FLUJOS_PRESIONES
        private GenericRepository<MS_FLUJOS_PRESIONES> _flujos_presionesRepository;

        //Entidad CAMIONES
        private GenericRepository<MS_CAMIONES> _camionesRepository;

        //Entidad USUARIO
        private GenericRepository<MS_USUARIO> _usuarioRepository;

        //Entidad ROL
        private GenericRepository<MS_ROL> _rolRepository;

        //Entidad OPCION
        private GenericRepository<MS_OPCION> _opcionRepository;

        //Entidad USUARIO_ROL
        private GenericRepository<MS_USUARIO_ROL> _usuario_rolRepository;

        //Entidad ROL_OPCION
        private GenericRepository<MS_ROL_OPCION> _rol_opcionRepository;

        //Entidad PROD_ORE_BIN
        private GenericRepository<MS_PROD_ORE_BIN> _prod_ore_binRepository;

        //Entidad PROD_CHANCADORA
        private GenericRepository<MS_PROD_CHANCADORA> _prod_chancadoraRepository;

        public UnitOfWork()
        {
            _context = new MinsurRepoEntities();
        }

        //**************
        //MS_LISTA_VALOR
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<MS_LISTA_VALOR> lista_valorRepository
        {
            get
            {
                if (this._lista_valorRepository == null)
                    this._lista_valorRepository = new GenericRepository<MS_LISTA_VALOR>(_context);
                return _lista_valorRepository;
            }
        }

        //**************
        //MS_LISTA
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_LISTA> listaRepository
        {
            get
            {
                if (this._listaRepository == null)
                    this._listaRepository = new GenericRepository<MS_LISTA>(_context);
                return _listaRepository;
            }
        }

        //**************
        //MS_ESTADO
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_ESTADO> estadoRepository
        {
            get
            {
                if (this._estadoRepository == null)
                    this._estadoRepository = new GenericRepository<MS_ESTADO>(_context);
                return _estadoRepository;
            }
        }

        //**************
        //MS_GUARDIA
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_GUARDIA> guardiaRepository
        {
            get
            {
                if (this._guardiaRepository == null)
                    this._guardiaRepository = new GenericRepository<MS_GUARDIA>(_context);
                return _guardiaRepository;
            }
        }

        //**************
        //MS_PARADA
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_PARADA> paradaRepository
        {
            get
            {
                if (this._paradaRepository == null)
                    this._paradaRepository = new GenericRepository<MS_PARADA>(_context);
                return _paradaRepository;
            }
        }

        //**************
        //MS_TIPO_PARADA
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_TIPO_PARADA> tipo_paradaRepository
        {
            get
            {
                if (this._tipo_paradaRepository == null)
                    this._tipo_paradaRepository = new GenericRepository<MS_TIPO_PARADA>(_context);
                return _tipo_paradaRepository;
            }
        }

        //**************
        //MS_PROCESO
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_PROCESO> procesoRepository
        {
            get
            {
                if (this._procesoRepository == null)
                    this._procesoRepository = new GenericRepository<MS_PROCESO>(_context);
                return _procesoRepository;
            }
        }

        //**************
        //MS_DESORCION
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_DESORCION> desorcionRepository
        {
            get
            {
                if (this._desorcionRepository == null)
                    this._desorcionRepository = new GenericRepository<MS_DESORCION>(_context);
                return _desorcionRepository;
            }
        }

        //**************
        //MS_ADSORCION
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_ADSORCION> adsorcionRepository
        {
            get
            {
                if (this._adsorcionRepository == null)
                    this._adsorcionRepository = new GenericRepository<MS_ADSORCION>(_context);
                return _adsorcionRepository;
            }
        }

        //**************
        //MS_PARAMETRO
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_PARAMETRO> parametroRepository
        {
            get
            {
                if (this._parametroRepository == null)
                    this._parametroRepository = new GenericRepository<MS_PARAMETRO>(_context);
                return _parametroRepository;
            }
        }

        //**************
        //MS_PRODUCCION
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_PRODUCCION> produccionRepository
        {
            get
            {
                if (this._produccionRepository == null)
                    this._produccionRepository = new GenericRepository<MS_PRODUCCION>(_context);
                return _produccionRepository;
            }
        }

        //**************
        //MS_CONSUMO_COMBUSTIBLE
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_CONSUMO_COMBUSTIBLE> consumo_combustibleRepository
        {
            get
            {
                if (this._consumo_combustibleRepository == null)
                    this._consumo_combustibleRepository = new GenericRepository<MS_CONSUMO_COMBUSTIBLE>(_context);
                return _consumo_combustibleRepository;
            }
        }

        //**************
        //MS_CHANCADORA
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_CHANCADORA> chancadoraRepository
        {
            get
            {
                if (this._chancadoraRepository == null)
                    this._chancadoraRepository = new GenericRepository<MS_CHANCADORA>(_context);
                return _chancadoraRepository;
            }
        }

        //**************
        //MS_MANT_EQUIPOS
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_MANT_EQUIPOS> mant_equiposRepository
        {
            get
            {
                if (this._mant_equiposRepository == null)
                    this._mant_equiposRepository = new GenericRepository<MS_MANT_EQUIPOS>(_context);
                return _mant_equiposRepository;
            }
        }

        //**************
        //MS_MANT_PRODUCCION_X_HORA
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_MANT_PRODUCCION_X_HORA> mant_produccion_x_horaRepository
        {
            get
            {
                if (this._mant_produccion_x_horaRepository == null)
                    this._mant_produccion_x_horaRepository = new GenericRepository<MS_MANT_PRODUCCION_X_HORA>(_context);
                return _mant_produccion_x_horaRepository;
            }
        }

        //**************
        //MS_INGRESONIVELESPOZA
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_INGRESONIVELESPOZA> ingresonivelespozaRepository
        {
            get
            {
                if (this._ingresonivelespozaRepository == null)
                    this._ingresonivelespozaRepository = new GenericRepository<MS_INGRESONIVELESPOZA>(_context);
                return _ingresonivelespozaRepository;
            }
        }

        //**************
        //MS_INGRESOPORGOTEO
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_INGRESOPORGOTEO> ingresoporgoteoRepository
        {
            get
            {
                if (this._ingresoporgoteoRepository == null)
                    this._ingresoporgoteoRepository = new GenericRepository<MS_INGRESOPORGOTEO>(_context);
                return _ingresoporgoteoRepository;
            }
        }

        //**************
        //MS_APILAMIENTO
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_APILAMIENTO> apilamientoRepository
        {
            get
            {
                if (this._apilamientoRepository == null)
                    this._apilamientoRepository = new GenericRepository<MS_APILAMIENTO>(_context);
                return _apilamientoRepository;
            }
        }

        //**************
        //MS_AGUAS_OPERACIONES
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_AGUAS_OPERACIONES> aguas_operacionesRepository
        {
            get
            {
                if (this._aguas_operacionesRepository == null)
                    this._aguas_operacionesRepository = new GenericRepository<MS_AGUAS_OPERACIONES>(_context);
                return _aguas_operacionesRepository;
            }
        }


        //**************
        //MS_TURNO_LIX
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_TURNO_LIX> turno_lixRepository
        {
            get
            {
                if (this._turno_lixRepository == null)
                    this._turno_lixRepository = new GenericRepository<MS_TURNO_LIX>(_context);
                return _turno_lixRepository;
            }
        }

        //**************
        //MS_CONTROL_DIG_LIXIVIACION
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_CONTROL_DIG_LIXIVIACION> control_dig_lixiviacionRepository
        {
            get
            {
                if (this._control_dig_lixiviacionRepository == null)
                    this._control_dig_lixiviacionRepository = new GenericRepository<MS_CONTROL_DIG_LIXIVIACION>(_context);
                return _control_dig_lixiviacionRepository;
            }
        }


        //**************
        //MS_FLUJOS_PRESIONES
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_FLUJOS_PRESIONES> flujos_presionesRepository
        {
            get
            {
                if (this._flujos_presionesRepository == null)
                    this._flujos_presionesRepository = new GenericRepository<MS_FLUJOS_PRESIONES>(_context);
                return _flujos_presionesRepository;
            }
        }

        //**************
        //MS_CAMIONES
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_CAMIONES> camionesRepository
        {
            get
            {
                if (this._camionesRepository == null)
                    this._camionesRepository = new GenericRepository<MS_CAMIONES>(_context);
                return _camionesRepository;
            }
        }

        //**************
        //MS_USUARIO
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_USUARIO> usuarioRepository
        {
            get
            {
                if (this._usuarioRepository == null)
                    this._usuarioRepository = new GenericRepository<MS_USUARIO>(_context);
                return _usuarioRepository;
            }
        }


        //**************
        //MS_ROL
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_ROL> rolRepository
        {
            get
            {
                if (this._rolRepository == null)
                    this._rolRepository = new GenericRepository<MS_ROL>(_context);
                return _rolRepository;
            }
        }

        //**************
        //MS_OPCION
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_OPCION> opcionRepository
        {
            get
            {
                if (this._opcionRepository == null)
                    this._opcionRepository = new GenericRepository<MS_OPCION>(_context);
                return _opcionRepository;
            }
        }

        //**************
        //MS_USUARIO_ROL
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_USUARIO_ROL> usuario_rolRepository
        {
            get
            {
                if (this._usuario_rolRepository == null)
                    this._usuario_rolRepository = new GenericRepository<MS_USUARIO_ROL>(_context);
                return _usuario_rolRepository;
            }
        }

        //**************
        //MS_ROL_OPCION
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_ROL_OPCION> rol_opcionRepository
        {
            get
            {
                if (this._rol_opcionRepository == null)
                    this._rol_opcionRepository = new GenericRepository<MS_ROL_OPCION>(_context);
                return _rol_opcionRepository;
            }
        }


        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_PROD_ORE_BIN> prod_ore_binRepository
        {
            get
            {
                if (this._prod_ore_binRepository == null)
                    this._prod_ore_binRepository = new GenericRepository<MS_PROD_ORE_BIN>(_context);
                return _prod_ore_binRepository;
            }
        }

        //**************
        //MS_PROD_CHANCADORA
        //**************
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        public GenericRepository<MS_PROD_CHANCADORA> prod_chancadoraRepository
        {
            get
            {
                if (this._prod_chancadoraRepository == null)
                    this._prod_chancadoraRepository = new GenericRepository<MS_PROD_CHANCADORA>(_context);
                return _prod_chancadoraRepository;
            }
        }

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Append(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Append(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }

                throw e;
            }

        }


        #endregion
        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
