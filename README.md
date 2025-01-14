# ProdManageCoordly - Gerenciamento de Produtos

Este projeto tem como objetivo implementar um sistema de gerenciamento de produtos, permitindo a criação, atualização, listagem e exclusão de produtos. O sistema também inclui configurações de ambiente utilizando Docker para facilitar o desenvolvimento e a execução.

### Funcionalidades principais:
- **Criação de produto**: Permite a criação de um novo produto com validação de campos obrigatórios.
- **Atualização de produto**: Possibilita a atualização dos dados de um produto existente com validação de dados.
- **Listagem de produtos**: Exibe todos os produtos cadastrados no sistema.
- **Exclusão de produto**: Permite excluir um produto utilizando seu `ProductID`.

A arquitetura do projeto foi construída utilizando **ASP.NET Core** e configurada para funcionar em um ambiente Dockerizado.

---

## Índice

- [Visão Geral](#visão-geral)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Instalação](#instalação)
- [Como Usar](#como-usar)
- [Estrutura de Diretórios](#estrutura-de-diretórios)
- [Configuração](#configuração)
- [Licença](#licença)
- [Contato](#contato)

---

## Visão Geral

O **ProdManageCoordly** é um sistema que facilita o gerenciamento de produtos, com as seguintes funcionalidades principais:

- **Criação de Produto**: A criação de novos produtos é realizada com validação de campos obrigatórios, como nome, preço e descrição.
- **Atualização de Produto**: O sistema permite atualizar dados de produtos, com validações para garantir a integridade dos dados.
- **Listagem de Produtos**: Os produtos cadastrados podem ser visualizados através de uma API REST.
- **Exclusão de Produto**: Produtos podem ser removidos utilizando seu `ProductID`.

A arquitetura foi planejada para ser robusta e escalável, utilizando Docker para orquestrar o ambiente e o SQL Server como banco de dados relacional.

---

## Tecnologias Utilizadas

Este projeto foi desenvolvido utilizando as seguintes tecnologias:

- **ASP.NET Core**: Framework principal para desenvolvimento da API.
- **SQL Server**: Banco de dados utilizado para armazenar informações dos produtos.
- **Docker**: Ferramenta para criação de contêineres e configuração de ambiente de desenvolvimento.
- **Docker Compose**: Utilizado para orquestrar a configuração do banco de dados e da API.

---

## Instalação

### Pré-requisitos

Antes de iniciar, verifique se você tem as seguintes ferramentas instaladas:

- **Docker**: Para rodar a aplicação e o banco de dados em contêineres. [Baixar Docker](https://www.docker.com/get-started)
- **.NET 7 SDK**: Para compilar e rodar a aplicação localmente. [Baixar .NET SDK](https://dotnet.microsoft.com/download)

### Passos para Instalar

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/ProdManageCoordly.git
   cd ProdManageCoordly
   ```

2. Compile o projeto (caso queira rodar localmente sem Docker):

   ```bash
   dotnet build
   ```

3. Configure o Docker:

   - No arquivo `Dockerfile`, a configuração de construção da aplicação é realizada utilizando multi-stage builds, o que garante uma imagem enxuta e eficiente.
   - O `docker-compose.yml` está configurado para rodar o SQL Server e a API do produto, garantindo que ambos os serviços estejam interligados.

4. Para rodar o projeto utilizando Docker, execute o comando:

   ```bash
   docker-compose up --build
   ```

---

## Como Usar

Após rodar o projeto, a API estará disponível para interagir com os seguintes endpoints:

1. **Criar Produto**:
   - **Método HTTP**: POST
   - **URL**: `/api/produtos`
   - **Descrição**: Cria um novo produto, validando campos obrigatórios (nome, preço, descrição).
   - **Exemplo de payload**:

   ```json
   {
     "nome": "Produto Exemplo",
     "preco": 29.99,
     "descricao": "Descrição do produto"
   }
   ```

2. **Atualizar Produto**:
   - **Método HTTP**: PUT
   - **URL**: `/api/produtos/{id}`
   - **Descrição**: Atualiza os dados de um produto existente, com validação de dados.
   - **Exemplo de payload**:

   ```json
   {
     "nome": "Produto Atualizado",
     "preco": 19.99,
     "descricao": "Descrição atualizada"
   }
   ```

3. **Listar Produtos**:
   - **Método HTTP**: GET
   - **URL**: `/api/produtos`
   - **Descrição**: Retorna todos os produtos cadastrados.

4. **Excluir Produto**:
   - **Método HTTP**: DELETE
   - **URL**: `/api/produtos/{id}`
   - **Descrição**: Exclui um produto pelo seu `ProductID`.

### Exemplos de uso com cURL ou Postman

**Criar Produto**:

```bash
curl -X POST http://localhost:8080/api/produtos -H "Content-Type: application/json" -d '{"nome":"Produto Exemplo","preco":29.99,"descricao":"Descrição do produto"}'
```

---

## Estrutura de Diretórios

A estrutura do projeto segue uma organização modular para facilitar a manutenção e a escalabilidade:

```
src/
├── API/                # Camada de apresentação (controladores e endpoints da API)
├── Application/        # Camada de lógica de negócios
├── Domain/             # Camada de domínio (entidades e interfaces)
├── Infrastructure/     # Camada de infraestrutura (conexões com banco, serviços, etc.)
```

---

## Configuração

### Configuração do Banco de Dados

No arquivo `appsettings.Development.json`, configure a string de conexão para o banco de dados SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=sqlserver;Database=ProdManageDb;User Id=sa;Password=Senha123!"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Debug"
    }
  }
}
```

### Configuração do Docker

O `docker-compose.yml` define os serviços necessários para rodar o projeto:

```yaml
version: '3.4'

services:
  sqlserver:
    image: mcr.microsoft.com/mssql/server:2019-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=Senha123!
    ports:
      - "1433:1433"
  
  pmanage.api:
    build: .
    ports:
      - "8080:80"
    depends_on:
      - sqlserver
```

## Contato

Caso tenha dúvidas ou sugestões, entre em contato:

- **Email**: [daniloopinheiro@dopme.io](mailto:daniloopinheiro@dopme.io)
- **LinkedIn**: [Danilo O. Pinheiro](https://www.linkedin.com/in/daniloopinheiro/)
