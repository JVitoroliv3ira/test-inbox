# **TestInbox**

**TestInbox** é uma ferramenta simples e eficiente para capturar e-mails localmente durante o desenvolvimento, permitindo que os desenvolvedores testem o envio e recebimento de e-mails sem depender de serviços de terceiros como Mailtrap ou outros servidores de e-mail.

## **Funcionalidades**

- Captura de e-mails enviados para um servidor SMTP local.
- Armazenamento dos e-mails recebidos no banco de dados.
- Visualização de e-mails recebidos via uma API RESTful.
- Filtros para pesquisa e interação com os e-mails.
- Marcação de e-mails como lidos ou não lidos.
- Exclusão de e-mails.

## **Arquitetura**

- **Backend (ASP.NET Core)**: API RESTful para interação com os e-mails.
- **Banco de Dados (SQLite)**: Armazenamento dos e-mails capturados.
- **Frontend (React)**: Interface simples para visualização e manipulação de e-mails.

## **Tecnologias**

- **Backend**: ASP.NET Core (C#)
- **Banco de Dados**: SQLite (via Entity Framework Core)
- **Frontend**: React (para interação com a API)

## **Como Funciona**

1. O desenvolvedor configura um servidor SMTP local.
2. O serviço captura os e-mails recebidos e os armazena no banco de dados.
3. O frontend permite visualizar e interagir com os e-mails através de uma API RESTful.

---

# **TestInbox - Roadmap de Desenvolvimento**

## **Fase 1: Implementação do Serviço de Captura de E-mails**

### **1.1. Configuração do Serviço de Captura de E-mails**

- [ ] **Escolher entre IMAP ou SMTP** para captura dos e-mails.
- [ ] Implementar a **conexão com o servidor SMTP local** via **SMTP** (usando **MailKit**).
- [ ] **Capturar e-mails** assim que chegarem ao servidor SMTP e armazená-los no banco de dados SQLite.

### **1.2. Armazenamento de E-mails no Banco de Dados**

- [ ] Criar um **model de e-mail** para armazenamento no banco de dados:
  - Campos: remetente, assunto, corpo, data de recebimento, status (lido ou não lido).
- [ ] **Inserir e-mails** no banco de dados SQLite assim que capturados.

### **1.3. Testar o Serviço de Captura**

- [ ] Testar a captura de e-mails localmente e garantir que os e-mails estão sendo armazenados corretamente no banco de dados.

---

## **Fase 2: Backend e API RESTful**

### **2.1. Configuração Inicial do Backend**

- [ ] Inicializar o **backend** com **ASP.NET Core**.
- [ ] Criar o arquivo **Program.cs** ou **Startup.cs** para configurar o servidor da API.

### **2.2. Implementação da API RESTful**

#### **2.2.1. Endpoint de Listagem de E-mails**

- [ ] Criar o endpoint `GET /emails` para listar todos os e-mails:
  - Consultar o banco de dados SQLite e retornar a lista de e-mails.

#### **2.2.2. Endpoint de Detalhamento de E-mail**

- [ ] Criar o endpoint `GET /emails/{id}` para retornar os detalhes de um e-mail específico.

#### **2.2.3. Endpoint de Exclusão de E-mail**

- [ ] Criar o endpoint `DELETE /emails/{id}` para excluir um e-mail.

#### **2.2.4. Endpoint de Marcação de E-mail como Lido**

- [ ] Criar o endpoint `PUT /emails/{id}/read` para marcar um e-mail como lido.

### **2.3. Conexão com o Banco de Dados**

- [ ] Conectar o **backend** com o banco de dados SQLite usando o **Entity Framework Core**.
- [ ] Implementar as operações de consulta, inserção, exclusão e atualização de e-mails no banco de dados.

### **2.4. Testar a API**

- [ ] Testar todos os endpoints utilizando **Postman** ou **Insomnia**:
  - Garantir que os e-mails sejam listados, detalhados, excluídos e marcados como lidos.

---

## **Fase 3: Desenvolvimento do Frontend**

### **3.1. Configuração Inicial do Frontend**

- [ ] Inicializar o projeto **React** utilizando `create-react-app` ou `vite`.
- [ ] Configurar o ambiente de desenvolvimento para React.

### **3.2. Implementação da Interface de Listagem de E-mails**

- [ ] Criar o componente `EmailList` para listar os e-mails capturados.
  - Fazer uma requisição ao endpoint `GET /emails` para exibir a lista de e-mails.

### **3.3. Implementação da Visualização de E-mail**

- [ ] Criar o componente `EmailDetails` para mostrar os detalhes de um e-mail.
  - Fazer uma requisição ao endpoint `GET /emails/{id}` para mostrar o conteúdo completo.

### **3.4. Marcação de E-mail como Lido**

- [ ] Criar a funcionalidade para marcar um e-mail como lido.
  - Fazer uma requisição ao endpoint `PUT /emails/{id}/read`.

### **3.5. Implementação da Exclusão de E-mails**

- [ ] Criar a funcionalidade para excluir e-mails.
  - Fazer uma requisição ao endpoint `DELETE /emails/{id}`.

### **3.6. Testar a Interface**

- [ ] Testar a interface de usuário e garantir que as interações com os e-mails funcionem corretamente (listar, visualizar, excluir, marcar como lido).

---

## **Fase 4: Integração e Testes Finais**

### **4.1. Integração Completa**

- [ ] Integrar o **frontend** com o **backend** e o **serviço de captura de e-mails**:
  - Garantir que todos os componentes funcionem corretamente juntos.

### **4.2. Testes End-to-End**

- [ ] Realizar testes **end-to-end** do sistema, verificando o fluxo completo de captura, visualização, exclusão e marcação de e-mails.

---

## **Fase 5: MVP (Produto Mínimo Viável)**

- [ ] Produto final com as seguintes funcionalidades:
  - **Captura de e-mails** via **SMTP**.
  - Interface para **visualizar**, **excluir** e **marcar e-mails como lidos**.
  - **Banco de dados SQLite** para persistência.
  - **Backend com APIs RESTful** para interação com os e-mails.
  - Testes completos do sistema.
