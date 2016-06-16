using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOProd_ore_binRespuesta
    {
        public DTOProd_ore_bin DTOProd_ore_bin { get; set; }
        public List<DTOProd_ore_bin> DTOListaProd_ore_bin { get; set; }
    }
    public class DTOProd_ore_bin
    {
        public int prod_ore_bin_id { get; set; }
        public int produccion_id { get; set; }
        public DateTime fecha_op { get; set; }
        public int turno_id { get; set; }
        public int viajes_ob { get; set; }
        public double ton_ob_cam { get; set; }
        public double ton_ob_ox { get; set; }
        public double ton_bal_faja { get; set; }
        public double tm_acum_ini_ob { get; set; }
        public double tm_acum_fin_ob { get; set; }
        public double tmh_ob_bal { get; set; }
        public double h_op_ob { get; set; }
        public double horas { get; set; }
        public double minutos { get; set; }
        public double h_mantto_ob { get; set; }
        public double horas_mantto { get; set; }
        public double minutos_mantto { get; set; }
        public double h_operacion { get; set; }
        public double horas_operacion { get; set; }
        public double minutos_operacion { get; set; }
        public double h_calendario { get; set; }
        public double porc_d_ob { get; set; }
        public double porc_ud_ob { get; set; }
        public double porc_u_ob { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}