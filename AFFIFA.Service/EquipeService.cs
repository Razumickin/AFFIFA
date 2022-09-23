﻿using AFFIFA.Domain;
using AFFIFA.Domain.Entities;
using AFFIFA.Domain.Interfaces;

namespace AFFIFA.Service
{
    public class EquipeService : EntidadeBase, IEquipeService
    {
        private readonly IEquipeRepository equipeRepository;
        public EquipeService(IEquipeRepository equipeRepository)
        {
            this.equipeRepository = equipeRepository;
        }

        public async Task<Equipe.Resposta> GetAllEquipes()
        {
            return await equipeRepository.GetAllEquipes();
        }

        public async Task<Equipe.Resposta> GetEquipesByNome(string equipeNome)
        {
            return await equipeRepository.GetEquipesByNome(equipeNome);
        }

        public async Task<Equipe.Resposta> GetEquipeById(int equipeId)
        {
            return await equipeRepository.GetEquipeById(equipeId);
        }

        public async Task<Equipe.Resposta> CreateEquipe(Equipe equipe)
        {
            return await equipeRepository.CreateEquipe(equipe);
        }

        public async Task<Equipe.Resposta> UpdateEquipe(int equipeId, Equipe equipe)
        {
            if(equipe.Id != equipeId)
            {
                return new Resposta(Status400BadRequest, "Erro nos parâmetros da requisição.");
            }

            return await equipeRepository.UpdateEquipe(equipe);
        }

        public async Task<Equipe.Resposta> DeleteEquipe(int equipeId)
        {
            Resposta resposta = await GetEquipeById(equipeId);
            if(resposta.Status != Status200OK)
            {
                return resposta;
            }

            return await equipeRepository.DeleteEquipe((Equipe)resposta.Objeto);
        }
    }
}
