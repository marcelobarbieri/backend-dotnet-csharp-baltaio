<h1>Aplicando Orientação a Objetos em Projetos Reais com C# 11 e .NET 7</h1>

Ref.: Balta.io

> O conteúdo também foi organizado nos **commits**

<!--#region Sumário -->

<!--#region Modelando o Domínio -->

<details><summary>Modelando o Domínio</summary>

<ul>
    <li><a href="#dominio-apresentacao">Apresentação</a></li>
    <li><a href="#dominio-solutions">Trabalhando com Solutions</a></li>
    <li><a href="#dominio-overview">Overview da Aplicação</a></li>
    <li><a href="#dominio-entidades">Organizando as Entidades</a></li>
    <li><a href="#dominio-vo">Value Objects</a></li>
    <li><a href="#dominio-nullables">Entendendo Nullables</a></li>
    <li><a href="#dominio-privateset">Private Set</a></li>
    <li><a href="#dominio-optional">Optional Parameters</a></li>
    <li><a href="#dominio-summary">Summary</a></li>
    <li><a href="#dominio-entidade">Finalizando a Entidade</a></li>
    <li><a href="#dominio-regex">Utilizando Regex</a></li>
    <li><a href="#dominio-exceptions">Exceptions</a></li>
    <li><a href="#dominio-melhorando-exceptions">Melhorando as Exceptions</a></li>
    <li><a href="#dominio-source-generator">Source Generators</a></li>
    <li><a href="#dominio-objeto-campanha">Finalizando o objeto de Campanha</a></li>
    <li><a href="#dominio-strings">Concatenação de Strings</a></li>
    <li><a href="#dominio-extension-methods">Extension Methods</a></li>
    <li><a href="#dominio-lista">Estendendo uma lista</a></li>
</ul>

</details>

<!--#endregion -->

<!--#endregion -->

<!--#region Modelando o Domínio -->

<h2 id="dominio">Modelando o Domínio</h2>

<!--#region Apresentação  -->

<details id="dominio-apresentacao"><summary>Apresentação</summary>

<br/>

Neste curso, vamos aprender a resolver problemas de um cenário real apenas utilizando orientação a objetos e alguns conceitos que vão mudar sua visão sobre desenvolvimento de software.

<h2>Introdução</h2>

Olá e seja bem vindo ao curso Aplicando Orientação a Objetos em Projetos Reais com C# 11 e .NET 7. Eu sou André Baltieri ou balta, 10x Microsoft MVP e vou te guiar por este curso.

<h2>O problema</h2>

Falamos muito sobre orientação a objetos e muitas vezes tornamos as coisas ainda mais obscuras e dificultamos o entendimento dos principais paradigmas.

É necessário entender que **orientação a objetos** nem sempre precisa ser algo extremamente complexo e gigante, na verdade ela tem que ser **simples e eficiente**, como tudo na computação.

**Mas como aplicar conceitos e técnicas que abrangem projetos de grande e pequeno porte em qualquer tipo de aplicação?**

<h2>O que vamos aprender</h2>

Neste curso, vamos aprender a resolver problemas de um cenário real apenas utilizando orientação a objetos e alguns conceitos que vão mudar sua visão sobre desenvolvimento de software.

Passaremos por todos os tópicos de organização da aplicação em soluções e projetos, seguido pela sub-organização a aplicação em pastas, para deixar tudo no lugar certo.

Vamos entender mais sobre a criação de SDKs que realmente são simples de usar e domínios pequenos e bem modelados, com entidades e objetos de valor.

Vamos passar por conceitos como herança, abstração, encapsulamento e até obsessão primitiva, tornando nosso código ainda mais reutilizável.

Claro que tudo isso aplicando o que há de mais novo no C# 11 e .NET 7, com recursos como **Source Generators, Implicit Operators e Extension Methods**.

Para fechar, vamos entender em quais cenários devemos utilizar **Exceptions** e como utilizá-las de uma forma testável e legível.

Toda esta implementação sem testes de unidade não nos favorece em nada, então temos um módulo dedicado a testes, onde vamos debater sobre o que e como testar todo nosso domínio.

Como resultado final, teremos uma biblioteca completa e testada, pronta para ser consumida por outros projetos na solução ou mesmo ser publicada em um Nuget público ou privado.

**E não esquece de conferir nosso curso de Git, GitHub, Azure e DevOps para aprender a publicar essa biblioteca de forma automatizada com GitHub Actions e GitHub Packages.**

