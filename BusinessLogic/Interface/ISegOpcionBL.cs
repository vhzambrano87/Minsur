﻿using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ISegOpcionBL
    {
        List<DTOSegOpcion> ObtenerSegOpcion(string usuarioCod);
    }
}
