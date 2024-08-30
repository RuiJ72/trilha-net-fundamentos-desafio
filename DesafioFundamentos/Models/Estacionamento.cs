using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private const decimal PrecoPorHora = 2.50m; // Preço fixo por hora
        private const decimal PrecoInicial = 1.50m; // Preço fixo inicial
        private List<(string Placa, int Horas)> veiculos; // Lista de veículos com horas de estacionamento

        // Construtor da classe
        public Estacionamento()
        {
            veiculos = new List<(string Placa, int Horas)>();
        }

        // Método para adicionar um veículo
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para cadastrar:");
            string placa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas;
                while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida. Digite um número inteiro positivo:");
                }

                veiculos.Add((placa, horas));

                // Calcula o valor total a pagar
                decimal valorTotal = PrecoInicial + (PrecoPorHora * horas);

                Console.WriteLine($"Veículo {placa} cadastrado por {horas} horas. Valor a pagar: {valorTotal:C2}");
            }
            else
            {
                Console.WriteLine("Placa inválida.");
            }
        }

        // Método para remover um veículo
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            var veiculo = veiculos.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());

            if (veiculo != default)
            {
                decimal valorTotal = PrecoInicial + (PrecoPorHora * veiculo.Horas);

                veiculos.Remove(veiculo);

                Console.WriteLine($"O veículo {placa} foi removido. Valor total a pagar: {valorTotal:C2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        // Método para listar veículos
        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo.Placa}, Horas: {veiculo.Horas}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
