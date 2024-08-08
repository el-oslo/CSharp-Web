using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs.Enseignant;
using Api.Model;

namespace Api.Mappers
{
    public static class EnseignantMappers
    {
        public static EnseignantDto ToEnseignantDto(this Enseignant enseignantModel){
            return new EnseignantDto{
                Numenseignant = enseignantModel.Numenseignant,
                Nomenseignant = enseignantModel.Nomenseignant,
                Prenomenseignant = enseignantModel.Prenomenseignant,
                Civiliteenseignant = enseignantModel.Civiliteenseignant
            };
        }

        public static Enseignant ToEnseignantFromCreate(this CreateEnseignantRequest enseignantReq){
            return new Enseignant{
                Nomenseignant = enseignantReq.Nomenseignant,
                Prenomenseignant = enseignantReq.Prenomenseignant,
                Civiliteenseignant = enseignantReq.Civiliteenseignant
            };
        }
    }
}