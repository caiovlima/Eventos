using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public SelectList Categorias()
        {
            return new SelectList(ListarCategorias(), "Id", "Nome");
        }
        public List<CategoriaViewModel> ListarCategorias()
        {
            var categoriasList = new List<CategoriaViewModel>()
            {
                new CategoriaViewModel(){ Id = new Guid("ac381ba8-c187-482c-a5cb-899ad7176137"), Nome = "Congresso"},
                new CategoriaViewModel(){ Id = new Guid("1bbfa7e9-5alf-4cef-b209-58595430dfc3"), Nome = "MeetUp"},
                new CategoriaViewModel(){ Id = new Guid("d4437fc6-z082-jkl8-54da-9e675gh4d564"), Nome = "Workshop"}
            };
            return categoriasList;
        }
    }
}
