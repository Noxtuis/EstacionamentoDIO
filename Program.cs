/*
    Aviso: me empolguei um pouco ao fazer esse algoritmo,
    ele usa o tempo da máquina para calcular o valor da estadia.

    Além disso, ele possui diversas funções para simular um estacionamento
    real (capacidade, registro de horários) e funções para lidar com erros de
    entrada do usuário.

    Não foi utilizado o código de auxilio do curso e provavelmente não está otimizado
    nem muito legível, mas funciona
*/

Dictionary<string, DateTime> carros = [];
int input, precoHorario, precoInicial, capacidade;
string placa;

Console.WriteLine("Bem vindo ao sistema de estacionamento!");
Console.WriteLine("Defina o valor inicial:");
while (!int.TryParse(Console.ReadLine(), out precoInicial)) 
{
    Console.WriteLine("Valor inválido");
}
Console.WriteLine("Defina o valor por hora:");
while (!int.TryParse(Console.ReadLine(), out precoHorario)) 
{
    Console.WriteLine("Valor inválido");
}
Console.WriteLine("Defina a capacidade do estacionamento:");
while (!int.TryParse(Console.ReadLine(), out capacidade)) 
{
    Console.WriteLine("Valor inválido");
}

while (true) 
{
    Console.WriteLine("Digite sua opção:");
    Console.WriteLine("1 - Cadastrar Veículo");
    Console.WriteLine("2 - Remover Veículo");
    Console.WriteLine("3 - Listar Veículos");
    Console.WriteLine("4 - Encerrar");

    while (!int.TryParse(Console.ReadLine(), out input))
    {
        Console.WriteLine("Valor inválido");
    }
    Console.Clear();
    switch (input)
    {
        case 1:
            Console.WriteLine("Digite a placa do veículo:");
            placa = Console.ReadLine();
            Cadastrar(placa);
            break;
        case 2:
            Console.WriteLine("Digite a placa do veículo:");
            placa = Console.ReadLine();
            Remover(placa);
            break;
        case 3:
            Listar();
            break;
        
    }
    if (input == 4)
    {
        break;
    }
}

void Cadastrar(string placa)
{
    if (carros.Count < capacidade)
    {
        try
        {
            carros.Add(placa, DateTime.Now);
            Console.WriteLine($"O veículo de placa {placa} foi cadastrado em {DateTime.Now}");
        }
        catch (ArgumentException)
        {
            Console.WriteLine($"Erro: veículo de placa {placa} já registrado");
        }
    }
    else
    {
        Console.WriteLine("O estacionamento não possui vagas disponíveis");
    }
}
void Remover(string placa)
{
    try
    {
        int horas = (DateTime.Now - carros[placa]).Hours;
        carros.Remove(placa);
        Console.WriteLine($"O veículo de placa {placa} esteve estacionado por {horas} horas");
        Console.WriteLine($"Valor da estadia: {horas * precoHorario + precoInicial}");
    }
    catch (KeyNotFoundException)
    {
        Console.WriteLine($"Não há um veículo de placa {placa} registrado");
    }
}
void Listar() 
{
    if (carros.Count != 0)
    {
        Console.WriteLine("Placa / Horário do cadastro");
        foreach (var elemento in carros)
        {
            Console.WriteLine(elemento);
        }
    }
    else
    {
        Console.WriteLine("Não há veículos registrados");
    }
}