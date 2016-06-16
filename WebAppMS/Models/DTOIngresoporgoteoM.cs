using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOCeldaM
    {

        public DTOCeldaM(int i, string d)
        {
            this.celdaId = i;
            this.celdaDesc = d;
        }
        public int celdaId { get; set; }
        public string celdaDesc { get; set; }
    }
    public class DTOIngresoporgoteoM
    {
        public DTOIngresoporgoteoM()
        {
            this.listaCelda = new List<DTOCeldaM>();
            //this.strfechainicioriego = string.Empty;
            //this.strfechafinriego = string.Empty;
            //this.strfechafinrealriego = string.Empty;

            _fechainicioriego = null;
            _fechafinriego = null;
            _fechafinrealriego = null;
        }
        public List<DTOCeldaM> listaCelda { get; set; }
        public string fecha_desc { get; set; }
        public string area_desc { get; set; }
        public Int64 ingresoporgoteo_id { get; set; }
        public string codarea { get; set; }
        public int? flujo { get; set; }

        public int? celdaId { get; set; }

        public decimal? tonelajechancado { get; set; }
        public decimal? leyauchancado { get; set; }
        public decimal? leyagchancado { get; set; }
        public decimal? tonelaje_overliner_ { get; set; }
        public decimal? leyauoverliner { get; set; }
        public decimal? leyagoverliner { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }

        public string strfechainicioapilamiento
        {
            get
            {
                string x = string.Empty;
                if (this.fechainicioapilamiento.HasValue)
                {
                    x = this.fechainicioapilamiento.Value.ToString("dd/MM/yyyy");
                }
                return x;
            }
        }
        public Nullable<System.DateTime> fechainicioapilamiento { get; set; }

        public string strfechafinapilamiento
        {
            get
            {
                string x = string.Empty;
                if (this.fechafinapilamiento.HasValue)
                {
                    x = this.fechafinapilamiento.Value.ToString("dd/MM/yyyy");
                }
                return x;
            }
        }
        public Nullable<System.DateTime> fechafinapilamiento { get; set; }

        Nullable<System.DateTime> _fechainicioriego;
        Nullable<System.DateTime> _fechafinriego;
        Nullable<System.DateTime> _fechafinrealriego;
        public Nullable<System.DateTime> fechainicioriego
        {
            get
            {
                //if (_fechainicioriego.HasValue)
                //{
                //    this.strfechainicioriego = _fechainicioriego.Value.ToString("dd/MM/yyyy");
                //}
                return _fechainicioriego;
            }
            set { _fechainicioriego = value; }
        }
        public Nullable<System.DateTime> fechafinriego
        {
            get
            {
                //if (_fechafinriego.HasValue)
                //{
                //    this.strfechafinriego = _fechafinriego.Value.ToString("dd/MM/yyyy");
                //}
                return _fechafinriego;
            }
            set { _fechafinriego = value; }
        }
        public Nullable<System.DateTime> fechafinrealriego
        {
            get
            {
                //if (_fechafinrealriego.HasValue)
                //{
                //    this.strfechafinrealriego = _fechafinrealriego.Value.ToString("dd/MM/yyyy");
                //}
                return _fechafinrealriego;
            }
            set { _fechafinrealriego = value; }
        }


        public string strfechainicioriego
        {
            get
            {
                string _x = string.Empty;
                if (_fechainicioriego.HasValue)
                {
                    _x = _fechainicioriego.Value.ToString("dd/MM/yyyy");
                }
                return _x;
            }
        }
        public string strfechafinriego
        {
            get
            {
                string _x = string.Empty;
                if (_fechafinriego.HasValue)
                {
                    _x = _fechafinriego.Value.ToString("dd/MM/yyyy");
                }
                return _x;
            }
        }
        public string strfechafinrealriego
        {
            get
            {
                string _x = string.Empty;
                if (_fechafinrealriego.HasValue)
                {
                    _x = _fechafinrealriego.Value.ToString("dd/MM/yyyy");
                }
                return _x;
            }
        }

        public int? diariegoalafecha { get; set; }
        public int? diaprograriego { get; set; }
        public decimal? onzasau { get; set; }
        public decimal? onzasag { get; set; }
        public decimal? tms { get; set; }

        public string strCelda { get; set; }
        public int resultado { get; set; }
    }
}