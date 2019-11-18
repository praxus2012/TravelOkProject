using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public TOA_Usuario tusChecarUsuario(TOA_Usuario user)
        {
            try
            {
                //using (var contexto = new TravelOKViajesEntities())//local
                using (var contexto = new TravelOKEntitiesQA())//QA
                {
                    TOA_Usuario Tuser = new TOA_Usuario();
                    Tuser = (from Tu in contexto.spVerificaUsuario(user.nvUsuario, user.nvContraseña)
                             select
                                new TOA_Usuario
                                {
                                nvUsuario = user.nvUsuario,
                                nvContraseña = user.nvContraseña,
                                nvNombre = Tu.nvNombre,
                                nvApPat = Tu.nvApPat,
                                nvApMat = Tu.nvApMat,
                                nvCorreo = Tu.nvCorreo,
                                dtFecNac = Tu.dtFecNac,
                                dtFecReg = Tu.dtFecReg,
                                dtFecAct = Tu.dtFecAct,
                                Activo = Tu.Activo
                                }).FirstOrDefault();

                    return Tuser;                    
                }
            }
            catch (EntityException ex)
            {
                return new TOA_Usuario
                {
                    nvUsuario = "Error",
                    nvContraseña = ex.Message.Substring(0, 24)
                };
            }
        }
    }
}
