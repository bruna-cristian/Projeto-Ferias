using Projetos;
using Projetos.Models;
using System.Globalization;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;


/******************************************************COMO LER UM ARQUIVO********************************************************************************

string [] linhas = File.ReadAllLines("Arquivos/arquivoLeitura.txt"); 

foreach(string linha in linhas)
{
    Console.WriteLine(linha);
}
*/

/******************************************************COMO DECLARAR TUPLA********************************************************************************

(int, string, string, decimal) tupla = (1, "Leonardo", "Buta", 1.80M); 

Console.WriteLine($"Id: {tupla.Item1}");
Console.WriteLine($"Nome: {tupla.Item2}");
Console.WriteLine($"Sobrenome: {tupla.Item3}");
Console.WriteLine($"Altura: {tupla.Item4}");

*/

/***********************************************TESTANDO METODO TUPLA*****************************************************************
Por ser uma classe que é tupla, para retornoar o metodo da tupla, tem que declarar uma variavel com os tipos de dados da tupla
para receber a classe/tupla e o método

LeituraArquivo arquivo = new LeituraArquivo();

var (sucesso, linhasArquivo, quantidadeLinhas) = arquivo.LerArquivo("Arquivos/arquivoLeitura.txt");

if (sucesso)
{
    foreach(string linha in linhasArquivo)
    {
        Console.WriteLine(linha);
    }
} 
else 
{
    Console.WriteLine("Não foi possível ler o arquivo");
}

*/

/********************************************** SERIALIZAÇÃO NA PRÁTICA ******************************************************************
No código abaixo vamos serializar o nosso código em C# em formato JSON  

Venda v1 = new Venda(1, "Material de escritório", 25.00M);

//Sintaxe Serialização
string serializado = JsonConvert.SerializeObject(v1); //sem identacao
string serializado1 = JsonConvert.SerializeObject(v1, Formatting.Indented); //com metodo que identa


//Console.WriteLine(serializado);
Console.WriteLine(serializado1);

*/

/********************************************** ESCREVENDO UM ARQUIVO JSON ******************************************************************


File.WriteAllText("Arquivos/vendas.json", serializado1);
*/

/********************************************** SERIALIZANDO UMA COLEÇÃO ******************************************************************


DateTime dataAtual = DateTime.Now; 

List<Venda> listaVendas = new List<Venda>();


Venda v1 = new Venda(1, "Material de escritório", 25.00M, dataAtual);
Venda v2 = new Venda(2, "Licença de Software", 110.00M, dataAtual); 

listaVendas.Add(v1);
listaVendas.Add(v2);

string colecaoSerializada = JsonConvert.SerializeObject(listaVendas, Formatting.Indented);

File.WriteAllText("Arquivos/vendas.json", colecaoSerializada);

*/

/********************************************** DESERIALIZANDO UM OBJETO ******************************************************************
Pegar um arquivo JSON e transformar em um objeto; 
*/



/********************************************** DESAFIO DE CODIGO I ******************************************************************
//DESAFIO 1.1 - SISTEMA BANCÁRIO DE SAQUE EM CAIXAS ELETRÔNICOS

- ReadLine: saldoTotal e valorSaque;
- if saldoDisponivel ≥ valorSaque  então saldoDisponivel - valorSaque  = saldo 
- and WriteLine: "Saque realizado com sucesso. Novo saldo: {saldo}"
- else: Saldo insuficiente. Saque nao realizado!

        int saldoTotal = int.Parse(Console.ReadLine());
        

        int valorSaque = int.Parse(Console.ReadLine());
        
        //TODO: Criar as condições necessárias para impressão da saída, vide tabela de exemplos.
        if(saldoTotal >= valorSaque)
        {
          int saldo = saldoTotal - valorSaque; 
          Console.WriteLine($"Saque realizado com sucesso. Novo saldo: {saldo}");
        } else 
        {
          Console.WriteLine("Saldo insuficiente. Saque nao realizado!");
        }

//DESAFIO 1.2 - LISTA DE JOGO RPG 

List<string> itens = new List<string>(); 

for (int i = 0; i < 3; i++)
{
    string item = Console.ReadLine();
    itens.Add(item);        
}

Console.WriteLine("Lista de itens:");
foreach (string item in itens)
{
    Console.WriteLine($"- {item}");
}
*/

/********************************************** DESAFIO DE CODIGO II ******************************************************************
//DESAFIO 2.1 - CALCULANDO O DANO  

static int CalcularDano(int ataque, int defesa)
{
    int dano = ataque - defesa; 
    if(dano < 0)
    {
        return dano = 0;
    } else 
    {
        return dano;
    }
}

int ataque = int.Parse(Console.ReadLine());
int defesa = int.Parse(Console.ReadLine()); 

int danoCausado = CalcularDano(ataque, defesa);
Console.WriteLine("O dano causado pelo ataque foi: " + danoCausado);

//DESAFIO 2.2 - O GUARDIÃO DOS ATRIBUTOS - Descrição Notion 

static bool VerificarAtributo(string atributo, int valorMinimo, int valorMaximo, int valorAtributo)
{
    return valorAtributo >= valorMinimo && valorAtributo <= valorMaximo;
}


    string atributo = Console.ReadLine();
    int valorMinimo = int.Parse(Console.ReadLine());
    int valorMaximo = int.Parse(Console.ReadLine());
    int valorAtributo = int.Parse(Console.ReadLine());


bool estaDentroDoIntervalo = VerificarAtributo(atributo, valorMinimo, valorMaximo, valorAtributo);

if (estaDentroDoIntervalo)
{
    Console.WriteLine("O valor do atributo está dentro do intervalo especificado");
} else 
{
    Console.WriteLine("O valor do atributo está fora do intervalo especificado");
}

//DESAFIO 2.3 -  Validando a Força de Senhas no IAM - Descrição Notion 
- senha com min 8 caracteres
- pelo menos uma letra maiuscula
- pelo menos uma letra minuscula
- pelo menos um num 
- pelo menos um caractere especial 

*/

static string VerificarForcaSenha(string senha)
{
    int comprimentoMinimo = 8;
    bool temLetraMaiuscula = false;
    bool temLetraMinuscula = false; 
    bool temNumero = false;
    bool temCaractereEspecial = false; 

//Verificando comprimento da senha
    if(senha.Length < comprimentoMinimo)    
        return "Sua senha e muito curta. Recomenda-se no minimo " + comprimentoMinimo +  " caracteres.";
    
//Verificando se a senha contém letras maiúsculas e minúsculas
    temLetraMaiuscula = senha.Any(char.IsUpper);
    temLetraMinuscula = senha.Any(char.IsLower);

//Verificando se a senha contém números e caracteres especiais
    temNumero = senha.Any(char.IsDigit);
    temCaractereEspecial = senha.Any(c => !char.IsLetterOrDigit(c));

//Valida todos as obrigatoriedades da senha
    if(temLetraMaiuscula && temLetraMinuscula && temNumero && temCaractereEspecial)
        return "Sua senha atende aos requisitos de seguranca. Parabens!";
    else 
        return "Sua senha nao atende aos requisitos de seguranca.";
}

string senha = Console.ReadLine().Trim(); 
string resultado = VerificarForcaSenha(senha); 

Console.WriteLine(resultado);












