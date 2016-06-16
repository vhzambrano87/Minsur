using AutoMapper;
using BusinessEntities;
using BusinessLogic.Interface;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public class ListaBL : IListaBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOListaRespuesta obtenerLista()
        {
            DTOListaRespuesta oListaRespuesta = new DTOListaRespuesta();
            List<DTOLista> oLista = new List<DTOLista>();
            try
            {
                var oListaLista = ounitOfWork.listaRepository.GetAll();
                foreach (var item in oListaLista)
                {
                    oLista.Add(new DTOLista()
                    {
                        lista_id = item.lista_id,
                        lista = item.lista,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oListaRespuesta.DTOListaLista = oLista;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oListaRespuesta;
        }


        public void registrarLista(DTOLista oDTOLista)
        {
            try
            {
                Mapper.CreateMap<DTOLista, MS_LISTA>().AfterMap((src, dest) => { dest.lista_id = src.lista_id; })
                         .AfterMap((src, dest) => { dest.lista = src.lista; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oLista = AutoMapper.Mapper.Map<DTOLista, MS_LISTA>(oDTOLista);
                ounitOfWork.listaRepository.Insert(oLista);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarLista(DTOLista oDTOLista)
        {
            try
            {
                Mapper.CreateMap<DTOLista, MS_LISTA>().AfterMap((src, dest) => { dest.lista_id = src.lista_id; })
                         .AfterMap((src, dest) => { dest.lista = src.lista; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oLista = AutoMapper.Mapper.Map<DTOLista, MS_LISTA>(oDTOLista);
                ounitOfWork.listaRepository.Update(oLista);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOListaRespuesta obtenerLista_por_id(int id)
        {
            DTOListaRespuesta oListaRespuesta = new DTOListaRespuesta();
            DTOLista oLista = new DTOLista();
            try
            {
                var objLista = ounitOfWork.listaRepository.GetFirst(u => u.lista_id == id);
                oLista.lista_id = objLista.lista_id;
                oLista.lista = objLista.lista;
                oLista.activo = Convert.ToBoolean(objLista.activo);
                oLista.usuario_crea = objLista.usuario_crea;
                oLista.fecha_crea = Convert.ToDateTime(objLista.fecha_crea);
                oLista.usuario_mod = objLista.usuario_mod;
                oLista.fecha_mod = Convert.ToDateTime(objLista.fecha_mod);

                oListaRespuesta.DTOLista = oLista;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oListaRespuesta;
        }
    }
}