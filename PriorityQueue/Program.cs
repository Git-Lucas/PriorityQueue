////Fila é um objeto que contém uma lista de String, e consigo ordenar pelo tipo Int
//var fila = new PriorityQueue<string, int>();
////Enqueue é como se fosse o Add dessa lista
//fila.Enqueue("Item 1", 0);
//fila.Enqueue("Item 2", 4);
//fila.Enqueue("Item 3", 2);
//fila.Enqueue("Item 4", 1);

//while (fila.TryDequeue(out var item, out var prioridade))
//    Console.WriteLine($"Item: {item} | Prioridade: {prioridade}");

//A fila será um objeto de lista de Estudante, e terá como ordenação a regra de comparação de String, definida em RoleComparer()
var fila = new PriorityQueue<Estudante, string>(new RoleComparer());

fila.Enqueue(new Estudante("Lucas"), "admin");
fila.Enqueue(new Estudante("Edson"), "admin");
fila.Enqueue(new Estudante("Tiago"), "premium");
fila.Enqueue(new Estudante("Mateus"), "estudante");

while (fila.TryDequeue(out var item, out var prioridade))
    Console.WriteLine($"Aluno: {item.Nome} | Prioridade: {prioridade}");

public record Estudante(string Nome);

public class RoleComparer : IComparer<string>
{
    public int Compare(string? roleA, string? roleB)
    {
        //Se for igual, sempre será 0
        if (roleA == roleB)
            return 0;

        //Prioridade 1: sempre será prioridade, em comparação com qualquer um
        else if (roleA == "admin")
            return -1;

        //Nunca será prioridade, em comparação com qualquer um
        else if (roleA == "estudante")
            return 1;

        //O Premium somente será prioridade, quando comparado com o estudante
        else if (roleA == "premium" && roleB == "estudante")
            return -1;

        //Em qualquer outro caso (premium x admin), ele não será prioridade
        else
            return 1;
    }
}