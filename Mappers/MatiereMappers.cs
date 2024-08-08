using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs.Matiere;
using Api.Model;

namespace Api.Mappers
{
    public static class MatiereMappers
    {
        public static MatiereDto ToMatiereDto(this Matiere matiereModel){
            return new MatiereDto{
                Codematiere = matiereModel.Codematiere,
                Nommatiere = matiereModel.Nommatiere
            };
        }

        public static Matiere ToMatiereFromCreate(this CreateMatiereRequest matiereReq){
            return new Matiere{
                Codematiere = matiereReq.Codematiere,
                Nommatiere = matiereReq.Nommatiere
            };
        }
    }
}