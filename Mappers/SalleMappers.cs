using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs.Salle;
using Api.Model;

namespace Api.Mappers
{
    public static class SalleMappers
    {
        public static SalleDto ToSalleDto(this Salle salleModel){
            return new SalleDto{
                Numsalle = salleModel.Numsalle,
                Designsalle = salleModel.Designsalle
            };
        }

        public static Salle ToSalleFromCreate(this CreateSalleRequest salleRequest){
            return new Salle{
                Numsalle = salleRequest.Numsalle,
                Designsalle = salleRequest.Designsalle
            };
        }
    }
}