<h2>Para quem é este curso</h2>

Este curso é destinado a todas as pessoas que já tem conhecimento em .NET, ou que vem seguindo nossa carreira aqui e querem dar um passo a frente.

Então se você já criou suas APIs ou Apps com .NET e quer aprender uma forma nova, eficiente e testável de escrever código, este curso é para você.

<h2>Suporte e versões</h2>

Este curso tem foco em .NET 7 e C# 11, contando com recursos exclusivos desta versão (ou superior).

Porém, conceitos como **Implicit Operators, Extension Methods, Abstração, Herança, Encapsulamento e Primitive Obsession** podem ser aplicados em diferentes versões do .NET e até mesmo outras linguagens de programação.

</details>

<!--#endregion -->

<!--#region Trabalhando com Solutions  -->

<details id="dominio-solutions"><summary>Trabalhando com Solutions</summary>

<br/>

Verificar a versão .NET:

```ps
dotnet --version
7.0.403
```

Criar diretório para a solução e projetos:

```ps
mkdir UtmBuilder
cd .\UtmBuilder\
```

Criar solução:

```ps
dotnet new sln
```

Criar projeto e adicioná-lo à solução:

```ps
dotnet new classlib -o UtmBuilder.Core
dotnet sln add .\UtmBuilder.Core\
```

</details>

<!--#endregion -->

<!--#region Overview da Aplicação  -->

<details id="dominio-overview"><summary>Overview da Aplicação</summary>

<br/>

> UTM - Urchin Tracking Module (Módulo de Rastreamento de URL) (Monitoramento de Tráfego)

