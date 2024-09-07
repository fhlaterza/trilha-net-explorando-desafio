using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa("Fernando", "Laterza");
Pessoa p2 = new Pessoa("Nicole", "Laterza");
Pessoa p3 = new Pessoa("Ana", "Laterza");

hospedes.Add(p1);
hospedes.Add(p2);
hospedes.Add(p3);

// Cria a suíte
//Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
Suite suite = new Suite();
Suite s2 = new Suite(tipoSuite: "Dupla", capacidade: 2, valorDiaria:100);
Suite s3 = new Suite(tipoSuite: "Tripla", capacidade:3, valorDiaria: 150);
List<Suite> suites = new List<Suite>();
suites.Add(s2);
suites.Add(s3);

// Cria uma nova reserva, passando a suíte e os hóspedes
// Reserva reserva = new Reserva(diasReservados: 5);
// reserva.CadastrarSuite(suite);
// reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
// Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
// Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
bool exibirMenu = true;
bool quit = false;
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("*** Seja Bem vindo ao Sistemas de Hospedagem do Hotel DIO ***\n \n \n");
    Console.WriteLine("Escolha o tipo de Suíte, ou digite 3 para Sair:" );
    int cont = 1;
    foreach (var s in suites)
    {  
        Console.WriteLine($"{cont} - {s.TipoSuite} - R$ {s.ValorDiaria} ");
        cont++;
    }
    Console.WriteLine($"3- Sair do Sistema");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine($"Você escolheu a opção: {s2.TipoSuite}");
            suite = s2;
            exibirMenu=false;
            break;

        case "2":
            Console.WriteLine($"Você escolheu a opção: {s3.TipoSuite}");
            exibirMenu=false;
            suite = s3;
            break;
    
        case "3":
            exibirMenu= false;
            quit= true;
            Console.WriteLine ("O programa foi encerrado.");
            break;
        
        default: 
            exibirMenu= true;
            quit=true;
            Console.WriteLine("Opção Inválida");
            break;
    }
    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}
if (!quit)
{   
        bool exibirMenu2 = true;
        while (exibirMenu2)
        {
            Console.WriteLine("\n Digite a quantidade de diárias:");
            string diarias = Console.ReadLine();
            int numeroDias;
            if (int.TryParse(diarias, out numeroDias))
            {
                bool semReserva = false;
                Reserva reserva = new Reserva(diasReservados: numeroDias);
                reserva.CadastrarSuite(suite);
                try{
                    reserva.CadastrarHospedes(hospedes);
                }
                catch(Exception ex) 
                {
                    Console.WriteLine($"Não foi possível efetuar a Reserva! {ex.Message}");
                    semReserva = true;
                }
                if (!semReserva)
                {
                    Console.WriteLine("Reserva Efetuada com sucesso!");
                    Console.WriteLine($"Hospedes: {reserva.ObterQuantidadeHospedes()}");

                    foreach (var nomeHospede in hospedes)  
                    {
                        Console.WriteLine(nomeHospede.NomeCompleto);
                    }
                    Console.WriteLine($"Valor Reserva: {reserva.CalcularValorDiaria()}");
                }
                exibirMenu2=false;
                break;
            }
            else
            {
                Console.WriteLine("Você precisa digitar um número! Tente novamente");
            }  
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();          
        }
}