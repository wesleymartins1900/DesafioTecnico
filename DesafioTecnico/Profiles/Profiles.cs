using AutoMapper;
using Data.Entities;
using Domain;
using System.Linq;

namespace DesafioTecnico.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            FilmeProfile();
            GeneroProfile();
        }

        private void FilmeProfile()
        {
            CreateMap<Filme, FilmeDto>();
            CreateMap<FilmeDto, Filme>();
        }

        private void GeneroProfile()
        {
            CreateMap<Genero, GeneroDto>();
            CreateMap<GeneroDto, Genero>();
        }
    }
}