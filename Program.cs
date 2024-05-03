using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

int numHospedes;

// Confere a quantidade máxima de pessoas 
do
{
    numHospedes = MenuHospedes();
    if (numHospedes > 6)
    {
        Console.WriteLine("As suítes do nosso hotel, só suportam no máximo 6 pessoas \n \n");
    }
} while (numHospedes > 6);


// Adiciona os hóspedes na lista
for (int i = 0; i < numHospedes; i++)
{
    Console.WriteLine($"\n Qual o nome do {i + 1}° hóspede da suíte?");
    Pessoa totalHospedes = new Pessoa(nome: Console.ReadLine());
    hospedes.Add(totalHospedes);
}

// Cria a suíte
Suite suitePremium = new Suite(tipoSuite: "Premium", capacidade: 6, valorDiaria: 600);
Suite suiteStandart = new Suite(tipoSuite: "Standart", capacidade: 4, valorDiaria: 400);
Suite suiteBasic = new Suite(tipoSuite: "Basic", capacidade: 2, valorDiaria: 200);

int op = MenuReserva();

// Menu de controle de reservas de suítes
switch (op)
{
    case 1:
        Console.WriteLine("\nQuarto Escolhido: Suíte Premium");
        Console.WriteLine("--------------------------------- \n");

        // Cria uma nova reserva, passando a suíte e os hóspedes
        int diasReservadosPremium = DiariaReserva();
        Reserva reserva1 = new Reserva(diasReservados: diasReservadosPremium);
        reserva1.CadastrarSuite(suitePremium);
        reserva1.CadastrarHospedes(hospedes);

        // Exibe a quantidade de hóspedes e o valor da diária
        Console.WriteLine($"Hóspedes: {reserva1.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {reserva1.CalcularValorDiaria()}");
        break;

    case 2:
        Console.WriteLine("\nQuarto Escolhido: Suíte Standart");
        Console.WriteLine("---------------------------------- \n");


        // Cria uma nova reserva, passando a suíte e os hóspedes
        int diasReservadosStandart = DiariaReserva();
        Reserva reserva2 = new Reserva(diasReservados: diasReservadosStandart);
        reserva2.CadastrarSuite(suiteStandart);
        reserva2.CadastrarHospedes(hospedes);

        // Exibe a quantidade de hóspedes e o valor da diária
        Console.WriteLine($"Hóspedes: {reserva2.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {reserva2.CalcularValorDiaria()}");
        break;

    case 3:
        Console.WriteLine("\nQuarto Escolhido: Suíte Basic");
        Console.WriteLine("------------------------------- \n");


        // Cria uma nova reserva, passando a suíte e os hóspedes
        int diasReservadosBasic = DiariaReserva();
        Reserva reserva3 = new Reserva(diasReservados: diasReservadosBasic);
        reserva3.CadastrarSuite(suiteBasic);
        reserva3.CadastrarHospedes(hospedes);

        // Exibe a quantidade de hóspedes e o valor da diária
        Console.WriteLine($"Hóspedes: {reserva3.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor total da reserva: {reserva3.CalcularValorDiaria()}");
        break;

    default:
        Console.WriteLine("Selecione uma opção válida");
        MenuReserva();
        break;
}

Console.WriteLine("\nReserva Concluída!");

// Método de Menu Inicial dos Hóspedes
static int MenuHospedes()
{
    Console.WriteLine("\n Bem vindo ao Hotel Sunshine! ");
    Console.WriteLine("-----------------------------\n");
    Console.Write("Deseja fazer uma reserva para quantas pessoas? \n");
    return int.Parse(Console.ReadLine());
}

// Método de Menu de Escolha de Suítes para Reserva
static int MenuReserva()
{
    Console.WriteLine("\n Qual o quarto desejado pelo hóspede? \n");
    Console.WriteLine("1 - Suíte Premium - Diária R$ 600,00");
    Console.WriteLine("2 - Suíte Standart - Diária R$ 400,00");
    Console.WriteLine("3 - Suíte Basic - Diária R$ 200,00");
    return int.Parse(Console.ReadLine());
}

// Método de Reserva do Número Diárias
static int DiariaReserva()
{
    Console.WriteLine("Quantas diárias?");
    return int.Parse(Console.ReadLine());
}