Segmentos de URL utilizado dentro do Analytics (https://ga-dev-tools.web.app/campaign-url/builder/).

- Campaign URL Builder:
  - Website Url
  - Campaign ID
  - Campaign Source (e.g. google, newsletter)
  - Campaign Medium (e.g. cpc, banner, email)
  - Campaign Name (e.g. spring_sale)
  - Campaign Term
  - Campaign Content
  - Generated URL

</details>

<!--#endregion -->

<!--#region Organizando as Entidades  -->

<details id="dominio-entidades"><summary>Organizando as Entidades</summary>

<br/>

Criar uma classe **Utm.cs**:

```c#
namespace UtmBuilder.Core;

public class Utm
{
    public string Url { get; set; }
    public string Source { get; set; }
    public string Medium { get; set; }
    public string Name { get; set; }
    public string Id { get; set; }
    public string Term { get; set; }
    public string Content { get; set; }
}
```

**Obsessão primitiva**

Reestruturar classe

</details>

<!--#endregion -->

<!--#region Value Objects  -->

<details id="dominio-vo"><summary>Value Objects</summary>

<br/>

- 2 Urls

  - Url de entrada
  - Url de saída
- Criar

  - Diretório **.\ValueObjects**
  - Item **.\ValueObjects\ValueObject.cs** (classe base)
  - Item **.\ValueObjects\Url.cs**

A classe base **ValueObject.cs** será do tipo **abstract** para não permitir a sua instanciação.

```c#
namespace UtmBuilder.Core.ValueObjects;

public abstract class ValueObject
{
}
```

As demais classes **ValueObjects** (i.e., **Url.cs**) herdarão da classe base **ValueObject.cs**

```c#
namespace UtmBuilder.Core.ValueObjects;

public class Url : ValueObject
{
}
```

Alterar o tipo da propriedade **Url** em **Utm.cs**

```c#
using UtmBuilder.Core.ValueObjects;

public class Utm
{
    public Url Url { get; set; }

    ...
```

</details>

<!--#endregion -->

<!--#region Entendendo Nullables  -->

<details id="dominio-nullables"><summary>Entendendo Nullables</summary>

<br/>

Criação de mais um Value Objetct **Campaign.cs**:

```c#
namespace UtmBuilder.Core.ValueObjects;

public class Campaign : ValueObject
{
    public string Id { get; set; }
    public string Source { get; set; }
    public string Medium { get; set; }
    public string Name { get; set; }
    public string Term { get; set; }
    public string Content { get; set; }
}
```

Ajustar a classe **Utm.cs**:

```c#
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core;

public class Utm
{
    public Url Url { get; set; }
    public Campaign Campaign { get; set; }
}
```

3 opções:

| Opção        | Código                                | Observação |
| :---         | :---                                  | :--- |
| Nullable     | public Url? Url { get; set; };        | Permite nulo, existir ou não existir |
| Target Typed | public Url Url { get; set; } = new(); | O objeto é instanciado |
| Null Not     | public Url Url { get; set; } = null!; | O objeto pode ser nulo na declaração, mas não pode ser nulo quando acessado pois pode retornar *ObjectNullReferenceException*. |

</details>

<!--#endregion -->

<!--#region Private Set  -->

<details id="dominio-privateset"><summary>Private Set</summary>

<br/>

Ajuste do *Value Object* **Url.cs** para receber o endereço obrigatoriamente na sua instância e inicializar a sua propriedade resolvendo assim o **Nullable**:

```c#
namespace UtmBuilder.Core.ValueObjects;

public class Url : ValueObject
{
    public Url(string address)
        => Address = address;

    public string Address { get; }
}
```

- Os *Value Objects* são imutáveis
- Pode-se remover o **set** ou utilizar **private set**
- O **private set** permite alterar a propriedade dentro da classe

</details>

<!--#endregion -->

<!--#region Optional Parameters  -->

<details id="dominio-optional"><summary>Optional Parameters</summary>

<br/>

Ajustar os parâmetros no objeto de valor **Campaign.cs** e retirar o **set**:
- Opcionais:
  - Id
  - Term
  - Content
- Obrigatórios:
  - Source
  - Medium
  - Name

```c#
namespace UtmBuilder.Core.ValueObjects;

public class Campaign : ValueObject
{
    public Campaign(
        string source,
        string medium,
        string name,
        string? id = null,
        string? term = null,
        string? content = null)
    {
        Source = source;
        Medium = medium;
        Name = name;
        Id = id;
        Term = term;
        Content = content;
    }

    public string Source { get; }
    public string Medium { get; }
    public string Name { get; }

    public string? Id { get; }
    public string? Term { get; }
    public string? Content { get; }
}

```

</details>

<!--#endregion -->

<!--#region Summary  -->

<details id="dominio-summary"><summary>Summary</summary>

<br/>

Documenta uma propriedade, métodos etc.

</details>

<!--#endregion -->

<!--#region Finalizando a Entidade  -->

<details id="dominio-entidade"><summary>Finalizando a Entidade</summary>

<br/>

Implementação do construtor da classe **Utm.cs** e inclusão do **summary**:

```c#
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core;

public class Utm
{
    public Utm(
        Url url,
        Campaign campaign)
    {
        Url = url;
        Campaign = campaign;          
    }

    /// <summary>
    /// URL (Website Link)
    /// </summary>
    public Url Url { get; }

    /// <summary>
    /// Campaign Details
    /// </summary>
    public Campaign Campaign { get; }
}

```

Pode ser utilizado **init** ao invés de **private set**, para dizer que a propriedade só pode ser associada no construtor:

```c#
   public Url Url { get; init; }
```

```ps
dotnet clean

Versão do MSBuild 17.7.3+4fca21998 para .NET
Compilação de 25/11/2023 19:32:58 iniciada.
     1>Projeto "F:\Marcelo\Educação\Aplicando Orientação a Objetos em Projetos Reais com C# 11 e .NET 7 (Balta.io)\UtmB
       uilder\UtmBuilder.sln" no nó 1 (Clean destino(s)).
     1>ValidateSolutionConfiguration:
         Compilando a configuração de solução "Debug|Any CPU".
     1>Projeto de compilação pronto "F:\Marcelo\Educação\Aplicando Orientação a Objetos em Projetos Reais com C# 11 e .
       NET 7 (Balta.io)\UtmBuilder\UtmBuilder.sln" (Clean destino(s)).

Compilação com êxito.
    0 Aviso(s)
    0 Erro(s)

Tempo Decorrido 00:00:01.99
```

```ps
dotnet build

Versão do MSBuild 17.7.3+4fca21998 para .NET
  Determinando os projetos a serem restaurados...
  Todos os projetos estão atualizados para restauração.
  UtmBuilder.Core -> F:\Marcelo\Educação\Aplicando Orientação a Objetos em Projetos Reais com C# 11 e .NET 7 (Balta.io)
  \UtmBuilder\UtmBuilder.Core\bin\Debug\net7.0\UtmBuilder.Core.dll

Compilação com êxito.
    0 Aviso(s)
    0 Erro(s)

Tempo Decorrido 00:00:11.56
```

</details>

<!--#endregion -->

<!--#region Utilizando Regex  -->

<details id="dominio-regex"><summary>Utilizando Regex</summary>

<br/>

Implementar a validação da Url:

```c#
public class Url : ValueObject
{
    private const string UrlRegexPattern =
        @"^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$";

    /// <summary>
    /// Create a new URL
    /// </summary>
    /// <param name="address">Address of URL (Website link)</param>
    public Url(string address)
    {
        Address = address;

        if (Regex.IsMatch(Address, UrlRegexPattern))
            throw new Exception("Teste");
    }

    ...
```

</details>

<!--#endregion -->

<!--#region Exceptions  -->

<details id="dominio-exceptions"><summary>Exceptions</summary>

<br/>

Notificações de domínio x Exceptions

**Exception** é a exceção mais genérica possível, e pode confundir com as demais exceções do tipo **Exception** porque pode ser qualquer tipo de **Exception**.

Criação de uma exceção customizada com o item **Exceptions/InvalidUrlException** que herda de **Exception**:

```c#
namespace UtmBuilder.Core.ValueObjects.Exceptions;

public class InvalidUrlException : Exception
{
    public InvalidUrlException(string message = "Invalid URL")
        : base(message)
    {
        
    }
}
```

Ajuste da exceção chamada no construtor da classe **Url.cs**:

```c#
        ...
        if (Regex.IsMatch(Address, UrlRegexPattern))            
            throw new InvalidUrlException();
        ...
```

</details>

<!--#endregion -->

<!--#region Melhorando as Exceptions  -->

<details id="dominio-melhorando-exceptions"><summary>Melhorando as Exceptions</summary>

<br/>

Criação do método abaixo dentro de **InvalidUrlException.cs**:

```c#
... 

public static void ThrowIfInvalid(
    string address, 
    string message = DefaultErrorMessage)
{

  ...
```

Mover as validações inseridas do objeto de valor **Url.cs** para **InvalidUrlException.cs**:

```c#
using System.Net;
using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValueObjects.Exceptions;

public class InvalidUrlException : Exception
{
    private const string DefaultErrorMessage = "Invalid URL";
    private const string UrlRegexPattern =
    @"^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$";

    public InvalidUrlException(string message = DefaultErrorMessage)
        : base(message)
    {
        
    }

    public static void ThrowIfInvalid(
        string address, 
        string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidUrlException(message);

        if (!Regex.IsMatch(address, UrlRegexPattern))
            throw new InvalidUrlException(message);
    }
}
```

O objeto de valor **Url.cs** pode ser finalmente ajustado:

```c#
...

public class Url : ValueObject
{
    /// <summary>
    /// Create a new URL
    /// </summary>
    /// <param name="address">Address of URL (Website link)</param>
    public Url(string address)
    {
        Address = address;
        InvalidUrlException.ThrowIfInvalid(address);
    }

    ...

```

> Exceções devem ser da mais específica para a mais genérica

</details>

<!--#endregion -->

<!--#region Source Generators -->

<details id="dominio-source-generator"><summary>Source Generators</summary>

<br/>

Recurso disponível a partir do .NET 7: **Code Generation** que gera um código estático para a expressão reguar **Regex** tornando-o mais otimizado e melhora o desempenho.

O código será compilado como parte do **Regex**

```c#
public partial class InvalidUrlException : Exception
{
    ...

    public static void ThrowIfInvalid(
        string address, 
        string message = DefaultErrorMessage)
    {
        ...

        if (!UrlRegex().IsMatch(address))
            throw new InvalidUrlException(message);
    }

    [GeneratedRegex("^(http|https):(\\\\/\\\\/www\\\\.|\\\\/\\\\/www\\\\.|\\\\/\\\\/|\\\\/\\\\/)[a-z0-9]+([\\\\-\\\\.]{1}[a-z0-9]+)*\\\\.[a-z]{2,5}(:[0-9]{1,5})?(\\\\/.*)?$|(http|https):(\\\\/\\\\/localhost:\\\\d*|\\\\/\\\\/127\\\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\\\/.*)?$")]
    private static partial Regex UrlRegex();
}
```

A expressão foi inserida como atributo do **Regex**

</details>

<!--#endregion -->

<!--#region Finalizando o objeto de Campanha  -->

<details id="dominio-objeto-campanha"><summary>Finalizando o objeto de Campanha</summary>

<br/>

Criação de um novo item **Exceptions/InvalidCampaignException.cs**

```c#
namespace UtmBuilder.Core.ValueObjects.Exceptions;

public class InvalidCampaignException : Exception
{
    private const string DefaultErrorMessage = "Invalid Campaign";

    public InvalidCampaignException(string message = DefaultErrorMessage)
        : base(message)
    {

    }

    public static void ThrowIfInvalid(
        string address,
        string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidUrlException(message);
    }
}
```

Utilização da **InvalidCampaignException** no construtor do objeto de valor **Campaign**:

```c#
public class Campaign : ValueObject
{
    /// <summary>
    /// Generate a new campaign for a URL
    /// </summary>
    /// <param name="source">The referrer (e.g. google, newsletter)</param>
    /// <param name="medium">Marketing medium (e.g. cpc, banner, email)</param>
    /// <param name="name">Product, promo code, or slogan (e.g. spring_sale) One of campaign name or campaign id are required.</param>
    /// <param name="id">The ads campaign id.</param>
    /// <param name="term">Identify the paid keywords</param>
    /// <param name="content">Use to differentiate ads</param>
    public Campaign(
        string source,
        string medium,
        string name,
        string? id = null,
        string? term = null,
        string? content = null)
    {
        Source = source;
        Medium = medium;
        Name = name;
        Id = id;
        Term = term;
        Content = content;

        InvalidCampaignException.ThrowIfInvalid(source,"Source is invalid");
        InvalidCampaignException.ThrowIfInvalid(medium, "Medium is invalid");
        InvalidCampaignException.ThrowIfInvalid(name, "Name is invalid");
    }

    ...
```

A classe **Utm** não precisa ser validada pois **Url** e **Campaign** estão sendo validados.

```c#
public class Utm
{
    public Utm(
        Url url,
        Campaign campaign)
    {
        Url = url;
        Campaign = campaign;          
    }

    ...
```

Abordagem realizada com base em **Exceptions**

</details>

<!--#endregion -->

<!--#region Concatenação de Strings  -->

<details id="dominio-strings"><summary>Concatenação de Strings</summary>

<br/>

```c#
// ?utm_source=YouTube&utm_campaign=social-to-lp&utm_content=...
```

- Interpolação
- **StringBuilder**
- **String.Format** (baixa performance)
- **String.Join** (melhor performance)

Pacote **Benchmark.Net** para testar a performance do cenário existente

</details>

<!--#endregion -->

<!--#region Extension Methods  -->

<details id="dominio-extension-methods"><summary>Extension Methods</summary>

<br/>

Criar novo item **Extensions/ListExtensions.cs** que extende **List** com a utilização da palavra reservada **this**:

```c#
namespace UtmBuilder.Core.Extensions;

public static class ListExtensions
{
    public static void AddIfNotNull(this List<string> list)
    {

    }
}
```

```c#
using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core;

public class Utm
{
    ...

    public override string ToString()
    {
        var segments = new List<string>();
        segments.AddIfNotNull();
        return $"{Url.Address}?{string.Join("&", segments)}";
    }
}
```

</details>

<!--#endregion -->

<!--#region Estendendo uma lista  -->

<details id="dominio-lista"><summary>Estendendo uma lista</summary>

<br/>

```c#
namespace UtmBuilder.Core.Extensions;

public static class ListExtensions
{
    public static void AddIfNotNull(
        this List<string> list,
        string key,
        string? value)
    {
        if (!string.IsNullOrEmpty(value))
            list.Add($"{key}={value}");
    }
}
```

```c#
using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core;

public class Utm
{
    ...

    public override string ToString()
    {
        var segments = new List<string>();
        segments.AddIfNotNull("utm_source",Campaign.Source);
        segments.AddIfNotNull("utm_medium", Campaign.Medium);
        segments.AddIfNotNull("utm_campaign", Campaign.Name);
        segments.AddIfNotNull("utm_id", Campaign.Id);
        segments.AddIfNotNull("utm_term", Campaign.Term);
        segments.AddIfNotNull("utm_content", Campaign.Content);
        return $"{Url.Address}?{string.Join("&", segments)}";

        // https://balta.io?
        // utm_source=YouTube&
        // utm_medium=social&
        // utm_campaign=BF2022&
        // utm_id=BF&
        // utm_term=dotnet&
        // utl_content=video-sobre-implicit-operators
    }
}
```

</details>

<!--#endregion -->

<!--#endregion -->
