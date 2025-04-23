# Profile Management API

A **Profile Management API** é uma aplicação ASP.NET Core desenvolvida para gerenciar perfis e usuários, com suporte a autenticação JWT, banco de dados InMemory e implementação de padrões como CQRS com MediatR.

---

## Tecnologias Utilizadas

- **.NET 8**: Framework principal para desenvolvimento da API.
- **ASP.NET Core**: Para criação de APIs RESTful.
- **Entity Framework Core**: Para acesso e manipulação de dados.
- **Clean Architecture**: Para design do sistema. 
- **InMemory Database**: Banco de dados em memória para testes e desenvolvimento.
- **JWT (JSON Web Token)**: Para autenticação e autorização.
- **Swashbuckle (Swagger)**: Para documentação e teste da API.
- **Dependency Injection**: Para gerenciamento de dependências.

---

## Funcionalidades

- Gerenciamento de perfis com operações CRUD.
- Autenticação de usuários com geração de tokens JWT.
- Validação de permissões de perfis.
- Dados semeados para usuários padrão (Admin e User).
- Documentação interativa com Swagger.

---

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- **.NET 8 SDK**: [Download .NET 8](https://dotnet.microsoft.com/download)
- **IDE**: Visual Studio 2022 (ou superior) ou qualquer editor compatível com .NET (como Visual Studio Code).

---

## Como Executar o Projeto

### 1. **Clone o Repositório**
- Clone o repositório para sua máquina local:
  <br>
  
```
git clone <URL_DO_REPOSITORIO> cd profile-management-api
```
---

### 2. **Configurar o Ambiente**
Certifique-se de que o arquivo `appsettings.json` contém as configurações necessárias, como `JwtSettings` e `DefaultUsers`. Exemplo:
<br>
```
{
    "JwtSettings": {
        "Issuer": "ProfileManagementAPI",
        "Audience": "ProfileManagementAPI",
        "SecretKey": "YourSuperSecretKeyWith32Characters!"
    },
    "DefaultUsers": {
        "Admin": {
            "Username": "admin",
            "Password": "admin123",
            "Role": "Admin"
        },
        "User": {
            "Username": "user",
            "Password": "user123",
            "Role": "User"
        }
    }
}

```

---

### 3. **Restaurar Dependências**
- No diretório raiz do projeto, execute o comando para restaurar as dependências:
<br>

```
dotnet restore

```


---

### 4. **Executar o Projeto**
- Inicie a aplicação com o seguinte comando: 
<br>

```
dotnet run --project ProfileManagementAPI
```

- Caso deseje fazer sem ser pelo terminal, basta definir como projeto de inicialização e startar.

A API estará disponível em: `https://localhost:5001` ou `http://localhost:5000`.

---

### 5. **Acessar o Swagger**
- Abra o navegador e acesse o Swagger para testar os endpoints:
<br>

```
https://localhost:5001/swagger
```

---

## Endpoints Principais

### **Autenticação**
- **POST** `/api/auth/login`:
  - Gera um token JWT para autenticação.
  <br>

- **Body** :

  ```
  {
    "username": "admin",
    "password": "admin123"
  }
  ```

---
### **Perfis**
- **GET** `/api/profiles`:
  - Retorna todos os perfis.
- **GET** `/api/profiles/{profileName}`:
  - Retorna um perfil específico.
- **POST** `/api/profiles`:
  - Cria um novo perfil.
- **PUT** `/api/profiles/{profileName}`:
  - Atualiza os parâmetros de um perfil.
- **DELETE** `/api/profiles/{profileName}`:
  - Exclui um perfil.

---

## Testes

### Banco de Dados InMemory
- O projeto utiliza o banco de dados InMemory para facilitar o desenvolvimento e testes. Os dados são armazenados temporariamente e são perdidos ao reiniciar a aplicação.

---

## Contribuição
- Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

---

## Licença
- Este projeto está licenciado sob a [MIT License](LICENSE).

