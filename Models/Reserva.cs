namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            
            // Implementado!!
            bool validaCapacidade = Suite.Capacidade >= hospedes.Count;
            if(validaCapacidade)
            {
                Hospedes=hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                
                //Implementado!!
                throw new Exception($"A capacidade da Suite {Suite.TipoSuite} é para o máximo de {Suite.Capacidade} pessoas!\n"
                +$"Não comporta a quantidade de Hospedes({hospedes.Count}) que está sendo solicitada!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*

            //Implementado!!
                        int qtdHospedes = 0;
            if (Hospedes.Count < 1)
            {
                qtdHospedes=0;
            }
            else {
                qtdHospedes= Hospedes.Count;
            }
            return qtdHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*

            //Implementado!!
            decimal valor = 0;
            valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*

            //Implementado
            decimal desconto = 0.10M;
            if (DiasReservados >=10)
            {
                valor = valor - (valor * desconto);
            }

            return valor;
        }
    }
}