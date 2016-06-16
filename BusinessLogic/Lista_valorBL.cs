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

    public class Lista_valorBL : ILista_valorBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOLista_valorRespuesta obtenerLista_valor()
        {
            DTOLista_valorRespuesta oLista_valorRespuesta = new DTOLista_valorRespuesta();
            List<DTOLista_valor> oLista_valor = new List<DTOLista_valor>();
            ListaBL oListaBL = new ListaBL();
            try
            {
                var oListaLista_valor = ounitOfWork.lista_valorRepository.GetAll();
                foreach (var item in oListaLista_valor)
                {
                    oLista_valor.Add(new DTOLista_valor()
                    {
                        lista_valor_id = item.lista_valor_id,
                        lista_id = Convert.ToInt32(item.lista_id),
                        lista = oListaBL.obtenerLista_por_id(Convert.ToInt32(item.lista_id)).DTOLista.lista,
                        valor = item.valor,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oLista_valorRespuesta.DTOListaLista_valor = oLista_valor;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oLista_valorRespuesta;
        }


        public void registrarLista_valor(DTOLista_valor oDTOLista_valor)
        {
            try
            {
                Mapper.CreateMap<DTOLista_valor, MS_LISTA_VALOR>().AfterMap((src, dest) => { dest.lista_valor_id = src.lista_valor_id; })
                         .AfterMap((src, dest) => { dest.lista_id = src.lista_id; })
                         .AfterMap((src, dest) => { dest.valor = src.valor; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oLista_valor = AutoMapper.Mapper.Map<DTOLista_valor, MS_LISTA_VALOR>(oDTOLista_valor);
                ounitOfWork.lista_valorRepository.Insert(oLista_valor);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarLista_valor(DTOLista_valor oDTOLista_valor)
        {
            try
            {
                Mapper.CreateMap<DTOLista_valor, MS_LISTA_VALOR>().AfterMap((src, dest) => { dest.lista_valor_id = src.lista_valor_id; })
                         .AfterMap((src, dest) => { dest.lista_id = src.lista_id; })
                         .AfterMap((src, dest) => { dest.valor = src.valor; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oLista_valor = AutoMapper.Mapper.Map<DTOLista_valor, MS_LISTA_VALOR>(oDTOLista_valor);
                ounitOfWork.lista_valorRepository.Update(oLista_valor);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOLista_valorRespuesta obtenerLista_valor_por_id(int id)
        {
            DTOLista_valorRespuesta oLista_valorRespuesta = new DTOLista_valorRespuesta();
            DTOLista_valor oLista_valor = new DTOLista_valor();
            ListaBL oListaBL = new ListaBL();
            try
            {
                var objLista_valor = ounitOfWork.lista_valorRepository.GetFirst(u => u.lista_valor_id == id);
                oLista_valor.lista_valor_id = objLista_valor.lista_valor_id;
                oLista_valor.lista_id = Convert.ToInt32(objLista_valor.lista_id);
                oLista_valor.lista = oListaBL.obtenerLista_por_id(Convert.ToInt32(objLista_valor.lista_id)).DTOLista.lista;
                oLista_valor.valor = objLista_valor.valor;
                oLista_valor.activo = Convert.ToBoolean(objLista_valor.activo);
                oLista_valor.usuario_crea = objLista_valor.usuario_crea;
                oLista_valor.fecha_crea = Convert.ToDateTime(objLista_valor.fecha_crea);
                oLista_valor.usuario_mod = objLista_valor.usuario_mod;
                oLista_valor.fecha_mod = Convert.ToDateTime(objLista_valor.fecha_mod);

                oLista_valorRespuesta.DTOLista_valor = oLista_valor;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oLista_valorRespuesta;
        }
    }
}