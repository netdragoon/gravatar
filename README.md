# Canducci Gravatar

___http://pt.gravatar.com/___

####Gravatar

[![Travis](https://img.shields.io/travis/netdragoon/gravatar.svg)](https://github.com/netdragoon/gravatar)
[![NuGet](https://img.shields.io/nuget/dt/Canducci.Gravatar.svg?style=plastic&label=downloads)](https://www.nuget.org/packages/Canducci.Gravatar/)
[![NuGet](https://img.shields.io/nuget/v/Canducci.Gravatar.svg?style=plastic&label=version)](https://www.nuget.org/packages/Canducci.Gravatar/)

##Instalação do Pacote (NUGET)

```Csharp

PM> Install-Package Canducci.Gravatar

```

##Como utilizar?

Declare o namespace `using Canducci.Gravatar;` 

###Version 0.0.2 
___(Recomendado)___

- Melhoramento no código.
- Adição da classe AvatarFolder.
- Aumento do desempenho do código.

___Em um projeto ASP NET MVC faça:___

###Exemplo do Código:
```Csharp
[Route("avatar")]
public ActionResult AvatarResult()
{            
    //Tamanho da imagem
    int width = 400;

    //Configuração para Web MVC precisa passar a pasta raiz pelo
    // Server.MapPath("~"), se for projeto local não há necessidade
    // "Images/" pasta da imagem
    // "Server.MapPath("~")" pasta raiz da sua aplicação Web
    IAvatarFolder folder = 
        new AvatarFolder("Images/", Server.MapPath("~"));

    //Email configurado no gravatar.com    
    IEmail email = 
        new Email("exemplo@exemplo.com");

    //Configurações    
    IAvatarConfiguration configuration =
        new AvatarConfiguration(email, folder, width, 
                AvatarImageExtension.Jpg, AvatarRating.R);            
    
    //classe Avatar
    IAvatar avatar = new Avatar(configuration);

    //Verifica se já foi baixado a imagem padrão do seu
    // gravatar.com
    if (avatar.Exists() == false)
    {             
        //se não ele salva mediante as configurações
        // da classe AvatarFolder.
        avatar.Save();
    }
    
    //WebPath é o caminho salvo em sua pasta web.
    ViewBag.Path = "/" + avatar.WebPath();          

    return View();
}
```
###Exemplo de View:
```HTML
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>AvatarResult</title>
</head>
<body>
    <div> 
        <img src="@ViewBag.Path" />
    </div>
</body>
</html>
```
___Observações:___

    - Se não informar o nome do `filename` será colocado o hash do e-mail
    - Se for aplicação Web não esquecer de passar o prefix da classe `AvatarFolder`
        segundo item do construtor.

###MVC com FileResult
```Csharp
[Route("avatarimage")]
public FileResult AvatarResultByte()
{
    int width = 400;

    IAvatarFolder folder = new AvatarFolder("Images/", Server.MapPath("~"));
    IEmail email = new Email("exemplo@exemplo.com");

    IAvatarConfiguration configuration =
        new AvatarConfiguration(email, folder, width, 
            AvatarImageExtension.Jpg, AvatarRating.R);

    IAvatar avatar = new Avatar(configuration);

    if (avatar.Exists() == false)
    {
        avatar.Save();
    }

    return File(avatar.Image, "image/jpg");
}
```
Na view coloque um tag:
```HTML
<div>
    <img src="@Url.Action("AvatarResultByte")" />
</div>
```

###Console Application:

```Csharp
static void Main(string[] args)
{
    //Tamanho da imagem
    int width = 400;

    IAvatarFolder folder = new AvatarFolder("Images/");

    IEmail email = new Email("exemplo@exemplo.com");

    IAvatarConfiguration configuration =
        new AvatarConfiguration(email, folder, width, 
                AvatarImageExtension.Jpeg, AvatarRating.R);

    IAvatar avatar = new Avatar(configuration);
    
    if (avatar.Exists() == false)
    {
        avatar.Save();
        Console.WriteLine("Foto gravada com sucesso !!!");
    }
    else
    {
        Console.WriteLine("Foto existente: {0}", avatar.Path());
    }
    Console.ReadKey();
}
```

___

###Version 0.0.1

___Em um projeto ASP NET MVC faça:___

```Csharp
[Route("avatar")]
public ActionResult AvatarResult()
{
	//Pasta que vai ser gravada a imagem
    string folder = "/Images/";

    //Nome da imagem
    string filename = "foto";

    //Tamanho da imagem (pixel)
    int width = 400;

    //Instanciando a classe Email
    IEmail email = new Email("exemplo@exemplo.com");

    //Instanciando a classe de Configuração
    IAvatarConfiguration configuration =
        new AvatarConfiguration(email, 
            width, 
            AvatarImageExtension.Jpg, 
            AvatarRating.R);

    //Pasta do Servidor (deve ter permissão de escrita)             
    string path = Server.MapPath(folder);
    
    //Instanciando a classe Avatar
    IAvatar avatar = new Avatar(configuration);
    
    //Verificando se já existe a imagem no seu diretório 
    //Se não existir ela baixa uma cópia para o seu diretório web
    if (avatar.Exists(path, filename) == false)
    {             
        avatar.SaveAs(path, filename);
    }

    //Cria o caminho da imagem dentro da sua aplicação web
    ViewBag.Path = avatar.Path(folder, filename);            

    return View();
}

```

###Exemplo de View:

```HTML
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>AvatarResult</title>
</head>
<body>
    <div> 
        <img src="@ViewBag.Path" />
    </div>
</body>
</html>
```

###Resultado da View

```HTML
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>AvatarResult</title>
</head>
<body>
    <div> 
        <img src="/Images/foto.400.jpg" />
    </div>
</body>
</html>

```

###Console Application

```Csharp
static void Main(string[] args)
{
    string folder = "image/";
    string filename = "foto";
    int width = 250;

    IEmail email = Email.Parse("exemplo@exemplo.com");

    IAvatarConfiguration configuration =
        new AvatarConfiguration(
            email,
            width,
            AvatarImageExtension.Jpeg,
            AvatarRating.R);

    IAvatar avatar = new Avatar(configuration);
    
    if (avatar.Exists(folder, filename) == false)
    {
        
        avatar.SaveAs(folder, filename);

        Console.WriteLine("Foto gravada com sucesso !!!");

    }
    else
    {

        Console.WriteLine("Foto existente !!!");

    }

    Console.ReadKey();
}
```
___Observação:___ Pode ser usado em WebForms, Web MVC, Forms e Console Application.