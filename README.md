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

<!--#endregion -->
