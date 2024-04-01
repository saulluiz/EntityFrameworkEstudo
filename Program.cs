using EntityFrameWorkEstudo1;

namespace EntityFrameworkEstudo1{

class Program{
    static void Main(string[] args)
    {
            using(var baseDeDados= new AppDbContext()){
                var cliente=new Cliente {Nome= "Saulo"};
                baseDeDados.Clientes.Add(cliente);
                baseDeDados.SaveChanges();
            }
    }
}
}