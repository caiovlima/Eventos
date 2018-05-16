using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Application.ViewModels
{
    public class EstadoViewModel
    {
        public string UF { get; set; }
        public string Nome { get; set; }

        public static List<EstadoViewModel> ListarEstados()
        {
            return new List<EstadoViewModel>()
            {
                new EstadoViewModel() {UF = "AC", Nome = "Acre"},
                new EstadoViewModel() {UF = "AL", Nome = "Alagoas"},
                new EstadoViewModel() {UF = "AP", Nome = "Amapá"},
                new EstadoViewModel() {UF = "AM", Nome = "Amazonas"},
                new EstadoViewModel() {UF = "BA", Nome = "Bahia"},
                new EstadoViewModel() {UF = "CE", Nome = "Ceará"},
                new EstadoViewModel() {UF = "DF", Nome = "Distrito Federal"},
                new EstadoViewModel() {UF = "ES", Nome = "Espírito Santo"},
                new EstadoViewModel() {UF = "GO", Nome = "Goiás"},
                new EstadoViewModel() {UF = "MA", Nome = "Maranhão"},
                new EstadoViewModel() {UF = "MT", Nome = "Mato Grosso"},
                new EstadoViewModel() {UF = "MS", Nome = "Mato Grosso Do Sul"},
                new EstadoViewModel() {UF = "MG", Nome = "Minas Gerais"},
                new EstadoViewModel() {UF = "PA", Nome = "Pará"},
                new EstadoViewModel() {UF = "PB", Nome = "Paraíba"},
                new EstadoViewModel() {UF = "PR", Nome = "Paraná"},
                new EstadoViewModel() {UF = "PE", Nome = "Pernambuco"},
                new EstadoViewModel() {UF = "PI", Nome = "Piauí"},
                new EstadoViewModel() {UF = "RJ", Nome = "Rio De Janeiro"},
                new EstadoViewModel() {UF = "RN", Nome = "Rio Grande Do Norte"},
                new EstadoViewModel() {UF = "RS", Nome = "Rio Grande Do Sul"},
                new EstadoViewModel() {UF = "RO", Nome = "Rondônia"},
                new EstadoViewModel() {UF = "RR", Nome = "Roraima"},
                new EstadoViewModel() {UF = "SC", Nome = "Santa Catarina"},
                new EstadoViewModel() {UF = "SP", Nome = "São Paulo"},
                new EstadoViewModel() {UF = "SE", Nome = "Sergipe"},
                new EstadoViewModel() {UF = "TO", Nome = "Tocantins"}

            };
        }
    }
}
