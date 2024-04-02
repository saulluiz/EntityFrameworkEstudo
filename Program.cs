using EntityFrameWorkEstudo1;

namespace EntityFrameworkEstudo1
{

    class Program
    {
        static void Main(string[] args)
        {
            using (var baseDeDados = new AppDbContext())
            {
                baseDeDados.Clientes.Add(new Cliente { Nome = "Saulo" });
                baseDeDados.Clientes.Add(new Cliente { Nome = "Luiz" });
                baseDeDados.Clientes.Add(new Cliente { Nome = "Oliveira" });
                baseDeDados.SaveChanges();
                Console.WriteLine("Consulta 1");
                ConsultaClientes(baseDeDados);
                AlterarCliente(2,"Saulo",baseDeDados);
                Console.WriteLine("Consulta 2");
                ConsultaClientes(baseDeDados); 
                LimparTabela(baseDeDados);
                Console.WriteLine("Consulta 3");
                ConsultaClientes(baseDeDados);
            }
        }
        static void ConsultaClientes(AppDbContext context)
        {
            foreach (var client in context.Clientes)
            {
                Console.WriteLine($"Id:{client.Id} Nome:{client.Nome}");

            }
        }
        static void AlterarCliente(int id, string nome,AppDbContext context)
        {
           var cliente=context.Clientes.Find(id);
           if(cliente==null){
            Console.WriteLine("Id inexistente");
            return;
           }
           //Busca pela primary key
           cliente.Nome= nome;
           context.SaveChanges();
        }
        static void LimparTabela(AppDbContext tabela){
            foreach(var item in tabela.Clientes){
                tabela.Clientes.Remove(item);
                
            }
            tabela.SaveChanges();

        }
    }
}